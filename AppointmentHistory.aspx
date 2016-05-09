<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AppointmentHistory.aspx.cs" Inherits="AppointmentHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <h2>Appointment History
    </h2>
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

</asp:Content>

