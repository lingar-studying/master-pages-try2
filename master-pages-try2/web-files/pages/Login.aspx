<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="master_pages_try2.web_files.pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <h1>Login</h1>

    <div>
        <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
        <asp:TextBox ID="OfUserName" runat="server"></asp:TextBox>

        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>

        <asp:TextBox ID="OfPassword" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="ErrorMsg" runat="server" ForeColor="red" Font-Size="Larger"></asp:Label>
        <asp:Button ID="Button3" runat="server" Text="Add User" OnClick="LoginUser" OnClientClick="  return validateUserForm();" />
    </div>
    <script>
        function validateUserForm() {
            console.log("validate");
            const username = document.getElementById('<%= OfUserName.ClientID %>').value;
            const password = document.getElementById('<%= OfPassword.ClientID %>').value;


            let el = document.getElementById('<%=ErrorMsg.ClientID%>');

            if (username.trim() === "") {
                el.innerHTML = "Username is required.";


                return false;
            }
            if (password.trim() === "") {
                el.innerHTML = "Password is required.";

                return false;
            }


            return true;
        }

    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="QuickLoginUI" runat="server">
</asp:Content>
