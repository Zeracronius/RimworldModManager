using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Autosorting.CommunityRules.Model.Rimsort
{
	internal class RuleSet
	{
		[JsonProperty("rules")]
		public Dictionary<string, RuleEntry> Rules;
	}
}
