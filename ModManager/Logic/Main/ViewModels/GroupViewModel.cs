using ModManager.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.Main.ViewModels
{
    internal class GroupViewModel : ITreeListViewItem
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
            Children = new List<ITreeListViewItem>();
            _groupKeys.Add(key);
        }

        public List<ITreeListViewItem> Children { get; }
        public ITreeListViewItem Parent { get; set; }
        public string Caption { get; set; }
        public string Key { get; }
        public string Downloaded => "";

        public string SupportedVersions => "";

        public bool IsAncestorOf(ITreeListViewItem item)
        {
            ITreeListViewItem parent = item.Parent;
            while (parent != null)
            {
                if (parent == this)
                    return true;

                parent = parent.Parent;
            }
            return false;
        }
    }
}
