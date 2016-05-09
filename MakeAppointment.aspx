<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="MakeAppointment.aspx.cs" Inherits="MakeAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <section id="loginForm" runat="server">
        <div class="form-horizontal">
            <h4>Make Appointment Here</h4>
            <hr />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddl_Specialization" CssClass="col-md-2 control-label">Specialization</asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Specialization" CssClass="form-control" 
                        OnSelectedIndexChanged="ddl_Specialization_SelectedIndexChanged" AutoPostBack="true" runat="server" >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_Specialization" InitialValue="Select"
                        CssClass="text-danger" ErrorMessage="The user name field is required." />
                </div>
                <asp:Label runat="server" AssociatedControlID="ddl_Doctors" CssClass="col-md-2 control-label">Doctor Available</asp:Label>
                <div class="col-md-3">
                    <asp:DropDownList ID="ddl_Doctors" AutoPostBack="true"  CssClass="form-control" runat="server" ></asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txt_Date" CssClass="col-md-2 control-label">Date needed</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txt_Date" TextMode="Date" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Date" CssClass="text-danger" ErrorMessage="The date field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Create Appointment" CssClass="btn btn-info btn-sm" ID="btn_Create" OnClick="btn_Create_Click"/>
                </div>
            </div>
        </div>
    </section>
</asp:Content>

