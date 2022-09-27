using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModManager.Logic.TextDialog
{
    public class TextDialogPresenter
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Value { get; set; }

        public TextDialogPresenter(string title, string value, string description = null)
        {
            Title = title;
            Value = value;
            Description = description ?? "Value:";
        }
    }
}
