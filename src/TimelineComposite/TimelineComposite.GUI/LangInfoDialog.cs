using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimelineComposite
{
    public partial class LangInfoDialog : Form
    {
        public string LangName
        {
            get => this.txtName.Text;
            set => this.txtName.Text = value;
        }

        public string LangPath
        {
            get => this.txtPath.Text;
            set => this.txtPath.Text = value;
        }

        public LangInfoDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = this.openFileDialog.FileName;
            }
        }
    }
}
