using ModManager.Gui.Components.Native;
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


		public event EventHandler<string> StatusChanged;

		public ModSorter(IEnumerable<ModMetaData> mods, string coreVersion = null)
        {
			_mods = mods.ToList();
			_coreVersion = coreVersion;
		}

		public List<string> Sort()
		{
			_loadAfter.Clear();

			// Populate LoadAfter keys
			foreach (ModMetaData mod in _mods)
				_loadAfter[mod.PackageId.ToLower()] = new List<string>();

			// Process metadata, convert everything into LoadAfter
			foreach (ModMetaData mod in _mods)
			{
				if (mod.LoadBefore != null)
					foreach (string loadBefore in mod.LoadBefore.Where(x => _loadAfter.ContainsKey(x.ToLower())))
						_loadAfter[loadBefore.ToLower()].Add(mod.PackageId.ToLower());

				if (mod.LoadAfter != null)
					foreach (string loadAfter in mod.LoadAfter.Where(x => _loadAfter.ContainsKey(x.ToLower())))
						_loadAfter[mod.PackageId.ToLower()].Add(loadAfter.ToLower());

				if (_coreVersion != null)
				{
					if (mod.LoadBeforeByVersion != null)
						foreach (string loadBefore in mod.LoadBeforeByVersion[_coreVersion].Where(x => _loadAfter.ContainsKey(x.ToLower())))
							_loadAfter[loadBefore.ToLower()].Add(mod.PackageId.ToLower());

					if (mod.LoadAfterByVersion != null)
						foreach (string loadAfter in mod.LoadAfterByVersion[_coreVersion].Where(x => _loadAfter.ContainsKey(x.ToLower())))
							_loadAfter[mod.PackageId.ToLower()].Add(loadAfter.ToLower());
				}

				// If core should load after mod
				if (mod.PackageId.ToLower() != "ludeon.rimworld" && _loadAfter[mod.PackageId.ToLower()].Contains("ludeon.rimworld") == false)
				{
					if (_loadAfter["ludeon.rimworld"].Contains(mod.PackageId.ToLower()) == false)
						_loadAfter[mod.PackageId.ToLower()].Add("ludeon.rimworld");

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
