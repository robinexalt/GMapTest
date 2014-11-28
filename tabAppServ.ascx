<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabAppServ.ascx.cs" Inherits="ForeClosure.Admin.tabAppServ" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<table>
    <tr>
        <td style="width: 100%;" align="center">
            <asp:UpdatePanel ID="updpnlappserv" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnlappserv" runat="server">
                        <table width="100%">
                            <tr>
                                <td align="right">
                                    Created By :
                                </td>
                                <td align="left">
                                    <%-- <asp:TextBox ID="txtapuser" runat="server"></asp:TextBox>--%>
                                    <asp:Label ID="lbluser" runat="server" Text='<%#bind("user_name") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    APN :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblapna" runat="server" Text='<%#bind("APN") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Street Address :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblstreetname" runat="server" Text='<% #bind("STREET_NAME") %>'></asp:Label>
                                    ,
                                    <asp:Label ID="lblstdir" runat="server" Text='<% #bind("DIRECTION") %>'></asp:Label>
                                    ,
                                    <asp:Label ID="lblsttype" runat="server" Text='<% #bind("STREET_TYPE") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Status :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblstatus" runat="server" Text='<% #bind("OCCUPIED") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Value :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblvalue" runat="server" Text='<% #bind("PROP_VALUE") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Cost to Fix :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblcost" runat="server" Text='<% #bind("FIX_COST") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Notes :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblnotesa" runat="server" Text='<% #bind("COMMENTS") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    Photos :
                                </td>
                                <td align="left">
                                    <asp:Repeater ID="rptimage" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="img1" runat="server" ImageUrl='<%# Eval("IMAGE_PATH") %>' Height="120px"
                                                Width="120px" />
                                        </ItemTemplate>
                                        <FooterTemplate>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                    <asp:UpdatePanel runat="server" ID="UpdatePanel1" UpdateMode="Always" ChildrenAsTriggers="true">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btnYes" runat="server" Text="Enlarge" ForeColor="Orange"></asp:LinkButton>
                                            <cc1:ModalPopupExtender TargetControlID="btnYes" ID="pnlModal_ModalPopupExtender"
                                                runat="server" Enabled="True" BackgroundCssClass="modalPopupBackground" PopupControlID="pnlModal"
                                                CancelControlID="btnClose">
                                            </cc1:ModalPopupExtender>
                                            <asp:Panel ID="pnlModal" runat="server" Style="display: none;" CssClass="modalPopup">
                                                <div align="right">
                                                    <asp:Button ID="btnClose" runat="server" Text="close" CssClass="button" />
                                                </div>
                                                <div>
                                                    <asp:GridView ID="gvBigImage" runat="server" Width="100%" BorderWidth="0px" AllowPaging="true"
                                                        PageSize="1" BackColor="#f2f2f2" AutoGenerateColumns="false" OnPageIndexChanging="gvBigImage_OnPageIndexChanging">
                                                        <HeaderStyle BackColor="#f2f2f2" BorderStyle="None" />
                                                        <FooterStyle BackColor="#f2f2f2" BorderStyle="None" />
                                                        <PagerStyle BackColor="#f2f2f2" VerticalAlign="Middle" HorizontalAlign="Center" />
                                                        <Columns>
                                                            <asp:TemplateField>
                                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                                <ItemTemplate>
                                                                    <asp:Image ID="img11" runat="server" ImageUrl='<%# Eval("IMAGE_PATH") %>' Width="500px"
                                                                        Height="500px" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                            </asp:Panel>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvBigImage" EventName="PageIndexChanging" />
                                            <asp:AsyncPostBackTrigger ControlID="btnClose" EventName="Click" />
                                            <asp:PostBackTrigger ControlID="btnYes" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:UpdatePanel ID="updpnledit" runat="server" UpdateMode="Always">
                                        <ContentTemplate>
                                            <asp:ImageButton ID="imgtnedit" runat="server" ImageUrl="~/Admin/images/edit.jpg"
                                                OnClick="imgtnedit_Click" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:PostBackTrigger ControlID="imgtnedit" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <asp:Panel ID="pnleditappserv" runat="server" Visible="false">
                        <table width="100%">
                            <tr>
                                <td align="right" class="Lnew">
                                    Created By :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblcreatedby" runat="server" Text='<% #bind("USER_NAME") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    APN :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblapnedit" runat="server" Text='<% #bind("APN") %>'></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Street Address :
                                </td>
                                <td align="left">
                                    <%--<asp:Label ID="lblstreetname" runat="server" Text='<% #bind("STREET_NAME") %>'></asp:Label>--%>
                                    <asp:TextBox ID="txtstreetname" runat="server" CssClass="TBox" Text='<% #bind("STREET_NAME") %>'
                                        TextMode="MultiLine" Width="142px" Height="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Street Direction :
                                </td>
                                <%--<asp:Label ID="lblstdir" runat="server" Text='<% #bind("DIRECTION") %>'></asp:Label>--%>
                                <td align="left">
                                    <asp:DropDownList ID="ddldir" runat="server">
                                        <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                        <asp:ListItem Text="N" Value="N"></asp:ListItem>
                                        <asp:ListItem Text="W" Value="W"></asp:ListItem>
                                        <asp:ListItem Text="E" Value="E"></asp:ListItem>
                                        <asp:ListItem Text="S" Value="S"></asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Street Type :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtsttype" runat="server" Text='<% #bind("STREET_TYPE") %>' CssClass="TBox"
                                        Enabled="false"></asp:TextBox>
                                    <asp:UpdatePanel ID="upddltype" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:TextBox ID="txtnewtype" runat="server" Visible="false"></asp:TextBox>
                                            <asp:DropDownList ID="ddltype" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                                <asp:ListItem Text="--Select--" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="RD" Value="RD"></asp:ListItem>
                                                <asp:ListItem Text="DR" Value="DR"></asp:ListItem>
                                                <asp:ListItem Text="CIR" Value="CIR"></asp:ListItem>
                                                <asp:ListItem Text="CT" Value="CT"></asp:ListItem>
                                                <asp:ListItem Text="AVE" Value="AVE"></asp:ListItem>
                                                <asp:ListItem Text="ST" Value="ST"></asp:ListItem>
                                                <asp:ListItem Text="OTHER TYPE" Value="OTHER TYPE"></asp:ListItem>
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="ddltype" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <%--<asp:Label ID="lblsttype" runat="server" Text='<% #bind("STREET_TYPE") %>'></asp:Label>--%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Status :
                                </td>
                                <td align="left">
                                    <%--<asp:Label ID="lblstatus" runat="server" Text='<% #bind("OCCUPIED") %>'></asp:Label>--%>
                                    <asp:RadioButtonList ID="rdlstvaccent" runat="server">
                                        <asp:ListItem Text="tenent" Value="Tenent"></asp:ListItem>
                                        <asp:ListItem Text="owner" Value="Owner"></asp:ListItem>
                                        <asp:ListItem Text="Vacant" Value="Vacant"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Value :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtvalue" runat="server" Text='<% #bind("PROP_VALUE") %>' CssClass="TBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Cost to Fix :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtcost" runat="server" Text='<% #bind("FIX_COST") %>' CssClass="TBox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="Lnew">
                                    Notes :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtnotesa" runat="server" Text='<% #bind("COMMENTS") %>' CssClass="TBox"
                                        TextMode="MultiLine" Width="142px" Height="50px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    <asp:ImageButton ID="imgbtnsave" runat="server" ImageUrl="~/Admin/images/save.jpg"
                                        OnClick="imgbtnsave_Click" />
                                    <div style="width: 2px; float: left;">
                                    </div>
                                    <asp:ImageButton ID="imgbtncancel" runat="server" ImageUrl="~/Admin/images/cancel.jpg"
                                        OnClick="imgbtncancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
</table>