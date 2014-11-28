<%@ Page Title="" Language="C#" MasterPageFile="~/BingMap.master" AutoEventWireup="true" CodeBehind="PropertyReport2.aspx.cs" Inherits="ForeClosure.Admin.PropertyReport2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="iucon.web.Controls.PartialUpdatePanel" Namespace="iucon.web.Controls" TagPrefix="iucon" %>
<%--<%@ Register Src="~/Admin/GoogleMapForASPNet1.ascx" TagName="GoogleMapForASPNet" TagPrefix="uc1" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Property Report</title>
<!-- Google map -->
<script src="http://code.jquery.com/jquery-1.7.1.min.js" type="text/javascript" language="javascript"></script>
<%--<script type="text/javascript" src="GoogleMapAPIWrapper1.js"></script>--%>

<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=false"></script> 
<script type="text/javascript">
    var googleObject = $.parseJSON('<%=GoogleMapObject_String %>');
</script>
<script type="text/javascript" src="GoogleMapWrapper.js"></script>
<script type="text/javascript">
    var pageUrl = '<%=Page.ResolveUrl("~/GService.asmx")%>';
    var ctrlId = '<%=pnlMasterSlip.ClientID%>';
  
</script> 

<!-- EIS 27-July-2012 Drag & Drop -->
<%--<script src="<%=Page.ResolveUrl("../Scripts/Drag_drop.js")%>" language="javascript" type="text/javascript"></script>--%>
<link href="../Styles/Drag.css" rel="Stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MenuPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="LoginPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div style="clear: both; padding-left: 10px; padding-right: 10px;">

        <cc1:TabContainer ID="tbMain" runat="server" Width="100%" ActiveTabIndex="0" >

            <cc1:TabPanel runat="server" ID="tbpnlcomps" HeaderText="Comps Report" ToolTip="Comps Report">
                <ContentTemplate>
                    <iucon:PartialUpdatePanel runat="server" ID="pnlMap" >
                        <Parameters>
                            <iucon:Parameter Name="Id" />
                            <iucon:Parameter Name="MainApn" />
                            <iucon:Parameter Name="MainAddress" />
                        </Parameters>
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif" />
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                    <iucon:PartialUpdatePanel runat="server" ID="pnlCompsReport" >
                        <Parameters>
                            <iucon:Parameter Name="Id" />
                            <iucon:Parameter Name="MainApn" />
                        </Parameters>
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif" />
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>

            <%--<cc1:TabPanel runat="server" ID="tbpnlMaps" HeaderText="Maps" ToolTip="Maps">
                <ContentTemplate>
                     <iucon:PartialUpdatePanel runat="server" ID="PartialUpdatePanel4" UserControlPath="~/Admin/tabMap.ascx">
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif" />
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>--%>

            <cc1:TabPanel runat="server" ID="tbpnlMoreInfo" HeaderText="More Information" ToolTip="More Information">
                <ContentTemplate>
                    <iucon:PartialUpdatePanel runat="server" ID="pnlMoreInfo" >
                        <Parameters>
                            <iucon:Parameter Name="Id" />
                            <iucon:Parameter Name="MainApn" />
                        </Parameters>
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif" />
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>

            <cc1:TabPanel runat="server" ID="tbpnlimages" HeaderText="PhotoGallery" ToolTip="View Photo">
                <ContentTemplate>
                    <iucon:PartialUpdatePanel runat="server" ID="pnlPhotoGallery" >
                        <Parameters>
                            <iucon:Parameter Name="Id" />
                            <iucon:Parameter Name="MainApn" />
                        </Parameters>
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif"/>
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>

            <cc1:TabPanel runat="server" ID="tbpnlmasterslip" HeaderText="MasterSlip">
                <ContentTemplate>
                    <iucon:PartialUpdatePanel runat="server" ID="pnlMasterSlip" >
                        <Parameters>
                            <iucon:Parameter Name="Id" />
                            <iucon:Parameter Name="MainApn" />
                        </Parameters>
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif" />
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>

            <cc1:TabPanel runat="server" ID="tbpnlappserv" HeaderText="AppServ" ToolTip="View AppServ">
                <ContentTemplate>
                    <iucon:PartialUpdatePanel runat="server" ID="pnlAppServ" >
                        <Parameters>
                            <iucon:Parameter Name="Id" />
                            <iucon:Parameter Name="MainApn" />
                        </Parameters>
                        <LoadingTemplate>
                            <div style="margin-top: 10px;height:250px;">
                                <asp:Image ID="Image1" runat="server" ImageUrl="~/loading2.gif" />
                            </div>
                        </LoadingTemplate>
                    </iucon:PartialUpdatePanel>
                </ContentTemplate>
            </cc1:TabPanel>
        </cc1:TabContainer>
    </div>
</asp:Content>
