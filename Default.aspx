<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>My Doctor</h1>
        <p class="lead">
            My Doctor is an online portal to contact your personal doctor at your free time. Our doctors are always at your service.
        </p>
        <p><a href="About.aspx" class="btn btn-primary btn-lg">Know more&raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Login/Signup</h2>
            <p>
                Doctors portal has specialist at varied levels who wil be available for your service 24/7. All you got to do is make an appointment and be there on time. Please register from below.
            </p>
            <p>
                <a class="btn btn-default" href="Login.aspx">Know more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Make an Appointment</h2>
            <p>
                All the docotors at this are portal will be available at your service only with an appoinment. So, why are thinking register with us and make an appointment. 
            </p>
            <p>
                <a class="btn btn-default" href="MakeAppointment.aspx">Know more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Buy Insurance</h2>
            <p>
                You can buy insurance from us by which you will be able get all the services from us. Please follow the below link to buy the insurance.
            </p>
            <p>
                <a class="btn btn-default" href="BuyInsurance.aspx">know  more &raquo;</a>
            </p>
        </div>
    </div>
</asp:Content>
