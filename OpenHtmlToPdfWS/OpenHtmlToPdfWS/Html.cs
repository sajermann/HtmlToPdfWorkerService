using HandlebarsDotNet;
using System;

namespace OpenHtmlToPdfWS
{
  public static class Html
  {
    public static string Generate(byte[] barCode, byte[] qrCode)
    {
      var urlBarCode = @String.Format("data:image/png;base64,{0}", Convert.ToBase64String(barCode));
      var urlQrCode = @String.Format("data:image/png;base64,{0}", Convert.ToBase64String(qrCode));
      var source = @"<!DOCTYPE html>
        <html lang = ""pt_BR""> 
        <head> 
        <meta charset = ""utf-8"">
        <meta http-equiv = ""X-UA-Compatible"" content = ""IE=edge"">
        <meta name = ""viewport"" content = ""width=device-width, initial-scale=1"">
        <title>{{title}}</title>
        </head>
        <body>
         <div class=""container"">
        <h1>Bar Code</h1>
        <img src=""{{urlBarCode}} ""/> 
        <h1>QR Code</h1>
        <img src=""{{urlQrCode}}"" />
        <hr/>
        <h2>Aviso de Produto</h2>
          {{title}}
        </body>
        </html>";
      var template = Handlebars.Compile(source);
      var data = new
      {
        title = "Ambev",
        urlBarCode = urlBarCode,
        urlQrCode = urlQrCode,
        body = "This is my first post!"
      };
      var result = template(data);
      return result;
    }
  }
}
