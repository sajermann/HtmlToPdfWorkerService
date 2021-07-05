using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace OpenHtmlToPdfWS
{
  public static class Helpers
  {
    public static Byte[] BitmapToBytes(Bitmap img)
    {
      using (MemoryStream stream = new MemoryStream())
      {
        img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
        return stream.ToArray();
      }
    }
  }
}
