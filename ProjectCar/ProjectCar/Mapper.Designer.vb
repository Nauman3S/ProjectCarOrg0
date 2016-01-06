<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Mapper
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.leftTimer = New System.Windows.Forms.Timer(Me.components)
        Me.rightTimer = New System.Windows.Forms.Timer(Me.components)
        Me.downTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.upb = New System.Windows.Forms.Button()
        Me.downb = New System.Windows.Forms.Button()
        Me.leftb = New System.Windows.Forms.Button()
        Me.rightb = New System.Windows.Forms.Button()
        Me.stopb = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 630)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(690, 22)
        Me.StatusStrip1.TabIndex = 1
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'Timer2
        '
        '
        'leftTimer
        '
        '
        'rightTimer
        '
        '
        'downTimer
        '
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.stopb)
        Me.Panel1.Controls.Add(Me.rightb)
        Me.Panel1.Controls.Add(Me.leftb)
        Me.Panel1.Controls.Add(Me.downb)
        Me.Panel1.Controls.Add(Me.upb)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(690, 630)
        Me.Panel1.TabIndex = 2
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(690, 630)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'upb
        '
        Me.upb.Location = New System.Drawing.Point(550, 115)
        Me.upb.Name = "upb"
        Me.upb.Size = New System.Drawing.Size(75, 23)
        Me.upb.TabIndex = 3
        Me.upb.Text = "^"
        Me.upb.UseVisualStyleBackColor = True
        '
        'downb
        '
        Me.downb.Location = New System.Drawing.Point(550, 198)
        Me.downb.Name = "downb"
        Me.downb.Size = New System.Drawing.Size(75, 23)
        Me.downb.TabIndex = 4
        Me.downb.Text = "v"
        Me.downb.UseVisualStyleBackColor = True
        '
        'leftb
        '
        Me.leftb.Location = New System.Drawing.Point(468, 158)
        Me.leftb.Name = "leftb"
        Me.leftb.Size = New System.Drawing.Size(75, 23)
        Me.leftb.TabIndex = 5
        Me.leftb.Text = "<"
        Me.leftb.UseVisualStyleBackColor = True
        '
        'rightb
        '
        Me.rightb.Location = New System.Drawing.Point(607, 158)
        Me.rightb.Name = "rightb"
        Me.rightb.Size = New System.Drawing.Size(75, 23)
        Me.rightb.TabIndex = 6
        Me.rightb.Text = ">"
        Me.rightb.UseVisualStyleBackColor = True
        '
        'stopb
        '
        Me.stopb.Location = New System.Drawing.Point(546, 158)
        Me.stopb.Name = "stopb"
        Me.stopb.Size = New System.Drawing.Size(58, 23)
        Me.stopb.TabIndex = 7
        Me.stopb.Text = "X"
        Me.stopb.UseVisualStyleBackColor = True
        '
        'Mapper
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 652)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Location = New System.Drawing.Point(664, 0)
        Me.Name = "Mapper"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Mapper"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents Timer2 As Timer
    Friend WithEvents leftTimer As Timer
    Friend WithEvents rightTimer As Timer
    Friend WithEvents downTimer As Timer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents rightb As Button
    Friend WithEvents leftb As Button
    Friend WithEvents downb As Button
    Friend WithEvents upb As Button
    Friend WithEvents stopb As Button
End Class
