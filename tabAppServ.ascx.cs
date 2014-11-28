using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ForeClosure.Admin
{
    public partial class tabAppServ : System.Web.UI.UserControl
    {
        clsAppServ objapp = new clsAppServ();
        DataSet ds;
        iucon.web.Controls.ParameterCollection parameters = iucon.web.Controls.ParameterCollection.Instance;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region Appserv

        public void FillAppriaserByID(int ID)
        {
            DataTable dt = new DataTable();

            dt = FetchByID(ID);
            if (dt != null && dt.Rows.Count > 0)
            {
                FillDataListImages(dt, ID);
                //lblapna.Text = Session["MainAPN"].ToString();
                //lblapnedit.Text = Session["MainAPN"].ToString(); ;
                lblapna.Text = parameters["MainApn"];
                lblapnedit.Text = parameters["MainApn"];
                lblstreetname.Text = dt.Rows[0]["STREET_NAME"].ToString();
                lblstdir.Text = dt.Rows[0]["DIRECTION"].ToString();
                lblsttype.Text = dt.Rows[0]["STREET_TYPE"].ToString();
                //lblZipCode.Text = dt.Rows[0]["ZIPCODE"].ToString();
                lbluser.Text = dt.Rows[0]["User_Name"].ToString();
                lblvalue.Text = dt.Rows[0]["PROP_VALUE"].ToString();
                lblcost.Text = dt.Rows[0]["FIX_COST"].ToString();
                lblstatus.Text = dt.Rows[0]["OCCUPIED"].ToString();
                lblnotesa.Text = dt.Rows[0]["COMMENTS"].ToString();
                rdlstvaccent.ClearSelection();
                ddldir.SelectedIndex = 0;
                ddltype.SelectedIndex = 0;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "SecurityAlert", string.Format("alert(\"{0}\");", "No value found in database"), true);
            }
        }
        public DataTable FetchByID(int ID)
        {
            try
            {//here get details for unique value. Right now it is prop_id.in future APN will be considered.
                objapp.Prop_Id = ID;
                ViewState["APN"] = ID;
                ds = new DataSet();
                ds = objapp.GetProperty();
                return ds.Tables[0];
            }
            catch (DBConcurrencyException)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public void FillDataListImages(DataTable dt, int mainID)
        {
            DataTable myDataTable = new DataTable();
            DataColumn myDataColumn;
            myDataColumn = new DataColumn();
            myDataColumn.DataType = Type.GetType("System.String");
            myDataColumn.ColumnName = "IMAGE_PATH";
            myDataTable.Columns.Add(myDataColumn);
            DataRow row;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                if (dt.Columns[i].ColumnName == "IMAGE1_PATH" ||
                    dt.Columns[i].ColumnName == "IMAGE2_PATH" ||
                    dt.Columns[i].ColumnName == "IMAGE3_PATH" ||
                    dt.Columns[i].ColumnName == "IMAGE4_PATH" ||
                    dt.Columns[i].ColumnName == "IMAGE5_PATH")
                {
                    if (dt.Rows[0][i] != DBNull.Value && dt.Rows[0][i].ToString() != "")
                    {
                        string id = mainID + "/" + dt.Columns[i].ColumnName;
                        row = myDataTable.NewRow();
                        row["IMAGE_PATH"] = "~/Admin/ShowImage.ashx?id=" + id;
                        myDataTable.Rows.Add(row);
                    }
                }
            }
            rptimage.DataSource = myDataTable;
            rptimage.DataBind();
            gvBigImage.DataSource = myDataTable;
            gvBigImage.DataBind();
            ViewState["dtImageURL"] = myDataTable;
            //GetSlides(myDataTable);
        }

        protected void gvBigImage_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvBigImage.PageIndex = e.NewPageIndex;
            DataTable dt = new DataTable();
            dt = (DataTable)ViewState["dtImageURL"];
            if (dt != null && dt.Rows.Count > 0)
            {
                gvBigImage.DataSource = dt;
                gvBigImage.DataBind();
            }
            pnlModal_ModalPopupExtender.Show();
        }
        protected void imgtnedit_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                pnleditappserv.Visible = true;
                pnlappserv.Visible = false;

                lblcreatedby.Text = lbluser.Text;
                lblapnedit.Text = lblapna.Text;
                txtstreetname.Text = lblstreetname.Text;
                ddldir.ClearSelection();
                if (lblstdir.Text != "0")
                    ddldir.Items.FindByText(lblstdir.Text).Selected = true;
                else
                    ddldir.Items.FindByText("--Select--").Selected = true;
                txtsttype.Text = lblsttype.Text;
                //  FillType();

                //ddltype.ClearSelection();

                //ddltype.Items.FindByText(lblsttype.Text).Selected = true;
                txtvalue.Text = lblvalue.Text;
                txtcost.Text = lblcost.Text;
                rdlstvaccent.ClearSelection();
                if (lblstatus.Text != "")
                    rdlstvaccent.Items.FindByText(lblstatus.Text).Selected = true;
                txtnotesa.Text = lblnotesa.Text;
            }
            catch (Exception ex) { }
        }

        protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddltype.Items.FindByText("OTHER TYPE").Selected == true)
            {
                txtsttype.Visible = false;
                txtnewtype.Visible = true;
                txtnewtype.Text = "";
            }
            else if (ddltype.Items.FindByText("--Select--").Selected == true)
            {
                txtnewtype.Visible = false;
                txtnewtype.Text = "";
            }
            else
            {
                txtnewtype.Visible = false;
                txtsttype.Text = ddltype.SelectedItem.Text;

            }
        }

        protected void imgbtnsave_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                objapp.Prop_Id = Convert.ToInt32(ViewState["APN"]);
                objapp.STREETNAME = txtstreetname.Text;
                objapp.Direction = ddldir.SelectedItem.Text;
                if (ddltype.Items.FindByText("OTHER TYPE").Selected == true)
                    objapp.STREETTYPE = txtnewtype.Text;
                else
                    objapp.STREETTYPE = txtsttype.Text;
                objapp.STATUS = rdlstvaccent.SelectedItem.Text;
                objapp.VALUE = txtvalue.Text;
                objapp.COST = txtcost.Text;
                objapp.NOTES = txtnotesa.Text;
                objapp.EditProperty();
                FillAppriaserByID(Convert.ToInt32(ViewState["APN"]));
                pnlappserv.Visible = true;
                pnleditappserv.Visible = false;
            }
            catch (Exception ex) { }
        }

        protected void imgbtncancel_Click(object sender, ImageClickEventArgs e)
        {
            pnleditappserv.Visible = false;
            pnlappserv.Visible = true;
        }
        #endregion
    }
}