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
      //var source = @"<!DOCTYPE html>
      //  <html lang = ""pt_BR""> 
      //  <head> 
      //  <meta charset = ""utf-8"">
      //  <meta http-equiv = ""X-UA-Compatible"" content = ""IE=edge"">
      //  <meta name = ""viewport"" content = ""width=device-width, initial-scale=1"">
      //  <title>{{title}}</title>
      //  <style>
      //    .divOculta{display:none}
      //    .divRed{width: '100px'; heigth: '100px'; background-color: red; border: 1px solid black;}
      //  </style>
      //  </head>
      //  <body>
      //   <div class=""container"">
      //  <h1>Bar Code</h1>
      //  <img src=""{{urlBarCode}} ""/> 
      //  <h1>QR Code</h1>
      //  <img src=""{{urlQrCode}}"" />
      //  <hr/>
      //  <div class=""divOculta"">Div que tem que ser ocultada</div>
      //  <div class=""divRed"">Div Vermelha</div>
      //  <h2>Aviso de Produto</h2>
      //    {{title}}
      //  </body>
      //  </html>";

      var source = @"
<!DOCTYPE html>
<html lang=""en"">

<head>
  <meta charset=""UTF-8"">
  <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
  <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
  <title>Boleto Refugo</title>
  <style type=""text/css"">
    html{font-family:Calibri, Arial, Helvetica, sans-serif;font-size:9pt;background-color:white }
    table{border-collapse:collapse;width:100%;}
    .container{width:1200px;margin:auto;}
    .borderTop{border-top:1px solid #000000 }
    .borderLeft{border-left:1px solid #000000 }
    .borderRight{border-right:1px solid #000000 }
    .borderBotton{border-bottom:1px solid #000000 }
    .borderAll{border:1px solid #000000 }
    .textRight{text-align:right;}
    .textLeft{text-align:left;}
    .textCenter{text-align:center;}
    .logoImg{width:300px;height:150px;}
    .paddRight30{padding-right:30px;}
    .paddLeft130{padding-left:130px;}
    .paddTop30{padding-top:30px;}
    .paddBottom30{padding-bottom:30px;}
    .textBold{font-weight:bold;}
    .fontSize9{font-size:9px;}
    .maxWid100{max-width:100px;}
    .maxWid90{max-width:90px;}
    .verticalAlignBase{vertical-align: baseline;}
  </style>

  <!-- #region Footer João */ -->
  <style>
    body {
      font-family: ""Arial"";
    }

    @media print {

      .no-print,
      .no-print * {
        display: none !important;
      }
    }

    .document {
      margin: auto auto;
      width: 216mm;
      height: 108mm;
      background-color: #fff;
    }

    .headerBtn {
      margin: auto auto;
      width: 216mm;
      background-color: #fff;
      display: none;
    }

    table {
      width: 100%;
      position: relative;
      border-collapse: collapse;
    }

    .bankLogo {
      width: 28%;
    }

    .boletoNumber {
      width: 62%;
      font-weight: bold;
    }

    .center {
      text-align: center;
    }

    .right {
      text-align: right;
      right: 20px;
    }

    td {
      position: relative;
    }

    .title {
      position: absolute;
      left: 0px;
      top: 0px;
      font-size: 8px;
      font-weight: bold;
    }

    .text {
      font-size: 12px;
    }

    p.content {
      padding: 0px;
      width: 100%;
      margin: 0px;
      font-size: 12px;
    }

    .sideBorders {
      border-left: 1px solid black;
      border-right: 1px solid black;
    }

    hr {
      size: 1;
      border: 1px dashed;
    }

    br {
      content: "" "";
      display: block;
      margin: 12px 0;
      line-height: 12px;
    }

    .print {
      /* TODO(dbeam): reconcile this with overlay.css' .default-button. */
      background-color: rgb(77, 144, 254);
      background-image: linear-gradient(to bottom, rgb(77, 144, 254), rgb(71, 135, 237));
      border: 1px solid rgb(48, 121, 237);
      color: #fff;
      text-shadow: 0 1px rgba(0, 0, 0, 0.1);
    }

    .btnDefault {
      font-kerning: none;
      font-weight: bold;
    }

    .btnDefault:not(:focus):not(:disabled) {
      border-color: #808080;
    }

    button {
      border: 1px;
      padding: 5px;
      line-height: 20px;
    }
  </style>
  <!-- #endregion -->
</head>

<body>
  <div class=""container"">
    <table class=""header"">
      <tbody>
        <tr class=""row"">
          <td class=""borderBotton borderRight textBold"" colspan=""3"">{{nomeBanco}}</td>
          <td class=""borderBotton borderLeft borderRight textBold textCenter"" colspan=""1"">{{codBanco}}</td>
          <td class=""borderLeft textRight paddRight30 textBold"" colspan=""10"">Comprovante de Entrega</td>
        </tr>
        <tr class=""row"">
          <td class=""borderLeft borderRight borderTop textBold fontSize9"" colspan=""3"">Cedente</td>
          <td class=""borderLeft borderRight borderTop textBold fontSize9"" colspan=""3"">Agência/Código Cedente</td>
          <td class=""borderRight textBold"" colspan=""8"">Motivo de não entrega (Para uso da empresa entregadora)</td>
        </tr>
        <tr class=""row"">
          <td class=""borderLeft borderRight borderBotton textBold"" colspan=""3"">{{razSocial}} - {{locFabrica}} -
            {{cnpjEmitente}}</td>
          <td class=""borderLeft borderRight borderBotton textBold"" colspan=""3"">{{agBanco}} / {{codCedente}}</td>
          <td class=""borderRight textBold"" colspan=""8""></td>
        </tr>
        <tr class=""row"">
          <td class=""borderTop borderRight borderLeft textBold fontSize9"" colspan=""3"">Sacado</td>
          <td class=""borderRight borderLeft borderTop textBold fontSize9"" colspan=""3"">Nosso Número</td>
          <td class="" textBold"" colspan=""3"">( )Mudou-se</td>
          <td class="" textBold"" colspan=""3"">( )Ausente</td>
          <td class=""borderRight textBold"" colspan=""2"">( )Não existe o Nº</td>
        </tr>
        <tr class=""row"">
          <td class=""borderRight borderLeft textBold"" colspan=""3"">{{nomeCliente}}</td>
          <td class=""borderRight borderLeft textBold"" colspan=""3"">{{carteira}} / {{nunDoc}}</td>
          <td class="" textBold"" colspan=""3"">( )Recusado</td>
          <td class="" textBold"" colspan=""3"">( )Não Procurado</td>
          <td class=""borderRight textBold"" colspan=""2"">( )Falecido</td>
        </tr>
        <tr class=""row"">

          <td class=""borderTop borderRight borderLeft textBold"">Vencimento</td>
          <td class=""borderTop borderRight borderLeft textBold"">Nº do Documento</td>
          <td class=""borderTop borderRight borderLeft textBold"">Espécie</td>
          <td class=""borderTop borderRight borderLeft textBold"" colspan=""3"">(=)Valor do Documento</td>
          <td class="" textBold"" colspan=""3"">( )Desconhecido</td>
          <td class="" textBold"" colspan=""3"">( )End. Insuficiente</td>
          <td class=""borderRight textBold"" colspan=""2"">( )Outros</td>

        </tr>
        <tr class=""row"">

          <td class=""borderBotton borderRight borderLeft textBold"">{{dataVenc}}</td>
          <td class=""borderBotton borderRight borderLeft textBold"">{{nunDoc}}</td>
          <td class=""borderBotton borderRight borderLeft textBold"">R$</td>
          <td class=""borderBotton borderRight borderLeft textBold"" colspan=""3"">{{valorTotal}}</td>
          <td class=""borderBotton borderRight borderLeft textBold"" colspan=""8""></td>

        </tr>
        <tr class=""row"">
          <td class=""borderTop borderRight borderLeft textBold"" colspan=""2"">Recebi(emos) o Bloqueto/Título</td>
          <td class=""borderTop borderRight borderLeft textBold"">Data</td>
          <td class=""borderTop borderRight borderLeft textBold"">Assinatura</td>
          <td class=""borderTop borderRight borderLeft textBold"" colspan=""2"">Data</td>
          <td class=""borderTop borderRight textBold"" colspan=""8"">Entregador</td>
        </tr>
        <tr class=""row"">
          <td class=""borderBotton borderRight borderLeft textBold"" colspan=""2"">com as caracteristicas acima.</td>
          <td class=""borderBotton borderRight borderLeft""></td>
          <td class=""borderBotton borderRight borderLeft""></td>
          <td class=""borderBotton borderRight borderLeft textBold"" colspan=""2""></td>
          <td class=""borderBotton borderRight textBold"" colspan=""8""></td>
        </tr>
        <tr class=""row"">
          <td class=""borderLeft borderTop textBold"" colspan=""5"">Local do Pagamento</td>
          <td class=""borderLeft borderRight borderTop textBold"" colspan=""9"">Data do Processamento</td>
        </tr>
        <tr class=""row"">
          <td class=""borderLeft borderBotton textBold"" colspan=""5"">{{razaoBanco}} - Pagável preferencialmente nas
            Agências {{nomeBanco}}</td>
          <td class=""borderLeft borderRight borderBotton textBold"" colspan=""9"">{{dataProce}}</td>
        </tr>
        <tr class=""row"">
          <td class="" textBold"" colspan=""14""></td>
        </tr>
        <tr class=""row"">
          <td class=""textLeft paddLeft130 paddTop30 borderBotton textBold fontSize9"" colspan=""14"">CORTE AQUI</td>
        </tr>

        <tr class=""row"">
          <td class="" textBold"" colspan=""7"" row=""5"">
            <div style=""position: relative;"">
              <img class=""logoImg"" src=""logo.png"" />
            </div>
          </td>
          <td class="" textBold"" colspan=""7"" row=""5"">BRADESCO</td>
        </tr>
        <tr></tr>
        <tr></tr>
        <tr></tr>
        <tr></tr>
        <tr></tr>

        <tr class=""row"">
          <td class=""textRight textBold"" colspan=""14"">Recibo de Pagamento</td>
        </tr>
        <tr class=""row"">
          <td class=""borderTop borderLeft textBold"" colspan=""3"">{{razSocial}} - {{locFabrica}} - {{cnpjEmitente}}</td>
          <td class=""borderTop textBold"" colspan=""5"">C.N.P.J: {{cnpjEmitente}}</td>
          <td class=""borderTop borderRight textBold"" colspan=""6"">Data de Emissão: {{dataDoc}}</td>
        </tr>
        <tr class=""row"">
          <td class=""borderBotton borderLeft textBold"" colspan=""1"">{{endEmissor}}</td>
          <td class=""borderBotton borderRight textBold"" colspan=""13"">Inscrição Estadual: </td>
        </tr>
        <tr class=""row"">
          <td class=""borderLeft borderTop borderRight textBold"" colspan=""14"">Destinatário: {{nomeCliente}}</td>
        </tr>
        <tr class=""row"">
          <td class=""borderLeft textBold"" colspan=""3"">Banco: </td>
          <td class=""borderRight textBold"" colspan=""11""></td>
        </tr>
        <tr class=""row"">
          <td class=""borderBotton borderLeft textBold"" colspan=""3"">Agência bancária:</td>
          <td class=""borderBotton borderRight textBold"" colspan=""11"">Conta Corrente:</td>
        </tr>
      </tbody>
    </table>

    <table class=""main"">
      <tbody>
        <tr class=""row"">
          <td class=""textBold borderLeft borderRight borderBotton textCenter paddRight30 textBold"" colspan=""14"">
            DEMONSTRATIVO DO BOLETO</td>
        </tr>
        </tr>
        <tr class="""">
          <td class=""textBold borderTop borderBotton borderLeft borderBotton paddTop30 textRight maxWid100"">Nº</td>
          <td class=""textBold borderTop borderBotton paddTop30 maxWid100 textCenter"">Tipo de Cobrança</td>
          <td class=""textBold borderTop borderBotton paddTop30 maxWid100 textCenter"">Valor R$</td>
          <td class=""textBold borderTop borderBotton borderRight paddTop30 maxWid100 textCenter"">Vencimento</td>
          <td class=""textBold borderTop borderBotton borderRight paddTop30 textCenter maxWid100"">Nota Fiscal de Entrada
          </td>
        </tr>
        <tr class="""">
          <td class=""textBold paddBottom30 borderLeft textRight maxWid100 verticalAlignBase"">30000319</td>
          <td class=""textBold paddBottom30 textCenter maxWid100 verticalAlignBase"">REFUGO</td>
          <td class=""textBold paddBottom30 textCenter maxWid100 verticalAlignBase"">1.952,66</td>
          <td class=""textBold paddBottom30 borderRight maxWid100 textCenter verticalAlignBase"">20/04/2021</td>
          <td class=""textBold paddBottom30 borderRight textCenter maxWid100 verticalAlignBase"">351831-1 352180-1 352181-1 351831-1
            352180-1 352181-1 351831-1 352180-1 352181-1 351831-1 352180-1 352181-1</td>
        </tr>
        <tr class="""">
          <td class=""textBold paddBottom30 borderLeft textRight maxWid100 verticalAlignBase"">30000319</td>
          <td class=""textBold paddBottom30 textCenter maxWid100 verticalAlignBase"">REFUGO</td>
          <td class=""textBold paddBottom30 textCenter maxWid100 verticalAlignBase"">1.952,66</td>
          <td class=""textBold paddBottom30 borderRight maxWid100 textCenter verticalAlignBase"">20/04/2021</td>
          <td class=""textBold paddBottom30 borderRight textCenter maxWid100 verticalAlignBase"">351831-1 352180-1 352181-1 351831-1
            352180-1 352181-1 351831-1 352180-1 352181-1 351831-1 352180-1 352181-1 351831-1 352180-1 352181-1 351831-1
            352180-1 352181-1 351831-1 352180-1 352181-1 351831-1 352180-1 352181-1</td>
        </tr>

        <tr class="""">
          <td class=""textBold paddBottom30 borderLeft textRight maxWid100""></td>
          <td class=""textBold paddBottom30 textCenter maxWid100""></td>
          <td class=""textBold paddBottom30 maxWid100"">TAXA DO BOLETO</td>
          <td class=""textBold paddBottom30 borderRight textCenter"">0,00</td>
          <td class=""textBold paddBottom30 borderRight textCenter maxWid100""></td>
        </tr>

        <tr class="""">
          <td class=""textBold paddBottom30 borderLeft textRight maxWid100""></td>
          <td class=""textBold paddBottom30 textCenter maxWid100""></td>
          <td class=""textBold paddBottom30 maxWid100"">Total:</td>
          <td class=""textBold paddBottom30 borderRight maxWid100 textCenter"">1.952,66</td>
          <td class=""textBold paddBottom30 borderRight textCenter maxWid100""></td>
        </tr>

        <tr class="""">
          <td class=""textBold borderBotton borderLeft borderRight borderBotton textRight"" colspan=""4""></td>
          <td class=""textBold borderBotton borderLeft borderRight borderBotton textRight"" colspan=""1""></td>
        </tr>
      </tbody>
    </table>

  <!-- </div> -->
  <!-- <div class=""document""> -->
    <hr />

    <table cellspacing=""0"" cellpadding=""0"">
      <td width=""70%"" colspan=""6"">
      <td class=""bankLogo"">BRADESCO</td>
      <td class=""sideBorders center""><span style=""font-size:24px;font-weight:bold;"">237-2</span></td>
      <td class=""boletoNumber center""><span>23792.37205 90001.046417 53002.082104 2 86020011232739</span></td>
      </tr>
      </td>
    </table>
    <table cellspacing=""0"" cellpadding=""0"" border=""1"">
      <tr>
        <td width=""70%"" colspan=""6"">
          <span class=""title"">Local de Pagamento</span>
          <br />
          <span class=""text"">Banco Brasdeco S.A. - Pagável preferencialmente nas Agências Bradesco</span>
          <br />
          <br />
        </td>
        <td width=""30%"">
          <span class=""title"">Vencimento</span>
          <br />
          <br />
          <p class=""content right text"" style=""font-weight:bold;"">01/01/2016</p>
        </td>
      </tr>
      <tr>
        <td width=""70%"" colspan=""6"">
          <span class=""title"">Cedente:</span>
          <br />
          <table border=""0"" style=""border:none"">
            <tr>
              <td width=""60%""><span class=""text"">AMBEV S/A - F. PERNAMBUCO- 07.526.557/0021-53</span></td>
              <td><span class=""text"">&nbsp;</span></td>
            </tr>
          </table>
          <br />
          <span class=""text"">&nbsp;</span>
        </td>
        <td width=""30%"">
          <span class=""title"">Agência/Código Beneficiário</span>
          <br />
          <br />
          <p class=""content right"">1234/12345-1</p>
        </td>
      </tr>

      <tr>
        <td width=""15%"">
          <span class=""title"">Data do Documento</span>
          <br />
          <p class=""content center"">01/07/2015</p>
        </td>
        <td width=""17%"" colspan=""2"">
          <span class=""title"">Número do Documento</span>
          <br />
          <p class=""content center"">1</p>
        </td>
        <td width=""10%"">
          <span class=""title"">Espécie doc</span>
          <br />
          <p class=""content center"">DM</p>
        </td>
        <td width=""8%"">
          <span class=""title"">Aceite</span>
          <br />
          <p class=""content center"">N</p>
        </td>
        <td>
          <span class=""title"">Data Processamento</span>
          <br />
          <p class=""content center"">01/07/2015</p>
        </td>
        <td width=""30%"">
          <span class=""title"">Nosso Número</span>
          <br />
          <br />
          <p class=""content right"">157/12345678-9</p>
        </td>
      </tr>

      <tr>
        <td width=""15%"">
          <span class=""title"">Uso do Banco</span>
          <br />
          <p class=""content center"">&nbsp;</p>
        </td>
        <td width=""10%"">
          <span class=""title"">Carteira</span>
          <br />
          <p class=""content center"">157</p>
        </td>
        <td width=""10%"">
          <span class=""title"">Espécie</span>
          <br />
          <p class=""content center"">R$</p>
        </td>
        <td width=""8%"" colspan=""2"">
          <span class=""title"">Quantidade</span>
          <br />
          <p class=""content center"">N</p>
        </td>
        <td>
          <span class=""title"">Valor</span>
          <br />
          <p class=""content center"">10,00</p>
        </td>
        <td width=""30%"">
          <span class=""title"">(=) Valor do Documento</span>
          <br />
          <br />
          <p class=""content right"">10,00</p>
        </td>
      </tr>
      <tr>
        <td colspan=""6"" rowspan=""4"">
          <span class=""title"">Instruções(todas as informações desse bloqueto são de exclusiva responsabilidade do
            cedente)</span>
        </td>
      </tr>
      <tr>
        <td>
          <span class=""title"">(-) Descontos/Abatimento</span>
          <br />
          <p class=""content right"">&nbsp;</p>
        </td>
      </tr>
      <tr>
        <td>
          <span class=""title"">(+) Juros/Multa</span>
          <br />
          <p class=""content right"">&nbsp;</p>
        </td>
      </tr>
      <tr>
        <td>
          <span class=""title"">(=) Valor Pago</span>
          <br />
          <p class=""content right"">&nbsp;</p>
        </td>
      </tr>
      <tr>
        <td colspan=""7"">
          <table border=""0"" style=""border:none"">
            <tr>
              <td width=""70%""><span class=""title"">Sacado: </span></td>
              <td><span class=""text"">&nbsp;</td>
            </tr>
            <tr>
              <td><span class=""text"">&nbsp;&nbsp;GP7 DISTRIBUIDOR BEBIDAS LTDA - C.N.P.J: 26.834.370/0001-18 ROD PA 242
                  SN, KM 1</span><br /></td>
              <td>&nbsp;</td>
              <td>&nbsp;</td>
            </tr>
            <tr>

              <td><span class=""title"">Sacador Avalista:</span></td>
              <td width=""30%""><span class=""title"">Código de baixa <br />Autentificação Mecânica /FICHA DE
                  COMPENSAÇÃO</span></td>
              <td><span class=""text"">&nbsp;</span></td>
            </tr>
          </table>

        </td>

      </tr>
    </table>
<img src=""data:image/png;base64,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""
            alt="""">
  </div>
</body>

</html>




";
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
