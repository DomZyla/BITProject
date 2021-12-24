<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="BITWebApplication.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h2><%: Title %></h2>
    <br />
    <h3>Contact Us!</h3>
    <address>
        Andrew Road 5<br />
        Sydney, NSW 98052-6399<br />
        <p title="Phone">Phone Number : +61 2 5550 9382</p>
    </address>

    <address>
        <strong>Support:</strong>   <a href="mailto:BITSupport@Gmail.com">BITSupport@Gmail.com</a><br />
        <strong>Marketing:</strong> <a href="mailto:BITMarketing@example.com">BITMarketing@Gmail.com</a>
    </address>
</asp:Content>
