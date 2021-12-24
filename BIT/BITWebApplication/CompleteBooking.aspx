<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CompleteBooking.aspx.cs" Inherits="BITWebApplication.CompleteBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Complete Booking</h1>

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-6">
                <label>Job Request ID</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtRequestJobId" runat="server" Enabled="false"/>
                </div>
            </div>
            <div class="col-md-6">
                <label>Kilometers</label>
                <div class="form-group">
                    <asp:TextBox CssClass="form-control" ID="txtKilometers" runat="server" placeholder="Enter Kilometers" />
                    <asp:RequiredFieldValidator ID="rpvKilometers" runat="server" ErrorMessage="Please Enter Kilometers" ControlToValidate="txtKilometers"  style="color:red;"/>
                    <br />
                    <asp:CustomValidator ID="CustomKilometerValidator" runat="server" ErrorMessage="Kilometers must be a number" OnServerValidate="CustomKilometerValidator_ServerValidate" style="color:red;"/>
                </div>
            </div>
            <hr />
            <div class="row">
                <div class="col-12">
                    <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnComplete" Text="Complete Service" runat="server" OnClick="btnComplete_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
