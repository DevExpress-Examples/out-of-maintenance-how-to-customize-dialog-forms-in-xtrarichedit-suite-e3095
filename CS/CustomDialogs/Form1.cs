using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraRichEdit;

namespace CustomDialogs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region #SearchFormShowing
        private void richEditControl1_SearchFormShowing(object sender, SearchFormShowingEventArgs e)
        {
            string curWord = richEditControl1.Document.GetText(richEditControl1.Document.Selection);
            MySearchTextForm form = new MySearchTextForm(e.ControllerParameters, curWord);
            e.DialogResult = form.ShowDialog();
            form.Dispose();
            e.Handled = true;
        }
        #endregion #SearchFormShowing

        #region #HyperlinkFormShowing
        private void richEditControl1_HyperlinkFormShowing(object sender,HyperlinkFormShowingEventArgs e)
        {
            MyHyperlinkForm form = new MyHyperlinkForm(e.ControllerParameters);
            e.DialogResult = form.ShowDialog();
            form.Dispose();
            e.Handled = true;
        }
        #endregion #HyperlinkFormShowing

        private void richEditControl1_FontFormShowing(object sender, FontFormShowingEventArgs e)
        {
            MyFontForm form = new MyFontForm(e.ControllerParameters);
            e.DialogResult = form.ShowDialog();
            form.Dispose();
            e.Handled = true;
        }
    }
}