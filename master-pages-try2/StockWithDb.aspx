<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StockWithDb.aspx.cs" Inherits="master_pages_try2.StockWithDb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Stock with Database demo</h2>

    <p>For this page will work you need to create a DB named "master-page-try" 


        and put the correct connection name (take it from the server setting and 
        remove the problematic values
    </p>

    <p> data = 

        <asp:Label ID ="dbData" runat="server"></asp:Label>

    </p>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="QuickLoginUI" runat="server">
</asp:Content>
