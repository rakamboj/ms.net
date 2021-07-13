using SmartHotel.Registration.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SmartHotel.Registration
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
            if (IsPostBack)
                return;

            //using (var client = ServiceClientFactory.NewServiceClient())
            //{
            //    var registrations = client.GetTodayRegistrations();
            //    RegistrationGrid.DataSource = registrations;
            //    RegistrationGrid.DataBind();
            //}
            
            var registrations = new Service().GetTodayRegistrations();
            RegistrationGrid.DataSource = registrations;
            RegistrationGrid.DataBind();
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

        protected void UploadToExcel(Object sender, EventArgs e)
        {
            var grid = new GridView();
            //using (var client = ServiceClientFactory.NewServiceClient())
            //{
            //    var registrations = client.GetTodayRegistrations();
            //    grid.DataSource = registrations;
            //    grid.DataBind();
            //}
            var registrations = new Service().GetTodayRegistrations();
            grid.DataSource = registrations;
            grid.DataBind();

            grid.DataBind();
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=CustomerList.xls");
            Response.ContentType = "application/excel";
            //Response.WriteFile(@"C:\New folder\SmartHotel360-internal-booking-apps-master\media\CustomerList.xls");
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            grid.RenderControl(htw);
            string renderedGridView = sw.ToString();
            //File.WriteAllText(@"E:\CustomerList.xls", renderedGridView);
            Response.Write(sw.ToString());           
            Response.End();
            
        }

        protected void btnimport_Click(object sender, EventArgs e)
        {
            Response.Redirect("ImportExcel.aspx");
        }
    }
}