<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabMap2.ascx.cs" Inherits="ForeClosure.Admin.tabMap2" %>
<table width="75%">
    <tr>
        <td>
            <asp:Label ID="lblmsg" runat="server" Text="No. Records available...!!" Font-Bold="True"
                ForeColor="Red" Visible="False"></asp:Label>
        </td>
    </tr>
</table>
<table width="75%">
    <tr>
        <td>
            <table width="100%">
                <tr>
                    <td align="left">
                        <asp:Label ID="Label1" runat="server" Text="Street Map Plus Report" Font-Bold="True"
                            Font-Size="X-Large" ForeColor="#333399"></asp:Label>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="For Property Located At" Font-Bold="True"></asp:Label>
                    </td>
                    <td>
                        <asp:Image ID="imglogo1" runat="server" ImageUrl="~/images/defaultlogo.jpg" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
<table width="75%">
    <tr>
        <td colspan="2" align="left">
            <asp:Label ID="lbladd" runat="server"></asp:Label>
        </td>
    </tr>
</table>
<div id="GoogleMap_Div_Container">
    <div id="GoogleMap_Div" style="width: 75%; height: 600px;">
    </div>
</div>
