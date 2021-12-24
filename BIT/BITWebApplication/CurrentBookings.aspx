<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CurrentBookings.aspx.cs" Inherits="BITWebApplication.CurrentBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">

    <h1>Current Bookings</h1>

    <%--<asp:GridView ID="gridCurrentBookings" runat="server" />--%>

    <asp:GridView CssClass="table table-striped table-bordered" ID="gvCurrentBookings" runat="server" AutoGenerateColumns="false" >
        <Columns>
            <asp:BoundField HeaderText="Job Request ID" DataField="JobRequest_ID" />
            <asp:BoundField HeaderText="Client ID" DataField="Client_ID" Visible="false" />
            <asp:BoundField HeaderText="Contractor Name" DataField="FirstName" />
            <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
            <asp:BoundField HeaderText="Service Date" DataField="Date" />
            <asp:BoundField HeaderText="Service Start Time" DataField="StartTime" />
            <asp:BoundField HeaderText="Request Status" DataField="RequestStatus" />
            <asp:BoundField HeaderText="Kilometers" DataField="Kilometers" />
        </Columns>
    </asp:GridView>
</asp:Content>
