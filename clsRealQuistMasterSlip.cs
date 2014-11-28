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

namespace ForeClosure
{
    public class clsRealQuistMasterSlip
    {
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ForeClosure"].ConnectionString.ToString());

        public clsRealQuistMasterSlip()
        {
        }

        public DataSet FillRetranData()
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                ds = new DataSet();
                cmd = new SqlCommand("spFillMSlip", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RetFlId", SqlDbType.Int, 18).Value = RetFlId;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch { }
            finally
            {

				if (con.State == ConnectionState.Open)

					con.Close();
            }
            return ds;
        }

        public void AUDOP(string str)
        {
            try
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
                con.Open();
                cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
            }
            catch { }
            finally
            {

				if (con.State == ConnectionState.Open)

					con.Close();
            }
        }

        public int _RetFlId;
        public int RetFlId
        {
            get { return _RetFlId; }
            set { _RetFlId = value; }
        }

    }
}
