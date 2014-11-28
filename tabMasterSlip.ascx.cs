using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Configuration;


namespace ForeClosure.Admin
{
    public partial class tabMasterSlip : System.Web.UI.UserControl
    {
        ForeClosure.clsRealQuistMasterSlip objmaster = new ForeClosure.clsRealQuistMasterSlip();
        ForeClosure.DataBase obj = new ForeClosure.DataBase();
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        static string _TS, _APN;
        iucon.web.Controls.ParameterCollection parameters = iucon.web.Controls.ParameterCollection.Instance;

        protected new bool IsPostBack
        {
            get { return (bool)(ViewState["IsPostBack"] ?? false); }
            set { ViewState["IsPostBack"] = true; }
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            IsPostBack = true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Javascript function call
            string script = "Initialize2()";
            ScriptManager.RegisterStartupScript(this, GetType(), "alert", script, true);

            if (!IsPostBack)
            {
                FillRetranData();
                BindPrinters();
            }

            BindFiles();
        }

        public void FillRetranData()
        {
            try
            {
               // ViewState["RetFlId"] = Session["id"].ToString();
                ViewState["RetFlId"] = parameters["Id"];
                DataSet dsRet = new DataSet();

                objmaster.RetFlId = Convert.ToInt32(ViewState["RetFlId"].ToString());
                dsRet = objmaster.FillRetranData();

                //ViewState["SI"] = dsRet.Tables[0].Rows[0]["StatusId"].ToString();
                //rdlStatus.SelectedIndex = 0;
                string statusid = dsRet.Tables[0].Rows[0]["StatusId"].ToString();
                ViewState["SI"] = statusid;

                if (statusid == "16" || statusid == "17" || statusid == "20" || statusid == "21" || statusid == "22")
                    rdlStatus.SelectedValue = statusid;
                else
                    rdlStatus.SelectedValue = "18";

                if (dsRet.Tables[0].Rows[0]["AuctionDate"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["AuctionTime"].ToString() != "")
                    {
                        if (dsRet.Tables[0].Rows[0]["AuctionAdd1"].ToString() != "")
                        {
                            if (dsRet.Tables[0].Rows[0]["AuctionAdd2"].ToString() != "")
                            {
                                txtauctionvalue.Text = dsRet.Tables[0].Rows[0]["AuctionDate"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionTime"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd2"].ToString();
                            }
                            else
                            {
                                txtauctionvalue.Text = txtauctionvalue.Text = dsRet.Tables[0].Rows[0]["AuctionDate"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionTime"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd1"].ToString() + ";";
                            }
                        }
                        else
                        {
                            txtauctionvalue.Text = dsRet.Tables[0].Rows[0]["AuctionDate"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionTime"].ToString() + ";" + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd2"].ToString();
                        }
                    }
                    else
                    {
                        txtauctionvalue.Text = dsRet.Tables[0].Rows[0]["AuctionDate"].ToString() + ";" + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd2"].ToString();
                    }
                }
                else
                {
                    txtauctionvalue.Text = ";" + dsRet.Tables[0].Rows[0]["AuctionTime"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["AuctionAdd2"].ToString();
                }

                //Address
                if (dsRet.Tables[0].Rows[0]["SITUSTREET"].ToString() != "")
                {
                    ViewState["SN"] = dsRet.Tables[0].Rows[0]["SITUSTREET"].ToString();
                    if (dsRet.Tables[0].Rows[0]["SITUS1"].ToString() != "")
                    {
                        ViewState["A1"] = dsRet.Tables[0].Rows[0]["SITUS1"].ToString();
                        if (dsRet.Tables[0].Rows[0]["SITUS2"].ToString() != "")
                        {
                            ViewState["A2"] = dsRet.Tables[0].Rows[0]["SITUS2"].ToString();
                            if (dsRet.Tables[0].Rows[0]["SITUS3"].ToString() != "")
                            {
                                ViewState["A3"] = dsRet.Tables[0].Rows[0]["SITUS3"].ToString();
                                txtaddressvalue.Text = dsRet.Tables[0].Rows[0]["SITUSTREET"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS2"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS3"].ToString();
                            }
                            else
                            {
                                ViewState["A3"] = "";
                                txtaddressvalue.Text = dsRet.Tables[0].Rows[0]["SITUSTREET"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS2"].ToString() + ";";
                            }
                        }
                        else
                        {
                            ViewState["A2"] = "";
                            txtaddressvalue.Text = dsRet.Tables[0].Rows[0]["SITUSTREET"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS1"].ToString() + ";;" + dsRet.Tables[0].Rows[0]["SITUS3"].ToString();
                        }
                    }
                    else
                    {
                        ViewState["A1"] = "";
                        txtaddressvalue.Text = dsRet.Tables[0].Rows[0]["SITUSTREET"].ToString() + ";;" + dsRet.Tables[0].Rows[0]["SITUS2"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS3"].ToString();
                    }
                }
                else
                {
                    ViewState["SN"] = "";
                    txtaddressvalue.Text = ";" + dsRet.Tables[0].Rows[0]["SITUS1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS2"].ToString() + ";" + dsRet.Tables[0].Rows[0]["SITUS3"].ToString();
                }

                //trustor
                if (dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd1"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd2"].ToString() != "")
                    {
                        if (dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd3"].ToString() != "")
                        {
                            txtaddressnvalue.Text = dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd2"].ToString() + ";" + dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd3"].ToString();
                        }
                        else
                        {
                            txtaddressnvalue.Text = dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd1"].ToString() + ";" + dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd2"].ToString() + ";";
                        }
                    }
                    else
                    {
                        txtaddressnvalue.Text = dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd1"].ToString() + ";;" + dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd3"].ToString();
                    }
                }
                else
                {
                    txtaddressnvalue.Text = ";" + dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd2"].ToString() + ";" + dsRet.Tables[0].Rows[0]["TrustorOwnerMailingAdd3"].ToString();
                }

                //Benificiary
                if (dsRet.Tables[0].Rows[0]["Beneficiary"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["BeneficiaryPhone"].ToString() != "")
                    {
                        txtbeneficiaryvalue.Text = dsRet.Tables[0].Rows[0]["Beneficiary"].ToString() + ";" + dsRet.Tables[0].Rows[0]["BeneficiaryPhone"].ToString();
                    }
                    else
                    {
                        txtbeneficiaryvalue.Text = dsRet.Tables[0].Rows[0]["Beneficiary"].ToString() + ";";
                    }
                }
                else
                {
                    txtbeneficiaryvalue.Text = ";" + dsRet.Tables[0].Rows[0]["BeneficiaryPhone"].ToString();
                }

                //Trustee
                if (dsRet.Tables[0].Rows[0]["Trustee"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["TrusteePhone"].ToString() != "")
                    {
                        txttrusteevalue.Text = dsRet.Tables[0].Rows[0]["Trustee"].ToString() + ";" + dsRet.Tables[0].Rows[0]["TrusteePhone"].ToString();
                    }
                    else
                    {
                        txttrusteevalue.Text = dsRet.Tables[0].Rows[0]["Trustee"].ToString() + ";";
                    }
                }
                else
                {
                    txttrusteevalue.Text = ";" + dsRet.Tables[0].Rows[0]["TrusteePhone"].ToString();
                }

                //Trustor Owner
                if (dsRet.Tables[0].Rows[0]["Trustor"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["TrustorOwnwePhone"].ToString() != "")
                    {
                        txttrustorvalue.Text = dsRet.Tables[0].Rows[0]["Trustor"].ToString() + ";" + dsRet.Tables[0].Rows[0]["TrustorOwnwePhone"].ToString();
                    }
                    else
                    {
                        txttrustorvalue.Text = dsRet.Tables[0].Rows[0]["Trustor"].ToString() + ";";
                    }
                }
                else
                {
                    txttrustorvalue.Text = ";" + dsRet.Tables[0].Rows[0]["TrustorOwnwePhone"].ToString();
                }

                //Loan 
                if (dsRet.Tables[0].Rows[0]["LoanDate"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["LoanDocument"].ToString() != "")
                    {
                        txtTDrecordedvalue.Text = dsRet.Tables[0].Rows[0]["LoanDate"].ToString() + ";" + dsRet.Tables[0].Rows[0]["LoanDocument"].ToString();
                    }
                    else
                    {
                        txtTDrecordedvalue.Text = dsRet.Tables[0].Rows[0]["LoanDate"].ToString() + ";";
                    }
                }
                else
                {
                    txtTDrecordedvalue.Text = ";" + dsRet.Tables[0].Rows[0]["LoanDocument"].ToString();
                }

                //Notice of ret sale
                if (dsRet.Tables[0].Rows[0]["NOSDate"].ToString() != "")
                {
                    if (dsRet.Tables[0].Rows[0]["DateTruncTrstSaleDoc"].ToString() != "")
                    {
                        txtnoticesalevalue.Text = dsRet.Tables[0].Rows[0]["NOSDate"].ToString() + ";" + dsRet.Tables[0].Rows[0]["DateTruncTrstSaleDoc"].ToString();
                    }
                    else
                    {
                        txtnoticesalevalue.Text = dsRet.Tables[0].Rows[0]["NOSDate"].ToString() + ";";
                    }
                }
                else
                {
                    txtnoticesalevalue.Text = ";" + dsRet.Tables[0].Rows[0]["DateTruncTrstSaleDoc"].ToString();
                }

                //EIS : 18-April-13 ;#376 Update to the Masterslip
                //abridge1
                if (dsRet.Tables[0].Rows[0]["LoanDate"].ToString() != "" && dsRet.Tables[0].Rows[0]["TD"].ToString() != "" && dsRet.Tables[0].Rows[0]["LoanDocument"].ToString() != "")
                {
                    txtabridge1.Text = "1";
                }

                ////abridge1
                //if (dsRet.Tables[0].Rows[0]["loan1RecDate"].ToString() != "" && dsRet.Tables[0].Rows[0]["loan1LoanAmount"].ToString() != "" && dsRet.Tables[0].Rows[0]["loan1DocNumber"].ToString() != "")
                //{
                //    txtabridge1.Text = "1";
                //}
                ////abridge2
                //if (dsRet.Tables[0].Rows[0]["loan2RecDate"].ToString() != "" && dsRet.Tables[0].Rows[0]["loan2LoanAmount"].ToString() != "" && dsRet.Tables[0].Rows[0]["loan2DocNumber"].ToString() != "")
                //{
                //    txtabridge2.Text = "2";
                //}

                ////abridge3
                //if (dsRet.Tables[0].Rows[0]["loan3RecDate"].ToString() != "" && dsRet.Tables[0].Rows[0]["loan3LoanAmount"].ToString() != "" && dsRet.Tables[0].Rows[0]["loan3DocNumber"].ToString() != "")
                //{
                //    txtabridge3.Text = "3";
                //}

                txtTSValue.Text = _TS = dsRet.Tables[0].Rows[0]["TS"].ToString();
                txtAPNValue.Text =_APN = dsRet.Tables[0].Rows[0]["APN"].ToString();

                ViewState["OB"] = dsRet.Tables[0].Rows[0]["OpeningBid"].ToString();
                txtopeningbidvalue.Text = dsRet.Tables[0].Rows[0]["OpeningBid"].ToString();

                ViewState["MB"] = dsRet.Tables[0].Rows[0]["MinBid"].ToString();
                txtpublishedbidvalue.Text = dsRet.Tables[0].Rows[0]["MinBid"].ToString();

                txtUnitsvalue.Text = dsRet.Tables[0].Rows[0]["Units"].ToString();
                txtBDvalue.Text = dsRet.Tables[0].Rows[0]["Bed"].ToString();
                txtbavalue.Text = dsRet.Tables[0].Rows[0]["Bath"].ToString();
                txtYRvalue.Text = dsRet.Tables[0].Rows[0]["YearBuiltTruncated"].ToString();
                txtsqftvalue.Text = dsRet.Tables[0].Rows[0]["BLDSqrFt"].ToString();
                txtLOTvalue.Text = dsRet.Tables[0].Rows[0]["LOTAR"].ToString();
                txtTMGvalue.Text = dsRet.Tables[0].Rows[0]["TMG"].ToString();
                txtUSEvalue.Text = dsRet.Tables[0].Rows[0]["USECode"].ToString();
                txtzoningvalue.Text = dsRet.Tables[0].Rows[0]["Zoning"].ToString();
                txtestvalue.Text = dsRet.Tables[0].Rows[0]["EstimatedValue"].ToString();
                txtleagalvalue.Text = dsRet.Tables[0].Rows[0]["LotTrack"].ToString();

                //EIS : 18-April-13 ;#376 Update to the Masterslip
                txtloan1recdate.Text = dsRet.Tables[0].Rows[0]["LoanDate"].ToString() == null ? string.Empty : Convert.ToDateTime(dsRet.Tables[0].Rows[0]["LoanDate"].ToString()).ToString("yyyy-MM-dd");
                txtloan1doc.Text = dsRet.Tables[0].Rows[0]["LoanDocument"].ToString();
                txtloan1amt.Text = dsRet.Tables[0].Rows[0]["TD"].ToString();

                //EIS : 18-April-13 ;#376 Update to the Masterslip
                //txtloan2recdate.Text = dsRet.Tables[0].Rows[0]["loan2RecDate"].ToString();
                //txtloan2doc.Text = dsRet.Tables[0].Rows[0]["loan2DocNumber"].ToString();
                //txtloan2amt.Text = dsRet.Tables[0].Rows[0]["loan2LoanAmount"].ToString();
                //txtloan3recdate.Text = dsRet.Tables[0].Rows[0]["loan3RecDate"].ToString();
                //txtloan3doc.Text = dsRet.Tables[0].Rows[0]["loan3DocNumber"].ToString();
                //txtloan3amt.Text = dsRet.Tables[0].Rows[0]["loan3LoanAmount"].ToString();

                txttitle.Text = dsRet.Tables[0].Rows[0]["Title"].ToString();
                txtgi.Text = dsRet.Tables[0].Rows[0]["GI"].ToString();
                txtappreport.Text = dsRet.Tables[0].Rows[0]["AppraisalReport"].ToString();
                txtTaxes.Text = dsRet.Tables[0].Rows[0]["Taxes"].ToString();
                txtZestimate.Text = dsRet.Tables[0].Rows[0]["Zestimate"].ToString();
            }
            catch (Exception ex) { }
        }

