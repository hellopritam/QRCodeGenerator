Imports QRCoder
Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing
Imports QRCoder.QRCodeGenerator.QRCode

Partial Class qrcode
    Inherits System.Web.UI.Page
    











    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim code As String
        Dim qrGenerator As QRCodeGenerator
        Dim qrcode As QRCodeGenerator.QRCode
        Dim imgBarCode As System.Web.UI.WebControls.Image
        Dim bitMap As Bitmap
        Dim ms As MemoryStream
        Dim byteImage As Byte()
        code = TextBox1.Text
        qrGenerator = New QRCodeGenerator()
        qrcode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q)
        imgBarCode = New System.Web.UI.WebControls.Image()
        imgBarCode.Height = 250
        imgBarCode.Width = 250
        bitMap = qrcode.GetGraphic(20)
        ms = New MemoryStream()
        bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
        byteImage = ms.ToArray()
        imgBarCode.ImageUrl = "data:image/png;base64," & Convert.ToBase64String(byteImage)
        PlaceHolder1.Controls.Add(imgBarCode)
        Label1.Visible = True
    End Sub
End Class
