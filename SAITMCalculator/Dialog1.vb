'Developed by Badde Liyanage Don Dilanga. bld@dilanga.com. 

Imports System.Windows.Forms

Public Class Dialog1

    Dim image As System.Drawing.Bitmap

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click

        If (ComboBox1.SelectedItem = "Wood Style") Then
            image = My.Resources.Texturebackground
        End If

        If (ComboBox1.SelectedItem = "Nature Elaborate") Then
            image = My.Resources.VectorBackground
        End If

        If Not (ComboBox1.SelectedItem = "") Then

            MsgBox("Selected Theme is : " + ComboBox1.SelectedItem.ToString())
            Form1.BackgroundImage = image

        End If

        Me.Close()

    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Form1.Opacity = 0.9
        Me.Close()
    End Sub

    Private Sub Dialog1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Nature Elaborate")
        ComboBox1.Items.Add("Wood Style")

    End Sub

    Private Sub track_option_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles track_option.Scroll

        ''Change the Opacity level of the main form
        Form1.Opacity = track_option.Value / 10

    End Sub
End Class
