<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCustomer.aspx.cs" Inherits="RWA.WebForms.EditCustomer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title> Uredite kupca </title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-control">
            <input runat="server" type="text" id="firstName"/>
                           
            <input runat="server" type="text" id="lastName" />
            <input runat="server" type="text" id="phone" />
            <input runat="server" type="text" id="email" />     
            <asp:DropDownList id="dlTowns" runat="server"></asp:DropDownList>
           </div> 

    </form>
</body>
</html>
