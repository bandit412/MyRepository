<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ManagePlayList.aspx.cs" Inherits="BusinessProcesses_ManagePlayList" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="jumbotron">
        <h2>Manage Playlist</h2>
    </div>
    <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    <div class="row">
        <div class="col-sm-3">
            <asp:Label ID="ArtistLabel" runat="server" Text="Artist" /><br />
            <asp:DropDownList ID="ArtistrList" runat="server" Width="300px"
                DataSourceID="ArtistListODS"
                DataTextField="DisplayText"
                DataValueField="PFKeyIdentifier">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="ArtistFetch" runat="server" Text="Fetch" CssClass="btn btn-primary" OnClick="ArtistFetch_Click" />
            <br />
            <br />

            <asp:Label ID="MediaTypeLabel" runat="server" Text="Media Type" /><br />
            <asp:DropDownList ID="MediaTypeList" runat="server" Width="300px"
                DataSourceID="MediaTypeListODS"
                DataTextField="DisplayText"
                DataValueField="PFKeyIdentifier">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="MediaTypeFetch" runat="server" Text="Fetch" CssClass="btn btn-primary" OnClick="MediaTypeFetch_Click" />
            <br />
            <br />

            <asp:Label ID="GenreLabel" runat="server" Text="Genre" /><br />
            <asp:DropDownList ID="GenreList" runat="server" Width="300px"
                DataSourceID="GenreListODS"
                DataTextField="DisplayText"
                DataValueField="PFKeyIdentifier">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="GenreFetch" runat="server" Text="Fetch" CssClass="btn btn-primary" OnClick="GenreFetch_Click" />
            <br />
            <br />

            <asp:Label ID="AlbumLabel" runat="server" Text="Album" /><br />
            <asp:DropDownList ID="AlbumList" runat="server" Width="300px"
                DataSourceID="AlbumListODS"
                DataTextField="DisplayText"
                DataValueField="PFKeyIdentifier">
            </asp:DropDownList>
            &nbsp;&nbsp;
            <asp:Button ID="AlbumFetch" runat="server" Text="Fetch" CssClass="btn btn-primary" OnClick="AlbumFetch_Click" />
            <br />
            <br />
        </div>

        <div class="sm-9">
            <asp:Label ID="ListViewLabel" runat="server" Text="Tracks by " />
            <asp:Label ID="TracksBy" runat="server" />
            <asp:Label ID="SearchArgID" runat="server" Visible="false" />
            <asp:ListView ID="TrackSearchList" runat="server"
                DataSourceID="TracksForSelectionODS"
                OnItemCommand="TrackSearchList_ItemCommand">
                <EmptyDataTemplate>
                    <tr>
                        <td>No data was returned ...</td>
                    </tr>
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server">
                            <td runat="server">
                                <table runat="server" id="itemPlaceholderContainer" style="" border="0">
                                    <tr runat="server" style="">
                                        <th runat="server">TrackId&nbsp;&nbsp;</th>
                                        <th runat="server">Name&nbsp;&nbsp;</th>
                                        <th runat="server">Title&nbsp;&nbsp;</th>
                                        <th runat="server">Media Type&nbsp;&nbsp;</th>
                                        <th runat="server">Genre&nbsp;&nbsp;</th>
                                        <th runat="server">Composer&nbsp;&nbsp;</th>
                                        <th runat="server">MSec&nbsp;&nbsp;</th>
                                        <th runat="server">Bytes&nbsp;&nbsp;</th>
                                        <th runat="server">Price&nbsp;&nbsp;</th>
                                    </tr>
                                    <tr runat="server" id="itemPlaceholder"></tr>
                                </table>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td runat="server" style="">
                                <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                                    <Fields>
                                        <asp:NumericPagerField ButtonType="Button" ButtonCount="4" />
                                    </Fields>
                                </asp:DataPager>
                            </td>
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:LinkButton ID="AddToPlaylist" runat="server" CssClass="btn" CommandArgument='<%#Eval("TrackId") %>'>
                            <span aria-hidden="true" class="glyphicon glyphicon-plus"></span>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:Label ID="NameLabel" runat="server" Text='<%#Eval("Name") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="TitleLabel" runat="server" Text='<%#Eval("Title") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="MediaTypeLabel" runat="server" Text='<%#Eval("MediaName") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="GenreLabel" runat="server" Text='<%#Eval("GenreName") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="ComposerLabel" runat="server" Text='<%#Eval("Composer") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="MSecLabel" runat="server" Text='<%#Eval("Milliseconds") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="BytesLabel" runat="server" Text='<%#Eval("Bytes") %>' />&nbsp;&nbsp;
                        </td>
                        <td>
                            <asp:Label ID="UnitPriceLabel" runat="server" Text='<%#Eval("UnitPrice") %>' />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <asp:Label ID="PlayListSearchLabel" runat="server" Text="Playlist" />
            &nbsp;&nbsp;
            <asp:TextBox ID="PlaylistName" runat="server" />&nbsp&nbsp;
            <asp:Button ID="PlaylistFetch" runat="server" CssClass="btn btn-primary" Text="Fetch" OnClick="PlaylistFetch_Click" />
            &nbsp;&nbsp;
            <asp:LinkButton ID="DeleteTrack" runat="server" CssClass="btn">
                <span aria-hidden="true" class="glyphicon glyphicon-remove" style="color:red;"></span>
            </asp:LinkButton>
            <br />
            <br />

            <asp:GridView ID="CurrentPlaylist" runat="server"
                AutoGenerateColumns="false"
                Caption="Playlist"
                GridLines="Horizontal"
                BorderStyle="None">
                <Columns>
                    <asp:TemplateField HeaderText="Name">
                        <ItemTemplate>
                            <asp:Label ID="PL_Name" runat="server" Text='<%#Bind("Name") %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Album">
                        <ItemTemplate>
                            <asp:Label ID="PL_Album" runat="server" Text='<%#Bind("Title") %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="MSec">
                        <ItemTemplate>
                            <asp:Label ID="PL_MSec" runat="server" Text='<%#Bind("Milliseconds") %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="$">
                        <ItemTemplate>
                            <asp:Label ID="PL_Price" runat="server" Text='<%#Bind("UnitPrice") %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Pd">
                        <ItemTemplate>
                            <asp:CheckBox ID="PL_Paid" runat="server" Checked='<%#Bind("Purchased") %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="PL_TrackNumber" runat="server" Text='<%#Bind("TrackNumber") %>' />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Label ID="PL_TrackID" runat="server" Text='<%#Bind("TrackId") %>' Visible="false" />&nbsp;&nbsp;
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <asp:ObjectDataSource ID="ArtistListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="ArtistList"
        TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="MediaTypeListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="MediaTypeList"
        TypeName="ChinookSystem.BLL.MediaTypeController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="GenreListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="GenreList"
        TypeName="ChinookSystem.BLL.GenreController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="AlbumListODS" runat="server"
        OldValuesParameterFormatString="original_{0}"
        SelectMethod="AlbumList"
        TypeName="ChinookSystem.BLL.AlbumController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TracksForSelectionODS" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="TracksForPlaylistSelection_Get" TypeName="ChinookSystem.BLL.TrackController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SearchArgID"
                PropertyName="Text" Name="id" Type="Int32"></asp:ControlParameter>
            <asp:ControlParameter ControlID="TracksBy"
                PropertyName="Text" Name="fetchBy" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

