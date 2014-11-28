using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ForeClosure.Admin
{
    public partial class tabMap2 : System.Web.UI.UserControl
    {
        iucon.web.Controls.ParameterCollection parameters = iucon.web.Controls.ParameterCollection.Instance;
    
        protected void Page_Load(object sender, EventArgs e)
        {
            string script = "initialize()";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);
            lbladd.Text = parameters["MainAddress"];
            if (string.Equals(parameters["MainAddress"], "Not Available", StringComparison.CurrentCulture))
            {
                lblmsg.Visible = true;
                lbladd.Visible = false;
            }
            
        }

    }
}