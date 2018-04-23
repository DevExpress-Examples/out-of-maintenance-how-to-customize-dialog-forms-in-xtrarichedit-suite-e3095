#Region "#CustomHyperlinkForm"
Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.XtraRichEdit.Forms

Namespace CustomDialogs
	Friend Class MyHyperlinkForm
		Inherits HyperlinkForm
		Public Sub New(ByVal controllerParameters As HyperlinkFormControllerParameters)
			MyBase.New(controllerParameters)
			AddHandler btnEditAddress.EditValueChanged, AddressOf btnEditAddress_EditValueChanged
			AddHandler btnEditAddress.LostFocus, AddressOf btnEditAddress_LostFocus
		End Sub

		Private Sub btnEditAddress_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
			Me.btnEditAddress.Text = Controller.NavigateUri
		End Sub

		Private Sub btnEditAddress_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
			Controller.NavigateUri = ValidateUrl(btnEditAddress.Text)
			Me.btnOk.Enabled = Not String.IsNullOrEmpty(Me.btnEditAddress.Text)
		End Sub

		Private Function ValidateUrl(ByVal p As String) As String
			Dim s As String = p.Replace("devexpres.com", "devexpress.com")
			Return s
		End Function

	End Class
End Namespace
#End Region ' #CustomHyperlinkForm