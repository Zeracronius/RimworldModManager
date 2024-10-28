using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Autosorting.CommunityRules
{
	internal interface ICommunityRuleset
	{
		Dictionary<string, List<string>> GetLoadAfters();
	}
}