        public void BindPrinters()
        {
            // clsGoogleCloudPrint.BindPrinters(ddlPrinter);
            clsPrint.BindPrinters(ddlPrinter);
        }

        protected void rptFiles_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //if (Impersonation())
            //{
            string filePath = e.CommandArgument.ToString();
            //string filename = (new FileInfo(filePath)).Name;
            //string dropboxPath = filePath.Remove(filePath.LastIndexOf(filename));
            //string appHarborPath = Server.MapPath("~/Admin/Uploads/Drag");

            if (e.CommandName == "download")
            {
                //try
                //{
                //    clDropbox.DropboxDownloadFile(filename, dropboxPath, appHarborPath);

                //    HttpResponse response = HttpContext.Current.Response;
                //    //Set the appropriate ContentType.
                //    //response.ContentType = "Application/pdf";
                //    response.AppendHeader("content-disposition", "attachment; filename=" + filename);
                //    //Write the file directly to the HTTP content output stream.
                //    response.WriteFile(appHarborPath + "\\" + filename);
                //    response.End();
                //}
                //catch (Exception ex)
                //{ }
            }
            else if (e.CommandName.ToString() == "delete")
            {
                //if (System.IO.File.Exists(filePath))
                //    System.IO.File.Delete(filePath);

                //clDropbox.DropboxDeleteFile(filename, dropboxPath);
                //EIS 28-Mar-2013 Replace dropbox with AWS S3
                //clsAmazon.DeleteFile(filePath);

                BindFiles();
                //  tbMain.ActiveTabIndex = 4;
            }

