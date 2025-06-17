using ModManager.Gui.Components.Native;
using ModManager.Logic.Autosorting.CommunityRules;
using ModManager.Logic.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Autosorting
{
	internal class ModSorter
	{
		List<ModMetaData> _mods;
		Dictionary<string, List<string>> _loadAfter = new Dictionary<string, List<string>>();
		string _coreVersion;

		List<ICommunityRuleset> _communityRulesets = new List<ICommunityRuleset>();

		List<string> _loadEarly = new List<string>();
		List<string> _loadLate = new List<string>() 
		{
			"taranchuk.performanceoptimizer".ToLower(),
			"krkr.rocketman".ToLower(),
			"Dubwise.DubsPerformanceAnalyzerButchered".ToLower(),
		};


		public event EventHandler<string> StatusChanged;

		public ModSorter(IEnumerable<ModMetaData> mods, string coreVersion = null)
        {
			_mods = mods.ToList();
			_coreVersion = coreVersion;
		}

		public void AddCommunityRules(ICommunityRuleset communityRuleset)
		{
			if (communityRuleset != null)
				_communityRulesets.Add(communityRuleset);
		}

		public List<string> Sort()
		{
			_loadAfter.Clear();

			// Populate LoadAfter keys
			foreach (ModMetaData mod in _mods)
				_loadAfter[mod.PackageId.ToLower()] = new List<string>();

			// Add all official content to load early
			_loadEarly.AddRange(_loadAfter.Keys.Where(x => x.StartsWith("ludeon")));

			// Process metadata, convert everything into LoadAfter
			foreach (ModMetaData mod in _mods)
			{
				string packageId = mod.PackageId.ToLower();


				foreach (string loadBefore in mod.GetLoadBefore(_coreVersion).Where(x => _loadAfter.ContainsKey(x)))
					_loadAfter[loadBefore].Add(packageId);

				foreach (string loadAfter in mod.GetLoadAfter(_coreVersion).Where(x => _loadAfter.ContainsKey(x)))
					_loadAfter[packageId].Add(loadAfter);

				// If mod is not listed as an early loader, then set to load after every early loading mod
				if (_loadEarly.Contains(packageId) == false)
				{
					bool mustLoadBeforeEarly = false;
					foreach (string earlyLoader in _loadEarly)
					{
						// If mod is set to load after any other early loaders, then do nothing
						if (_loadAfter.TryGetValue(earlyLoader, out List<string> collection))
							if (collection.Contains(packageId))
								mustLoadBeforeEarly = true;
					}

					if (mustLoadBeforeEarly == false)
					{
						foreach (string earlyLoader in _loadEarly)
						{
							// Add to load after official content if not already added.
							if (_loadAfter[packageId].Contains(earlyLoader) == false)
								_loadAfter[packageId].Add(earlyLoader);
						}
					}
				}
				
				if (_loadLate.Contains(packageId) == false)
				{
					// If this mod needs to load after any late loaders, then do nothing.
					if (_loadAfter[packageId].Any(_loadLate.Contains) == false)
					{
						// Assign all late loaders to load after this mod.
						foreach (string lateLoader in _loadLate)
						{
							if (_loadAfter.TryGetValue(lateLoader, out List<string> collection))
								if (collection.Contains(packageId) == false)
									collection.Add(packageId);
						}
					}
				}

				// Apply additional rulesets:
				foreach (ICommunityRuleset ruleset in _communityRulesets)
				{
					foreach (var item in ruleset.GetLoadAfters())
					{
						if (_loadAfter.TryGetValue(item.Key, out List<string> ruleEntries))
							ruleEntries.AddRange(item.Value);
					}
				}
			}

			Queue<string> unsorted = new Queue<string>(_loadAfter.OrderBy(x => x.Value.Count).Select(x => x.Key.ToLower()));
			List<string> result = new List<string>();

			while (unsorted.Count > 0)
			{
				string packageId = unsorted.Dequeue();

				// If all requirements that exist have been added to the new list, then add this.

				var presentRequirements = _loadAfter[packageId].Where(x => _loadAfter.ContainsKey(x));
				var presentRequirementsLoaded = presentRequirements.All(x => result.Contains(x));

				if (presentRequirementsLoaded)
					result.Add(packageId);
				else
					unsorted.Enqueue(packageId);
			}

			return result;
		}
    }
}
