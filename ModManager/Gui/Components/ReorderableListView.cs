using BrightIdeasSoftware;
using ModManager.Logic.Main.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager.Gui.Components
{
    public class ReorderableTreeListView : DataTreeListView
    {

        protected override void OnModelCanDrop(BrightIdeasSoftware.ModelDropEventArgs e)
        {
            e.Handled = true;
            e.Effect = DragDropEffects.None;
            if (e.SourceModels.Contains(e.TargetModel))
                e.InfoMessage = "Cannot drop on self";
            else
            {
                var sourceModels = e.SourceModels.Cast<ITreeListViewItem>();
                ITreeListViewItem target = e.TargetModel as ITreeListViewItem;
                
                if (e.DropTargetLocation == DropTargetLocation.Item && sourceModels.Any(x => target.IsAncestorOf(x)))
                    e.InfoMessage = "Cannot drop on descendant (think of the temporal paradoxes!)";
                else
                    e.Effect = DragDropEffects.Move;
            }
            base.OnModelCanDrop(e);
        }
    }
}
