<%@ Page Title="Uploaded Custome Data" Language="C#" MasterPageFile="~/Site.Master"  EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ShowImportExcelData.aspx.cs" Inherits="SmartHotel.Registration.ShowImportExcelData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
       <div>
          <h1>Uploaded Customer Data</h1>
      	</div>
        <asp:Label ID="lbltxt" runat="server" ForeColor="Green"></asp:Label>
        <asp:GridView ID="RegistrationGrid" runat="server"
            OnSelectedIndexChanged="RegistrationGrid_SelectedIndexChanged"
            OnRowDataBound="RegistrationGrid_RowDataBound"
            DataKeyNames="Id,Type"
            AutoGenerateColumns="false"
            ShowHeader="true">
            <Columns>
                <asp:BoundField DataField="Id" Visible="false" />
                <asp:BoundField DataField="Type" Visible="false" />
                <asp:BoundField DataField="CustomerName" HeaderText="Cutomer Name" />
                <asp:BoundField DataField="Passport" HeaderText="Passport" />
                <asp:BoundField DataField="CustomerId" HeaderText="Customer Id" />
                <asp:BoundField DataField="Address" HeaderText="Address" />
                <asp:BoundField DataField="Type" HeaderText="Operation" />
            </Columns>
        </asp:GridView>
      
    </div>
</asp:Content>
