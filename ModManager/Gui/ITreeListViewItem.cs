using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Gui
{
    public interface ITreeListViewItem
    {
        bool IsAncestorOf(ITreeListViewItem item);
        List<ITreeListViewItem> Children { get; }
        ITreeListViewItem Parent { get; set; }
        string Caption { get; }
        string Key { get; }
    }
}
