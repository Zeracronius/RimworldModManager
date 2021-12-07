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
        Rectangle _lastRect;

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            this.DoDragDrop(this.SelectedItems, DragDropEffects.Move);
            base.OnItemDrag(e);
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            int len = drgevent.Data.GetFormats().Length - 1;
            for (int i = 0; i <= len; i++)
            {
                if (drgevent.Data.GetFormats()[i].Equals("System.Windows.Forms.ListView+SelectedListViewItemCollection"))
                {
                    drgevent.Effect = DragDropEffects.Move;
                    break;
                }
            }

            base.OnDragEnter(drgevent);
        }

        protected override void OnDragLeave(EventArgs e)
        {
            ClearIndicatorLine();
            base.OnDragLeave(e);
        }

        private void ClearIndicatorLine()
        {
            if (_lastRect.IsEmpty == false)
            {
                _lastRect.Offset(0, -1);
                Invalidate(_lastRect);
                _lastRect = default(Rectangle);
            }
        }

        private void DrawIndicatorLine(DragEventArgs dragArgs)
        {
            Point cp = this.PointToClient(new Point(dragArgs.X, dragArgs.Y));
            ListViewItem targetItem = this.GetItemAt(cp.X, cp.Y);

            if (targetItem == null)
                targetItem = this.Items[this.Items.Count - 1];

            Rectangle targetItemRect = this.GetItemRect(targetItem.Index);

            float itemCenter = targetItemRect.Top + (targetItemRect.Height / 2);
            int targetPosition = targetItemRect.Bottom;
            if (cp.Y < itemCenter && cp.X < targetItemRect.Right)
                targetPosition = targetItemRect.Top;




            if (_lastRect.Top == targetPosition)
                return;

            ClearIndicatorLine();
            using (Graphics line = this.CreateGraphics())
            {
                line.DrawLine(new Pen(Color.Black, 2), new Point(0, targetPosition), new Point(this.Columns[0].Width, targetPosition));
                _lastRect = new Rectangle(0, targetPosition, this.Columns[0].Width, 2);
            }
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            DrawIndicatorLine(drgevent);
            base.OnDragOver(drgevent);
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            ClearIndicatorLine();

            if (drgevent.Data == null)
                return;

            Point cp = this.PointToClient(new Point(drgevent.X, drgevent.Y));
            ListViewItem dragToItem = this.GetItemAt(cp.X, cp.Y);

            int targetIndex = Items.Count - 1;
            if (dragToItem != null)
                targetIndex = dragToItem.Index;

            Rectangle itemRec = this.GetItemRect(targetIndex);
            float itemCenter = itemRec.Top + (itemRec.Height / 2);

            // If inserting below
            if (cp.Y > itemCenter)
                targetIndex += 1;


            SelectedListViewItemCollection draggedItems = drgevent.Data.GetData(typeof(SelectedListViewItemCollection)) as SelectedListViewItemCollection;
            foreach (ListViewItem draggedItem in draggedItems)
            {
                int index = targetIndex;
                if (draggedItem.ListView == this)
                {
                    if (targetIndex == draggedItem.Index)
                    {
                        // Trying to insert item in it's existing index.
                        targetIndex++;
                        continue;
                    }

                    if (draggedItem.Index > targetIndex && draggedItem.ListView == this)
                        targetIndex++;
                }
                else
                    targetIndex++;

                ListViewItem insertItem = (ListViewItem)draggedItem.Clone();
                insertItem.Name = draggedItem.Name;
                this.Items.Insert(index, insertItem);

                draggedItem.ListView.Items.Remove(draggedItem);
            }

            base.OnDragDrop(drgevent);
        }
    }
}
