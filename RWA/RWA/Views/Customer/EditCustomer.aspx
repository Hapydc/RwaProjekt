<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="RWA.WebForms.EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <title>Uredite kupca </title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="jumbotron">
        <div>
            <input  runat="server" type="text" id="Ime" />
        </div>
        <div >
            <input runat="server" type="text" id="Prezime" />
        </div>
        <div >
            <input runat="server" type="text" id="Telefon" />
        </div>
        <div >
            <input runat="server" type="text" id="email" />
        </div>
        <div >
            <asp:DropDownList class="" ID="grad" DataValueField="" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Spremi"  />
            </div>
            </div>
    </form>
</body>
</html>

