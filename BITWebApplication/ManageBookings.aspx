<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageBookings.aspx.cs" Inherits="BITWebApplication.ManageBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Manage Bookings</h1>
    <br />
    <hr />
    <h2>Current Bookings</h2>
    <div class="row">
        <div class="col-12">
            <asp:GridView CssClass="table table-striped table-bordered" ID="gvCurrentSessions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvCurrentSessions_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Job Request ID" DataField="JobRequest_ID" />
                    <asp:BoundField HeaderText="Client ID" DataField="Client_ID" />
                    <asp:BoundField HeaderText="Contractor Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
                    <asp:BoundField HeaderText="Service Date" DataField="Date" />
                    <asp:BoundField HeaderText="Service Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="Request Status" DataField="RequestStatus" />
                    <asp:BoundField HeaderText="Kilometers" DataField="Kilometers" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <br />

    <h2>Completed Bookings</h2>
    <div class="row">
        <div class="col-12">
            <asp:GridView CssClass="table table-striped table-bordered" ID="gvManageSessions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvManageSessions_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Job Request ID" DataField="JobRequest_ID" />
                    <asp:BoundField HeaderText="Client ID" DataField="Client_ID" />
                    <asp:BoundField HeaderText="Contractor Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
                    <asp:BoundField HeaderText="Service Date" DataField="Date" />
                    <asp:BoundField HeaderText="Service Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="Request Status" DataField="RequestStatus" />
                    <asp:BoundField HeaderText="Kilometers" DataField="Kilometers" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnVerify" runat="server" Text="Verify" Width="80px" Height="40px" CommandName="Verify" CommandArgument="<%# Container.DataItemIndex %>"/>
                            <asp:Button ID="btnSendForPayment" runat="server" Text="SendForPayment" Width="140px" Height="40px" CommandName="SendForPayment" CommandArgument="<%# Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <br />

    <h2>Past Bookings</h2>
    <div class="row">
        <div class="col-12">
            <asp:GridView CssClass="table table-striped table-bordered" ID="gvPastSessions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvPastSessions_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Job Request ID" DataField="JobRequest_ID" />
                    <asp:BoundField HeaderText="Client ID" DataField="Client_ID" />
                    <asp:BoundField HeaderText="Contractor Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
                    <asp:BoundField HeaderText="Service Date" DataField="Date" />
                    <asp:BoundField HeaderText="Service Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="Request Status" DataField="RequestStatus" />
                    <asp:BoundField HeaderText="Kilometers" DataField="Kilometers" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
