<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AccessingDataSetControls.aspx.cs" Inherits="BusinessProcesses_AccessingDataSetControls" %>

<%@ Register Src="~/UserControls/MessageUserControl.ascx" TagPrefix="uc1" TagName="MessageUserControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ObjectDataSource ID="AlbumListODS" runat="server" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="AlbumList" 
        TypeName="ChinookSystem.BLL.AlbumController"
        OnSelected="CheckForException">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="TracksDataODS" runat="server"
        DataObjectTypeName="ChinookSystem.Data.Entities.Track" 
        OldValuesParameterFormatString="original_{0}" 
        SelectMethod="TracksForPlaylistSelection_Get" 
        TypeName="ChinookSystem.BLL.TrackController"
        OnSelected="CheckForException">
        <SelectParameters>
            <asp:ControlParameter ControlID="AlbumList" PropertyName="Text" Name="id" Type="Int32"></asp:ControlParameter>
            <asp:ControlParameter ControlID="TracksBy" PropertyName="Text" Name="fetchBy" Type="String"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    <div class="row jumbotron">
        <h2>Demonstrating Access to GridView and ListView</h2>
    </div>
    <div class="row">
        <uc1:MessageUserControl runat="server" ID="MessageUserControl" />
    </div>
    <div class="row">
        <asp:Panel ID="ControlPanel" runat="server">
            <asp:Label ID="TracksBy" runat="server" Text="Album"></asp:Label>&nbsp;
            <asp:DropDownList ID="AlbumList" runat="server"
                AppendDataBoundItems="true"
                DataSourceID="AlbumListODS"
                DataTextField="DisplayText"
                DataValueField="PFKeyIdentifier">
                <asp:ListItem Value="0">Select Album</asp:ListItem>
            </asp:DropDownList>&nbsp;
            <asp:LinkButton ID="Fetch" runat="server">Fetch Tracks</asp:LinkButton>
            <asp:GridView ID="TracksListGV" runat="server" 
                AutoGenerateColumns="false" 
                DataSourceID="TracksDataODS" OnSelectedIndexChanged="TracksListGV_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField HeaderText="Name" DataField="Name" />
                    <asp:BoundField HeaderText="Milliseconds" DataField="Milliseconds" />
                    <asp:TemplateField HeaderText="Size">
                        <ItemTemplate>
                            <asp:Label ID="Bytes" runat="server" Text='<%# Eval("Bytes") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="$">
                        <ItemTemplate>
                            <asp:TextBox ID="UnitPrice" runat="server"
                                Text='<%# string.Format("{0:0.00}", Eval("UnitPrice")) %>'></asp:TextBox>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:CommandField ShowSelectButton="true" />
                </Columns>
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
            </asp:GridView>
            <br />
            <asp:Button ID="WalkThroughGV" runat="server" Text="Walk Through (GV)" OnClick="WalkThroughGV_Click" />
            <br /><br />
            <asp:ListView ID="TracksListLV" runat="server" DataSourceID="TracksDataODS" OnItemCommand="TracksListLV_ItemCommand">
                <EmptyDataTemplate>
                    No data to display
                </EmptyDataTemplate>
                <LayoutTemplate>
                    <table runat="server">
                        <tr runat="server" style="background-color: #DCDCDC; color: #000000;">
                            <th runat="server">
                                Name
                            </th>
                            <th runat="server">
                                Milliseconds
                            </th>
                            <th runat="server">
                                Size
                            </th>
                            <th runat="server">
                                $
                            </th>
                            <th runat="server"></th>
                        </tr>
                        <tr runat="server" id="itemPlaceholder"></tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr style=" color: #000000;">
                        <td>
                            <asp:Label ID="Name" runat="server" Text='<%# Eval("Name") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Milliseconds" runat="server" Text='<%# Eval("Milliseconds") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="Bytes" runat="server" Text='<%# Eval("Bytes") %>'></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="UnitPrice" runat="server" Text='<%# string.Format("{0:0.00}", Eval("UnitPrice")) %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button runat="server" ID="SelectButton" CommandName="Select" Text="Select" /> 
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <asp:Button ID="WalkThroughLV" runat="server" Text="Walk Through (LV)" OnClick="WalkThroughLV_Click" />
        </asp:Panel>
    </div>
</asp:Content>

