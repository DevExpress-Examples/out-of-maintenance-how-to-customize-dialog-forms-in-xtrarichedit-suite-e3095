#region #CustomHyperlinkForm
using System;
using DevExpress.XtraRichEdit.Forms;

namespace CustomDialogs
{
    class MyHyperlinkForm : HyperlinkForm
    {
        public MyHyperlinkForm(HyperlinkFormControllerParameters controllerParameters)
            : base(controllerParameters)
        {
            btnEditAddress.EditValueChanged += new EventHandler(btnEditAddress_EditValueChanged);
            btnEditAddress.LostFocus += new EventHandler(btnEditAddress_LostFocus);
        }

        void btnEditAddress_LostFocus(object sender, EventArgs e)
        {
            this.btnEditAddress.Text = Controller.NavigateUri;
        }

        void btnEditAddress_EditValueChanged(object sender, EventArgs e)
        {
            Controller.NavigateUri = ValidateUrl(btnEditAddress.Text);
            this.btnOk.Enabled = true;
        }

        private string ValidateUrl(string p)
        {
            string s = p.Replace("devexpres.com", "devexpress.com");
            return s;
        }

    }
}
#endregion #CustomHyperlinkForm