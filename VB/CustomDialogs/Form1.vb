Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraRichEdit

Namespace CustomDialogs
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "#SearchFormShowing"
		Private Sub richEditControl1_SearchFormShowing(ByVal sender As Object, ByVal e As SearchFormShowingEventArgs) Handles richEditControl1.SearchFormShowing
			Dim curWord As String = richEditControl1.Document.GetText(richEditControl1.Document.Selection)
			Dim form As New MySearchTextForm(e.ControllerParameters, curWord)
			e.DialogResult = form.ShowDialog()
			e.Handled = True
		End Sub
		#End Region ' #SearchFormShowing

		#Region "#HyperlinkFormShowing"
		Private Sub richEditControl1_HyperlinkFormShowing(ByVal sender As Object, ByVal e As HyperlinkFormShowingEventArgs) Handles richEditControl1.HyperlinkFormShowing
			Dim form As New MyHyperlinkForm(e.ControllerParameters)
			e.DialogResult = form.ShowDialog()
			e.Handled = True
		End Sub
		#End Region ' #HyperlinkFormShowing

		Private Sub richEditControl1_FontFormShowing(ByVal sender As Object, ByVal e As FontFormShowingEventArgs) Handles richEditControl1.FontFormShowing
			Dim form As New MyFontForm(e.ControllerParameters)
			e.DialogResult = form.ShowDialog()
			e.Handled = True
		End Sub
	End Class
End Namespace