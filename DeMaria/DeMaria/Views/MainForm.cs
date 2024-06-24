using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeMaria
{
    public partial class MainForm : Form
    {
        public event EventHandler UserButtonClicked;
        public event EventHandler ChangePasswordButtonClicked;
        public event EventHandler ProductButtonClicked;
        public event EventHandler CustomerButtonClicked;
        public event EventHandler StoreButtonClicked;
        public MainForm()
        {
            InitializeComponent();
        }
        public void UpdateLabelTitle(string newText)
        {
            LabelTitle.Text = newText;

            LabelTitle.AutoSize = true;

            int x = (TitlePanel.Width - LabelTitle.Width) / 2;
            int y = (TitlePanel.Height - LabelTitle.Height) / 2;
            LabelTitle.Location = new Point(x, y);
        }

        private void labelTitle_Click(object sender, EventArgs e)
        {

        }

        private void UserButton_Click(object sender, EventArgs e)
        {
            UserButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePasswordButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void ProductButton_Click(object sender, EventArgs e)
        {
            ProductButtonClicked?.Invoke(this, EventArgs.Empty);

        }

        private void CustomerButton_Click(object sender, EventArgs e)
        {
            CustomerButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        private void StoreButton_Click(object sender, EventArgs e)
        {
            StoreButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
