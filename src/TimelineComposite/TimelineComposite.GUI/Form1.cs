using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TimelineComposite
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.btnTemplateBrowse.Focus();
        }

        private void PathValidating(object sender, CancelEventArgs e)
        {
            TextBox txt = (TextBox)sender;
            e.Cancel = !(string.IsNullOrWhiteSpace(txt.Text) || File.Exists(txt.Text));
        }

        private void btnTemplateBrowse_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.txtTemplatePath.Text = this.openFileDialog.FileName;
            }
        }

        private LangInfoDialog langInfoDialog = new LangInfoDialog();

        private void btnTemplateAdd_Click(object sender, EventArgs e)
        {
            if (this.langInfoDialog.ShowDialog() == DialogResult.OK)
            {
                this.lvTemplate.Items.Add(new ListViewItem(new string[]{
                    string.Empty,
                    this.langInfoDialog.LangName,
                    this.langInfoDialog.LangPath,
                }));
            }
        }
    }
}
