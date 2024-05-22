<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        TextBox1 = New TextBox()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(12, 12)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(572, 687)
        Panel1.TabIndex = 0
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.White
        TextBox1.ForeColor = Color.Red
        TextBox1.Location = New Point(603, 299)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(58, 27)
        TextBox1.TabIndex = 1
        TextBox1.Text = "Red"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(694, 711)
        Controls.Add(TextBox1)
        Controls.Add(Panel1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox1 As TextBox

End Class
