<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="lingar-home.aspx.cs" Inherits="master_pages_try2.lingar_home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    Here is my header lingar 

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" class ="regular-page">

    <h1>Home page lingar</h1>

</asp:Content>


<%--<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class ="regular-page">Main Area</h1>

</asp:Content>--%>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder2">

    Added automatically 
</asp:Content>



