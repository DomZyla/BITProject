<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewBooking.aspx.cs" Inherits="BITWebApplication.NewBooking" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>New Booking</h1>
    <hr />

    <div class="container-fluid">
        <div class="row">

            <div class="col-md-6">
                <label>Skills for Service</label>
                <div class="form-group">
                    <asp:DropDownList CssClass="form-control" ID="ddlServiceSkills" runat="server">
                        <asp:ListItem Text="Select Skill for Service" Value="0" />
                        <asp:ListItem Text="Computer Cleaner" Value="ComputerCleaner" />
                        <asp:ListItem Text="Database Managing" Value="DatabaseManaging" />
                        <asp:ListItem Text="Updates" Value="Updates" />
                        <asp:ListItem Text="Windows 10 Knowledge" Value="Windows 10 Knowledge" />
                        <asp:ListItem Text="Mac OS Knowledge" Value="Mac OS" />
                        <asp:ListItem Text="Bug Fixing and Updates" Value="Bug Fixing and Updates" />
                        <asp:ListItem Text="Troubleshooting" Value="Troubleshooting" />
                        <asp:ListItem Text="Screen Repair" Value="Screen repair" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvServiceSkills" runat="server" ControlToValidate="ddlServiceSkills" InitialValue="0" ErrorMessage="Please select a Skill for your Service" style="color:red;" />
                </div>
            </div>
            <div class="col-md-6">
                <label>Preffered Rating</label>
                <div class="form-group">
                    <asp:DropDownList CssClass="form-control" ID="ddlRating" runat="server">
                        <asp:ListItem Text="Select Preffered Rating" Value="0" />
                        <asp:ListItem Text="1 Star" Value="1" />
                        <asp:ListItem Text="2 Star" Value="2" />
                        <asp:ListItem Text="3 Star" Value="3" />
                        <asp:ListItem Text="4 Star" Value="4" />
                        <asp:ListItem Text="5 Star" Value="5" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvRating" runat="server" ControlToValidate="ddlRating" InitialValue="0" ErrorMessage="Please select a Preffered Rating" style="color:red;" />
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <label>Time of Service</label>
                <div class="form-group">
                    <asp:DropDownList CssClass="form-control" ID="ddlTime" runat="server">
                        <asp:ListItem Text="Select Time of Service" Value="0" />
                        <asp:ListItem Text="8:00AM" Value="8:00:00" />
                        <asp:ListItem Text="9:00AM" Value="9:00:00" />
                        <asp:ListItem Text="10:00AM" Value="10:00:00" />
                        <asp:ListItem Text="11:00AM" Value="11:00:00" />
                        <asp:ListItem Text="12:00PM" Value="12:00:00" />
                        <asp:ListItem Text="1:00PM" Value="13:00:00" />
                        <asp:ListItem Text="2:00PM" Value="14:00:00" />
                        <asp:ListItem Text="3:00PM" Value="15:00:00" />
                        <asp:ListItem Text="4:00PM" Value="16:00:00" />
                        <asp:ListItem Text="5:00PM" Value="17:00:00" />
                        <asp:ListItem Text="6:00PM" Value="18:00:00" />
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStartTime" runat="server" ControlToValidate="ddlTime" InitialValue="0" ErrorMessage="Please select a Time of Service" style="color:red;" />
                </div>
            </div>
            <div class="col-md-6">
                <label>Service Date</label>
                <div class="form-group">
                    <asp:Calendar ID="calBookingDate" runat="server" />
                    <asp:CustomValidator ID="customBookingDateValidator" runat="server" ErrorMessage="Please select a Date for the Service" style="color:red;" OnServerValidate="customBookingDateValidator_ServerValidate" ></asp:CustomValidator>
                </div>
            </div>
        </div>
    </div>
        <div class="row">
            <div class="col-12">
                <asp:Button CssClass="btn btn-success btn-block btn-lg" ID="btnFind" Text="Find Sessions" runat="server" OnClick="btnFind_Click" />
            </div>
        </div>
    <hr />
    <div class="row">
        <div class="col-12">
            <asp:GridView CssClass="table table-striped table-bordered" ID="gvAvailableSessions" runat="server" AutoGenerateColumns="false" OnRowCommand="gvAvailableSessions_RowCommand">
                <Columns>
                    <asp:BoundField HeaderText="Contractor ID" DataField="Contractor_ID" />
                    <asp:BoundField HeaderText="First Name" DataField="firstname" />
                    <asp:BoundField HeaderText="Last Name" DataField="lastname" />
                    <asp:BoundField HeaderText="Skill ID" DataField="Skill_ID" />
                    <asp:BoundField HeaderText="Skill Name" DataField="SkillName" />
                    <asp:BoundField HeaderText="Time Slot ID" DataField="timeslotId" Visible="false"/>
                    <asp:BoundField HeaderText="Starting Time" DataField="SlotStartTime" />
                    <asp:BoundField HeaderText="Rating" DataField="Rating" />
                    <asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            <asp:Button ID="btnConfirm" runat="server" Text="Assign" Width="80px" Height="40px" CommandName="Assign" CommandArgument="<%# Container.DataItemIndex %>"/>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
    <hr />
</asp:Content>