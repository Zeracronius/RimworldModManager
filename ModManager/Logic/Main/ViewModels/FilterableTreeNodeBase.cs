using ModManager.Gui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ModManager.Logic.Main.ViewModels
{
	public abstract class FilterableTreeNodeBase : ITreeListViewItem
	{
		private bool _visible;

		public FilterableTreeNodeBase()
		{
			Children = new List<ITreeListViewItem>();
			_visible = true;
		}

		public List<ITreeListViewItem> Children { get; set; }
		public ITreeListViewItem Parent { get; set; }
		public string Caption { get; set; }
		public abstract string Key { get; }
		public IEnumerable<ITreeListViewItem> FilteredChildren
		{
			get
			{
				for (int i = 0; i < Children.Count; i++)
				{
					ITreeListViewItem child = Children[i];
					if (child.Visible)
						yield return child;
				}
			}
		}

		bool ITreeListViewItem.Visible => _visible;

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

		public void ApplyFilter(string filterText)
		{
			_visible = Caption.ToLower().Contains(filterText);
			if (_visible)
			{
				var parent = Parent;
				while (parent != null)
				{
					if (parent is FilterableTreeNodeBase filterableNode)
						filterableNode._visible = true;

					parent = parent.Parent;
				}

				filterText = string.Empty;
			}

			for (int i = 0; i < Children.Count; i++)
			{
				ITreeListViewItem child = Children[i];
				child.ApplyFilter(filterText);
			}
		}
	}
}