            //}
        }

        public void BindFiles()
        {
          //  string directory = Session["id"].ToString();
            string directory = parameters["Id"];

            //rptFiles.DataSource = clDropbox.DropboxGetFiles("ForeClosure/Drag/" + directory);
			//rptFiles.DataSource = clsAmazon.GetSubDirectoryList("ForeClosure/Drag/" + directory);
			//rptFiles.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string statusid;
                //if (rdlStatus.SelectedItem.Value != "16" || rdlStatus.SelectedItem.Value != "17")

                //    statusid = this.rdlStatus.SelectedItem.Value.ToString();
                //else
                //    statusid = ViewState["SI"].ToString();

                statusid = rdlStatus.SelectedItem.Value.ToString();

                // DateTime AT = Convert.ToDateTime(this.ddlHr.SelectedValue + ":" + this.ddlMin.SelectedValue + ":00");
                //obj.AUDOP("update RetRequred set BUPStatus = StatusId where RetFlId = '" + ViewState["id"].ToString() + "'");

                /**/
                if (objmaster.con.State == ConnectionState.Closed)
                {
                    objmaster.con.Open();
                }
                cmd = new SqlCommand("UpdateRetranInfo", objmaster.con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@StatusId", SqlDbType.NVarChar, 50).Value = statusid;
                cmd.Parameters.Add("@RetFlId", SqlDbType.NVarChar, 50).Value = ViewState["RetFlId"].ToString();
                //cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 50).Value = ViewState["UName"].ToString();
                cmd.Parameters.Add("@RecordMeter", SqlDbType.NVarChar, 100).Value = Request.Cookies["user_name"].Value + "_tabMasterSlip_Save";
                cmd.ExecuteNonQuery();
                objmaster.con.Close();
                /**/

                // EIS Godwin 06-Feb-13 #176 Audit-Trail on all actions to see who changed the data
                if (ViewState["SI"].ToString() != statusid)
                {
                    string pValue = ViewState["RetFlId"].ToString() + "|" + _TS + "|" + _APN;
                    string strIns = "INSERT INTO Audit_Trail_Actions (ip_address,user_name,table_name,column_name,old_value,new_value,action_description,modified_date,primary_key_field,primary_key_value) VALUES ('" + GetIPAddress() + "','" + Request.Cookies["user_name"].Value + "','RetRequred','StatusId',(SELECT StatusName FROM StatusMast WHERE StatusId=  '" + ViewState["SI"].ToString() + "'),(SELECT StatusName FROM StatusMast WHERE StatusId= '" + statusid + "'),'Update(MasterSlip)','" + DateTime.Now + "','RetFlId|TS|APN','" + pValue + "')";
                    obj.AUDOP(strIns.ToString());
                }

                string strUp;
                string[] auct = new string[4];
                auct = txtauctionvalue.Text.ToString().Split(';');

                string[] address = new string[4];
                address = txtaddressvalue.Text.ToString().Split(';');

                string[] trustadd = new string[3];
                trustadd = txtaddressnvalue.Text.ToString().Split(';');

                string[] beni = new string[2];
                beni = txtbeneficiaryvalue.Text.ToString().Split(';');

                string[] trustee = new string[2];
                trustee = txttrusteevalue.Text.ToString().Split(';');

                string[] trustor = new string[2];
                trustor = txttrustorvalue.Text.ToString().Split(';');

                string[] loan = new string[2];
                loan = txtTDrecordedvalue.Text.ToString().Split(';');

                string[] salerec = new string[2];
                salerec = txtnoticesalevalue.Text.ToString().Split(';');

                cmd = new SqlCommand("update RetRequred set StatusId = @statusid,AuctionDate = @auct0,AuctionTime= "
                    + "@auct1,AuctionAdd1=@auct2,AuctionAdd2=@auct3,SITUSTREET=@address0,SITUS1=@address1,"
                    + "SITUS2=@address2,SITUS3=@address3,TrustorOwnerMailingAdd1=@trustadd0,"
                    + "TrustorOwnerMailingAdd2=@trustadd1,TrustorOwnerMailingAdd3=@trustadd2,Beneficiary=@beni0,"
                    + "BeneficiaryPhone=@beni1,Trustee=@trustee0,TrusteePhone=@trustee1,Trustor=@trustor0,"
                    + "TrustorOwnwePhone=@trustor1,"
                   // + "LoanDate=@loan0,LoanDocument=@loan1, "
                    + "NOSDate=@salerec0,"
                    + "DateTruncTrstSaleDoc=@salerec1,TS=@SValue,APN=@APNValue,MinBid=@publishedbidvalue,"
                    + "Units=@Unitsvalue,Bed=@BDvalue,Bath=@bavalue,BLDSqrFt=@sqftvalue,YearBuiltTruncated= @YRvalue,"
                    + "LOTAR=@LOTvalue,TMG=@TMGvalue,USECode=@USEvalue,Zoning=@zoningvalue,"
                    + "OpeningBid =@openingbidvalue,UpdatedBy=@UName,Title=@Title,GI=@GI,EstimatedValue=@EstimatedValue,"

                    //EIS : 18-April-13 ;#376 Update to the Masterslip
                    + "LoanDate=@LoanDate,LoanDocument=@LoanDocument,TD=@TD, "
                    //+ "loan1RecDate=@loan1RecDate,loan1DocNumber=@loan1DocNumber,loan1LoanAmount=@loan1LoanAmount, "
                    //+ "loan2RecDate=@loan2RecDate,loan2DocNumber=@loan2DocNumber,loan2LoanAmount=@loan2LoanAmount, "
                    //+ "loan3RecDate=@loan3RecDate,loan3DocNumber=@loan3DocNumber,loan3LoanAmount=@loan3LoanAmount, "

                    + "AppraisalReport=@AppraisalReport,Taxes=@Taxes,Zestimate=@Zestimate,RecordMeter=@RecordMeter "
                    + "where RetFlId = @RetFlId");


                cmd.Parameters.Add("@statusid", SqlDbType.Int).Value = Convert.ToInt32(statusid);
                cmd.Parameters.Add("@auct0", SqlDbType.NVarChar).Value = auct[0].ToString();
                cmd.Parameters.Add("@auct1", SqlDbType.NVarChar).Value = auct[1].ToString();
                cmd.Parameters.Add("@auct2", SqlDbType.NVarChar).Value = auct[2].ToString();
                cmd.Parameters.Add("@auct3", SqlDbType.NVarChar).Value = auct[3].ToString();
                cmd.Parameters.Add("@address0", SqlDbType.NVarChar).Value = address[0].ToString();
                cmd.Parameters.Add("@address1", SqlDbType.NVarChar).Value = address[1].ToString();
                cmd.Parameters.Add("@address2", SqlDbType.NVarChar).Value = address[2].ToString();
                cmd.Parameters.Add("@address3", SqlDbType.NVarChar).Value = address[3].ToString();
                cmd.Parameters.Add("@trustadd0", SqlDbType.NVarChar).Value = trustadd[0].ToString();
                cmd.Parameters.Add("@trustadd1", SqlDbType.NVarChar).Value = trustadd[1].ToString();
                cmd.Parameters.Add("@trustadd2", SqlDbType.NVarChar).Value = trustadd[2].ToString();
                cmd.Parameters.Add("@beni0", SqlDbType.NVarChar).Value = beni[0].ToString();
                cmd.Parameters.Add("@beni1", SqlDbType.NVarChar).Value = beni[1].ToString();
                cmd.Parameters.Add("@trustee0", SqlDbType.NVarChar).Value = trustee[0].ToString();
                cmd.Parameters.Add("@trustee1", SqlDbType.NVarChar).Value = trustee[1].ToString();
                cmd.Parameters.Add("@trustor0", SqlDbType.NVarChar).Value = trustor[0].ToString();

                cmd.Parameters.Add("@trustor1", SqlDbType.NVarChar).Value = trustor[1].ToString();

                if (loan[0].ToString() != "")
                    cmd.Parameters.Add("@loan0", SqlDbType.DateTime).Value = Convert.ToDateTime(loan[0].ToString());
                else
                    cmd.Parameters.Add("@loan0", SqlDbType.DateTime).Value = DBNull.Value;

                cmd.Parameters.Add("@loan1", SqlDbType.NVarChar).Value = loan[1].ToString();
                if (salerec[0].ToString() != "")
                    cmd.Parameters.Add("@salerec0", SqlDbType.DateTime).Value = Convert.ToDateTime(salerec[0].ToString());
                else
                    cmd.Parameters.Add("@salerec0", SqlDbType.DateTime).Value = DBNull.Value;

                cmd.Parameters.Add("@salerec1", SqlDbType.NVarChar).Value = salerec[1].ToString();
                cmd.Parameters.Add("@SValue", SqlDbType.NVarChar).Value = this.txtTSValue.Text;
                cmd.Parameters.Add("@APNValue", SqlDbType.NVarChar).Value = this.txtAPNValue.Text;
                cmd.Parameters.Add("@publishedbidvalue", SqlDbType.NVarChar).Value = this.txtpublishedbidvalue.Text;
                cmd.Parameters.Add("@Unitsvalue", SqlDbType.NVarChar).Value = this.txtUnitsvalue.Text;
                cmd.Parameters.Add("@BDvalue", SqlDbType.NVarChar).Value = this.txtBDvalue.Text;

                cmd.Parameters.Add("@bavalue", SqlDbType.NVarChar).Value = this.txtbavalue.Text;
                cmd.Parameters.Add("@sqftvalue", SqlDbType.NVarChar).Value = this.txtsqftvalue.Text;
                cmd.Parameters.Add("@YRvalue", SqlDbType.NVarChar).Value = this.txtYRvalue.Text;
                cmd.Parameters.Add("@LOTvalue", SqlDbType.NVarChar).Value = this.txtLOTvalue.Text;
                cmd.Parameters.Add("@TMGvalue", SqlDbType.NVarChar).Value = this.txtTMGvalue.Text;
                cmd.Parameters.Add("@USEvalue", SqlDbType.NVarChar).Value = this.txtUSEvalue.Text;
                cmd.Parameters.Add("@zoningvalue", SqlDbType.NVarChar).Value = this.txtzoningvalue.Text;
                cmd.Parameters.Add("@openingbidvalue", SqlDbType.NVarChar).Value = this.txtopeningbidvalue.Text;
                cmd.Parameters.Add("@EstimatedValue", SqlDbType.NVarChar).Value = this.txtestvalue.Text;

                //EIS : 18-April-13 ;#376 Update to the Masterslip
                cmd.Parameters.Add("@LoanDate", SqlDbType.NVarChar).Value = this.txtloan1recdate.Text;
                cmd.Parameters.Add("@LoanDocument", SqlDbType.NVarChar).Value = this.txtloan1doc.Text;
                cmd.Parameters.Add("@TD", SqlDbType.NVarChar).Value = this.txtloan1amt.Text;

                //EIS : 18-April-13 ;#376 Update to the Masterslip
                //cmd.Parameters.Add("@loan2RecDate", SqlDbType.NVarChar).Value = this.txtloan2recdate.Text;
                //cmd.Parameters.Add("@loan2DocNumber", SqlDbType.NVarChar).Value = this.txtloan2doc.Text;
                //cmd.Parameters.Add("@loan2LoanAmount", SqlDbType.NVarChar).Value = this.txtloan2amt.Text;
                //cmd.Parameters.Add("@loan3RecDate", SqlDbType.NVarChar).Value = this.txtloan3recdate.Text;
                //cmd.Parameters.Add("@loan3DocNumber", SqlDbType.NVarChar).Value = this.txtloan3doc.Text;
                //cmd.Parameters.Add("@loan3LoanAmount", SqlDbType.NVarChar).Value = this.txtloan3amt.Text;

                cmd.Parameters.Add("@AppraisalReport", SqlDbType.NVarChar).Value = this.txtappreport.Text;
                cmd.Parameters.Add("@Taxes", SqlDbType.NVarChar).Value = this.txtTaxes.Text;
                cmd.Parameters.Add("@Zestimate", SqlDbType.NVarChar).Value = this.txtZestimate.Text;
                cmd.Parameters.Add("@RecordMeter", SqlDbType.NVarChar).Value = Request.Cookies["user_name"].Value  +  "_MasterSlip"  ;
                

                if (ViewState["UName"] != null)
                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar).Value = Convert.ToString(ViewState["UName"]);
                else
                    cmd.Parameters.Add("@UName", SqlDbType.NVarChar).Value = "";

                cmd.Parameters.Add("@Title", SqlDbType.NVarChar).Value = txttitle.Text;
                cmd.Parameters.Add("@GI", SqlDbType.NVarChar).Value = txtgi.Text;

                if (ViewState["RetFlId"] != null)
                    cmd.Parameters.Add("@RetFlId", SqlDbType.Int).Value = Convert.ToInt32(ViewState["RetFlId"]);
                else
                    cmd.Parameters.Add("@RetFlId", SqlDbType.Int).Value = null;


                cmd.Connection = objmaster.con;




                //strUp = "update RetRequred set StatusId = " + Convert.ToInt32(statusid) + ",AuctionDate = '" + auct[0].ToString() + "',AuctionTime='" + auct[1].ToString() + "',AuctionAdd1='" + auct[2].ToString() + "',AuctionAdd2='" + auct[3].ToString() + "',SITUSTREET='" + address[0].ToString() + "',SITUS1='" + address[1].ToString() + "',SITUS2='" + address[2].ToString() + "',SITUS3='" + address[3].ToString() + "',TrustorOwnerMailingAdd1='" + trustadd[0].ToString() + "',TrustorOwnerMailingAdd2='" + trustadd[1].ToString() + "',TrustorOwnerMailingAdd3='" + trustadd[2].ToString() + "',Beneficiary='" + beni[0].ToString() + "',BeneficiaryPhone='" + beni[1].ToString() + "',Trustee='" + trustee[0].ToString() + "',TrusteePhone='" + trustee[1].ToString() + "',Trustor='" + trustor[0].ToString() + "',TrustorOwnwePhone='" + trustor[1].ToString() + "',LoanDate='" + Convert.ToDateTime(loan[0].ToString()) + "',LoanDocument='" + loan[1].ToString() + "',NOSDate='" + Convert.ToDateTime(salerec[0].ToString()) + "',DateTruncTrstSaleDoc='" + salerec[1].ToString() + "',TS='" + this.txtTSValue.Text + "',APN= '" + this.txtAPNValue.Text + "',MinBid= '" + this.txtpublishedbidvalue.Text + "',Units= '" + this.txtUnitsvalue.Text + "',Bed= '" + this.txtBDvalue.Text + "', Bath= '" + this.txtbavalue.Text + "',BLDSqrFt= '" + this.txtsqftvalue.Text + "',YearBuiltTruncated= '" + this.txtYRvalue.Text + "',LOTAR= '" + this.txtLOTvalue.Text + "',TMG= '" + this.txtTMGvalue.Text + "',USECode= '" + this.txtUSEvalue.Text + "',Zoning= '" + this.txtzoningvalue.Text + "',OpeningBid = '" + this.txtopeningbidvalue.Text + "',UpdatedBy=' " + Convert.ToString(ViewState["UName"]) + " '  where RetFlId = '" + ViewState["RetFlId"].ToString() + "'";



                //obj.AUDOP(strUp);
                if (objmaster.con.State == ConnectionState.Open)
                {
                    objmaster.con.Close();
                }
                objmaster.con.Open();
                cmd.ExecuteNonQuery();
                objmaster.con.Close();
                //string strSaleDate = "update RetRequred set RecDate = '" + this.txtSaleDate.Text + "' where RetFlId = '" + ViewState["id"].ToString() + "'";
                //obj.AUDOP(strSaleDate);

                if (ViewState["MB"] != null && ViewState["OB"] != null && ViewState["OB"] != null)
                    if (this.txtpublishedbidvalue.Text != ViewState["MB"].ToString() || this.txtopeningbidvalue.Text != ViewState["OB"].ToString())
                    {
                        string strBidUp = "update RetRequred set MBidEdit = '1'  , RecordMeter = '" + Request.Cookies["user_name"].Value + "_MasterSlip'" + " where RetFlId = '" + ViewState["RetFlId"].ToString() + "'";
                        objmaster.AUDOP(strBidUp);
                    }
                if (ViewState["SN"] != null && ViewState["A1"] != null && ViewState["A2"] != null && ViewState["A3"] != null)
                    if (address[0].ToString() != ViewState["SN"].ToString() || address[1].ToString() != ViewState["A1"].ToString() || address[2].ToString() != ViewState["A2"].ToString() || address[3].ToString() != ViewState["A3"].ToString())
                    {
                        string strAddUp = "update RetRequred set MAddEdit = '1'  , RecordMeter = '" + Request.Cookies["user_name"].Value + "_MasterSlip'" + " where RetFlId = '" + ViewState["id"].ToString() + "'";
                        objmaster.AUDOP(strAddUp);
                    }
                if (ViewState["SI"] != null && ViewState["SI"] != null)
                    if (Convert.ToString(ViewState["SI"]) != "16" && Convert.ToString(ViewState["SI"]) != "17")
                    {
                        string strPreS = "update RetRequred set PrevStatusid='" + Convert.ToString(ViewState["SI"]) + "' , RecordMeter = '" +  Request.Cookies["user_name"].Value  +  "_MasterSlip'" +  " where RetFlId = '" + ViewState["RetFlId"].ToString() + "'";                            
                        objmaster.AUDOP(strPreS);
                    }
                if (ViewState["status"] != null)
                    statuschanged(ViewState["status"].ToString());

                //this.lblMsg.Visible = true;
                //this.lblMsg.Text = "Data saved sucessfully.";

                FillRetranData();
            }
            catch
            {

            }
        }

        public void statuschanged(string status)
        {
            ViewState["status"] = status;
            if (objmaster.con.State == ConnectionState.Open)
            {
                objmaster.con.Close();
            }
            objmaster.con.Open();
            ds = new DataSet();
            cmd = new SqlCommand("DataRetanSelectStatus", objmaster.con);
            cmd.Parameters.Add("@Type", SqlDbType.NVarChar, 50).Value = "RETRAN";
            cmd.Parameters.Add("@Status", SqlDbType.NVarChar, 50).Value = status;
            if (ViewState["txtdate"].ToString() == "")
            {
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50).Value = Convert.ToString(System.DateTime.Now.ToString("MM/dd/yy"));
            }
            else
            {
                cmd.Parameters.Add("@Date", SqlDbType.NVarChar, 50).Value = Convert.ToString(Convert.ToDateTime(ViewState["txtdate"]).ToString("MM/dd/yy"));
            }
            cmd.CommandType = CommandType.StoredProcedure;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            objmaster.con.Close();
            // lblCount.Text = ds.Tables[0].Rows.Count.ToString();

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (ddlPrinter.SelectedValue != "0")
            {
                //EIS 24-Jul-2013 #410 Console Printing Utility
                //Session["SelectedPrinter"] = ddlPrinter.SelectedValue;

                //string url = "finalprint2.aspx";
                //string fullURL = "window.open('" + url + "', '_blank', 'height=500,width=800,status=yes,toolbar=no,menubar=no,location=no,scrollbars=yes,resizable=yes,titlebar=no' );";
                //ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", fullURL, true);

                bool isPrintSuccess = false;
                MemoryStream printStream = new MemoryStream();
                string apn = txtAPNValue.Text.Trim();
                string mapSource = string.Empty;
                string reportType = string.Empty;

                if (chkMSlip.Checked == true || chkMLS.Checked == true)
                {
                    if (chkMSlip.Checked == true && chkMLS.Checked == true)//Masterslip + Map
                    {
                        reportType = "comps";
						//PrintOption po = new PrintOption();
						//mapSource = po.GetGMapSource(apn);
                    }
                    else if (chkMSlip.Checked == true)//Masterslip
                    {
                        reportType = "masterslip";
                    }
                    else if (chkMLS.Checked == true)//Map
                    {
                        reportType = "map";
						//PrintOption po = new PrintOption();
						//mapSource = po.GetGMapSource(apn);
                    }

					//PropertyPrintReport2 report2 = new PropertyPrintReport2(reportType, Convert.ToInt32(ViewState["RetFlId"].ToString()), apn, mapSource);
					//report2.ExportToPdf(printStream);
					//string filename = Guid.NewGuid().ToString() + ".pdf";
					//byte[] bytes = printStream.GetBuffer();
					//printStream.Write(bytes, 0, bytes.Length);
					//clsAmazon.WriteMemoryStreamToFile("Print", filename, printStream);

					//string description = ViewState["RetFlId"].ToString() + "|" + txtTSValue.Text.Trim();
					//int id = obj.AUDOPID("INSERT INTO PrintQueue (Filename,PrinterId,StartTime,Status,Description,SubmittedBy,FormName) VALUES ('" + filename + "'," + int.Parse(ddlPrinter.SelectedValue.ToString()) + ",'" + DateTime.Now + "','Awaiting','" + description + "','" + Request.Cookies["user_name"].Value + "','tabMasterSlip'); SELECT SCOPE_IDENTITY()");

                    try
                    {
						//PrintServiceReference.StatusClient cl = new PrintServiceReference.StatusClient();
						//cl.ClientCredentials.UserName.UserName = ConfigurationManager.AppSettings["PrintServiceUsername"].ToString();
						//cl.ClientCredentials.UserName.Password = ConfigurationManager.AppSettings["PrintServicePassword"].ToString();
						//isPrintSuccess = cl.SendPrintJobToPrinter(id);
                    }
                    catch (Exception ex)
                    {
                        //obj.AUDOP("UPDATE PrintQueue SET ErrorMessage='Foreclosure => " + ex.ToString().Replace("'", "''") + "' WHERE ID=" + id);
                    }

                    if (isPrintSuccess)
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Printing Successful');", true);
                    else
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Error... Please try again');", true);
                }
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Please select the printer...');", true);
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Please select the printer...');", true);
        }

        public static string GetIPAddress()
        {
            System.Web.HttpContext context = System.Web.HttpContext.Current;
            string sIPAddress = context.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(sIPAddress))
            {
                return context.Request.ServerVariables["REMOTE_ADDR"];
            }
            else
            {
                string[] ipArray = sIPAddress.Split(new Char[] { ',' });
                return ipArray[0];
            }
        }
    }
}
