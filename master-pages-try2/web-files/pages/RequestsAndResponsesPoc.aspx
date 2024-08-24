<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="RequestsAndResponsesPoc.aspx.cs" Inherits="master_pages_try2.web_files.pages.RequestsAndResponsesPoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">


    <div style="text-align: center">
        <label for ="req1">Type something in request1</label>
      <input type ="text" name="req1" id="req1id" />
    <%Response.Write("I am some custom (made manually) Response object"); %>
    <br />
    <%="And I shortcut of response written by '='" %>

    <p>Click here and get the the response values:</p>
    <input type="submit" name="submit" id="submit1" />
    <br />
    <%="Request Form:" %>
   <p> <%=Request.Form %></p>

    <p>Specific field (req1): <%= Request.Form["req1"] %></p>

        <a href ="chrome-extension://efaidnbmnnnibpcajpcglclefindmkaj/https://webprogramming.azurewebsites.net/Pages/ASP/PDF/Request&Response.pdf">Documentation</a>

</div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="QuickLoginUI" runat="server">
</asp:Content>
