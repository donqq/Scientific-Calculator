
'*******************************************************
'
'Developed by Badde Liyanage Don Dilanga. bld@dilanga.com. 

'*******************************************************



'*******************************************************
'
'Import Appropriate Library Files 
'
'*******************************************************


Imports SAITM_FC '//Import the (F to C)and(C to F) library file
Imports SAITM_Conversion '//Import the Conversion Library file
Imports SAITM_Algebra '//Import algebra

Public Class Form1

    ''*********************************************
    '' Form 
    ''
    ''*********************************************

    '//Drag and Drop Variables

    Dim menu_point_min, menu_point_max As System.Drawing.Point
    Dim current_dir As String

    '//Calculation part

    Dim class_calculation As New calculation
    Dim first_value, second_value, symbol As Double

    '//Scientific Part
    Dim value, answer_value As Double

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'initialization size
        Me.Size = New Size(342, 412)
        StandardToolStripMenuItem1.Checked = True

        current_dir = My.Computer.FileSystem.CurrentDirectory

        'prevent typing on the textbox
        txtmain.BackColor = Color.White
        txtmain.ForeColor = Color.Black
        txtmain.TextAlign = HorizontalAlignment.Right

        btn_mg.Text = "Mo"
        btn_mplus.Enabled = False
        btn_mminus.Enabled = False

        '//hide the memory combo
        combo_memory.Hide()

        '//Scientific Part
        radio_rad.Checked = True

        '//conversion part initialization
        radio_decimal.Checked = True

        'if octal selected then hide unnesseccary controls
        btn_2.Enabled = True
        btn_3.Enabled = True
        btn_4.Enabled = True
        btn_5.Enabled = True
        btn_6.Enabled = True
        btn_7.Enabled = True
        btn_8.Enabled = True
        btn_9.Enabled = True

        btn_a.Enabled = False
        btn_b.Enabled = False
        btn_c.Enabled = False
        btn_d.Enabled = False
        btn_e.Enabled = False
        btn_f.Enabled = False

        btn_decimal_point.Enabled = True
        btn_addminus.Enabled = True

        '//Notify Icon
        notify_ico.BalloonTipIcon = ToolTipIcon.Info
        notify_ico.BalloonTipText = "CSSCal 0.1"
        notify_ico.ContextMenuStrip = cms_1

        '//Unit Conversion Loading to the Page
        cmb_box_unit.Items.Add("km/h to m/s")
        cmb_box_unit.Items.Add("m/s to km/h")

        cmb_box_unit.Items.Add("mmHg to Pa")
        cmb_box_unit.Items.Add("Pa to mmHg")

        cmb_box_unit.Items.Add("hP to W")
        cmb_box_unit.Items.Add("W to hP")

        cmb_box_unit.Items.Add("Inch to cm")
        cmb_box_unit.Items.Add("cm to Inch")

    End Sub

    Private Sub Form1_MouseMove(ByVal sender As System.Object, ByVal e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove

        Dim location2 As System.Drawing.Point

        If (e.Button = Windows.Forms.MouseButtons.Left) Then

            location2.X = MousePosition.X
            location2.Y = MousePosition.Y



            Me.Location = location2

        End If

        '///move the leaf as well



        '////Testing_01 2010-02-09////


        'e get the relative coordination to form not relative to screen
        'but MousePosition propertiy get the coordination relative to screen

        'Console.WriteLine("Xmouse " + location2.X.ToString())
        'Console.WriteLine("MeX " + Me.Location.X.ToString())

        'Console.WriteLine("Ymouse " + location2.Y.ToString())
        'Console.WriteLine("MeY " + Me.Location.Y.ToString())


        'Console.WriteLine("Xmouse" + x_mouse.ToString())
        'Console.WriteLine("Me X" + Me.Location.X.ToString())

        'Console.WriteLine("Ymouse" + y_mouse.ToString())
        'Console.WriteLine("Me Y" + Me.Location.Y.ToString())

        '////Testing_01 2010-02-09////

    End Sub

    ''*********************************************
    '' View
    ''
    ''*********************************************


    Private Sub StandardToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardToolStripMenuItem1.Click
        StandardToolStripMenuItem1.Checked = True 'Not (StandardToolStripMenuItem1.Checked)

        If (StandardToolStripMenuItem1.Checked) Then ''if this checked
            Me.Size = New Size(342, 412)

            'uncheck rest of all
            ScientificToolStripMenuItem1.Checked = False
            ConversionToolStripMenuItem.Checked = False

            'Disable Scientifical operations
            grp_advance_top.Enabled = False
            grp_advance_bottom.Enabled = False

            'change location of the close and minimize button

            'the close button
            menu_point_min.X = 266
            menu_point_min.Y = 8
            btn_close.Location = menu_point_min

            'the minimize button
            menu_point_min.X = 301
            menu_point_min.Y = 8
            btn_minimize.Location = menu_point_min

        End If

    End Sub

    Private Sub ScientificToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScientificToolStripMenuItem1.Click
        ScientificToolStripMenuItem1.Checked = True 'Not (ScientificToolStripMenuItem1.Checked)

        If (ScientificToolStripMenuItem1.Checked) Then ''if this checked
            Me.Size = New Size(702, 392)

            'uncheck rest of all
            StandardToolStripMenuItem1.Checked = False
            ConversionToolStripMenuItem.Checked = False

            'Enable Scientifical operations
            grp_advance_top.Enabled = True
            grp_advance_bottom.Enabled = True

            'the close button
            menu_point_min.X = 620
            menu_point_min.Y = 6
            btn_close.Location = menu_point_min

            'the minimize button
            menu_point_min.X = 655
            menu_point_min.Y = 6
            btn_minimize.Location = menu_point_min

        End If

    End Sub

    Private Sub ConversionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConversionToolStripMenuItem.Click
        ConversionToolStripMenuItem.Checked = True 'Not (ConversionToolStripMenuItem.Checked)

        If (ConversionToolStripMenuItem.Checked) Then ''if this checked
            Me.Size = New Size(702, 555)

            'uncheck rest of all
            ScientificToolStripMenuItem1.Checked = False
            StandardToolStripMenuItem1.Checked = False

            'when user selected the base conversion then hide rest of scientifical operations

            grp_advance_top.Enabled = False
            grp_advance_bottom.Enabled = False


            'the close button
            menu_point_min.X = 620
            menu_point_min.Y = 6
            btn_close.Location = menu_point_min

            'the minimize button
            menu_point_min.X = 655
            menu_point_min.Y = 6
            btn_minimize.Location = menu_point_min

        End If

    End Sub

    Private Sub QuitToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QuitToolStripMenuItem1.Click
        Application.Exit()
    End Sub

    Private Sub CopyToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem1.Click
        txtmain.Copy()
    End Sub

    Private Sub PasteToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem1.Click
        txtmain.Paste()
    End Sub

    Private Sub SelectAllToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SelectAllToolStripMenuItem.Click
        txtmain.SelectAll()
    End Sub

    Private Sub OptionToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptionToolStripMenuItem1.Click
        Dim option_form As New Dialog1

        option_form.Show()

    End Sub

    Private Sub HelpMeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpMeToolStripMenuItem.Click
        Try

            Dim pdf_file As String
            pdf_file = My.Computer.FileSystem.GetName("CSS Cal 0.1 Manual.pdf")
            Help.ShowHelp(Me, pdf_file) '//display the help pdf file

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        show_about()
    End Sub

    Public Sub show_about()
        Dim about_form As New AboutBox1
        about_form.Show()
    End Sub

    '*********************************************
    'When buttons Move
    '
    '*********************************************

    Private Sub btn_1_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1.MouseMove
        btn_1.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_2_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_2.MouseMove
        btn_2.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_3_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_3.MouseMove
        btn_3.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_4_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_4.MouseMove
        btn_4.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_5_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_5.MouseMove
        btn_5.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_6_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_6.MouseMove
        btn_6.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_7_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_7.MouseMove
        btn_7.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_8_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_8.MouseMove
        btn_8.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_9_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_9.MouseMove
        btn_9.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_0_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_0.MouseMove
        btn_0.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_add_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.MouseMove
        btn_add.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_subtract_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subtract.MouseMove
        btn_subtract.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_multiply_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multiply.MouseMove
        btn_multiply.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_divide_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_divide.MouseMove
        btn_divide.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_1_2_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1_2.MouseMove
        btn_1_2.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_mplus_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mplus.MouseMove
        btn_mplus.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_mminus_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mminus.MouseMove
        btn_mminus.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_clear_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.MouseMove
        btn_clear.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_mg_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mg.MouseMove
        btn_mg.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_addminus_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addminus.MouseMove
        btn_addminus.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_back_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.MouseMove
        btn_back.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_decimal_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_decimal_point.MouseMove
        btn_decimal_point.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_equal_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_equal.MouseMove
        btn_equal.BackColor = Color.GreenYellow
    End Sub
    '-------------------------
    'ADVANCE SECTION
    '-------------------------

    Private Sub btn_sin_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sin.MouseMove
        btn_sin.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_cos_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cos.MouseMove
        btn_cos.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_tan_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tan.MouseMove
        btn_tan.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_x_1_y_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_1_y.MouseMove
        btn_x_1_y.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_sec_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sec.MouseMove
        btn_sec.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_cot_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cot.MouseMove
        btn_cot.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_exp_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp.MouseMove
        btn_exp.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_pi_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pi.MouseMove
        btn_pi.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_cosec_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cosec.MouseMove
        btn_cosec.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_deg_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deg.MouseMove
        btn_deg.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_rad_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rad.MouseMove
        btn_rad.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_e_2_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e_2.MouseMove
        btn_e_2.BackColor = Color.GreenYellow
    End Sub
    Private Sub btn_e_x_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e_x.MouseMove
        btn_e_x.BackColor = Color.GreenYellow

    End Sub


    Private Sub btn_f_c_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_f_c.MouseMove
        btn_f_c.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_log_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_log.MouseMove
        btn_log.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_x_y_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_y.MouseMove
        btn_x_y.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_x_2_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_2.MouseMove
        btn_x_2.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_ln_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ln.MouseMove
        btn_ln.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_x_3_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_3.MouseMove
        btn_x_3.BackColor = Color.GreenYellow
    End Sub



    '-------------------------
    'CONVERSION SECTION
    '-------------------------


    Private Sub btn_c_f_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c_f.MouseMove
        btn_c_f.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_d_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_d.MouseMove
        btn_d.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_e_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e.MouseMove
        btn_e.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_c_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c.MouseMove
        btn_c.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_b_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_b.MouseMove
        btn_b.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_a_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_a.MouseMove
        btn_a.BackColor = Color.GreenYellow
    End Sub




    Private Sub btn_n_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_n.MouseMove
        btn_n.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_sigma_nr_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sigma_nr.MouseMove
        btn_sigma_nr.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_sigma_n1_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sigma_n1.MouseMove
        btn_sigma_n1.BackColor = Color.GreenYellow
    End Sub

    Private Sub btn_ncr_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ncr.MouseMove
        btn_ncr.BackColor = Color.GreenYellow
    End Sub


    '************************************************************************************************************************************************************************************
    '****************************************************************************************************************************************************************************************
    '************************************************************************************************************************************************************************************
    '************************************************************************************************************************************************************************************
    '************************************************************************************************************************************************************************************
    '************************************************************************************************************************************************************************************





    '*********************************************
    'When buttons LEAVE
    '
    '*********************************************


    Private Sub btn_1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1.MouseLeave
        btn_1.BackColor = Color.Transparent
    End Sub
    Private Sub btn_2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_2.MouseLeave
        btn_2.BackColor = Color.Transparent
    End Sub
    Private Sub btn_3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_3.MouseLeave
        btn_3.BackColor = Color.Transparent
    End Sub
    Private Sub btn_4_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_4.MouseLeave
        btn_4.BackColor = Color.Transparent
    End Sub
    Private Sub btn_5_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_5.MouseLeave
        btn_5.BackColor = Color.Transparent
    End Sub
    Private Sub btn_6_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_6.MouseLeave
        btn_6.BackColor = Color.Transparent
    End Sub
    Private Sub btn_7_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_7.MouseLeave
        btn_7.BackColor = Color.Transparent
    End Sub
    Private Sub btn_8_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_8.MouseLeave
        btn_8.BackColor = Color.Transparent
    End Sub
    Private Sub btn_9_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_9.MouseLeave
        btn_9.BackColor = Color.Transparent
    End Sub
    Private Sub btn_0_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_0.MouseLeave
        btn_0.BackColor = Color.Transparent
    End Sub
    Private Sub btn_add_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.MouseLeave
        btn_add.BackColor = Color.Transparent
    End Sub
    Private Sub btn_subtract_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subtract.MouseLeave
        btn_subtract.BackColor = Color.Transparent
    End Sub
    Private Sub btn_multiply_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multiply.MouseLeave
        btn_multiply.BackColor = Color.Transparent
    End Sub
    Private Sub btn_divide_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_divide.MouseLeave
        btn_divide.BackColor = Color.Transparent
    End Sub
    Private Sub btn_1_2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1_2.MouseLeave
        btn_1_2.BackColor = Color.Transparent
    End Sub
    Private Sub btn_mplus_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mplus.MouseLeave
        btn_mplus.BackColor = Color.Transparent
    End Sub
    Private Sub btn_mminus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mminus.MouseLeave
        btn_mminus.BackColor = Color.Transparent
    End Sub
    Private Sub btn_clear_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.MouseLeave
        btn_clear.BackColor = Color.Transparent
    End Sub
    Private Sub btn_mg_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mg.MouseLeave
        btn_mg.BackColor = Color.Transparent
    End Sub
    Private Sub btn_addminus_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addminus.MouseLeave
        btn_addminus.BackColor = Color.Transparent
    End Sub
    Private Sub btn_back_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.MouseLeave
        btn_back.BackColor = Color.Transparent
    End Sub
    Private Sub btn_decimal_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_decimal_point.MouseLeave
        btn_decimal_point.BackColor = Color.Transparent
    End Sub
    Private Sub btn_equal_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_equal.MouseLeave
        btn_equal.BackColor = Color.Transparent
    End Sub
    '-------------------------
    'ADVANCE SECTION
    '-------------------------

    Private Sub btn_sin_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sin.MouseLeave
        btn_sin.BackColor = Color.Transparent
    End Sub
    Private Sub btn_cos_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cos.MouseLeave
        btn_cos.BackColor = Color.Transparent
    End Sub
    Private Sub btn_tan_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tan.MouseLeave
        btn_tan.BackColor = Color.Transparent
    End Sub
    Private Sub btn_x_1_y_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_1_y.MouseLeave
        btn_x_1_y.BackColor = Color.Transparent
    End Sub
    Private Sub btn_sec_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sec.MouseLeave
        btn_sec.BackColor = Color.Transparent
    End Sub
    Private Sub btn_cot_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cot.MouseLeave
        btn_cot.BackColor = Color.Transparent
    End Sub
    Private Sub btn_exp_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp.MouseLeave
        btn_exp.BackColor = Color.Transparent
    End Sub
    Private Sub btn_pi_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pi.MouseLeave
        btn_pi.BackColor = Color.Transparent
    End Sub
    Private Sub btn_cosec_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cosec.MouseLeave
        btn_cosec.BackColor = Color.Transparent
    End Sub
    Private Sub btn_deg_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deg.MouseLeave
        btn_deg.BackColor = Color.Transparent
    End Sub
    Private Sub btn_rad_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rad.MouseLeave
        btn_rad.BackColor = Color.Transparent
    End Sub
    Private Sub btn_e_2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e_2.MouseLeave
        btn_e_2.BackColor = Color.Transparent
    End Sub
    Private Sub btn_e_x_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e_x.MouseLeave
        btn_e_x.BackColor = Color.Transparent

    End Sub


    Private Sub btn_f_c_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_f_c.MouseLeave
        btn_f_c.BackColor = Color.Transparent
    End Sub

    Private Sub btn_log_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_log.MouseLeave
        btn_log.BackColor = Color.Transparent
    End Sub

    Private Sub btn_x_y_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_y.MouseLeave
        btn_x_y.BackColor = Color.Transparent
    End Sub

    Private Sub btn_x_2_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_2.MouseLeave
        btn_x_2.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ln_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ln.MouseLeave
        btn_ln.BackColor = Color.Transparent
    End Sub

    Private Sub btn_x_3_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_3.MouseLeave
        btn_x_3.BackColor = Color.Transparent
    End Sub



    '-------------------------
    'CONVERSION SECTION
    '-------------------------


    Private Sub btn_c_f_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c_f.MouseLeave
        btn_c_f.BackColor = Color.Transparent
    End Sub

    Private Sub btn_d_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_d.MouseLeave
        btn_d.BackColor = Color.Transparent
    End Sub

    Private Sub btn_e_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e.MouseLeave
        btn_e.BackColor = Color.Transparent
    End Sub

    Private Sub btn_c_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c.MouseLeave
        btn_c.BackColor = Color.Transparent
    End Sub

    Private Sub btn_b_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_b.MouseLeave
        btn_b.BackColor = Color.Transparent
    End Sub

    Private Sub btn_a_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_a.MouseLeave
        btn_a.BackColor = Color.Transparent
    End Sub


    Private Sub btn_n_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_n.MouseLeave
        btn_n.BackColor = Color.Transparent
    End Sub

    Private Sub btn_sigma_nr_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sigma_nr.MouseLeave
        btn_sigma_nr.BackColor = Color.Transparent
    End Sub

    Private Sub btn_sigma_n1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sigma_n1.MouseLeave
        btn_sigma_n1.BackColor = Color.Transparent
    End Sub

    Private Sub btn_ncr_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ncr.MouseLeave
        btn_ncr.BackColor = Color.Transparent
    End Sub

    '******************************************************************
    '
    'FORM MENU BUTTONS
    '
    '******************************************************************

    Private Sub btn_minimize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_minimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btn_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.Click
        Application.Exit()
    End Sub

    'MOUSE MOVE

    Private Sub btn_minimize_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_minimize.MouseMove
        btn_minimize.BackColor = Color.White
        btn_minimize.ForeColor = Color.Green
    End Sub

    Private Sub btn_close_MouseMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.MouseMove
        btn_close.BackColor = Color.White
        btn_close.ForeColor = Color.Green
    End Sub

    'MOUSE LEAVE

    Private Sub btn_minimize_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_minimize.MouseLeave
        btn_minimize.BackColor = Color.Transparent
        btn_minimize.ForeColor = Color.Black
    End Sub

    Private Sub btn_close_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_close.MouseLeave
        btn_close.BackColor = Color.Transparent
        btn_close.ForeColor = Color.Black
    End Sub

    '**************************************************************************
    '
    'BUTTONS TYPING
    '
    '**************************************************************************



    Private Sub btn_1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1.Click
        txtmain.Text += btn_1.Text
    End Sub

    Private Sub btn_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_2.Click
        txtmain.Text += btn_2.Text
    End Sub

    Private Sub btn_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_3.Click
        txtmain.Text += btn_3.Text
    End Sub

    Private Sub btn_4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_4.Click
        txtmain.Text += btn_4.Text
    End Sub

    Private Sub btn_5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_5.Click
        txtmain.Text += btn_5.Text
    End Sub

    Private Sub btn_6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_6.Click
        txtmain.Text += btn_6.Text
    End Sub

    Private Sub btn_7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_7.Click
        txtmain.Text += btn_7.Text
    End Sub

    Private Sub btn_8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_8.Click
        txtmain.Text += btn_8.Text
    End Sub

    Private Sub btn_9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_9.Click
        txtmain.Text += btn_9.Text
    End Sub

    Private Sub btn_0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_0.Click
        txtmain.Text += btn_0.Text
    End Sub


    '--------------------------------------
    'Basic Operations
    '--------------------------------------
    ' 1 = add +
    ' 2 = subtract -
    ' 3 = multiply *
    ' 4 = divide

    '//Hexa Calculation
    '//Convert Hexa to Decimal then Calculate then Decimal to Hexa and Show the Answer


    Private Sub btn_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_add.Click
        symbol = 1 '/add
        first_value = Val(txtmain.Text)
        txtmain.Clear()
    End Sub

    Private Sub btn_subtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_subtract.Click
        symbol = 2 '/subtract
        first_value = Val(txtmain.Text)
        txtmain.Clear()
    End Sub

    Private Sub btn_multiply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_multiply.Click
        symbol = 3 '/multiply
        first_value = Val(txtmain.Text)
        txtmain.Clear()
    End Sub

    Private Sub btn_divide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_divide.Click
        symbol = 4 '/divide
        first_value = Val(txtmain.Text)
        txtmain.Clear()
    End Sub


    Private Sub btn_back_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_back.Click
        Try
            txtmain.Text = txtmain.Text.Remove(txtmain.Text.Length - 1, 1) 'remove and returns the result

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub


    '//************************************
    '//Memory
    '//************************************


    Private Sub btn_mplus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mplus.Click

        If (combo_memory.Visible = True) Then '//if combo memory visible the add items
            combo_memory.Items.Add(Val(txtmain.Text))
        End If

    End Sub

    Private Sub btn_mminus_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mminus.Click

        If (combo_memory.Visible = True) Then '//if combo memory visible the add items
            combo_memory.Items.Add(-Val(txtmain.Text))
        End If

    End Sub

    Private Sub btn_mg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_mg.Click

        'if the combobox visible the hide it
        If (combo_memory.Visible = True) Then
            combo_memory.Hide()

            '//the hide the rest of M+ and M- buttons
            btn_mplus.Enabled = False
            btn_mminus.Enabled = False

            '//clear the memory values
            combo_memory.Items.Clear()

        ElseIf (combo_memory.Visible = False) Then
            combo_memory.Show()

            '//the show the rest of M+ and M- buttons
            btn_mplus.Enabled = True
            btn_mminus.Enabled = True

        End If

    End Sub


    Private Sub combo_memory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles combo_memory.SelectedIndexChanged
        '//return the value when SelectedIndexChanged has been changed to main txt
        txtmain.Text = combo_memory.SelectedItem.ToString()

    End Sub

    '//************************************


    Private Sub btn_clear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_clear.Click
        txtmain.Clear()
        txtmain.Text = "0"
    End Sub

    Private Sub btn_addminus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_addminus.Click

        If (txtmain.Text.Contains("-")) Then
            txtmain.Text = txtmain.Text.Replace("-", "")

        Else
            '//add Add or Minus Symbol before the number
            txtmain.Text = "-" + txtmain.Text
        End If

    End Sub

    Private Sub btn_1_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_1_2.Click
        txtmain.Text = System.Math.Sqrt(Val(txtmain.Text))
    End Sub

    Private Sub btn_decimal_point_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_decimal_point.Click

        If (Not txtmain.Text.Contains(".")) Then 'if there is no decimal point then add
            txtmain.Text = txtmain.Text + btn_decimal_point.Text

            If (txtmain.Text.StartsWith(".")) Then 'if the text start with .xxx then it goes 0.xx
                txtmain.Text = "0."
            End If


        End If

    End Sub

    Private Sub btn_equal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_equal.Click
        second_value = Val(txtmain.Text) '/get the second value
        txtmain.Text = class_calculation.calculate(first_value, second_value, symbol)


    End Sub


    ''********************************************************************
    ''
    ''
    ''Scientific Side
    ''
    ''
    ''********************************************************************

    'Sin/Cos/Tan/Cosec/Sec/Cot  values should be in radians 
    'Note PI rad = 180 degrees so 1 rad = 180/PI
    'and 1 degrees = PI rad / 180
    'so 30 degrees = (PI /180)*30 rad 

    'the default value is in radians so you should first convert that value into degrees
    'Sin(rad) == Sin(degree)

    Private Sub btn_pi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_pi.Click
        txtmain.Text = System.Math.PI '/get the Pi value 22/7
    End Sub

    Private Sub btn_cos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cos.Click

        If (radio_rad.Checked = True) Then

            txtmain.Text = System.Math.Cos(txtmain.Text)

        ElseIf (radio_degree.Checked = True) Then
            txtmain.Text = System.Math.Cos(degree_rad(txtmain.Text))
        End If

    End Sub

    Private Sub btn_tan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_tan.Click

        If (radio_rad.Checked = True) Then

            txtmain.Text = System.Math.Tan(txtmain.Text)

        ElseIf (radio_degree.Checked = True) Then
            txtmain.Text = System.Math.Tan(degree_rad(txtmain.Text))
        End If

    End Sub

    Private Sub btn_cosec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cosec.Click

        If (radio_rad.Checked = True) Then

            txtmain.Text = Val(1 / System.Math.Sin(txtmain.Text))

        ElseIf (radio_degree.Checked = True) Then
            txtmain.Text = Val(1 / System.Math.Sin(degree_rad(txtmain.Text)))
        End If

    End Sub

    Private Sub btn_sec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sec.Click

        If (radio_rad.Checked = True) Then

            txtmain.Text = 1 / System.Math.Cos(txtmain.Text)

        ElseIf (radio_degree.Checked = True) Then
            txtmain.Text = Val(1 / System.Math.Cos(degree_rad(txtmain.Text)))
        End If

    End Sub

    Private Sub btn_cot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cot.Click

        If (radio_rad.Checked = True) Then

            txtmain.Text = Val(1 / System.Math.Tan(txtmain.Text))

        ElseIf (radio_degree.Checked = True) Then
            txtmain.Text = Val(1 / System.Math.Tan(degree_rad(txtmain.Text)))
        End If

    End Sub

    Private Sub btn_exp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_exp.Click
        txtmain.Text = System.Math.E
    End Sub

    Private Sub btn_sin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sin.Click

        If (radio_rad.Checked = True) Then

            txtmain.Text = System.Math.Sin(txtmain.Text)

        ElseIf (radio_degree.Checked = True) Then
            Console.WriteLine(rad_degree(txtmain.Text))
            txtmain.Text = System.Math.Sin(degree_rad(txtmain.Text))

        End If

    End Sub

    Private Sub btn_deg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_deg.Click
        '/converts radions to degrees
        txtmain.Text = rad_degree(txtmain.Text)

    End Sub

    Private Sub btn_rad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_rad.Click
        '/converts degrees to radions  
        '30' -> Pi/6 example
        txtmain.Text = degree_rad(txtmain.Text)

    End Sub

    Public Function degree_rad(ByVal value)
        answer_value = (System.Math.PI / 180) * Val(value)

        Return answer_value
    End Function

    Public Function rad_degree(ByVal value)
        answer_value = (180 / System.Math.PI) * Val(value)

        Return answer_value
    End Function

    Private Sub btn_e_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e_2.Click
        txtmain.Text = Val(System.Math.E ^ 2)
    End Sub
    Private Sub btn_e_x_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e_x.Click
        Dim _value As Double

        txtmain.Text = Double.TryParse(txtmain.Text, _value)
        txtmain.Text = System.Math.E ^ _value

    End Sub


    '--------------------------------------
    'Scientific Lower part
    '
    '--------------------------------------
    Dim FtoC As New SAITM_FC.SAITM_FC_BLD_Dilanga

    Private Sub btn_f_c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_f_c.Click

        'convert  farenheir to celcius
        txtmain.Text = FtoC.FtoC(txtmain.Text, "FtoC")

    End Sub
    Private Sub btn_c_f_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c_f.Click

        'convert  celcius to farenheit
        txtmain.Text = FtoC.FtoC(txtmain.Text, "CtoF")

    End Sub
    Private Sub btn_x_y_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_y.Click
        Try

            Dim _firstValue, _secondValue As Double

            _firstValue = InputBox("Type the base value to be powered", "Base Number.?", 2)
            _secondValue = InputBox("Type the power", "Power Number.?", 36)

            If IsNumeric(_firstValue) And IsNumeric(_secondValue) Then
                txtmain.Text = Val(_firstValue) ^ Val(_secondValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btn_x_2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_2.Click
        txtmain.Text = Val(txtmain.Text) ^ 2
    End Sub
    Private Sub btn_ln_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ln.Click
        txtmain.Text = System.Math.Log10(txtmain.Text)
    End Sub
    Private Sub btn_x_3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_3.Click
        txtmain.Text = Val(txtmain.Text) ^ 3
    End Sub
    Private Sub btn_log_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_log.Click
        Try

            Dim _base As Double

            _base = InputBox("type the base value of logarithem", "Base Value.?", 2)

            txtmain.Text = System.Math.Log(txtmain.Text, _base)

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    Private Sub btn_x_1_y_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_x_1_y.Click
        Try

            Dim _firstValue, _secondValue As Double

            _firstValue = InputBox("Type your root number", "Root Number.?", 2)
            _secondValue = InputBox("Type your number to be rooted", "Number.?", 36)

            If IsNumeric(_firstValue) And IsNumeric(_secondValue) Then 'check both values are numerics
                txtmain.Text = _secondValue ^ (1 / _firstValue)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    'Values
    Dim hexa_values As Double
    'A = 10 , B = 11 , C = 12 , D = 13 , E = 14 , F = 15

    Private Sub btn_d_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_d.Click
        hexa_values = 13
        txtmain.Text += "D"
    End Sub

    Private Sub btn_e_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_e.Click
        hexa_values = 14
        txtmain.Text += "E"
    End Sub

    Private Sub btn_c_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_c.Click
        hexa_values = 12
        txtmain.Text += "C"
    End Sub

    Private Sub btn_b_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_b.Click
        hexa_values = 11
        txtmain.Text += "B"
    End Sub

    Private Sub btn_a_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_a.Click
        hexa_values = 10
        txtmain.Text += "A"
    End Sub

    Private Sub btn_f_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_f.Click
        hexa_values = 15
        txtmain.Text += "F"
    End Sub

    'Change the Radio Boxes

    Private Sub btn_binary_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_binary.CheckedChanged
        If (radio_binary.Checked) Then

            'if binary selected then hide unnesseccary controls
            btn_2.Enabled = False
            btn_3.Enabled = False
            btn_4.Enabled = False
            btn_5.Enabled = False
            btn_6.Enabled = False
            btn_7.Enabled = False
            btn_8.Enabled = False
            btn_9.Enabled = False

            btn_a.Enabled = False
            btn_b.Enabled = False
            btn_c.Enabled = False
            btn_d.Enabled = False
            btn_e.Enabled = False
            btn_f.Enabled = False

            btn_add.Enabled = False
            btn_subtract.Enabled = False
            btn_multiply.Enabled = False
            btn_divide.Enabled = False
            btn_equal.Enabled = False

            btn_decimal_point.Enabled = False
            btn_addminus.Enabled = False

            grp_algebra.Enabled = False

            Try

                If (_signal = 1) Then '//Decimal to Binary
                    DecimalToBinary(2)
                End If

                If (_signal = 3) Then '//Octal to Binary (Octal ->Decimal ->Binary)
                    BinaryToDecimal(8) 'Octal ->Decimal
                    DecimalToBinary(2) 'Decimal ->Binary
                End If

                If (_signal = 4) Then '//Hexa to Binary (Hexa ->Decimal->Binary)
                    HexaToDecimal(16)
                    DecimalToBinary(2)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub btn_hexadecimal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_hexadecimal.CheckedChanged
        If (radio_hexadecimal.Checked) Then

            'if hexa selected then hide unnesseccary controls
            btn_2.Enabled = True
            btn_3.Enabled = True
            btn_4.Enabled = True
            btn_5.Enabled = True
            btn_6.Enabled = True
            btn_7.Enabled = True
            btn_8.Enabled = True
            btn_9.Enabled = True

            btn_a.Enabled = True
            btn_b.Enabled = True
            btn_c.Enabled = True
            btn_d.Enabled = True
            btn_e.Enabled = True
            btn_f.Enabled = True

            btn_add.Enabled = False
            btn_subtract.Enabled = False
            btn_multiply.Enabled = False
            btn_divide.Enabled = False
            btn_equal.Enabled = False

            btn_decimal_point.Enabled = False
            btn_addminus.Enabled = False

            grp_algebra.Enabled = False

            Try

                If (_signal = 1) Then '//Decimal to Hexa
                    DecimalToHexa(16)
                End If

                If (_signal = 2) Then '//Binary to Hexa (Binary ->Decimal->Hexa)
                    BinaryToDecimal(2)
                    DecimalToHexa(16)
                End If

                If (_signal = 3) Then '//Octal to Hexa (Octal ->Decimal->Hexa)
                    BinaryToDecimal(8)
                    DecimalToHexa(16)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub btn_octal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_octal.CheckedChanged
        If (radio_octal.Checked) Then

            'if octal selected then hide unnesseccary controls
            btn_2.Enabled = True
            btn_3.Enabled = True
            btn_4.Enabled = True
            btn_5.Enabled = True
            btn_6.Enabled = True
            btn_7.Enabled = True
            btn_8.Enabled = False
            btn_9.Enabled = False

            btn_a.Enabled = False
            btn_b.Enabled = False
            btn_c.Enabled = False
            btn_d.Enabled = False
            btn_e.Enabled = False
            btn_f.Enabled = False

            btn_add.Enabled = False
            btn_subtract.Enabled = False
            btn_multiply.Enabled = False
            btn_divide.Enabled = False
            btn_equal.Enabled = False

            btn_decimal_point.Enabled = False
            btn_addminus.Enabled = False

            grp_algebra.Enabled = False

            Try

                If (_signal = 1) Then '//Decimal to Octal
                    DecimalToBinary(8)
                End If

                If (_signal = 2) Then '//Binary to Octal (Binary -> Decimal ->Octal)
                    BinaryToDecimal(2) 'Binary -> Decimal
                    DecimalToBinary(8) 'Decimal ->Octal
                End If

                If (_signal = 4) Then '//Hexa to Octal (Hexa ->Decimal ->Octal)
                    HexaToDecimal(16)
                    DecimalToBinary(8)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

        End If
    End Sub

    Private Sub btn_decimal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radio_decimal.CheckedChanged
        If (radio_decimal.Checked) Then

            'if octal selected then hide unnesseccary controls
            btn_2.Enabled = True
            btn_3.Enabled = True
            btn_4.Enabled = True
            btn_5.Enabled = True
            btn_6.Enabled = True
            btn_7.Enabled = True
            btn_8.Enabled = True
            btn_9.Enabled = True

            btn_a.Enabled = False
            btn_b.Enabled = False
            btn_c.Enabled = False
            btn_d.Enabled = False
            btn_e.Enabled = False
            btn_f.Enabled = False

            btn_add.Enabled = True
            btn_subtract.Enabled = True
            btn_multiply.Enabled = True
            btn_divide.Enabled = True
            btn_equal.Enabled = True

            btn_decimal_point.Enabled = True
            btn_addminus.Enabled = True

            grp_algebra.Enabled = True

            Try

                '//convert Signal TO Decimal 

                If (_signal = 1) Then '//Decimal to Decimal
                    '//Same nothing happened.!

                ElseIf (_signal = 2) Then '//Binary to Decimal
                    BinaryToDecimal(2)

                ElseIf (_signal = 3) Then '//Octal to Decimal
                    BinaryToDecimal(8)

                ElseIf (_signal = 4) Then '//Hexa to Decimal
                    HexaToDecimal(16)
                End If

            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            End If
    End Sub

    
    Public Sub DecimalToBinary(ByVal base As String)

        Dim _mainValue, _remainder, _base, final_answer As String

        _mainValue = txtmain.Text ' get the main value
        _base = base 'get the base value 
        _remainder = 0  'get the remainder

        'let the number divide from 2

        Do
            _remainder = _mainValue Mod _base
            _mainValue = Int(_mainValue / _base)

            final_answer += _remainder

        Loop Until _mainValue = 0

        txtmain.Text = StrReverse(final_answer)

    End Sub

    Public Sub BinaryToDecimal(ByVal base As String)

        Dim _mainValue, _tempValue, _base, length_of_values As String
        Dim final_answer As Double
        Dim i As Integer = 0

        _mainValue = txtmain.Text '//get the main value
        _base = base '//get the base
        length_of_values = txtmain.TextLength

        _mainValue = StrReverse(_mainValue) '// 111000 - > 000111

        Do
            _tempValue = _mainValue.Substring(i, 1) '//get the each number

            final_answer += (_tempValue * (_base ^ i))

            i += 1

            Console.WriteLine(txtmain.TextLength)

        Loop Until i = txtmain.TextLength

        txtmain.Text = final_answer

    End Sub


    Public Sub HexaToDecimal(ByVal Base As String)

        Dim _base, _originalValue, _tempValue As String
        Dim _finalAnswer As Double
        Dim i As Integer = 0

        _base = Base '//Get the Base (Obviously 16! )
        _originalValue = txtmain.Text '//get the Original Value

        _originalValue = StrReverse(_originalValue) '//Reverse 1DA - > AD1

        Do
            _tempValue = _originalValue.Substring(i, 1) '//Get values one by one for converting

            '//check if that value is A,B,C,D,E,F

            If (_tempValue = "A") Then
                _tempValue = 10

            ElseIf (_tempValue = "B") Then
                _tempValue = 11

            ElseIf (_tempValue = "C") Then
                _tempValue = 12

            ElseIf (_tempValue = "D") Then
                _tempValue = 13

            ElseIf (_tempValue = "E") Then
                _tempValue = 14

            ElseIf (_tempValue = "F") Then
                _tempValue = 15
            End If

            _finalAnswer += _tempValue * (_base ^ i) '//calculate base power then multiply with the value
            i += 1 ' //increase the i so can be incresed also the power


        Loop Until i = txtmain.TextLength

        txtmain.Text = _finalAnswer '//get the final answer

    End Sub

    Public Sub DecimalToHexa(ByVal Base As String)

        Dim _finalAnswer, _base, _originalValue, _tempValue, _remainder As String

        _base = Base '//get the base
        _originalValue = txtmain.Text '//get the original value

        Do
            _remainder = _originalValue Mod _base '//get the remainder
            _originalValue = Int(_originalValue / _base) '//get the next value of original

            If (_remainder = 10) Then
                _remainder = "A"
            ElseIf (_remainder = 11) Then
                _remainder = "B"

            ElseIf (_remainder = 12) Then
                _remainder = "C"

            ElseIf (_remainder = 13) Then
                _remainder = "D"

            ElseIf (_remainder = 14) Then
                _remainder = "E"

            ElseIf (_remainder = 15) Then
                _remainder = "F"
            End If

            _finalAnswer += _remainder '//add to the final answer

        Loop Until _originalValue = 0

        txtmain.Text = StrReverse(_finalAnswer) '//reverse and get the answer

    End Sub

    '--------------------------------------------------------
    'Special Contrls
    '
    '--------------------------------------------------------



    Dim _signal As Integer

    Private Sub txtmain_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtmain.TextChanged
        '//recognized which radio button was selected and release a signal accroding to that
        '//then radio button will convert that according to the signal
        '//Decimal = 1 , Binary = 2 , Octal = 3, Hexa 4

        If (radio_decimal.Checked) Then
            _signal = 1
        End If

        If (radio_binary.Checked) Then
            _signal = 2
        End If

        If (radio_octal.Checked) Then
            _signal = 3
        End If

        If (radio_hexadecimal.Checked) Then
            _signal = 4
        End If

        Console.WriteLine("Radio Signal Number : " + _signal.ToString())

    End Sub

    ''------------------------------------
    ''
    ''CONTEXT MENU STRIP
    ''
    ''
    ''------------------------------------


    Private Sub cms_close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cms_close.Click
        Application.Exit()
    End Sub

    Private Sub cms_about_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cms_about.Click
        show_about()
    End Sub


    '***********************************************************
    '
    'Unit Converting
    '
    '***********************************************************
    Dim unit_conversion As New SAITM_Conversion.UnitConversion

    'Case "IntoCm"
    'Case "CmtoIn"
    'Case "MstoKmh"
    'Case "KmhtoMs"
    'Case "mmHgtoPa"
    'Case "PatommHg"
    'Case "HptoW"
    'Case "WtoHp"

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmb_box_unit.SelectedIndexChanged

        Console.WriteLine(cmb_box_unit.SelectedIndex) '//0 Based

        If (cmb_box_unit.SelectedIndex = 0) Then '//KmhtoMs
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "KmhtoMs"))
        ElseIf (cmb_box_unit.SelectedIndex = 1) Then '//MstoKmh
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "MstoKmh"))
        ElseIf (cmb_box_unit.SelectedIndex = 2) Then '//mmHgtoPa
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "mmHgtoPa"))
        ElseIf (cmb_box_unit.SelectedIndex = 3) Then '//PatommHg
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "PatommHg"))
        ElseIf (cmb_box_unit.SelectedIndex = 4) Then '//HptoW
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "HptoW"))
        ElseIf (cmb_box_unit.SelectedIndex = 5) Then '//WtoHp
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "WtoHp"))
        ElseIf (cmb_box_unit.SelectedIndex = 6) Then '//IntoCm
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "IntoCm"))
        ElseIf (cmb_box_unit.SelectedIndex = 7) Then '//CmtoIn
            txtmain.Text = Val(unit_conversion.conversion(txtmain.Text, "CmtoIn"))
        End If

    End Sub

    '**********************************************************
    '
    'Basic Algebra Calculation
    '
    ''**********************************************************
    '//nCr = "nCr"
    '//n∑r = "nSigmar" (n start value , r the destination value)
    '//n∑1 = "nSigma1"
    '//n! = "n!"

    Dim algebra As New SAITM_Algebra.Algebra

    Private Sub btn_n_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_n.Click
        txtmain.Text = CDec(algebra.Factorial(txtmain.Text, ""))
    End Sub

    Private Sub btn_sigma_nr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sigma_nr.Click
        Try
            If txtmain.Text = "" Then
                Exit Sub
            End If

            second_value = InputBox("Type the destination (r) value of n∑r ", "n∑r Calculation", 1)

            If (IsNumeric(first_value)) Then
                If (txtmain.Text.Contains(".")) Then
                    Dim temp_ As Decimal
                    temp_ = txtmain.Text
                    txtmain.Text = CInt(txtmain.Text)

                End If
                txtmain.Text = (algebra.Sigma((txtmain.Text), (second_value), "nSigmar"))
            Else
                MsgBox("The second value need to be typed to proceed", MsgBoxStyle.Exclamation)
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_sigma_n1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_sigma_n1.Click
        Try
            txtmain.Text = CInt(txtmain.Text)

            If txtmain.Text = "" Then
                Exit Sub
            End If

            If (txtmain.Text.Contains(".")) Then
                Dim temp_ As Decimal
                temp_ = txtmain.Text
                txtmain.Text = CInt(txtmain.Text)

            End If

            txtmain.Text = (algebra.Sigma((txtmain.Text), 1, "nSigma1"))

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btn_ncr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ncr.Click
        Try

            first_value = InputBox("Type the value of n of nCr", "nCr Calculation", 1)
            second_value = InputBox("Type the value of r of nCr", "nCr Calculation", 1)

            If (Not IsNumeric(first_value)) Or (Not IsNumeric(second_value)) Then '//if one of them is non numeric
                MessageBox.Show("You need to type a numerical integer value to proceed")
            Else
                txtmain.Text = algebra.Sigma(first_value, second_value, "nCr")
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

End Class
