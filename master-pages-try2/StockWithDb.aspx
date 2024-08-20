<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="StockWithDb.aspx.cs" Inherits="master_pages_try2.StockWithDb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Stock with Database demo</h2>

    <p>
        For this page will work you need to create a DB named "master-page-try" 


        and put the correct connection name (take it from the server setting and 
        remove the problematic values
    </p>

    <p>
        data = 

        <asp:Label ID="dbData" runat="server"></asp:Label>

    </p>

    <h2>Add user </h2>
    <div>
        <asp:Label ID="lblUserName" runat="server" Text="User Name:"></asp:Label>
        <asp:TextBox ID="OfUserName" runat="server"></asp:TextBox>

        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>

        <%--        <asp:RequiredFieldValidator 
            ID="rfv" 
            runat="server" 
            ControlToValidate="OfNameInput" 
            ErrorMessage="חייב לרשום טקסט" 
            ForeColor="Green" />--%>

        <asp:TextBox ID="OfPassword" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Email:"></asp:Label>
        <asp:TextBox ID="OfEmail" runat="server" TextMode="Email"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="Comment:"></asp:Label>
        <asp:TextBox ID="OfComment" runat="server" TextMode="SingleLine"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" Text="Add User" OnClick="AddNewUser" />

        <asp:Label ID="Label3" runat="server"></asp:Label>


        
    <h2>Users List</h2>

    <asp:Table runat="server" ID="UsersTable" BorderWidth="1" GridLines="Both" CellPadding="10">
        <asp:TableHeaderRow ID="Table1HeaderRow" BackColor="LightBlue" runat="server">
            <asp:TableHeaderCell Scope="Column" Text="Username" />
            <asp:TableHeaderCell Scope="Column" Text="Email" />
            <asp:TableHeaderCell Scope="Column" Text="Birthday" />
            <asp:TableHeaderCell Scope="Column" Text="City" />
            <asp:TableHeaderCell Scope="Column" Text="Is Admin" />
        </asp:TableHeaderRow>
    </asp:Table>
    </div>
</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="QuickLoginUI" runat="server">

</asp:Content>
