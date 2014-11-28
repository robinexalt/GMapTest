<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabCompsReport.ascx.cs" Inherits="ForeClosure.Admin.tabCompsReport" %>

<div style="clear: both; margin-top: 25px; width: 75%;">
    <asp:GridView ID="grdFirstRealdata" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblrank" runat="server" Text="#"></asp:Label>
                </HeaderTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbladdresshead" runat="server" Text="Address"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbladdress" runat="server" Text='<% #bind("Address") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="30%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblsalepricehead" runat="server" Text="Sale Price"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblsaleprice" runat="server" Text='<%#bind("SalePrice") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="8%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblyearbuilthead" runat="server" Text="Year Built"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblyearbuilt" runat="server" Text='<%#bind("YearBuilt") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="7%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblbedhead" runat="server" Text="Bed"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblbed" runat="server" Text='<%#bind("Bed") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblbathhead" runat="server" Text="Bath"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblbath" runat="server" Text='<%#bind("Bath") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbllastrecordhead" runat="server" Text="Sale Date"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbllastrecord" runat="server" Text='<%#bind("SaleDate","{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbllivinghead" runat="server" Text="Living Area"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblliving" runat="server" Text='<%#bind("LivingArea") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="15%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbldistancehead" runat="server" Text="Distance"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbldistance" runat="server" Text='<%#bind("Distance") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="15%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <table>
        <tr>
            <td align="center">
                <asp:Label ID="lblheadcomp" runat="server" Text="Comparabale Properties" Font-Size="Smaller"
                    Font-Bold="True"></asp:Label>
            </td>
        </tr>
    </table>

    <asp:GridView ID="grdFirstCompare" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" ShowHeader="False" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblrankc" runat="server" Text='<% #bind("APNIndex") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lbladdressc" runat="server" Text='<% #bind("Address") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" Width="30%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblsalepricec" runat="server" Text='<%#bind("SalePrice","{0:n}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblyearbuiltc" runat="server" Text='<%#bind("YearBuilt") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblbedc" runat="server" Text='<%#bind("Bed") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lblbathc" runat="server" Text='<%#bind("Bath") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lbllastrecordc" runat="server" Text='<%#bind("SaleDate","{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lbllivingc" runat="server" Text='<%#bind("LivingArea") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="15%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Label ID="lbldistancec" runat="server" Text='<%#bind("Distance") %>'></asp:Label>
                </ItemTemplate>
                <ItemStyle Font-Size="Smaller" Width="15%" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>

    <br /><br />
    <asp:GridView ID="grdrealdata" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblrankHeader" runat="server" Text="#"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblrank" runat="server" Text='<% #bind("APNIndex") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle HorizontalAlign="Left" Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblAPNHead" runat="server" Text="APN"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblAPN" runat="server" Text='<% #bind("APN") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" Width="10%" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblOwnersHead" runat="server" Text="Owners"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblOwners" runat="server" Text='<% #bind("Owners") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" Width="10%" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbladdresshead" runat="server" Text="Address"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbladdress" runat="server" Text='<% #bind("Address") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="20%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="20%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblCityHead" runat="server" Text="City"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblCity" runat="server" Text='<% #bind("Situs2") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" Width="10%" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblStateHead" runat="server" Text="State"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblState" runat="server" Text='<% #bind("Situs3") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" Width="5%" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblZIPHead" runat="server" Text="ZIP"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblZIP" runat="server" Text='<% #bind("ZIP") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" Width="5%" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblPhoneNoHead" runat="server" Text="Phone No."></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPhoneNo" runat="server" Text='<% #bind("PhoneNo") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" Width="10%" />
                <ItemStyle Font-Size="Smaller" HorizontalAlign="Left" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbllastrecordhead" runat="server" Text="Last Recording(Rec Date)"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbllastrecord" runat="server" Text='<%#bind("LastRecord","{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblsaledatehead" runat="server" Text="Sale Date"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblsaledate" runat="server" Text='<%#bind("SaleDate","{0:d}") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblsalepricehead" runat="server" Text="Sale Price"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblsaleprice" runat="server" Text='<%#bind("SalePrice") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="8%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="8%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblyearbuilthead" runat="server" Text="Year Built"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblyearbuilt" runat="server" Text='<%#bind("YearBuilt") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="7%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="7%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblbedhead" runat="server" Text="Bed"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblbed" runat="server" Text='<%#bind("Bed") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblbathhead" runat="server" Text="Bath"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblbath" runat="server" Text='<%#bind("Bath") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbllivinghead" runat="server" Text="Living Area"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblliving" runat="server" Text='<%#bind("LivingArea") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblLotAreahead" runat="server" Text="Lot Area"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLotArea" runat="server" Text='<%#bind("LotArea") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblLotAreahead" runat="server" Text="Land Use"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblLotArea" runat="server" Text='<%#bind("LandUse") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lbldistancehead" runat="server" Text="Distance"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lbldistance" runat="server" Text='<%#bind("Distance") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="10%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="10%" />
            </asp:TemplateField>
            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:Label ID="lblPoolhead" runat="server" Text="Pool"></asp:Label>
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:Label ID="lblPool" runat="server" Text='<%#bind("Pool") %>'></asp:Label>
                </ItemTemplate>
                <HeaderStyle Width="5%" BackColor="#DDDDDD" Font-Size="Smaller" Font-Bold="True" />
                <ItemStyle Font-Size="Smaller" Width="5%" />
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
    </asp:GridView>
</div>
