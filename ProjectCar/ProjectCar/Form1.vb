Imports System.Speech.Recognition
Imports System.Threading
Imports System.Globalization
Imports System.Drawing
Imports System.IO.Ports


Public Class Form1
    ' recogniser & grammar
    Dim x1, x2, y1, y2, yTemp, xTemp As Integer
    Dim p As Point
    Dim recog As New SpeechRecognizer
    Dim gram As Grammar
    ' events
    Public Event SpeechRecognized As _
        EventHandler(Of SpeechRecognizedEventArgs)
    Public Event SpeechRecognitionRejected As _
        EventHandler(Of SpeechRecognitionRejectedEventArgs)
    ' word list
    Dim wordlist As String() = New String() {"Left", "Right", "Up", "Down", "Stop"}


    Public Sub recevent(ByVal sender As System.Object,
                ByVal e As RecognitionEventArgs)
        left.ForeColor = Color.LightGray
        right.ForeColor = Color.LightGray
        up.ForeColor = Color.LightGray
        down.ForeColor = Color.LightGray

        If (e.Result.Text = "Left") Then
            left.ForeColor = Color.Blue
            ' SendValue(4)
            'leftp.Image = My.Resources.LeftG
            'rightp.Image = My.Resources.Right
            'upp.Image = My.Resources.Up
            'downp.Image = My.Resources.Down
            TextBox1.Text = 4
            Button2.PerformClick()
        ElseIf (e.Result.Text = "Right") Then
            right.ForeColor = Color.Blue
            '    SendValue(3)
            '   rightp.Image = My.Resources.RightG
            '  leftp.Image = My.Resources.Left
            ' upp.Image = My.Resources.Up
            'downp.Image = My.Resources.Down
            TextBox1.Text = 3
            Button2.PerformClick()
        ElseIf (e.Result.Text = "Stop") Then
            right.ForeColor = Color.Blue
            ' SendValue(0)
            'rightp.Image = My.Resources.RightG
            TextBox1.Text = 0
            Button2.PerformClick()
        ElseIf (e.Result.Text = "Up") Then
            up.ForeColor = Color.Blue
            ' SendValue(1)
            'upp.Image = My.Resources.UpG
            'rightp.Image = My.Resources.Right
            'leftp.Image = My.Resources.Left
            'downp.Image = My.Resources.Down
            TextBox1.Text = 1
            Button2.PerformClick()
        ElseIf (e.Result.Text = "Down") Then
            down.ForeColor = Color.Blue
            ' SendValue(2)
            'downp.Image = My.Resources.DownG
            'rightp.Image = My.Resources.Right
            'upp.Image = My.Resources.Up
            'leftp.Image = My.Resources.Left
            TextBox1.Text = 2
            Button2.PerformClick()
        End If
    End Sub
    Public Sub recfailevent(ByVal sender As System.Object,
               ByVal e As RecognitionEventArgs)
        up.ForeColor = Color.LightGray
        down.ForeColor = Color.LightGray
        left.ForeColor = Color.LightGray
        right.ForeColor = Color.LightGray
    End Sub
    ' form initialisation
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Top = 0
        onLoadDrawer()

        ' need these to get British English rather than default US
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-GB")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-GB")
        ' convert the word list into a grammar
        Dim words As New Choices(wordlist)
        gram = New Grammar(New GrammarBuilder(words))
        recog.LoadGrammar(gram)

        ' add handlers for the recognition events
        AddHandler recog.SpeechRecognized, AddressOf Me.recevent
        AddHandler recog.SpeechRecognitionRejected, AddressOf Me.recfailevent
        ' enable the recogniser
        recog.Enabled = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        OpenPortC()
        Button1.Enabled = False
        Button3.Enabled = True
        Button2.Enabled = True
        TextBox1.Enabled = True

    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        SerialPort1.Close()

        Button1.Enabled = True
        Button3.Enabled = False
        Button2.Enabled = False
        TextBox1.Enabled = False

    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.Open()
        SerialPort1.Write(TextBox1.Text)
        If TextBox1.Text = 3 Then
            rightLine()
            Thread.Sleep(250)

            SerialPort1.Write(1)
            upLine()
            rightp.Image = My.Resources.RightG
            leftp.Image = My.Resources.Left
            upp.Image = My.Resources.Up
            downp.Image = My.Resources.Down

        End If
        If TextBox1.Text = 4 Then
            leftLine()
            Thread.Sleep(250)
            SerialPort1.Write(1)
            upLine()
            leftp.Image = My.Resources.LeftG
            rightp.Image = My.Resources.Right
            upp.Image = My.Resources.Up
            downp.Image = My.Resources.Down
        End If
        If TextBox1.Text = 1 Then
            upLine()
            upp.Image = My.Resources.UpG
            rightp.Image = My.Resources.Right
            leftp.Image = My.Resources.Left
            downp.Image = My.Resources.Down
        End If
        If TextBox1.Text = 2 Then
            downLine()
            downp.Image = My.Resources.DownG
            rightp.Image = My.Resources.Right
            upp.Image = My.Resources.Up
            leftp.Image = My.Resources.Left
        End If
        If TextBox1.Text = 0 Then
            stopLine()
            downp.Image = My.Resources.Down
            rightp.Image = My.Resources.Right
            upp.Image = My.Resources.Up
            leftp.Image = My.Resources.Left
        End If
        SerialPort1.Close()
    End Sub


    Public Sub DrawLinesPoint(ByVal e As PaintEventArgs)

        ' Create pen.
        Dim blackPen As New Pen(Color.Black, 3)

        ' Create array of points that define lines to draw.
        Dim points As Point() = {New Point(10, 10), New Point(10, 100),
        New Point(200, 50), New Point(250, 300)}

        'Draw lines to screen.
        e.Graphics.DrawLines(blackPen, points)
    End Sub



    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SendValue(0)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        SendValue(0)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If My.Computer.Keyboard.NumLock = True Then
            Try
                SerialPort1.Write(0)
            Catch ex As Exception

            End Try



        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        End
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
        PictureBox2.Top = y2 + 10
        PictureBox2.Left = x2
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
        PictureBox2.Top = y2
        PictureBox2.Left = x2 + 10

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

        PictureBox2.Top = y2
        PictureBox2.Left = x2 - 10

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
        PictureBox2.Top = y2 - 10
        PictureBox2.Left = x2
    End Sub
    Sub onLoadDrawer()
        PictureBox1.Image = New Bitmap(Width, Height)

        'x = PictureBox1.Height
        'PictureBox2.Parent = PictureBox1
        Panel1.AutoScroll = True
        Panel1.SetAutoScrollMargin(5000, 5000)
        'Panel1.ScrollControlIntoView(VScrollBar1)
        x1 = 10
        x2 = 10
        y1 = 90
        y2 = 90
        yTemp = 0
        xTemp = 0
        Using c As New Control() With {.Parent = Panel1, .Dock = DockStyle.Bottom, .Top = Panel1.Height + 10}
            Panel1.ScrollControlIntoView(c)
            Panel1.HorizontalScroll.Enabled = True
            c.Parent = Nothing
        End Using
        Panel1.VerticalScroll.Value = 0
        Panel1.HorizontalScroll.Value = 0
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)
        MsgBox("asdsadasd")
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs)
        'Button8.PerformClick()
    End Sub

    Private Sub Button8_Click_1(sender As Object, e As EventArgs)
        MsgBox("dsadsd")
    End Sub

    Private Sub Button7_Click_1(sender As Object, e As EventArgs)
        'Button8.PerformClick()
    End Sub

    Private Sub Button7_Click_2(sender As Object, e As EventArgs) Handles Button7.Click
        downLine()






    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs) Handles Button8.Click
        upLine()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        rightLine()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        downLine()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        leftLine()
    End Sub

    Sub upLine()
        ' ControllerTimer.Enabled = False
        rightTimer.Enabled = False
        leftTimer.Enabled = False
        Timer2.Enabled = False
        x1 = x2
        downTimer.Enabled = True
    End Sub

    Sub leftLine()
        'yTemp = y2
        Timer2.Enabled = False
        rightTimer.Enabled = False
        downTimer.Enabled = False
        'bolValRight = False
        y1 = y2
        leftTimer.Enabled = True
        '    ControllerTimer.Enabled = True
    End Sub

    Sub rightLine()
        'yTemp = y2
        Timer2.Enabled = False
        leftTimer.Enabled = False
        downTimer.Enabled = False
        'bolValRight = False
        y1 = y2
        rightTimer.Enabled = True
        '    ControllerTimer.Enabled = True
    End Sub

    Sub downLine()
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

    Sub stopLine()
        'bolValUp = True
        'bolValRight = True
        rightTimer.Enabled = False
        Timer2.Enabled = False
        leftTimer.Enabled = False
        downTimer.Enabled = False
    End Sub



End Class
