using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OpenHtmlToPdfWS
{
  public static class Barcode
  {
    public static byte[] Generate(string numberBarcode)
    {
      BarcodeLib.Barcode b = new BarcodeLib.Barcode();
      Image codeBar = b.Encode(BarcodeLib.TYPE.UPCA, numberBarcode, Color.Black, Color.White, 290, 120);
      Bitmap codeBarImg = new Bitmap(codeBar);
      return Helpers.BitmapToBytes(codeBarImg);
    }
  }
}
