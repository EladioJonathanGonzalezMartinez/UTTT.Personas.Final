<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarContra.aspx.cs" Inherits="UTTT.Ejemplo.Persona.RecuperarContra" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Recuperar contra</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" integrity="sha384-BVYiiSIFeK1dGmJRAkycuHAHRg32OmUcww7on3RYdg4Va+PmSTsz/K68vbdEjh4u" crossorigin="anonymous">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap-theme.min.css" integrity="sha384-rHyoN1iRsVXV4nD0JutlnGaslCJuC7uwjduW9SVrLvRYooPp2bWYgmgJQIXwl/Sp" crossorigin="anonymous">
    <link href="css/estilo.css" rel="stylesheet" />
</head>
<body style="font-family: 'Century Gothic';">
    <div style=" width: 400px;
    margin: 50px auto;
    background-color: #eceee7;
    border: 1px solid #000000;
    height: 450px;
    border-radius: 8px;
    padding: 0px 9px 0px 9px;">
    <form id="form1" runat="server">
        <div align="center">
            <div class="mb-3 container-fluid" style="font-size: medium; font-weight: bold">
                <h1>Recuperar tu contraseña</h1>
            </div>
            <br />
            
            <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Usuario: "></asp:Label>
                    <asp:TextBox ID="txtUser" runat="server" Width="370px" CssClass="form-control" type="password" Enabled="False"></asp:TextBox>
                </div>
            <br />
            <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Nueva contraseña: "></asp:Label>
                    <asp:TextBox ID="txtcontra" runat="server" Width="370px" CssClass="form-control" type="password"></asp:TextBox>
                </div>
            <br />
            <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Repetir contraseña: "></asp:Label>
                    <asp:TextBox ID="txtrecontra" runat="server" Width="370px" CssClass="form-control" type="password"></asp:TextBox>
                </div>
            <br />
  
            <div>
                <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Cambiar" Width="196px" CssClass="btn btn-success"/>
            </div>
            <br />
            <div>
                <asp:Label ID="lblmsj" runat="server"></asp:Label>
            </div>
            </div>
    </form>
        </div>
</body>
</html>
