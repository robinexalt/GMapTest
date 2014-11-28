using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ForeClosure.Admin
{
    public partial class tabCompsReport : System.Web.UI.UserControl
    {
        ForeClosure.clsRealQuest objreal = new clsRealQuest();
        iucon.web.Controls.ParameterCollection parameters = iucon.web.Controls.ParameterCollection.Instance;

        protected void Page_Load(object sender, EventArgs e)
        {
            //objreal.MainAPN = Session["MainAPN"].ToString();
            objreal.MainAPN = parameters["MainApn"];
            DataSet ds = new DataSet();
            ds = objreal.FillRealData2();

            if (ds.Tables[0].Rows.Count > 0)
            {
                var main = ds.Tables[0].AsEnumerable().Where(dr => dr.Field<string>("APN") == dr.Field<string>("MainAPN"));

                grdFirstRealdata.DataSource = main.AsDataView();
                grdFirstRealdata.DataBind();

                var compare = ds.Tables[0].AsEnumerable().Where(dr => dr.Field<string>("APN") != dr.Field<string>("MainAPN"));

                grdFirstCompare.DataSource = compare.AsDataView();
                grdFirstCompare.DataBind();

                grdrealdata.DataSource = ds.Tables[0];
                grdrealdata.DataBind();
            }

            //if (ds.Tables[0].Rows.Count > 0)
            //{
            //    ds = new DataSet();
            //    objreal.MainAPN = Session["MainAPN"].ToString();
            //    ds = objreal.GetAddressInfo();
            //    lbladd.Text = ds.Tables[0].Rows[0]["Address"].ToString() + "," + ds.Tables[0].Rows[0]["Situs2"].ToString() + " " + ds.Tables[0].Rows[0]["Situs3"].ToString();
            //}
        }
    }
}