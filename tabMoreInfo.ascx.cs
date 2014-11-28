using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ForeClosure.Admin
{
    public partial class tabMoreInfo : System.Web.UI.UserControl
    {
        ForeClosure.clsRealQuest objreal = new clsRealQuest();
        iucon.web.Controls.ParameterCollection parameters = iucon.web.Controls.ParameterCollection.Instance;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillOwnerInformation();
        }

        public void FillOwnerInformation()
        {
           // objreal.MainAPN = Session["MainAPN"].ToString();
            objreal.MainAPN = parameters["MainApn"];
            DataRow drow = objreal.FillRealData2().Tables[0].AsEnumerable().Where(dr => dr.Field<string>("APN") == dr.Field<string>("MainAPN")).FirstOrDefault();

            if (drow != null)
            {
                divOwnerInformation.InnerHtml = drow["OwnerInformation"].ToString();
            }
        }
    }
}