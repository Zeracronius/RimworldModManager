using BrightIdeasSoftware;
using ModManager.Logic.Main.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ModManager.Gui.Components
{
    public class ReorderableTreeListView : DataTreeListView
    {
        public bool SuspendSorting { get; set; }
        public bool Reloading { get; private set; }
        public IList RowData { get; set; }
		public IList FilteredRowData { get; set; }

		public void Reload()
        {
            OLVColumn sortColumn = PrimarySortColumn;
            SortOrder sortOrder = PrimarySortOrder;
            try
            {
                Reloading = true;
                SuspendSorting = true;
                Roots = GetRoots();
                BuildList(true);
            }
            finally
            {
                SuspendSorting = false;
                Sort(sortColumn, sortOrder);
                Reloading = false;
            }
        }

		private IEnumerable GetRoots()
		{
            foreach (var item in RowData)
            {
                if (item is ITreeListViewItem treeItem)
                {
                    if (treeItem.Visible)
                        yield return treeItem;
                }
                else
                    yield return item;
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
                
                if (target != null && sourceModels.Any(x => x.IsAncestorOf(target)))
                    e.InfoMessage = "Cannot drop as it's own child.";
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
            if (Reloading == false && e.ColumnToSort != null && LastSortColumn == e.ColumnToSort && Sorting == SortOrder.Descending)
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
					Roots = GetRoots();
					//Roots = RowData;
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


				filterText = filterText?.ToLower();

				foreach (var item in RowData.OfType<ITreeListViewItem>())
				{
                    item.ApplyFilter(filterText);
				}
				Roots = GetRoots();

				if (String.IsNullOrWhiteSpace(filterText))
				{
					ResetColumnFiltering();
                    RebuildColumns();
                    return;
                }

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


        public void DetachItems(IEnumerable<ITreeListViewItem> items)
        {
            foreach (ITreeListViewItem x in items)
            {
                DetachItem(x);
            }
        }

        public void DetachItem(ITreeListViewItem item)
        {
            if (item.Parent != null)
            {
                item.Parent.Children.Remove(item);
                item.Parent = null;
            }
            else
                RowData.Remove(item);
        }
    }
}
