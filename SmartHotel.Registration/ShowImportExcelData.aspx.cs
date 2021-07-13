
using ExcelDataReader;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHotel.Registration
{
    public partial class ShowImportExcelData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string filepath = Request.QueryString["filepath"].ToString();
                BindGrid(filepath);
            }
           
        }

        protected void RegistrationGrid_SelectedIndexChanged(Object sender, EventArgs e)
        {
            GridViewRow row = RegistrationGrid.SelectedRow;

            var registrationId = RegistrationGrid.DataKeys[RegistrationGrid.SelectedIndex]["Id"];
            var registrationType = RegistrationGrid.DataKeys[RegistrationGrid.SelectedIndex]["Type"].ToString();

            if (registrationType == "CheckIn")
            {
                Response.Redirect($"Checkin.aspx?registration={registrationId}");
            }

            if (registrationType == "CheckOut")
            {
                Response.Redirect($"Checkout.aspx?registration={registrationId}");
            }
        }

        protected void RegistrationGrid_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType != DataControlRowType.DataRow)
                return;
            e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(RegistrationGrid, "Select$" + e.Row.RowIndex);
        }

        public void BindGrid(string filename)
        {
            
            //----------------Get File from azure blob stoarge----------------------------------//
            string storageName = "smarthotelappstr";
            string storagekey = "rLUGJmc6ruwOJHRdsQC6rErh9nxPM3vzz18uR+Tq2IlZXyjqE3Ych1MsU2eTg4lDNA3XgSDAcHreIXCA5Ps2sQ==";

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageName, storagekey));

            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();

            CloudBlobContainer container = blobClient.GetContainerReference("excelcont");

            // Retrieve reference to a blob 
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);

            DataSet ds;
            using (var memoryStream = new MemoryStream())
            {
                //downloads blob's content to a stream
                blockBlob.DownloadToStream(memoryStream);
                var excelReader = ExcelReaderFactory.CreateOpenXmlReader(memoryStream);
                ds = excelReader.AsDataSet();
                DataTable dt = new DataTable();
                dt.Columns.Add("Id", typeof(string));
                dt.Columns.Add("Type", typeof(string));
                dt.Columns.Add("CustomerName", typeof(string));
                dt.Columns.Add("Passport", typeof(string));
                dt.Columns.Add("CustomerId", typeof(string));
                dt.Columns.Add("Address", typeof(string));  
                
                ds.Tables[0].AsEnumerable().Skip(1).ToList().ForEach(dr => dt.Rows.Add(dr[0], dr[7], dr[2], dr[6], dr[2],dr[0]));
                RegistrationGrid.DataSource = dt;
                //binding the gridview  
                RegistrationGrid.DataBind();
                excelReader.Close();
            }          
            lbltxt.Text = "File uplaod successfully";
        }

    }
}