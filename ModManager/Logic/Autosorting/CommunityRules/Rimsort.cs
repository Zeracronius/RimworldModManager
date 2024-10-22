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
	internal class Rimsort
	{


        public Rimsort()
        {
            
        }

		public RuleSet Load()
		{
			JsonSerializer serializer = new JsonSerializer();

			var request = HttpWebRequest.Create("https://github.com/RimSort/Community-Rules-Database/blob/main/communityRules.json");
			request.Method = "GET";
			request.ContentType = "application/json";
			var response = request.GetResponse();

			using (Stream stream = response.GetResponseStream())
			{
				var jsonReader = new JsonTextReader(new StreamReader(stream));
				RuleSet result = serializer.Deserialize<RuleSet>(jsonReader);
			}

			return null;
		}


    }
}
