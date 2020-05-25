#Region "#CustomSearchTextForm"
Imports System.Drawing
Imports DevExpress.XtraRichEdit.Forms

Namespace CustomDialogs
	Partial Public Class MySearchTextForm
		Inherits SearchTextForm

		Public Sub New(ByVal controllerParameters As SearchFormControllerParameters, ByVal searchWord As String)
			MyBase.New(controllerParameters)
			lblFndDirection.Location = New Point(lblFndDirection.Location.X - 10, lblFndDirection.Location.Y)
			lblFndDirection.Text = "Direction:"
			cbFndSearchString.Text = searchWord
			chbFndRegex.Enabled = False
		End Sub

	End Class
End Namespace
#End Region ' #CustomSearchTextForm