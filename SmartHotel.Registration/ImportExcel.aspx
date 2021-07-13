<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ImportExcel.aspx.cs" Inherits="SmartHotel.Registration.ExcelGridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        .Cntrl1
      {
       background-color:#abcdef;
       
       border: 1px solid #AB00CC;
       font: Verdana 10px;
       padding: 1px 4px;
       font-family: Palatino Linotype, Arial, Helvetica, sans-serif;
       
      }
    </style>
     
    <div class="row" style="margin-top:143px">
       <span style="margin-left: 435px;color:steelblue">Uploaded Customer Excel Data</span>
        <div class="col-lg-12">
            
            <div class="col-lg-4"></div>
             
            <div class="col-lg-8">
                
                <div class="col-lg-5">
                   
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="Cntrl1"/>
                      <asp:Label ID="lbltxt" runat="server" ForeColor="Red"></asp:Label>
                </div>
                <div class="col-lg-3">
                     <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /> 
                   
                    </div>
            </div>
            
        </div>
    </div>
   
      

</asp:Content>
