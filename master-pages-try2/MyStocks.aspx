﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="MyStocks.aspx.cs" Inherits="master_pages_try2.MyStocks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        First stock:    
        <asp:Label ID="StocksArea" runat="server"></asp:Label>
    </p>
    <h2>Here are the available stocks:</h2>

    <%-- How to make for: https://stackoverflow.com/questions/14732801/how-to-loop-through-data-in-webforms-like-in-mvc --%>


    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div><%# Container.DataItem %></div>
            <strong>Offical Name:</strong> <%# Eval("OfficialName") %>
            <br />

        </ItemTemplate>
    </asp:Repeater>

    <h3>Dynamic area...
        <br />
        Add Stock</h3>
    <h3>I am page of...
        <asp:Label runat="server" ID="MyTitle"><span>???? - click the button for explore</span></asp:Label>
    </h3>
    <asp:Button ID="Button1" runat="server" Text="Do some method" OnClick="DoSomething" />
    <asp:Button ID="Button2" runat="server" Text="Update some stock" OnClick="UpdateSomeStock" />


 
        <div>
            <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

            <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label>
            <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />

            <asp:Label ID="lblResult" runat="server"></asp:Label>
        </div>

   


</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="QuickLoginUI" runat="server">
</asp:Content>