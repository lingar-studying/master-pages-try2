<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyStocks.aspx.cs" Inherits="master_pages_try2.MyStocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Here are the available stocks:</h2>
    <asp:Label ID="StocksArea" runat="server"></asp:Label>

    <%-- How to make for: https://stackoverflow.com/questions/14732801/how-to-loop-through-data-in-webforms-like-in-mvc --%>


    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div><%# Container.DataItem %></div>
            <strong>Offical Name:</strong> <%# Eval("OfficialName") %> <br />

        </ItemTemplate>
    </asp:Repeater>


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="QuickLoginUI" runat="server">
</asp:Content>
