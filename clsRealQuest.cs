using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using ForeClosure;

/// <summary>
/// Summary description for clsRealQuest
/// </summary>
namespace ForeClosure
{
    public class clsRealQuest
    {
        ForeClosure.DataBase objdb = new ForeClosure.DataBase();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public clsRealQuest()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        public DataSet FillRealData()
        {
            try
            {
                if (objdb.con.State == ConnectionState.Open)
                {
                    objdb.con.Close();
                }
                objdb.con.Open();
                cmd = new SqlCommand("spFillRealData", objdb.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Status", SqlDbType.NVarChar).Value = Status;
                cmd.Parameters.Add("@MainAPN", SqlDbType.NVarChar).Value = MainAPN;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch { }
			finally
			{
				if (objdb.con.State == ConnectionState.Open)

					objdb.con.Close();
			}
            return ds;
        }


        //EIS : 21-Nov-12 Optimizing code for loading page fast
        public DataSet FillRealData2()
        {
            try
            {
                if (objdb.con.State == ConnectionState.Open)
                {
                    objdb.con.Close();
                }

                objdb.con.Open();
                cmd = new SqlCommand("spFillRealData2", objdb.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MainAPN", SqlDbType.NVarChar).Value = MainAPN;
                cmd.Parameters.Add("@Recdate", SqlDbType.DateTime).Value = DateTime.Now.Date.ToString("MM/dd/yyyy");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch { }
            finally
            {

				if (objdb.con.State == ConnectionState.Open)

					objdb.con.Close();
            }
            return ds;
        }

        public DataSet GetAddressInfo()
        {
            try
            {
                if (objdb.con.State == ConnectionState.Open)
                {
                    objdb.con.Close();
                }
                objdb.con.Open();
                cmd = new SqlCommand("spGetAddressinfo", objdb.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@MainAPN", SqlDbType.NVarChar).Value = MainAPN;
                cmd.Parameters.Add("@Recdate", SqlDbType.DateTime).Value = DateTime.Now.Date.ToString("MM/dd/yyyy");
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch { }
            finally
            {

				if (objdb.con.State == ConnectionState.Open)

					objdb.con.Close();
            }
            return ds;
        }



        #region Property
        public string _MainAPN, _Status;
        public string MainAPN
        {
            get { return _MainAPN; }
            set { _MainAPN = value; }
        }
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        #endregion


    }
}
