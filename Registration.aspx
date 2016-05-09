<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registartion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <div class="row">
        <asp:Label runat="server" ID="lbl_exists" Text="User Exists choose another id" Visible="false"></asp:Label>
        <section id="Register" runat="server" visible="true">
            <div class="form-horizontal">
                <br />
                <h4>Register Here.</h4>
                <hr />
                <asp:PlaceHolder runat="server" ID="PlaceHolder1" Visible="false">
                    <p class="text-danger">
                        <asp:Literal runat="server" ID="Literal1" />
                    </p>
                </asp:PlaceHolder>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txt_UserID" CssClass="col-md-3 control-label">User name</asp:Label>
                    <div class="col-md-9">
                        <asp:TextBox runat="server" ID="txt_UserID" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_UserID" ValidationGroup="Register"
                            CssClass="text-danger" ErrorMessage="The user name field is required." />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txt_Password" CssClass="col-md-3 control-label">Password</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Password" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Password"
                            CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="Register" />
                    </div>
                    <asp:Label runat="server" AssociatedControlID="txt_ConfirmPassword"
                        CssClass="col-md-3 control-label">Confirm Password</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_ConfirmPassword" TextMode="Password" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_ConfirmPassword"
                            CssClass="text-danger" ErrorMessage="The password field is required." ValidationGroup="Register" />
                        <asp:CompareValidator runat="server" ControlToCompare="txt_Password"
                            ControlToValidate="txt_ConfirmPassword" CssClass="text-danger" ErrorMessage="The password field did not match."
                            ValidationGroup="Register"></asp:CompareValidator>
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txt_SecQuestion" CssClass="col-md-3 control-label">Security Question</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_SecQuestion" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_SecQuestion"
                            CssClass="text-danger" ErrorMessage="The security question field is required." ValidationGroup="Register" />
                    </div>
                    <asp:Label runat="server" AssociatedControlID="txt_SecAnswer"
                        CssClass="col-md-3 control-label">Security Answer</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_SecAnswer" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_SecAnswer"
                            CssClass="text-danger" ErrorMessage="The security answer field is required." ValidationGroup="Register" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txt_Name" CssClass="col-md-3 control-label">Name</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Name" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Name"
                            CssClass="text-danger" ErrorMessage="The Name field is required." ValidationGroup="Register" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txt_Mobile" CssClass="col-md-3 control-label">
                        Mobile Number</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Mobile" TextMode="Number" min="0" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Mobile"
                            CssClass="text-danger" ErrorMessage="The Mobile Number field is required." ValidationGroup="Register" />
                    </div>
                    <asp:Label runat="server" AssociatedControlID="txt_Email"
                        CssClass="col-md-3 control-label">Email</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Email" CssClass="form-control" TextMode="Email"/>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Email"
                            CssClass="text-danger" ErrorMessage="The email field is required." ValidationGroup="Register" />
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" AssociatedControlID="txt_Address" CssClass="col-md-3 control-label">Address</asp:Label>
                    <div class="col-md-3">
                        <asp:TextBox runat="server" ID="txt_Address" CssClass="form-control" />
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_Address"
                            CssClass="text-danger" ErrorMessage="The address field is required." ValidationGroup="Register" />
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-offset-2 col-md-10">
                        <a href="Login.aspx" class="btn btn-info btn-sm">Login</a>
                        <asp:Button CssClass="btn btn-info btn-sm" runat="server" OnClick="btn_Register_Click" ValidationGroup="Register" Text="Register" ID="btn_Register" />
                    </div>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

