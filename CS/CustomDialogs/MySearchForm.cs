#region #CustomSearchTextForm
using System.Drawing;
using DevExpress.XtraRichEdit.Forms;

namespace CustomDialogs
{
    public partial class MySearchTextForm : SearchTextForm
    {
        public MySearchTextForm(SearchFormControllerParameters controllerParameters, string searchWord)
            : base(controllerParameters)
        {
            lblFndDirection.Location = new Point (lblFndDirection.Location.X - 10, lblFndDirection.Location.Y);
            lblFndDirection.Text = "Direction:";
            cbFndSearchString.Text = searchWord;
            chbFndRegex.Enabled = false;
        }

    }
}
#endregion #CustomSearchTextForm