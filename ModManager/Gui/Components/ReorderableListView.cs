using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager.Gui.Components
{
    public class ReorderableListView : ListView
    {
        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            //Begins a drag-and-drop operation in the ListView control.
            this.DoDragDrop(this.SelectedItems, DragDropEffects.Move);


            base.OnItemDrag(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            int len = drgevent.Data.GetFormats().Length - 1;
            int i;
            for (i = 0; i <= len; i++)
            {
                if (drgevent.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {

                    //The data from the drag source is moved to the target. 
                    drgevent.Effect = DragDropEffects.Move;
                }
            }

            base.OnDragEnter(drgevent);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            //Return if the items are not selected in the ListView control.
            if (drgevent.Data == null)
            {
                return;
            }
            //Returns the location of the mouse pointer in the ListView control.
            Point cp = this.PointToClient(new Point(drgevent.X, drgevent.Y));
            //Obtain the item that is located at the specified location of the mouse pointer.
            ListViewItem dragToItem = this.GetItemAt(cp.X, cp.Y);
            if (dragToItem == null)
            {
                return;
            }
            //Obtain the index of the item at the mouse pointer.
            int dragIndex = dragToItem.Index;

            SelectedListViewItemCollection draggedItems = drgevent.Data.GetData(typeof(SelectedListViewItemCollection)) as SelectedListViewItemCollection;
            
            int i = 0;
            foreach (ListViewItem dragItem in draggedItems)
            {
                int itemIndex = dragIndex;
                if (itemIndex == dragItem.Index)
                {
                    return;
                }
                if (dragItem.Index < itemIndex || dragItem.ListView != this)
                    itemIndex++;
                else
                    itemIndex = dragIndex + i;
                //Insert the item at the mouse pointer.
                ListViewItem insertItem = (ListViewItem)dragItem.Clone();
                insertItem.Name = dragItem.Name;
                this.Items.Insert(itemIndex, insertItem);
                //Removes the item from the initial location while 
                //the item is moved to the new location.
                dragItem.ListView.Items.Remove(dragItem);
                i++;
            }

            base.OnDragDrop(drgevent);
        }
    }
}
