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

/// <summary>
/// Summary description for clsAppServ
/// </summary>
namespace ForeClosure
{
    public class clsAppServ
    {
        ForeClosure.DataBase objdb = new ForeClosure.DataBase();
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;
        public clsAppServ()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public DataSet GetProperty()
        {
            ds = null;
            try
            {
                if (objdb.cona.State == ConnectionState.Open)
                {
                    objdb.cona.Close();
                }
                objdb.cona.Open();
                cmd = new SqlCommand("SP_PROPERTY_MASTER_SELECT_ID_NEW", objdb.cona);
                cmd.Parameters.Add("@PROP_ID", SqlDbType.Int).Value = Prop_Id;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception)
            { }
            finally
            {
				if(objdb.cona.State==ConnectionState.Open)
                objdb.cona.Close();
            }
            return ds;
        }



        public DataTable GetPropertyByAPN()
        {
            ds = new DataSet();
            try
            {
                if (objdb.cona.State == ConnectionState.Open)
                {
                    objdb.cona.Close();
                }
                objdb.cona.Open();
                cmd = new SqlCommand("SP_PROPERTY_MASTER_SELECT_APN", objdb.cona);
                cmd.Parameters.Add("@APN", SqlDbType.VarChar).Value = APN;
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

            }
            catch (Exception)
            { }
            finally
            {
				if(objdb.cona.State==ConnectionState.Open)
                objdb.cona.Close();
            }
            return ds.Tables[0];
        }
        public void EditProperty()
        {
            try
            {
                if (objdb.cona.State == ConnectionState.Open)
                {
                    objdb.cona.Close();
                }
                objdb.cona.Open();
                cmd = new SqlCommand("SP_PROPERTY_MASTER_UPDATE_NEW", objdb.cona);
                cmd.Parameters.Add("@PROP_ID", SqlDbType.Int).Value = Prop_Id;
                cmd.Parameters.Add("@STREET_NAME", SqlDbType.NVarChar).Value = STREETNAME;
                cmd.Parameters.Add("@DIRECTION", SqlDbType.NVarChar).Value = Direction;
                cmd.Parameters.Add("@STREET_TYPE", SqlDbType.NVarChar).Value = STREETTYPE;
                cmd.Parameters.Add("@PROP_VALUE", SqlDbType.Int).Value = VALUE;
                cmd.Parameters.Add("@FIX_COST", SqlDbType.Int).Value = COST;
                cmd.Parameters.Add("@OCCUPIED", SqlDbType.NVarChar).Value = STATUS;
                cmd.Parameters.Add("@COMMENTS", SqlDbType.NVarChar).Value = NOTES;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteScalar();


            }
            catch (Exception)
            { }
            finally { 
				if (objdb.cona.State==ConnectionState.Open)
				objdb.cona.Close(); }
        }

        public DataSet GetStreetType()
        {
            try
            {
                if (objdb.cona.State == ConnectionState.Open)
                {
                    objdb.cona.Close();
                }
                objdb.cona.Open();
                cmd = new SqlCommand("SP_GETSTREETTYPE", objdb.cona);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);
            }
            catch (Exception)
            { }
            finally
            {
				if(objdb.cona.State==ConnectionState.Open)
                objdb.cona.Close();
            }
            return ds;
        }


        #region Property

        public string _APN;
        public string APN
        {
            get { return _APN; }
            set { _APN = value; }
        }

        public int _Prop_Id;
        public int Prop_Id
        {
            get { return _Prop_Id; }
            set { _Prop_Id = value; }
        }

        public string _STREETNAME;
        public string STREETNAME
        {
            get { return _STREETNAME; }
            set { _STREETNAME = value; }
        }

        public string _Direction;
        public string Direction
        {
            get { return _Direction; }
            set { _Direction = value; }
        }

        public string _STREETTYPE;
        public string STREETTYPE
        {
            get { return _STREETTYPE; }
            set { _STREETTYPE = value; }
        }

        public string _VALUE;
        public string VALUE
        {
            get { return _VALUE; }
            set { _VALUE = value; }
        }

        public string _COST;
        public string COST
        {
            get { return _COST; }
            set { _COST = value; }
        }

        public string _STATUS;
        public string STATUS
        {
            get { return _STATUS; }
            set { _STATUS = value; }
        }

        public string _NOTES;
        public string NOTES
        {
            get { return _NOTES; }
            set { _NOTES = value; }
        }


        #endregion
    }
}
