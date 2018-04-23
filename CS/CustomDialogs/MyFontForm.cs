using System;
using System.Collections.Generic;
using System.Text;
using DevExpress.XtraRichEdit.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraRichEdit;

namespace CustomDialogs
{
    class MyFontForm : XtraForm
    {
        private LabelControl labelControl1;
        private FontEdit fontEdit1;

        FontFormController controller;
        private SimpleButton btnOk;
        private SimpleButton btnCancel;
        RichEditControl richEditControl;


        public MyFontForm()
        {
            
        }

        public MyFontForm(FontFormControllerParameters controllerParameters)
        {
            InitializeComponent();
            this.controller = CreateController(controllerParameters);
            this.richEditControl = (RichEditControl)controllerParameters.Control;
            UpdateForm();
        }

        public FontFormController Controller { get { return controller; } }
        
        public RichEditControl Control {
            get { return richEditControl;}
            set { this.richEditControl = value;}
        }
        protected internal virtual FontFormController CreateController(FontFormControllerParameters controllerParameters)
        {
            return new FontFormController(controllerParameters);
        }
        protected internal virtual void UpdateForm()
        {
            UnsubscribeControlsEvents();
            try {
            if (richEditControl != null) {
                this.fontEdit1.Enabled = richEditControl.Options.DocumentCapabilities.CharacterFormattingAllowed;
                this.fontEdit1.Text = controller.FontName;
            }
            }
            finally {
                SubscribeControlsEvents();
            }
        }

        private void UnsubscribeControlsEvents()
        {
            this.fontEdit1.EditValueChanged -= new EventHandler(fontEdit1_EditValueChanged);
        }

        private void SubscribeControlsEvents()
        {
            this.fontEdit1.EditValueChanged += new EventHandler(fontEdit1_EditValueChanged);
        }

        void fontEdit1_EditValueChanged(object sender, EventArgs e)
        {
            controller.FontName = this.fontEdit1.Text;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyFontForm));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.fontEdit1 = new DevExpress.XtraEditors.FontEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(348, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "This is a custom Font form that enables you to change the typeface only";
            // 
            // fontEdit1
            // 
            this.fontEdit1.Location = new System.Drawing.Point(84, 44);
            this.fontEdit1.Name = "fontEdit1";
            this.fontEdit1.Properties.AccessibleName = "";
            this.fontEdit1.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.fontEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.fontEdit1.Size = new System.Drawing.Size(200, 20);
            this.fontEdit1.TabIndex = 1;
            // 
            // btnOk
            // 
            this.btnOk.AccessibleName = "Ok";
            this.btnOk.Location = new System.Drawing.Point(200, 86);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleName = "Cancel";
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(281, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // MyFontForm
            // 
            this.ClientSize = new System.Drawing.Size(368, 124);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.fontEdit1);
            this.Controls.Add(this.labelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MyFontForm";
            ((System.ComponentModel.ISupportInitialize)(this.fontEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Controller.ApplyChanges();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }


    }
}
