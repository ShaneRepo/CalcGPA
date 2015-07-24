Option Strict On
Public Class MainForm

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' No default value , at least thats what I'm aiming for when form loads. ( PROBLEM SOLVED ) I had to make sure tab order did not have radio buttons = 0 'zero'
        radFemale.Checked = False
        radMale.Checked = False
        ' Fill list box with values on form load
        For decGPA As Decimal = 1D To 4D Step 0.1D
            lstGPA.Items.Add(decGPA.ToString("N2"))
        Next decGPA


    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        ' Closing the application
        Me.Close()

    End Sub

    Private Sub btnCalc_Click(sender As Object, e As EventArgs) Handles btnCalc.Click
        ' Calculate the ave GPA for all students
        Static decGpaAll As Decimal
        Static decGpaMale As Decimal
        Static decGpaFemale As Decimal
        Static decGpaTotal As Decimal
        Static decGpaTotalMale As Decimal
        Static decGpaTotalFemale As Decimal
        Static intCountAll As Integer
        Static intCountMale As Integer
        Static intCountFemale As Integer
        Static realGPA As Decimal
        Decimal.TryParse(lstGPA.SelectedItem.ToString, decGpaAll)
        Decimal.TryParse(lstGPA.SelectedItem.ToString, decGpaMale)
        Decimal.TryParse(lstGPA.SelectedItem.ToString, decGpaFemale)

      
        ' Gpa calc for all students
        decGpaAll = CDec(lstGPA.SelectedItem)
        decGpaTotal = decGpaTotal + decGpaAll
        intCountAll = intCountAll + 1
        lblAllOut.Text = CStr(decGpaTotal / intCountAll)
        ' Gpa for females
        If radFemale.Checked = True Then
            decGpaFemale = CDec(lstGPA.SelectedItem)
            decGpaTotalFemale = decGpaTotalFemale + decGpaFemale
            intCountFemale = intCountFemale + 1
            realGPA = CDec(CStr(decGpaTotalFemale / intCountFemale))
            lblFemaleOut.Text = CStr(realGPA)
            ' Gpa for males
        ElseIf radMale.Checked = True Then
            decGpaMale = CDec(lstGPA.SelectedItem)
            decGpaTotalMale = decGpaTotalMale + decGpaMale
            intCountMale = intCountMale + 1
            lblMaleOut.Text = CStr(decGpaTotalMale / intCountMale)
        End If


    End Sub

    Private Sub lstGPA_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstGPA.SelectedValueChanged
        ' Clear the output
        'lblAllOut.Text = String.Empty
        'lblFemaleOut.Text = String.Empty
        'lblMaleOut.Text = String.Empty
    End Sub
End Class
