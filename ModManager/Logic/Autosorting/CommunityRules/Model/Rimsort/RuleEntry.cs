using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Autosorting.CommunityRules.Model.Rimsort
{
	internal class RuleEntry
	{
		[JsonProperty("loadBefore")]
		public Dictionary<string, object> LoadBefore;

		[JsonProperty("loadAfter")]
		public Dictionary<string, object> LoadAfter;
	}
}
