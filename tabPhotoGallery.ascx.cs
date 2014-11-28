using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace ForeClosure.Admin
{
    public partial class tabPhotoGallery : System.Web.UI.UserControl
    {
        ForeClosure.DataBase obj = new ForeClosure.DataBase();
        SqlCommand cmd;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void imgbtnDelete_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            if (btn.CommandName.Equals("Delete"))
            {
                string path = btn.CommandArgument.ToString();
                if (obj.con.State == ConnectionState.Open)
                {
                    obj.con.Close();
                }
                obj.con.Open();

                cmd = new SqlCommand("Delete from RecieveMailDetails where Path='" + path + "'", obj.con);
                cmd.ExecuteNonQuery();
                obj.con.Close();

                DataListFriends.DataSourceID = "SqlDataSource1";
                DataListFriends.DataBind();

            }
        }
    }
}