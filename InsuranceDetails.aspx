<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="InsuranceDetails.aspx.cs" Inherits="InsuranceDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h4>Insurance Details</h4>
      <hr />
    <section id="Insurancedetails" runat="server">
        <div class="form-horizontal">
          
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">User name</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" Text="NA" ID="txt_UserID" CssClass="form-control" Enabled="false"/>
                </div>
                
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Plan</asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" Text="NA" ID="txt_plan" CssClass="form-control" Enabled="false"/>
                </div>
                <asp:Label runat="server" CssClass="col-md-2 control-label">Expires ON</asp:Label>
                <div class="col-md-3">
                    <asp:TextBox runat="server" Text="NA" ID="txt_date" CssClass="form-control" Enabled="false"/>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Insurance Number</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txt_id" Text="NA" CssClass="form-control" Enabled="false"/>
                </div>
                
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <a class="btn btn-info btn-sm" href="HomeUser.aspx">Go Back</a>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

