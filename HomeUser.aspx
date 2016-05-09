<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HomeUser.aspx.cs" Inherits="HomeUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>
        <asp:Label runat="server" ID="lbl_name" Text=""></asp:Label>
    </h2>
    <fieldset>
        <legend>Appointments</legend>
        <article>
            Your appointments information will be displayed in here.
            <br />
            <a class="btn btn-info btn-xs " style="float: right;" href="MakeAppointment.aspx">Create Appointment</a>
            <br />
            <br />
            <a class="btn btn-info btn-xs " style="float: right;" href="AppointmentHistory.aspx">Appointment History</a>
        </article>
    </fieldset>
    <fieldset>
        <legend>Insurance Details</legend>
        <article>
            Insuracne details can be found in here
        <a class="btn btn-info btn-xs " style="float: right;" href="InsuranceDetails.aspx">Insurance Details</a>
            <br />
            <br />
            <a class="btn btn-info btn-xs " style="float: right;" href="BuyInsurance.aspx">Buy Insurance</a>
        </article>
    </fieldset>
    <fieldset>
        <legend>Get Prescription</legend>
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddl_dateAppCompleted" CssClass="col-md-2 control-label">Date </asp:Label>
            <div class="col-md-9">
                <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_dateAppCompleted" OnSelectedIndexChanged="ddl_dateAppCompleted_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </div>
        <br />
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txt_prescription" CssClass="col-md-2 ">Prescription</asp:Label>
            <div class="col-md-9">
                <asp:TextBox TextMode="MultiLine" runat="server" Rows="6" ID="txt_prescription" CssClass="form-control" Enabled="false" Text="NA" />
            </div>
        </div>
    </fieldset>

</asp:Content>

