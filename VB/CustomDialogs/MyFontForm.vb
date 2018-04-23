Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports DevExpress.XtraRichEdit.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.XtraRichEdit

Namespace CustomDialogs
	Friend Class MyFontForm
		Inherits XtraForm
		Private labelControl1 As LabelControl
		Private fontEdit1 As FontEdit

		Private controller_Renamed As FontFormController
		Private WithEvents btnOk As SimpleButton
		Private btnCancel As SimpleButton
		Private richEditControl As RichEditControl


		Public Sub New()

		End Sub

		Public Sub New(ByVal controllerParameters As FontFormControllerParameters)
			InitializeComponent()
			Me.controller_Renamed = CreateController(controllerParameters)
			Me.richEditControl = CType(controllerParameters.Control, RichEditControl)
			UpdateForm()
		End Sub

		Public ReadOnly Property Controller() As FontFormController
			Get
				Return controller_Renamed
			End Get
		End Property

		Public Property Control() As RichEditControl
			Get
				Return richEditControl
			End Get
			Set(ByVal value As RichEditControl)
				Me.richEditControl = value
			End Set
		End Property
		Protected Friend Overridable Function CreateController(ByVal controllerParameters As FontFormControllerParameters) As FontFormController
			Return New FontFormController(controllerParameters)
		End Function
		Protected Friend Overridable Sub UpdateForm()
			UnsubscribeControlsEvents()
			Try
			If richEditControl IsNot Nothing Then
				Me.fontEdit1.Enabled = richEditControl.Options.DocumentCapabilities.CharacterFormattingAllowed
				Me.fontEdit1.Text = controller_Renamed.FontName
			End If
			Finally
				SubscribeControlsEvents()
			End Try
		End Sub

		Private Sub UnsubscribeControlsEvents()
			RemoveHandler fontEdit1.EditValueChanged, AddressOf fontEdit1_EditValueChanged
		End Sub

		Private Sub SubscribeControlsEvents()
			AddHandler fontEdit1.EditValueChanged, AddressOf fontEdit1_EditValueChanged
		End Sub

		Private Sub fontEdit1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			controller_Renamed.FontName = Me.fontEdit1.Text
		End Sub

		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(MyFontForm))
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			Me.fontEdit1 = New DevExpress.XtraEditors.FontEdit()
			Me.btnOk = New DevExpress.XtraEditors.SimpleButton()
			Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
			CType(Me.fontEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' labelControl1
			' 
			Me.labelControl1.Location = New System.Drawing.Point(12, 12)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(348, 13)
			Me.labelControl1.TabIndex = 0
			Me.labelControl1.Text = "This is a custom Font form that enables you to change the typeface only"
			' 
			' fontEdit1
			' 
			Me.fontEdit1.Location = New System.Drawing.Point(84, 44)
			Me.fontEdit1.Name = "fontEdit1"
			Me.fontEdit1.Properties.AccessibleName = ""
			Me.fontEdit1.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox
			Me.fontEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.fontEdit1.Size = New System.Drawing.Size(200, 20)
			Me.fontEdit1.TabIndex = 1
			' 
			' btnOk
			' 
			Me.btnOk.AccessibleName = "Ok"
			Me.btnOk.Location = New System.Drawing.Point(200, 86)
			Me.btnOk.Name = "btnOk"
			Me.btnOk.Size = New System.Drawing.Size(75, 23)
			Me.btnOk.TabIndex = 2
			Me.btnOk.Text = "OK"
'			Me.btnOk.Click += New System.EventHandler(Me.btnOK_Click);
			' 
			' btnCancel
			' 
			Me.btnCancel.AccessibleName = "Cancel"
			Me.btnCancel.CausesValidation = False
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(281, 86)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 3
			Me.btnCancel.Text = "Cancel"
			' 
			' MyFontForm
			' 
			Me.ClientSize = New System.Drawing.Size(368, 124)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnOk)
			Me.Controls.Add(Me.fontEdit1)
			Me.Controls.Add(Me.labelControl1)
			Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "MyFontForm"
			CType(Me.fontEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			Controller.ApplyChanges()
			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub


	End Class
End Namespace
