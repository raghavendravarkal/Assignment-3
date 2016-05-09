<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="BuyInsurance.aspx.cs" Inherits="BuyInsurance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="Server">
    <section id="buy" runat="server">
        <h4>Buy Here</h4>
        <div class="form-horizontal">
            <hr />
            <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                <p class="text-danger">
                    <asp:Literal runat="server" ID="FailureText" />
                </p>
            </asp:PlaceHolder>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="ddl_plan" CssClass="col-md-2 control-label">Plan Details</asp:Label>
                <div class="col-md-10">
                    <asp:DropDownList ID="ddl_plan" runat="server">
                        <asp:ListItem Value="Golden" Text="Golden" Selected="True"></asp:ListItem>
                        <asp:ListItem Value="Platinum" Text="Platinum"></asp:ListItem>
                        <asp:ListItem Value="Regular" Text="Regular"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txt_expired" CssClass="col-md-2 control-label">Till Date Needed</asp:Label>
                <div class="col-md-10">
                    <asp:TextBox runat="server" ID="txt_expired" TextMode="Date" CssClass="form-control" />
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="txt_expired" CssClass="text-danger" ErrorMessage="The date field is required." />
                </div>
            </div>
            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" Text="Buy" CssClass="btn btn-info btn-sm" ID="btn_Buy" OnClick="btn_Buy_Click" />
                </div>
            </div>
        </div>
    </section>
    <section id="bought" runat="server" visible="false">
        <div class="form-horizontal">
            <hr />
            <h4>You have successfully bought the insurance and it will visible in your home page.
                <br />Note: Your old Insurance policy has been renewed
            </h4>
            <br />
            <a href="HomeUser.aspx" class="btn btn-info btn-sm" >Go to Home</a>

        </div>
    </section>
</asp:Content>

