<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstSample.aspx.cs" Inherits="SampleQueries_FirstSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Entity vs. LINQ to Entity Query</h1>
    <asp:ObjectDataSource ID="EntityFrameworkODS" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LinqToEntityODS" runat="server"></asp:ObjectDataSource>
    <asp:GridView ID="EntityFrameworkList" runat="server"></asp:GridView>
    <asp:GridView ID="LinqToEntityList" runat="server"></asp:GridView>
</asp:Content>
