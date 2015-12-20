Imports System.Speech.Recognition
Imports System.Threading
Imports System.Globalization

Imports System.IO.Ports


Public Class Form1
    ' recogniser & grammar
    Dim recog As New SpeechRecognizer
    Dim gram As Grammar
    ' events
    Public Event SpeechRecognized As _
        EventHandler(Of SpeechRecognizedEventArgs)
    Public Event SpeechRecognitionRejected As _
        EventHandler(Of SpeechRecognitionRejectedEventArgs)
    ' word list
    Dim wordlist As String() = New String() {"Left", "Right", "Up", "Down"}


    Public Sub recevent(ByVal sender As System.Object,
                ByVal e As RecognitionEventArgs)
        left.ForeColor = Color.LightGray
        right.ForeColor = Color.LightGray
        up.ForeColor = Color.LightGray
        down.ForeColor = Color.LightGray

        If (e.Result.Text = "Left") Then
            left.ForeColor = Color.Blue
            SendTo(3)
        ElseIf (e.Result.Text = "Right") Then
            right.ForeColor = Color.Blue
            SendTo(4)
        ElseIf (e.Result.Text = "Up") Then
            up.ForeColor = Color.Blue
            SendTo(1)
        ElseIf (e.Result.Text = "Down") Then
            down.ForeColor = Color.Blue
            SendTo(2)
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
    Private Sub Form1_Load(ByVal sender As System.Object,
            ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SerialPort1.Close()
        SerialPort1.PortName = "COM5"
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Parity = Parity.None
        SerialPort1.StopBits = StopBits.One
        SerialPort1.Handshake = Handshake.None
        SerialPort1.Encoding = System.Text.Encoding.Default
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SerialPort1.Open()
        SerialPort1.Write(TextBox1.Text)
        SerialPort1.Close()
    End Sub
    Sub SendTo(ByVal val As Integer)
        SerialPort1.Open()
        SerialPort1.Write(val)
        SerialPort1.Close()

    End Sub


End Class
