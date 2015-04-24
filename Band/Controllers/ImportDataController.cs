using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Band.Models;
using System.Text;
using System.IO;
using System.Data.OleDb;

namespace Band.Controllers
{
    public class ImportDataController : Controller
    {
        //
        // GET: /ImportData/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Upload()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public string Upload(HttpPostedFileBase uploadFile)
        {
            StringBuilder strValidations = new StringBuilder(string.Empty);
            try
            {
                if (uploadFile.ContentLength > 0)
                {
                    string filePath = Path.Combine(HttpContext.Server.MapPath("../Uploads"),
                   Path.GetFileName(uploadFile.FileName));
                    uploadFile.SaveAs(filePath);
                    DataSet ds = new DataSet();

                    //A 32-bit provider which enables the use of

                    string ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;";

                    using (OleDbConnection conn = new System.Data.OleDb.OleDbConnection(ConnectionString))
                    {
                        conn.Open();
                        using (DataTable dtExcelSchema = conn.GetSchema("Tables"))
                        {
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            string query = "SELECT * FROM [" + sheetName + "]";
                            OleDbDataAdapter adapter = new OleDbDataAdapter(query, conn);
                            //DataSet ds = new DataSet();
                            adapter.Fill(ds, "Items");
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                                    {
                                        //insert this data to database
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return "";
        }
    }
}