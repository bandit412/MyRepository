﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="TrackCRUD.aspx.cs" Inherits="Admin_TrackCRUD" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <div class="jumbotron">
        <h2>Wired ListView CRUD</h2>
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />

    <asp:ListView ID="TrackList" runat="server">
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table runat="server" id="itemPlaceholderContainer"
                            style="background-color:#ffffff;border-collapse: collapse; border-color: #999999; border-style: none; border-width: 1px;" border="1">
                            <tr runat="server" style="background-color: #dcdcdc; color:#000000;">
                                <th runat="server">&nbsp;</th>
                                <th runat="server">Id&nbsp&nbsp;</th>
                                <th runat="server">Name&nbsp&nbsp;</th>
                                <th runat="server">Album&nbsp&nbsp;</th>
                                <th runat="server">Media Type&nbsp&nbsp;</th>
                                <th runat="server">Genre&nbsp&nbsp;</th>
                                <th runat="server">Composer&nbsp&nbsp;</th>
                                <th runat="server">MSec&nbsp&nbsp;</th>
                                <th runat="server">Bytes&nbsp&nbsp;</th>
                                <th runat="server">Price&nbsp&nbsp;</th>
                            </tr>
                            <tr runat="server" id="itemPlaceholder"></tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server">
                        <asp:DataPager ID="DataPager1" runat="server">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="true" ShowNextPageButton="false" ShowPreviousPageButton="false" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>

        <ItemTemplate>
            <tr>    
                <td>
                    <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Delete" />
                    <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Edit" />
                </td>
                <td>
                    <asp:Label ID="TrackIdLabel" runat="server" Text='<%#Eval("TrackId") %>' Width="75px"/>
                </td>
                <td>
                    <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />
                </td> 
                <td>
                    <asp:DropDownList ID="AlbumList" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="MediaTypeList" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:DropDownList ID="GenreList" runat="server"></asp:DropDownList>
                </td>
                <td>
                    <asp:Label ID="ComposerLabel" runat="server" Text='<%#Eval("Composer") %>' />
                </td>
                <td>
                    <asp:Label ID="MillisecondsLabel" runat="server" Text='<%#Eval("Milliseconds") %>' />
                </td>
                <td>
                    <asp:Label ID="BytesLabel" runat="server" Text='<%#Eval("Bytes") %>' />
                </td>
                <td>
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%#Eval("UnitPrice") %>' />
                </td>
            </tr>
        </ItemTemplate>

        <EditItemTemplate>

        </EditItemTemplate>

        <InsertItemTemplate>

        </InsertItemTemplate>

        <SelectedItemTemplate>

        </SelectedItemTemplate>
        
        <EmptyDataTemplate>

        </EmptyDataTemplate>
    </asp:ListView>

    <asp:ObjectDataSource ID="TrackListODS" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AlbumListODS" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MediaTypeListODS" runat="server"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GenreListODS" runat="server"></asp:ObjectDataSource>
</asp:Content>

