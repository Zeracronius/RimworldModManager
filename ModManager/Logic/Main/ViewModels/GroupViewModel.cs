using ModManager.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Main.ViewModels
{
    internal class GroupViewModel : FilterableTreeNodeBase
    {
        static HashSet<string> _groupKeys = new HashSet<string>();
        public static void ResetSeed()
        {
            _groupKeys.Clear();
        }

        public GroupViewModel(string caption)
        {
            string key = caption.ToLower().Replace(" ", "");
            int i = 0;
            while (_groupKeys.Contains(key))
            {
                i++;
                key = key + i;
            }

            Caption = caption;
            Key = key;
            _groupKeys.Add(key);
        }

        public override string Key { get; }
        public string Downloaded => "";

        public string SupportedVersions => "";

    }
}
