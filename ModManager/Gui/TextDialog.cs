using ModManager.Logic.TextDialog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModManager.Gui
{
    public partial class TextDialog : Form
    {
        TextDialogPresenter _presenter;

        public TextDialog(TextDialogPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
        }

        private void TextDialog_Load(object sender, EventArgs e)
        {
            this.Text = _presenter.Title;
            ValueTextBox.Text = _presenter.Value;
            DescriptionLabel.Text = _presenter.Description;
        }

        private void Accept_Click(object sender, EventArgs e)
        {
            _presenter.Value = ValueTextBox.Text;
            DialogResult = DialogResult.OK;
        }

    }
}
