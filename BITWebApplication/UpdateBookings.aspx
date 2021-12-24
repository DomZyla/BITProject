<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UpdateBookings.aspx.cs" Inherits="BITWebApplication.UpdateBookings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Update Bookings</h1>

    <div class="row">
        <div class="col-12">
            <asp:GridView CssClass="table table-striped table-bordered" ID="gvUpdateSessions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvUpdateSessions_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Job Request ID" DataField="JobRequest_ID" />
                    <asp:BoundField HeaderText="Client ID" DataField="Client_ID" />
                    <asp:BoundField HeaderText="Contractor Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
                    <asp:BoundField HeaderText="Service Date" DataField="Date" />
                    <asp:BoundField HeaderText="Service Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="Request Status" DataField="RequestStatus" />
                    <asp:BoundField HeaderText="Kilometers" DataField="Kilometers" Visible="false"/>
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnAccept" runat="server" Text="Accept" Width="80px" Height="40px" CommandName="Accept" CommandArgument="<%# Container.DataItemIndex %>"/>
                            <asp:Button ID="btnReject" runat="server" Text="Reject" Width="80px" Height="40px" CommandName="Reject" CommandArgument="<%# Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <h1>In-Progress Bookings</h1>

    <div class="row">
        <div class="col-12">
            <asp:GridView CssClass="table table-striped table-bordered" ID="gvProgressSessions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvProgressSessions_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Job Request ID" DataField="JobRequest_ID" />
                    <asp:BoundField HeaderText="Client ID" DataField="Client_ID" />
                    <asp:BoundField HeaderText="Contractor Name" DataField="FirstName" />
                    <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
                    <asp:BoundField HeaderText="Service Date" DataField="Date" />
                    <asp:BoundField HeaderText="Service Start Time" DataField="StartTime" />
                    <asp:BoundField HeaderText="Request Status" DataField="RequestStatus" />
                    <asp:BoundField HeaderText="Kilometers" DataField="Kilometers" Visible="false" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnComplete" runat="server" Text="Complete Booking" Width="80px" Height="40px" CommandName="Complete" CommandArgument="<%# Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

</asp:Content>
