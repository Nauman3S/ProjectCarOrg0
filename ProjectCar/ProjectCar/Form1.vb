Imports System.Speech.Recognition
Imports System.Threading
Imports System.Globalization
Imports System.Drawing
Imports System.IO.Ports


Public Class Form1
    ' recogniser & grammar
    Dim x1, x2, y1, y2, yTemp, xTemp As Integer
    Dim p As Point
    Dim recog As New SpeechRecognitionEngine
    Dim gram As Grammar
    ' events
    Public Event SpeechRecognized As _
        EventHandler(Of SpeechRecognizedEventArgs)
    Public Event SpeechRecognitionRejected As _
        EventHandler(Of SpeechRecognitionRejectedEventArgs)
    ' word list
    Dim wordlist As String() = New String() {"Left", "Right", "Up", "Down", "Stop"}
    'autonomous algo-variables
    Dim counterVals As Integer

    Dim upTime, downTime, leftTime, rightTime As Integer

    Public Sub recevent(ByVal sender As System.Object,
                ByVal e As RecognitionEventArgs)
        left.ForeColor = Color.LightGray
        right.ForeColor = Color.LightGray
        up.ForeColor = Color.LightGray
        down.ForeColor = Color.LightGray
        Me.Text = e.Result.Text
        If (e.Result.Text = "Left") Then
            left.ForeColor = Color.Blue
            ' SendValue(4)
            'leftp.Image = My.Resources.LeftG
            'rightp.Image = My.Resources.Right
            'upp.Image = My.Resources.Up
            'downp.Image = My.Resources.Down
            TextBox1.Text = 4
            '    Button2.PerformClick()
        ElseIf (e.Result.Text = "Right") Then
            right.ForeColor = Color.Blue
            '    SendValue(3)
            '   rightp.Image = My.Resources.RightG
            '  leftp.Image = My.Resources.Left
            ' upp.Image = My.Resources.Up
            'downp.Image = My.Resources.Down
            TextBox1.Text = 3
            '   Button2.PerformClick()
        ElseIf (e.Result.Text = "Stop") Then
            right.ForeColor = Color.Blue
            ' SendValue(0)
            'rightp.Image = My.Resources.RightG
            TextBox1.Text = 0
            '  Button2.PerformClick()
        ElseIf (e.Result.Text = "Up") Then
            up.ForeColor = Color.Blue
            ' SendValue(1)
            'upp.Image = My.Resources.UpG
            'rightp.Image = My.Resources.Right
            'leftp.Image = My.Resources.Left
            'downp.Image = My.Resources.Down
            TextBox1.Text = 1
            ' Button2.PerformClick()
        ElseIf (e.Result.Text = "Down") Then
            down.ForeColor = Color.Blue
            ' SendValue(2)
            'downp.Image = My.Resources.DownG
            'rightp.Image = My.Resources.Right
            'upp.Image = My.Resources.Up
            'leftp.Image = My.Resources.Left
            TextBox1.Text = 2
            'Button2.PerformClick()
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
        PictureBox2.BackColor = Color.Transparent

        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, False)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Dim aProp As Reflection.PropertyInfo = GetType(Panel).GetProperty("DoubleBuffered", Reflection.BindingFlags.NonPublic Or Reflection.BindingFlags.Instance)
        aProp.SetValue(Panel1, True, Nothing)

        Me.Top = 0
        upTime = 0
        leftTime = 0
        rightTime = 0
        downTime = 0
        onLoadDrawer()
        PictureBox1.Height = Panel1.Height
        PictureBox1.Width = Panel1.Width
        ' need these to get British English rather than default US
        Thread.CurrentThread.CurrentCulture = New CultureInfo("en-GB")
        Thread.CurrentThread.CurrentUICulture = New CultureInfo("en-GB")
        ' convert the word list into a grammar
        Dim words As New Choices(wordlist)
        gram = New Grammar(New GrammarBuilder(words))
        recog.SetInputToDefaultAudioDevice()
        recog.LoadGrammar(gram)
        'gram.Weight = 1.0
        ' add handlers for the recognition events
        AddHandler recog.SpeechRecognized, AddressOf Me.recevent
        AddHandler recog.SpeechRecognitionRejected, AddressOf Me.recfailevent
        ' enable the recogniser
        'recog.Enabled = True



        '        gram.Priority = 127

        'recog.Recognize()
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
        counterPlayer.Enabled = False
        counterRecorder.Enabled = True 'check for change in positions and record them
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
        stopLine()

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
        counterVals = 1
        Using myPen As New Pen(Drawing.Color.BurlyWood, 6)
            PictureBox1.Refresh()

            ' PictureBox1.CreateGraphics().DrawLine(myPen, x1, y1, x1, y2)
        End Using
        Me.Text = "hei" & PictureBox1.Height & "wid" & PictureBox1.Width
        ' Picturebox1.Height += 100

        Try

            '   Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Value + 3 'change to 12     


        Catch ex As Exception

        End Try
        y2 = y2 + 5 '10 ' where x is an integer intialize to zero at form starts
        PictureBox2.Top = y2 + 3
        PictureBox2.Left = x2
    End Sub
    Sub timer2temp()
        counterVals = 1


        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen


        '        myGraphics.Clear(Picturebox1.BackColor)

        myPen = New Pen(Drawing.Color.BurlyWood, 6)


        myGraphics.DrawLine(myPen, x1, y1, x1, y2)
        '  Graphics.FromImage(Picturebox1.image).DrawLine(myPen, 400, 0, 400, x2)
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
        PictureBox2.Top = y2 + 20
        PictureBox2.Left = x2
    End Sub
    Private Sub leftTimer_Tick(sender As Object, e As EventArgs) Handles leftTimer.Tick
        counterVals = 3
        Using myPen As New Pen(Drawing.Color.BurlyWood, 6)
            PictureBox1.Refresh()
            '    Picturebox1.CreateGraphics().DrawLine(myPen, x1, y1, x2, y1)
        End Using
        Try
            ' Panel1.HorizontalScroll.Value = Panel1.HorizontalScroll.Value - 3
        Catch ex As Exception

        End Try      '
        x2 = x2 - 5 '10 ' where x is an integer intialize to zero at form starts
        PictureBox2.Top = y2
        PictureBox2.Left = x2 + 3
    End Sub
    Sub lefttimertemp()
        counterVals = 3
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen

        myPen = New Pen(Drawing.Color.BurlyWood, 6)

        myGraphics.DrawLine(myPen, x1, y1, x2, y1)
        '  Graphics.FromImage(Picturebox1.image).DrawLine(myPen, 400, 0, 400, x2)
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
        PictureBox2.Left = x2 + 20

    End Sub
    Private Sub rightTimer_Tick(sender As Object, e As EventArgs) Handles rightTimer.Tick
        counterVals = 4
        Using myPen As New Pen(Drawing.Color.BurlyWood, 6)
            PictureBox1.Refresh()
            ' Picturebox1.CreateGraphics().DrawLine(myPen, x1, y1, x2, y1)
        End Using
        Try
            ' Panel1.HorizontalScroll.Value = Panel1.HorizontalScroll.Value + 3
        Catch ex As Exception

        End Try      '
        x2 = x2 + 5 '10 ' where x is an integer intialize to zero at form starts

        PictureBox2.Top = y2
        PictureBox2.Left = x2 - 3

    End Sub
    Sub rightTimertemp()
        counterVals = 4
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen

        myPen = New Pen(Drawing.Color.BurlyWood, 6)

        myGraphics.DrawLine(myPen, x1, y1, x2, y1)
        '  Graphics.FromImage(Picturebox1.image).DrawLine(myPen, 400, 0, 400, x2)
        If y2 > PictureBox1.Width Then
            PictureBox1.Width += 10

        End If



        Try
            '   Panel1.HorizontalScroll.Value = Panel1.HorizontalScroll.Value + 12 'change to 12     

        Catch ex As Exception

        End Try 'if false then stop there but redraw again and again  'i.e make it refresh at timer2's interval
        x2 = x2 + 5 '10 ' where x is an integer intialize to zero at form starts

        PictureBox2.Top = y2
        PictureBox2.Left = x2 - 20

    End Sub

    Private Sub downTimer_Tick(sender As Object, e As EventArgs) Handles downTimer.Tick
        counterVals = 2
        Using myPen As New Pen(Drawing.Color.BurlyWood, 6)
            PictureBox1.Refresh()
            '    Picturebox1.CreateGraphics().DrawLine(myPen, x1, y1, x1, y2)
        End Using
        Try
            'Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Value - 3 'change to 12     
        Catch ex As Exception

        End Try
        y2 = y2 - 5 '10 ' where x is an integer intialize to zero at form starts
        PictureBox2.Top = y2 - 3
        PictureBox2.Left = x2
    End Sub

    Sub downTimertemp()
        counterVals = 2
        Dim myGraphics As Graphics = PictureBox1.CreateGraphics
        Dim myPen As Pen


        '        myGraphics.Clear(Picturebox1.BackColor)

        myPen = New Pen(Drawing.Color.BurlyWood, 6)


        myGraphics.DrawLine(myPen, x1, y1, x1, y2)
        '  Graphics.FromImage(Picturebox1.image).DrawLine(myPen, 400, 0, 400, x2)
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
        PictureBox2.Top = y2 - 20
        PictureBox2.Left = x2
    End Sub
    Sub onLoadDrawer()
        PictureBox1.Image = New Bitmap(Width, Height)

        'x = Picturebox1.Height
        'PictureBox2.Parent = Picturebox1
        Panel1.AutoScroll = True
        Panel1.SetAutoScrollMargin(5000, 5000)
        'Panel1.ScrollControlIntoView(VScrollBar1)
        x1 = 200 ' Picturebox1.Width / 2 '10
        x2 = 200 'Picturebox1.Width / 2 '10
        y1 = 140 '(Picturebox1.Height / 2) + 4 '90
        y2 = 140 '(Picturebox1.Height / 2) + 4 '90
        yTemp = 0
        xTemp = 0
        Using c As New Control() With {.Parent = Panel1, .Dock = DockStyle.Bottom, .Top = Panel1.Height + 10}
            Panel1.ScrollControlIntoView(c)
            Panel1.HorizontalScroll.Enabled = True
            c.Parent = Nothing
        End Using

        Panel1.VerticalScroll.Value = 0 '2500
        Panel1.HorizontalScroll.Value = 0 '2500
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

    Private Sub Button7_Click_2(sender As Object, e As EventArgs)
        downLine()






    End Sub

    Private Sub Button8_Click_2(sender As Object, e As EventArgs) Handles Button8.Click
        upLine()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        rightLine()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        counterRecorder.Enabled = True

    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Button7_Click_3(sender As Object, e As EventArgs) Handles Button7.Click
        counterRecorder.Enabled = False
        upTime = 0
        downTime = 0
        leftTime = 0
        rightTime = 0
        x1 = 0
        x2 = 0
        y1 = 0
        y2 = 0
        stopLine()
        counterPlayer.Enabled = True
    End Sub

    Private Sub counterPlayer_Tick(sender As Object, e As EventArgs) Handles counterPlayer.Tick
        For i = ListBox1.Items.Count - 1 To 0 Step -1
            If ListBox1.Items.Item(i).ToString.Contains("Up") Then
                If downTime < ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) Then
                    upTime = 0
                    downTime += 1
                    leftTime = 0
                    rightTime = 0
                    TextBox1.Text = 2
                    Button2.PerformClick()
                    System.Threading.Thread.Sleep(ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) * 1000)
                End If

            ElseIf ListBox1.Items.Item(i).ToString.Contains("Down") Then
                If downTime < ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) Then
                    upTime += 1
                    downTime = 0
                    leftTime = 0
                    rightTime = 0
                    TextBox1.Text = 1
                    Button2.PerformClick()
                    System.Threading.Thread.Sleep(ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) * 1000)

                End If
            ElseIf ListBox1.Items.Item(i).ToString.Contains("Left") Then
                If downTime < ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) Then
                    upTime = 0
                    downTime = 0
                    leftTime = 0
                    rightTime += 1
                    TextBox1.Text = 3
                    Button2.PerformClick()
                    System.Threading.Thread.Sleep(ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) * 1000)

                End If
            ElseIf ListBox1.Items.Item(i).ToString.Contains("Right") Then
                If downTime < ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) Then
                    upTime = 0
                    downTime = 0
                    leftTime += 1
                    rightTime = 0
                    TextBox1.Text = 4
                    Button2.PerformClick()
                    System.Threading.Thread.Sleep(ListBox1.Items.Item(i).ToString.Substring(ListBox1.Items.Item(i).ToString.IndexOf(":") + 1) * 1000)

                End If
            End If
        Next
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Timer2.Enabled = False
        downTimer.Enabled = False
        leftTimer.Enabled = False
        rightTimer.Enabled = False
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        SendValue(4)
    End Sub

    Private Sub Picturebox1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        downLine()
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        leftLine()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

        If My.Computer.Keyboard.AltKeyDown Then
            'recog.RecognizeAsync(RecognizeMode.Multiple)
            'recog.RecognizeAsyncStop()

        Else
            ' recog.RecognizeAsyncStop()

        End If
    End Sub

    Private Sub counter_Tick(sender As Object, e As EventArgs) Handles counterRecorder.Tick
        If counterVals = 1 Then
            If leftTime <> 0 Then
                ListBox1.Items.Add("Left :" & leftTime)
            ElseIf rightTime <> 0
                ListBox1.Items.Add("Right :" & rightTime)
            ElseIf upTime <> 0
                ListBox1.Items.Add("Up :" & upTime)
            End If
            upTime = 0
            downTime += 1
            leftTime = 0
            rightTime = 0
        ElseIf counterVals = 2
            If leftTime <> 0 Then
                ListBox1.Items.Add("Left :" & leftTime)
            ElseIf rightTime <> 0
                ListBox1.Items.Add("Right :" & rightTime)
            ElseIf downTime <> 0
                ListBox1.Items.Add("Down :" & downTime)
            End If
            upTime += 1
            downTime = 0
            leftTime = 0
            rightTime = 0
        ElseIf counterVals = 3
            If upTime <> 0 Then
                ListBox1.Items.Add("Up: :" & upTime)
            ElseIf rightTime <> 0
                ListBox1.Items.Add("Right :" & rightTime)
            ElseIf downTime <> 0
                ListBox1.Items.Add("Down :" & downTime)
            End If
            upTime = 0
            downTime = 0
            leftTime += 1
            rightTime = 0
        ElseIf counterVals = 4
            If leftTime <> 0 Then
                ListBox1.Items.Add("Left :" & leftTime)
            ElseIf upTime <> 0
                ListBox1.Items.Add("Up :" & upTime)
            ElseIf downTime <> 0
                ListBox1.Items.Add("Down :" & downTime)
            End If
            upTime = 0
            downTime = 0
            leftTime = 0
            rightTime += 1
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        recog.Recognize()
    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub PictureBox1_Click_1(sender As Object, e As EventArgs) Handles PictureBox1.Click

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


    Private Sub Panel1_Scroll(sender As Object, e As ScrollEventArgs) Handles Panel1.Scroll
        '  Picturebox1.Refresh()
    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown

    End Sub

    Private Sub PictureBox1_Paint(sender As Object, e As PaintEventArgs) Handles PictureBox1.Paint
        Using myPen As New Pen(Drawing.Color.BurlyWood, 6)


            If Timer2.Enabled = True Then

                e.Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, x1, y1, x1, y2)
                'e.Graphics.DrawLine(myPen, x1, y1, x1, y2)
                ' Picturebox1.Invalidate()

            End If
            If leftTimer.Enabled = True Then
                e.Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, x1, y1, x2, y1)
                'e.Graphics.DrawLine(myPen, x1, y1, x2, y1)
            End If
            If rightTimer.Enabled = True Then
                e.Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, x1, y1, x2, y1)
                'e.Graphics.DrawLine(myPen, x1, y1, x2, y1)

            End If
            If downTimer.Enabled = True Then
                e.Graphics.FromImage(PictureBox1.Image).DrawLine(myPen, x1, y1, x1, y2)
                'e.Graphics.DrawLine(myPen, x1, y1, x1, y2)
            End If
        End Using
    End Sub
End Class
