using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;

namespace ForeClosure
{
    public static class clsPrint
    {
        static ForeClosure.DataBase obj = new ForeClosure.DataBase();

        public static void BindPrinters(DropDownList ddlPrinter)
        {
            DataTable dtPrinters = new DataTable();

            //dtPrinters = obj.FillDataSet("SELECT * FROM  CloudPrinter").Tables[0];

            //DataRow dr = dtPrinters.NewRow();
            //dr["PrinterName"] = "--- Select ---";
            //dr["PrinterCode"] = "0";
            //dtPrinters.Rows.InsertAt(dr, 0);

            //ddlPrinter.DataSource = dtPrinters;
            //ddlPrinter.DataTextField = "PrinterName";
            //ddlPrinter.DataValueField = "PrinterCode";
            //ddlPrinter.DataBind();

            //EIS 24-Jul-2013 #410 Console Printing Utility
            dtPrinters = obj.FillDataSet("SELECT * FROM  PrinterList WHERE IsDeleted=0").Tables[0];

            DataRow dr = dtPrinters.NewRow();
            dr["PrinterName"] = "--- Select ---";
            dr["PrinterID"] = "0";
            dtPrinters.Rows.InsertAt(dr, 0);

            ddlPrinter.DataSource = dtPrinters;
            ddlPrinter.DataTextField = "PrinterName";
            ddlPrinter.DataValueField = "PrinterID";
            ddlPrinter.DataBind();
        }

        public static DataTable GetPrinters()
        {
           return(obj.FillDataSet("SELECT * FROM  PrinterList WHERE IsDeleted=0").Tables[0]);
        }

    }
}