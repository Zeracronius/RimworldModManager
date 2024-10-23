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
	internal class Rimsort : ICommunityPatch
	{
		RuleSet _rules;

		public Rimsort()
        {
            
        }

		public IEnumerable<string> GetLoadAfter(string packageId)
		{
			if (_rules == null)
				return null;

			if (_rules.Rules.TryGetValue(packageId, out RuleEntry entry))
			{
				List<string> result = new List<string>();
				foreach (var item in entry.LoadBefore)
				{

				}

				foreach (var item in entry.LoadAfter)
				{

				}
			}
			return null;
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
