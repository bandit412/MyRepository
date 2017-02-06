<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="FirstSample.aspx.cs" Inherits="SampleQueries_FirstSample" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Entity vs. LINQ to Entity Query</h1>
    <asp:ObjectDataSource ID="EntityFrameworkODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="Artist_ListAll" TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="LinqToEntityODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="ArtistAlbums_Get" TypeName="ChinookSystem.BLL.ArtistController">
        <SelectParameters>
            <asp:Parameter Name="year" Type="Int32"></asp:Parameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:GridView ID="EntityFrameworkList" runat="server"></asp:GridView>
    <asp:GridView ID="LinqToEntityList" runat="server"></asp:GridView>
</asp:Content>
