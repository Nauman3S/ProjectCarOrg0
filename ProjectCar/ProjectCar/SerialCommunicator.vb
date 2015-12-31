Imports System.IO.Ports
Module SerialCommunicator

    Sub OpenPortC()
        Form1.SerialPort1.Close()
        Form1.SerialPort1.PortName = "COM5"
        Form1.SerialPort1.BaudRate = 9600
        Form1.SerialPort1.DataBits = 8
        Form1.SerialPort1.Parity = Parity.None
        Form1.SerialPort1.StopBits = StopBits.One
        Form1.SerialPort1.Handshake = Handshake.None
        Form1.SerialPort1.Encoding = System.Text.Encoding.Default
    End Sub
    Sub SendValue(ByVal val As Integer)
        Form1.SerialPort1.Open()
        Form1.SerialPort1.Write(val)
        Form1.SerialPort1.Close()

    End Sub
End Module
