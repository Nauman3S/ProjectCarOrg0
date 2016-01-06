Public Class Mapper
    Dim x1, x2, y1, y2, yTemp, xTemp As Integer
    Dim p As Point

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles upb.Click
        ' ControllerTimer.Enabled = False
        rightTimer.Enabled = False
        leftTimer.Enabled = False
        Timer2.Enabled = False
        x1 = x2
        downTimer.Enabled = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles leftb.Click
        'yTemp = y2
        Timer2.Enabled = False
        rightTimer.Enabled = False
        downTimer.Enabled = False
        'bolValRight = False
        y1 = y2
        leftTimer.Enabled = True
        '    ControllerTimer.Enabled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles rightb.Click
        'yTemp = y2
        Timer2.Enabled = False
        leftTimer.Enabled = False
        downTimer.Enabled = False
        'bolValRight = False
        y1 = y2
        rightTimer.Enabled = True
        '    ControllerTimer.Enabled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles downb.Click
        'ControllerTimer.Enabled = False
        rightTimer.Enabled = False
        leftTimer.Enabled = False
        downTimer.Enabled = False
        x1 = x2
        Timer2.Enabled = True
        'bolValUp = False
        'rightTimer.Enabled = False
        'bolValRight = True
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles stopb.Click
        'bolValUp = True
        'bolValRight = True
        rightTimer.Enabled = False
        Timer2.Enabled = False
        leftTimer.Enabled = False
        downTimer.Enabled = False
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen


        '        myGraphics.Clear(PictureBox1.BackColor)

        myPen = New Pen(Drawing.Color.BurlyWood, 6)


        myGraphics.DrawLine(myPen, x1, y1, x1, y2)
        '  Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, 400, 0, 400, x2)
        If y2 > PictureBox1.Height Then
            PictureBox1.Height += 10
            ' Using c As New Control() With {.Parent = Panel1, .Dock = DockStyle.Bottom, .Top = Panel1.Height + 10}
            'Panel1.ScrollControlIntoView(c)
            '   Panel1.HorizontalScroll.Enabled = False
            'c.Parent = Nothing
            'End Using

        End If


        'if false then stop there but redraw again and again  'i.e make it refresh at timer2's interval
        Try
            'Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Value + 12 'change to 12     
        Catch ex As Exception

        End Try

        y2 = y2 + 5 '10 ' where x is an integer intialize to zero at form starts



    End Sub
    Private Sub leftTimer_Tick(sender As Object, e As EventArgs) Handles leftTimer.Tick
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen

        myPen = New Pen(Drawing.Color.BurlyWood, 6)

        myGraphics.DrawLine(myPen, x1, y1, x2, y1)
        '  Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, 400, 0, 400, x2)
        If y2 > PictureBox1.Width Then
            PictureBox1.Width += 10

        End If




        Try
            'Panel1.HorizontalScroll.Value = Panel1.HorizontalScroll.Value - 12
        Catch ex As Exception

        End Try      '        If bolValRight = False Then      'if false then stop there but redraw again and again  'i.e make it refresh at timer2's interval
        'change to 12     
        x2 = x2 - 5 '10 ' where x is an integer intialize to zero at form starts


    End Sub
    Private Sub rightTimer_Tick(sender As Object, e As EventArgs) Handles rightTimer.Tick
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen

        myPen = New Pen(Drawing.Color.BurlyWood, 6)

        myGraphics.DrawLine(myPen, x1, y1, x2, y1)
        '  Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, 400, 0, 400, x2)
        If y2 > PictureBox1.Width Then
            PictureBox1.Width += 10

        End If



        Try
            '   Panel1.HorizontalScroll.Value = Panel1.HorizontalScroll.Value + 12 'change to 12     

        Catch ex As Exception

        End Try 'if false then stop there but redraw again and again  'i.e make it refresh at timer2's interval
        x2 = x2 + 5 '10 ' where x is an integer intialize to zero at form starts



    End Sub
    Private Sub downTimer_Tick(sender As Object, e As EventArgs) Handles downTimer.Tick
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen


        '        myGraphics.Clear(PictureBox1.BackColor)

        myPen = New Pen(Drawing.Color.BurlyWood, 6)


        myGraphics.DrawLine(myPen, x1, y1, x1, y2)
        '  Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, 400, 0, 400, x2)
        If y2 > PictureBox1.Height Then
            PictureBox1.Height += 10
            ' Using c As New Control() With {.Parent = Panel1, .Dock = DockStyle.Bottom, .Top = Panel1.Height + 10}
            'Panel1.ScrollControlIntoView(c)
            '   Panel1.HorizontalScroll.Enabled = False
            'c.Parent = Nothing
            'End Using

        End If


        'if false then stop there but redraw again and again  'i.e make it refresh at timer2's interval
        Try
            Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Value - 12 'change to 12     
        Catch ex As Exception

        End Try

        y2 = y2 - 5 '10 ' where x is an integer intialize to zero at form starts

    End Sub
    Private Sub Mapper_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = New Bitmap(Width, Height)

        'x = PictureBox1.Height
        'PictureBox2.Parent = PictureBox1
        Panel1.AutoScroll = True
        Panel1.SetAutoScrollMargin(5000, 5000)
        'Panel1.ScrollControlIntoView(VScrollBar1)
        x1 = 400
        x2 = 400
        y1 = 0
        y2 = 0
        yTemp = 0
        xTemp = 0
        Using c As New Control() With {.Parent = Panel1, .Dock = DockStyle.Bottom, .Top = Panel1.Height + 10}
            Panel1.ScrollControlIntoView(c)
            Panel1.HorizontalScroll.Enabled = True
            c.Parent = Nothing
        End Using
    End Sub
End Class