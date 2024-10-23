using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Autosorting.CommunityRules
{
	internal interface ICommunityPatch
	{
		IEnumerable<string> GetLoadAfter(string packageId);
	}
}
