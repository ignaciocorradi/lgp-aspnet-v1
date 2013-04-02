<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmReporteAsp.aspx.cs" Inherits="AppGest.Vista.Reportes.FrmReporteAsp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<body>
    <form id="form1" runat="server" style="height: 100%; width:100%">
    <asp:scriptmanager ID="Scriptmanager1" runat="server"></asp:scriptmanager>
    <div style="height: 600px;"  >
        <asp:Label ID="lblTitulo" runat="server" BackColor= "Transparent"
            Font-Bold="False" Font-Names="Segoe UI" Font-Size= "Larger" ForeColor= "DarkCyan" Width="100%" 
            Text=" Título del reporte"></asp:Label>
               
                       
        <rsweb:ReportViewer ID="rptControl" runat="server" Height="100%" 
            ProcessingMode="Remote" Width="100%" EnableTheming="False" 
            WaitMessageFont-Italic="False" WaitMessageFont-Names="Segoe UI Light"  
            WaitMessageFont-Size="Small" BorderColor= "ActiveBorder" BorderStyle="Solid"  BackColor= "#d0d0f2"
            BorderWidth="1px" Font-Names="Segoe UI" Font-Size="8pt" 
            InternalBorderColor="LightGray" ShowCredentialPrompts="False" 
            SplitterBackColor= "Gainsboro" >
        </rsweb:ReportViewer>
    </div>
    </form>
</body>
</html>
