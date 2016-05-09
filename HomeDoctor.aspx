<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="HomeDoctor.aspx.cs" Inherits="HomeDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>Welcome to Dashboard
    </h2>

    <fieldset>
        <legend>Active Appointments</legend>

        <div class="panel-body">
            <div id="div_MainPanel" runat="server" visible="false">
                <div class="col-lg-12 ">
                    <div class="table-responsive">
                        <asp:GridView ID="dataGrid1" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="False">
                            <Columns>
                                <asp:BoundField DataField="name" HeaderText="Name" />
                                <asp:BoundField DataField="mobile" HeaderText="Mobile Number" />
                                <asp:BoundField DataField="mail" HeaderText="e-Mail ID" />
                                <asp:BoundField DataField="dateneeded" HeaderText="Date Booked" />
                                <asp:BoundField DataField="status" HeaderText="Appointment Status" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
            <div class="row" id="div_mainPanelEmpty" runat="server" visible="false">
                <br />
                <div class="col-lg-12">
                    <div class="alert alert-info">
                        Sorry. Donors not available in the current region.
                    </div>
                </div>
            </div>
        </div>

    </fieldset>

    <fieldset>
        <legend>Confirm Appointments</legend>
        <article>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddl_patient" CssClass="col-md-2 control-label">Patient Name</asp:Label>
                <div class="col-md-9">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_patient" AutoPostBack="true"
                        OnSelectedIndexChanged="ddl_patient_SelectedIndexChanged">
                    </asp:DropDownList>
                </div>
            </div>

            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Patient name</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" Text="NA" ID="txt_patientName" CssClass="form-control" Enabled="false" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Appointment Date</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" Text="NA" ID="txt_dateApptointment" CssClass="form-control" Enabled="false" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" CssClass="col-md-2 control-label">Status</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" Text="NA" ID="txt_status" CssClass="form-control" Enabled="false" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" CssClass="btn btn-info btn-sm" ID="btn_confirm" OnClick="btn_confirm_Click" Text="Confirm"></asp:Button>
                </div>
            </div>
        </article>
    </fieldset>

    <fieldset>
        <legend>Take up</legend>
        <article>
            You can take up case in here
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddl_PatientActive" CssClass="col-md-2 control-label">User name</asp:Label>
                <div class="col-md-9">
                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddl_PatientActive">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="ddl_PatientActive" InitialValue="Select" ValidationGroup="Register"
                        CssClass="text-danger" ErrorMessage="The patient name field is required." />
                </div>

            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txt_prescription" CssClass="col-md-2 ">Prescription</asp:Label>
                <div class="col-md-9">
                    <asp:TextBox TextMode="MultiLine" runat="server" Rows="6" ID="txt_prescription" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_prescription" ValidationGroup="Register"
                        CssClass="text-danger" ErrorMessage="The prescription field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button CssClass="btn btn-info btn-sm" runat="server" ID="btn_CreatePrescription" Text="Create Prescription"
                        OnClick="btn_CreatePrescription_Click"></asp:Button>
                </div>
            </div>

        </article>
    </fieldset>
</asp:Content>

