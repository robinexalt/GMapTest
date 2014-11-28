<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="tabMasterSlip.ascx.cs" Inherits="ForeClosure.Admin.tabMasterSlip" %>

<style type="text/css">
    .table{background-color: #ffffff; padding: 4px; text-align: left; border: 1px #000000 solid;}
    .table1{width:100%;border-right:1px solid #000;border-top:1px solid #000;}
    .table1 td{border-left:1px solid #000;border-bottom:1px solid #000;height:20px;}
    .table1 thead td{width:33%;text-align:center;}
</style>

<script type="text/javascript">
    $(function () {
        $('#chkMSlip').change(function () {
            <%
            if(chkMSlip.Checked)
                Session["Masterslip"] = "true";
            else
                Session["Masterslip"] = "false";
            %>
        });
        $('#chkMLS').change(function () {
            <%
            if (chkMLS.Checked )
                Session["Comps"] = "true";
            else
                Session["Comps"] = "false";
            %>
        });
        $('#chkOtherup').change(function () {
            <%
            if (chkOtherup.Checked == true)
                Session["Images"] = "true";
            else
                Session["Images"] = "false";
            %>
        });
    }); 
</script>
  <table width="100%" class="table">
            <tr>
                <td align="left" colspan="2">
                    <asp:RadioButtonList runat="server" ID="rdlStatus" Font-Bold="False" Font-Names="Arial"
                        Font-Size="Larger" RepeatDirection="Horizontal">
                        <asp:ListItem Value="16">Active</asp:ListItem>
                        <asp:ListItem Value="17">Pass</asp:ListItem>
                        <asp:ListItem Value="18">Awaiting Designation</asp:ListItem>
                        <asp:ListItem Value="20">No Match</asp:ListItem>
                        <asp:ListItem Value="21">Postponed</asp:ListItem>
                         <asp:ListItem Value="22">Sold</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td valign="top">
                    <table width="100%" class="table">
                        <tr>
                            <td width="20%" valign="top">
                                <asp:Label CssClass="Lable" ID="lblauction" runat="server" Text="AUCTION :"></asp:Label>
                            </td>
                            <td align="left" valign="top">
                                <asp:TextBox runat="server" ID="txtauctionvalue" CssClass="Textbox" Width="100%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
                <td style="width: 50%" valign="top">
                    <table class="table" width="100%">
                        <tr>
                            <td width="10%">
                                <asp:Label ID="lblTS" runat="server" Text="TS :" CssClass="Lable"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox CssClass="Textbox" ID="txtTSValue" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
                                <tr>
                                    <td valign="top">
                                        <table width="100%" class="table">
                                            <tr>
                                                <td width="20%" valign="top">
                                                    <asp:Label ID="lbladdress" runat="server" CssClass="Lable" Text="ADDRESS :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtaddressvalue" runat="server" CssClass="Textbox" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 30%" valign="top">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td width="10%">
                                                    <asp:Label ID="lblAPN" runat="server" Text="APN :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtAPNValue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td style="width: 50%">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td width="20%" valign="top">
                                                    <asp:Label ID="lbltrustee" runat="server" Text="TRUSTEE :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txttrusteevalue" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="30%" valign="top">
                                                    <asp:Label ID="lblbeneficiary" runat="server" Text="BENEFICIARY :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtbeneficiaryvalue" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lbltrustor" runat="server" Text="TRUSTOR :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txttrustorvalue" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lbladdressn" runat="server" Text="ADDRESS :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtaddressnvalue" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 50%" valign="top">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td width="42%">
                                                    <asp:Label ID="lblopeningbid" runat="server" Text="OPENING BID :" CssClass="Lable"></asp:Label>
                                                    &#160;
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtopeningbidvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblpublishedbid" runat="server" Text="PUBLISHED BID :" CssClass="Lable"></asp:Label>
                                                    &#160;
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtpublishedbidvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblTDrecorded" runat="server" Text="TD RECORDED :" CssClass="Lable"></asp:Label>
                                                    &#160;
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtTDrecordedvalue" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td valign="top">
                                                    <asp:Label ID="lblnoticesale" runat="server" Text="NOTICE OF SALE REC :" CssClass="Lable"></asp:Label>
                                                    &#160;
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtnoticesalevalue" runat="server" Width="100%"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            &#160; &#160;
                            <table width="100%">
                                <tr>
                                    <td style="width: 45%">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblUnits" runat="server" Text="UNITS :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox Width="40%" ID="txtUnitsvalue" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblYR" runat="server" Text="YR BUILT :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtYRvalue" runat="server" Height="16px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblBD" runat="server" Text="BD :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox Width="40%" ID="txtBDvalue" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblsqft" runat="server" Text="SQFT :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtsqftvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="right">
                                                    <asp:Label ID="lblBA" runat="server" Text="BA :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox Width="40%" ID="txtbavalue" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblLOT" runat="server" Text="LOT :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td width="25%" style="width: 12%">
                                                    <asp:TextBox CssClass="Textbox" ID="txtLOTvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td style="width: 55%">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblTMG" runat="server" Text="TMG :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtTMGvalue" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right" width="25%">
                                                    <asp:Label ID="lblestval" runat="server" Text="EST VALUE :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtestvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblUSE" runat="server" Text="USE :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtUSEvalue" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right" width="30%">
                                                    <asp:Label ID="lblequity" runat="server" Text="EQUITY % :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td align="right" valign="middle">
                                                    <asp:TextBox CssClass="Textbox" ID="txtequvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td width="20%">
                                                    <asp:Label ID="lblzoning" runat="server" Text="ZONING :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtzoningvalue" runat="server"></asp:TextBox>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblLeagal" runat="server" Text="LEGAL :" CssClass="Lable"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox CssClass="Textbox" ID="txtleagalvalue" runat="server"></asp:TextBox>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="lblabridged" runat="server" Text="ABRIDGED TITLE :" CssClass="Lable"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lbltrustdeed" runat="server" Text="TRUST DEED :" CssClass="Lable"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblrecdate" runat="server" Text="REC DATE :" CssClass="Lable"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lbldoc" runat="server" Text="DOC# :" CssClass="Lable"></asp:Label>
                                    </td>
                                    <td align="center">
                                        <asp:Label ID="lblloanamount" runat="server" Text="LOAN AMOUNT :" CssClass="Lable"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtabridge1" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan1recdate" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan1doc" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan1amt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                              <%--  <tr>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtabridge2" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan2recdate" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan2doc" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan2amt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtabridge3" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan3recdate" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan3doc" runat="server"></asp:TextBox>
                                    </td>
                                    <td align="center">
                                        <asp:TextBox CssClass="Textbox" ID="txtloan3amt" runat="server"></asp:TextBox>
                                    </td>
                                </tr>--%>
                            </table>
                            <table width="100%">
                                <tr>
                                    <td valign="top">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblappraisal" runat="server" Text="APPRAISAL REPORT :" CssClass="Lable"></asp:Label>
                                                    <asp:TextBox ID="txtappreport" runat="server" TextMode="MultiLine" Height="170px"
                                                        Width="100%"></asp:TextBox>
                                                    <div id="dropZone">
                                                        <span class="message">Drop files here to upload</span>
                                                    </div>
                                                    <div id="dropedFiles">
                                                        <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="link1">
                                                                    <%#(((RepeaterItem)Container).ItemIndex+1).ToString() %>.
                                                                    <asp:HyperLink ID="hypFilename" runat="server" NavigateUrl='<%# "Download.aspx?path=" + Server.UrlEncode(Eval("Path").ToString()) %>' Target="_blank" ><%# Eval("Filename") %></asp:HyperLink> 
                                                                    <%--<asp:LinkButton ID="lnkFilename" CommandName="download" CommandArgument='<%# Eval("Path") %>' runat="server"><%# Eval("Filename") %></asp:LinkButton>--%>
                                                                    <asp:LinkButton ID="lnkRemove" CommandName="delete" CommandArgument='<%# Eval("Path") %>' runat="server" OnClientClick="return confirm('Are you sure you want to remove this uploaded file?')">(Remove)</asp:LinkButton>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table" width="100%">
                                                        <tr>
                                                            <td style="border-bottom:1px solid #000;">
                                                                Agent / Appraisar :</td>
                                                            <td align="left"  style="border-bottom:1px solid #000;">
                                                                Date :</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <asp:Label ID="lblvalfix" runat="server" Text="Zillow Value :" CssClass="Lable"></asp:Label>
                                                                <br />
                                                                <asp:TextBox CssClass="Textbox" ID="txtvalfix" runat="server" OnKeyPress="NumericOnly()"></asp:TextBox>
                                                            </td>
                                                            <td align="left">
                                                                <asp:Label ID="lblasis" runat="server" Text="Zillow Rent  :" CssClass="Lable"></asp:Label>
                                                                <br />
                                                                <asp:TextBox CssClass="Textbox" ID="txtZestimate" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td valign="top">
                                        <table class="table" width="100%">
                                            <tr>
                                                <td style="border-bottom:1px solid #000;">
                                                    Date :
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td width="100%" style="height:283px;width:33%; vertical-align:top;border-right:1px solid #000;">
                                                                <asp:Label ID="lblnotes" runat="server" Text="TITLE  :" CssClass="Lable"></asp:Label>
                                                                <br />
                                                                <asp:TextBox ID="txttitle" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td width="100%" style="width:33%;vertical-align:top; border-right:1px solid #000;">
                                                                <asp:Label ID="lblGi" runat="server" Text="GI :" CssClass="Lable"></asp:Label>
                                                                <br />
                                                                <asp:TextBox ID="txtgi" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                            <td width="100%" style="width:33%;vertical-align:top;">
                                                                <asp:Label ID="lbltaxes" runat="server" Text="TAXES :" CssClass="Lable"></asp:Label>
                                                                <br />
                                                                $<asp:TextBox ID="txtTaxes" runat="server" TextMode="MultiLine"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table class="table" width="100%">
                                                        <tr>
                                                            <td height="183px" valign="top" style="width:50%;">
                                                                <table class="table1" cellpadding="0" cellspacing="0" border="0">
                                                                    <thead>
                                                                        <tr>
                                                                            <td>A</td>
                                                                            <td>B</td>
                                                                            <td>C</td>
                                                                        </tr>
                                                                    </thead>
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>Cap</td>
                                                                            <td colspan="2"></td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Rent</td>
                                                                            <td colspan="2">$</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Rehab</td>
                                                                            <td colspan="2">$</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Taxes</td>
                                                                            <td colspan="2">$</td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>Bid</td>
                                                                            <td colspan="2">$</td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                            <td valign="top" style="width:50%;">
                                                                <table width="100%" style="height:127px;" class="table">
                                                                    <tr>
                                                                        <td style="vertical-align:top;">
                                                                            Notes :
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <table class="table" width="100%">
                                <tr>
                                    <td align="left" valign="top">
                                        <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
                                        &#160;<asp:Button ID="btnCancel" runat="server" Text="Cancel" />
                                    </td>
                                    <td>
                                        <table class="table" width="100%">
                                            <tr>
                                                <td>
                                                    <table width="100%">
                                                        <tr>
                                                            <td style="width: 35%" align="left">
                                                                <table>
                                                                    <tr>
                                                                        <td>
                                                                            <asp:DropDownList ID="ddlPrinter" runat="server" Width="190px">
                                                                            </asp:DropDownList>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Button ID="btnPrint" runat="server" Text="Print" OnClick="btnPrint_Click" />
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                            <td style="width: 40%">
                                                                <asp:CheckBox ID="chkMSlip" runat="server" CssClass="Lable" Text="Master Slip" ClientIDMode="Static"/>
                                                            </td>
                                                            <td style="width: 25%">
                                                                <%--     <asp:FileUpload ID="fluldmasterslp" runat="server" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 35%">
                                                            </td>
                                                            <td style="width: 40%">
                                                                <asp:CheckBox ID="chkMLS" runat="server" CssClass="Lable" ClientIDMode="Static" Text="MLS"  />
                                                            </td>
                                                            <td style="width: 25%">
                                                                <%-- <asp:FileUpload ID="fluldmls" runat="server" />--%>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 35%">
                                                            </td>
                                                            <td style="width: 40%">
                                                                <asp:CheckBox ID="chkOtherup" ClientIDMode="Static" runat="server" CssClass="Lable" Text="OTHER UPLOADS"
                                                                     />
                                                            </td>
                                                            <td style="width: 25%">
                                                                <%-- <asp:FileUpload ID="fluldothers" runat="server" />--%>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

