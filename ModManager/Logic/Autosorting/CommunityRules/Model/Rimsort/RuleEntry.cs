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
		public List<string> LoadBefore;

		[JsonProperty("loadAfter")]
		public List<string> LoadAfter;
	}
}
