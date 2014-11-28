using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;

namespace ForeClosure.Admin
{
    public partial class PropertyReport2 : System.Web.UI.Page
    {
        private string _mainAddress = string.Empty;
        public string Mainaddress
        {
            get { return _mainAddress; }
            set { _mainAddress = value; }
        }
        // ForeClosure.DataBase obj = new ForeClosure.DataBase();

        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);

        //Session["id"] = Request.QueryString["id"].ToString();
        //Session["MainApn"] = Request.QueryString["mainapn"].ToString();

        //    if (Request.QueryString["id"] != null)
        //        Session["id"] = Request.QueryString["id"];
        //    string strsel = "select * from RetRequred where RetFlId = '" + Session["id"].ToString() + "'";
        //    DataSet ds = obj.FillDataSet(strsel);
        //    Session["MainAPN"] = ds.Tables[0].Rows[0]["APN"];
        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id"] = Request.QueryString["id"].ToString();
            Session["MainApn"] = Request.QueryString["mainapn"].ToString();

            if (Request.QueryString["link"] != null)
            {
                if (Request.QueryString["link"].ToString() == "AppServ")
                    tbMain.ActiveTabIndex = 5;
                else
                    tbMain.ActiveTabIndex = 0;
            }
            else
                tbMain.ActiveTabIndex = 0;

            string id = Request.QueryString["id"].ToString();
            string mainApn = Request.QueryString["mainapn"].ToString();

            pnlCompsReport.Parameters["Id"] = id;
            pnlCompsReport.Parameters["MainApn"] = mainApn;

            pnlMap.Parameters["Id"] = id;
            pnlMap.Parameters["MainApn"] = mainApn;
            pnlMap.Parameters["MainAddress"] = Mainaddress;

            pnlMoreInfo.Parameters["Id"] = id;
            pnlMoreInfo.Parameters["MainApn"] = mainApn;

            pnlPhotoGallery.Parameters["Id"] = id;
            pnlPhotoGallery.Parameters["MainApn"] = mainApn;

            pnlMasterSlip.Parameters["Id"] = id;
            pnlMasterSlip.Parameters["MainApn"] = mainApn;

            pnlAppServ.Parameters["Id"] = id;
            pnlAppServ.Parameters["MainApn"] = mainApn;
            
           // pnlMap.UserControlPath = "~/tabMap.ascx";
            pnlMap.UserControlPath = "~/tabMap2.ascx";
            pnlCompsReport.UserControlPath = "~/tabCompsReport.ascx";
            pnlMoreInfo.UserControlPath = "~/tabMoreInfo.ascx";
            pnlPhotoGallery.UserControlPath = "~/tabPhotoGallery.ascx";
            pnlMasterSlip.UserControlPath = "~/tabMasterSlip.ascx";
            pnlAppServ.UserControlPath = "~/tabAppServ.ascx";


