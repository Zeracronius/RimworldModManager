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
        public bool SuspendSorting { get; set; }
        public IList RowData { get; set; }


        public void Reload()
        {
            try
            {
                SuspendSorting = true;
                Roots = RowData;
                BuildList(true);
            }
            finally
            {
                SuspendSorting = false;
            }
        }

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

        protected override void OnBeforeSorting(BeforeSortingEventArgs e)
        {
            if (SuspendSorting == true)
            {
                e.Canceled = true;
                return;
            }

            // Detect third column sort toggle and trigger unsort
            if (e.ColumnToSort != null && LastSortColumn == e.ColumnToSort && Sorting == SortOrder.Descending)
            {
                e.SortOrder = SortOrder.None;
                e.ColumnToSort = null;
                e.Handled = true;
            }
            Sorting = e.SortOrder;
            base.OnBeforeSorting(e);
        }

        protected override void OnAfterSorting(AfterSortingEventArgs e)
        {
            if (SuspendSorting == true)
                return;


            if (e.ColumnToSort == null)
            {
                // Unsort
                try
                {
                    SuspendSorting = true;
                    Roots = RowData;
                    RebuildColumns();
                    UpdateFiltering();
                }
                finally
                {
                    SuspendSorting = false;
                }
            }
            else
                base.OnAfterSorting(e);
        }


        public void ApplyFilter(string filterText)
        {
            try
            {
                SuspendSorting = true;

                if (String.IsNullOrWhiteSpace(filterText))
                {
                    ResetColumnFiltering();
                    RebuildColumns();
                    return;
                }

                filterText = filterText.ToLower();
                if (ModelFilter == null)
                {
                    TextMatchFilter filter = TextMatchFilter.Contains(this, filterText);
                    ModelFilter = filter;
                    DefaultRenderer = new HighlightTextRenderer(filter);
                }
                else
                {
                    (ModelFilter as TextMatchFilter).ContainsStrings = new string[] { filterText };
                }

                UpdateFiltering();
            }
            finally
            {
                SuspendSorting = false;
            }
        }
    }
}
