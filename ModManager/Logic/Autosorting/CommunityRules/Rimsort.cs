using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ModManager.Logic.Autosorting.CommunityRules.Model.Rimsort;
using Newtonsoft.Json;

namespace ModManager.Logic.Autosorting.CommunityRules
{
	internal class Rimsort : ICommunityRuleset
	{
		RuleSet _rules;

		public Rimsort()
        {
            
        }

		public Dictionary<string, List<string>> GetLoadAfters()
		{
			if (_rules == null)
				Load();

			if (_rules == null)
				return null;

			Dictionary<string, List<string>> result = new Dictionary<string, List<string>>();

			foreach (KeyValuePair<string, RuleEntry> item in _rules.Rules)
			{
				string currentPackageId = item.Key.ToLower();
				if (item.Value.LoadBefore != null)
					foreach (var packageId in item.Value.LoadBefore.Keys.Select(x => x.ToLower()))
					{
						if (result.TryGetValue(packageId, out List<string> loadAfterOtherRules) == false)
							loadAfterOtherRules = result[packageId] = new List<string>();

						if (loadAfterOtherRules.Contains(currentPackageId) == false)
							loadAfterOtherRules.Add(currentPackageId);
					}

				if (item.Value.LoadAfter != null)
				{
					if (result.TryGetValue(currentPackageId, out List<string> loadAfterRules) == false)
						loadAfterRules = result[currentPackageId] = new List<string>();

					foreach (var packageId in item.Value.LoadAfter.Keys.Select(x => x.ToLower()))
					{
						if (loadAfterRules.Contains(packageId) == false)
							loadAfterRules.Add(packageId);
					}
				}
			}

			return result;
		}

		public void Load()
		{
			_rules = Download();
		}

		private RuleSet Download()
		{
			JsonSerializer serializer = new JsonSerializer();

			var request = HttpWebRequest.Create("https://raw.githubusercontent.com/RimSort/Community-Rules-Database/refs/heads/main/communityRules.json");
			request.Method = "GET";
			request.ContentType = "application/json";
			var response = request.GetResponse();

			try
			{
				using (Stream stream = response.GetResponseStream())
				{
					var jsonReader = new JsonTextReader(new StreamReader(stream));
					return serializer.Deserialize<RuleSet>(jsonReader);
				}
			}
			catch
			{
				return null;
			}
		}


    }
}
