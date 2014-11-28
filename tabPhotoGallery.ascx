<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabPhotoGallery.ascx.cs" Inherits="ForeClosure.Admin.tabPhotoGallery" %>

<table width="100%">
    <tr>
        <td align="center">
            <table width="70%">
                <tr>
                    <td align="center">
                        <asp:Panel ID="pnlFriends" runat="server" Height="100%" Width="60%">
                            <asp:DataList ID="DataListFriends" runat="server" DataKeyField="APN" RepeatColumns="2"
                                CellPadding="4" CellSpacing="20" RepeatDirection="Horizontal" Width="100%" DataSourceID="SqlDataSource1">
                                <ItemStyle BorderStyle="Double" BorderWidth="2px" HorizontalAlign="Left" VerticalAlign="Top"
                                    Width="20%" />
                                <ItemTemplate>
                                    <table>
                                        <tr>
                                            <td>
                                                <img alt='<%# Eval("APN") %>' src='<%#Eval("Path") %>' height="200" width="200" style="border: 0" />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <a href='<%#Eval("Path") %>' rel="lightbox">
                                                    <asp:ImageButton ID="imgbtnZoom" runat="server" ImageUrl="~/Admin/images/Zoom-icon.png" />
                                                </a>&nbsp;
                                                <asp:ImageButton ID="imgbtnDelete" runat="server" CommandArgument='<%#Eval("Path") %>'
                                                    CommandName="Delete" ImageUrl="~/Admin/images/btn-Delete.png" OnClick="imgbtnDelete_Click"
                                                    OnClientClick="return confirm('Are you sure you want to delete this Record?');" />
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:DataList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ForeClosure %>"
                                SelectCommand="SELECT * FROM [RecieveMailDetails] WHERE ([APN] = @APN)">
                                <SelectParameters>
                                    <asp:SessionParameter Name="APN" SessionField="MainAPN" Type="String" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
