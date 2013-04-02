<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="AppGest.Vista.Error" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            text-align: center;
            height: 337px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="style1">
    
        <br />
        Se ha producido un error. 
        <br />
       Disculpe las molestias.<br />
        <br />
        <asp:Image ID="Image1" runat="server" Height="79px" 
            ImageUrl="~/Resources/Images/Logo60x59.png" style="text-align: right" 
            Width="83px" />
        <br />
        <br />
        <asp:TextBox ID="TextBox1" runat="server" BackColor="#FFFFCC" 
            BorderStyle="None" Height="144px" TextMode="MultiLine" Width="445px"></asp:TextBox>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