            //  string s = Request.QueryString["id"].ToString(); 
        }


        GoogleObject _googlemapobject = new GoogleObject();
        private string _gObj = string.Empty;
        public string GoogleMapObject_String
        {
            get { return _gObj ; }
            set { _gObj = value; }
        }
        
         public GoogleObject  GoogleMapObject
        {
            get { return _googlemapobject; }
            set { _googlemapobject = value; }
            }
        DataSet ds = new DataSet();
        ForeClosure.clsRealQuest objreal = new clsRealQuest();

        protected override void OnInit(EventArgs e)
        {
            CreateGoogleMap();
            JavaScriptSerializer oSerializer = new JavaScriptSerializer();
            _gObj = oSerializer.Serialize(GoogleMapObject);
        }
        
        public void CreateGoogleMap()
        {
            GoogleMapObject = new GoogleObject();
            //Specify Center Point for map. Map will be centered on this point.
            ds = new DataSet();
            string mainApn = Request.QueryString["mainapn"].ToString();

            objreal.MainAPN = mainApn;
            ds = objreal.GetAddressInfo();
         
            if (ds.Tables[0].Rows.Count > 0)
            {
                //if ((ds.Tables[0].Rows[0]["Situs2"].ToString().Trim().ToUpper() == "VENTURA") && (ds.Tables[0].Rows[0]["Situs3"].ToString().Trim().ToUpper() == "CA"))
                //{
                //    imglogo1.ImageUrl = "https://pasimage.sitexdata.com/WebImage/ClientPhoto/rep/Admin_1.jpg";
                //    imglogo1.Height = 80;
                //    imglogo1.Width = 400;
                //    imglogo2.ImageUrl = "https://pasimage.sitexdata.com/WebImage/ClientPhoto/rep/Admin_1.jpg";
                //    imglogo2.Height = 80;
                //    imglogo2.Width = 400;
                //}
                //else
                //{
                //    imglogo1.ImageUrl = "~/images/defaultlogo.jpg";
                //    imglogo2.ImageUrl = "~/images/defaultlogo.jpg";
                //}
            }

            GooglePoint[] GP21 = new GooglePoint[ds.Tables[0].Rows.Count];
            GooglePoint GPCenter = new GooglePoint();
            if (ds.Tables[0].Rows.Count > 0)
            {
                // lbladd.Text = ds.Tables[0].Rows[0]["Address"].ToString() + "," + ds.Tables[0].Rows[0]["Situs2"].ToString() + " " + ds.Tables[0].Rows[0]["Situs3"].ToString();
                //lbladd0.Text = ds.Tables[0].Rows[0]["Address"].ToString() + "," + ds.Tables[0].Rows[0]["Situs2"].ToString() + " " + ds.Tables[0].Rows[0]["Situs3"].ToString();
                _mainAddress = ds.Tables[0].Rows[0]["Address"].ToString()
                                + "," + ds.Tables[0].Rows[0]["Situs2"].ToString() + " "
                                + ds.Tables[0].Rows[0]["Situs3"].ToString();

                string Cen_cnt = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Situs3"].ToString()) ? "" : ds.Tables[0].Rows[0]["Situs3"].ToString().Substring(0, 2);
                string Cen_post = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Situs3"].ToString()) ? "" : ds.Tables[0].Rows[0]["Situs3"].ToString().Substring(2);
                string Cen_address = string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Address"].ToString()) ? "" : ds.Tables[0].Rows[0]["Address"].ToString() + "-" + (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["Situs2"].ToString()) ? "" : ds.Tables[0].Rows[0]["Situs2"].ToString()) + "-" + Cen_cnt + " " + Cen_post;

                GPCenter.Address = Cen_address;

                if (GPCenter.GeocodeAddressV3())
                {
                    GoogleMapObject.CenterPoint = new GooglePoint("CenterPoint", GPCenter.Latitude, GPCenter.Longitude);
                }

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    //Char[] ch = ds.Tables[0].Rows[i]["Situs3"].ToString().ToCharArray();

                    /*string cnt = ds.Tables[0].Rows[i]["Situs3"].ToString().Substring(0, 2);
                    string post = ds.Tables[0].Rows[i]["Situs3"].ToString().Substring(2);
                    string address = ds.Tables[0].Rows[i]["Address"].ToString() + "-" + ds.Tables[0].Rows[i]["Situs2"].ToString() + "-" + cnt + " " + post;*/
                    string cnt = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Situs3"].ToString()) ? "" : ds.Tables[0].Rows[i]["Situs3"].ToString().Substring(0, 2);
                    string post = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Situs3"].ToString()) ? "" : ds.Tables[0].Rows[i]["Situs3"].ToString().Substring(2);
                    string address = string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Address"].ToString()) ? "" : ds.Tables[0].Rows[i]["Address"].ToString() + "-" + (string.IsNullOrEmpty(ds.Tables[0].Rows[i]["Situs2"].ToString()) ? "" : ds.Tables[0].Rows[i]["Situs2"].ToString()) + "-" + cnt + " " + post;

                    GP21[i] = new GooglePoint();
                    GP21[i].ID = i.ToString();
                    GP21[i].Address = address;

                    //GeocodeAddress() function will geocode address and set Latitude and Longitude of GP(GooglePoint) to it's respected value.
                    if (GP21[i].GeocodeAddressV3())
                    {
                        string name = "<table width='220px' height='30px'>";
                        name += "<tr>";
                        name += "<td width='10%'>";
                        name += "</td>";
                        name += "<td align='center' style='font-weight: bold;'>";
                        name += "<br />";
                        name += ds.Tables[0].Rows[i]["Address"].ToString() + "," + ds.Tables[0].Rows[i]["Situs2"].ToString() + " " + ds.Tables[0].Rows[i]["Situs3"].ToString();
                        name += "</td>";
                        name += "</tr>";
                        name += "<tr>";
                        name += "<td width='10%'>";
                        name += "</td>";
                        name += "<td width='90%' align='center'>";
                        //name += "Click <a target='_blank' href='http://maps.google.com/maps?cbp=12,,,0,-9.25&cbll=" + GP21[i].Latitude + "," + GP21[i].Longitude + "&panoid=&v=1&gl=us&output=svembed&layer=c'>";
                        //name += "Click <a target='_blank' href='http://maps.google.com/maps?cbp=12,,,0,-9.25&cbll=" + GP21[i].Latitude + "," + GP21[i].Longitude + "&panoid=&v=1&gl=us&layer=c'>";
                        name += "Click <a target='_blank' href='http://maps.google.com/maps?cbp=12,0,0,0,-9.25&cbll=" + GP21[i].Latitude + "," + GP21[i].Longitude + "&q=" + GP21[i].Latitude + "," + GP21[i].Longitude + "&panoid=&v=1&gl=us&output=classic&layer=c'>";
                        name += "Here</a> to see StreetView";
                        name += "</td>";
                        name += "</tr>";
                        name += "</table>";

                        //Once GP is geocoded, you can add it to google map.                
                        GP21[i].InfoHTML = name;
                        if (i == 0)
                        {
                            GP21[i].IconImage = "images/marker1.gif";
                        }
                        else
                        {
                            GP21[i].IconImage = "images/marker.gif";
                        }
                        //Set GP as center point.

                        
                        GoogleMapObject.CenterPoint = GP21[i];

                        //Add geocoded GP to GoogleMapObject
                        GoogleMapObject.Points.Add(GP21[i]);
                        GoogleMapObject.ZoomLevel = 17;
                        //Recenter map to GP.
                        GoogleMapObject.RecenterMap = true;
                        GoogleMapObject.APIVersion = "3";
                        
                    }
                }
            }
            else
            {
                _mainAddress = "Not Available";
            }
        }
    }
}