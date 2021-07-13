using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHotel.Registration
{
    public partial class ExcelGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                //---Upload file in app folder-- //        
                string filename = FileUpload1.PostedFile.FileName;
                string savefilepath = Server.MapPath("~/images/");
                if (!Directory.Exists(savefilepath))
                {
                    Directory.CreateDirectory(savefilepath);
                }
                FileUpload1.SaveAs(savefilepath + FileUpload1.PostedFile.FileName);

                //---Upload file in azure blob stoarge account -- //  
                string storageName = "smarthotelappstr";
                string storagekey = "rLUGJmc6ruwOJHRdsQC6rErh9nxPM3vzz18uR+Tq2IlZXyjqE3Ych1MsU2eTg4lDNA3XgSDAcHreIXCA5Ps2sQ==";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(String.Format("DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1}", storageName, storagekey));
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                // Retrieve reference to a container and create if not exists. 
                CloudBlobContainer container = blobClient.GetContainerReference("excelcont");
                container.CreateIfNotExists();
                // Retrieve reference to a blob  
                CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
                //upload file using specified path 
                using (FileStream fs = File.OpenRead(savefilepath + FileUpload1.PostedFile.FileName))
                {
                    blockBlob.UploadFromStream(fs);
                }
                ShowGrid(filename);
                
            }
            catch (Exception ex)
            {

                lbltxt.Text = ex.Message;
            }        
          
        }

        public void ShowGrid(string filename)
        {
            Response.Redirect("ShowImportExcelData.aspx?filepath=" + filename,false);
        }
    }
}