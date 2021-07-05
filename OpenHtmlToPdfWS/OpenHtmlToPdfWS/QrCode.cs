using QRCoder;
using System;
using System.Drawing;
using System.IO;
using static QRCoder.PayloadGenerator;

namespace OpenHtmlToPdfWS
{
  class QrCode
  {
    public static Byte[] Generate(string url)
    {
      Url generator = new Url(url);
      string payload = generator.ToString();

      QRCodeGenerator qrGenerator = new QRCodeGenerator();
      QRCodeData qrCodeData = qrGenerator.CreateQrCode(payload, QRCodeGenerator.ECCLevel.Q);
      QRCode qrCode = new QRCode(qrCodeData);
      Bitmap qrCodeImage = qrCode.GetGraphic(5);
      return Helpers.BitmapToBytes(qrCodeImage);
    }
  }
}
