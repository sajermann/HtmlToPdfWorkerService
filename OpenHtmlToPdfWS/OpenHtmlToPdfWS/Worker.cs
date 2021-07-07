using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OpenHtmlToPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OpenHtmlToPdfWS
{
  public class Worker : BackgroundService
  {
    private readonly ILogger<Worker> _logger;

    public Worker(ILogger<Worker> logger)
    {
      _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      var barCode = Barcode.Generate("12345678910");
      var qrCode = QrCode.Generate("http://google.com.br");
      var html = Html.Generate(barCode, qrCode);

      var pdf = Pdf.From(html).Content();
      File.WriteAllBytes($"‪teste.pdf", pdf);
      Console.WriteLine("Hello World!");

    }
  }
}
