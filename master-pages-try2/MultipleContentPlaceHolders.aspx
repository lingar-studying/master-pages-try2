<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MultipleContentPlaceHolders.aspx.cs" Inherits="master_pages_try2.MultipleContentPlaceHolders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">

    My main content 
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h3>Page-Specific Content</h3>
    <ul>
        <li>This content is defined in the content page.</li>
        <li>The master page has two regions in the Web Form that are editable on a
 page-by-page basis.</li>
    </ul>
</asp:Content>
