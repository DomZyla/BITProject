<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BITWebApplication.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <h1>Login</h1>
    <div class="container-fluid">
        <div class="row">
            <div class="col">
                  <div class="form-group">
                    <label for="txtUser">Username</label>
                    <asp:Textbox ID="txtUser" runat="server" CssClass="form-control" placeholder="Username"/>
                  </div>
                  <div class="form-group">
                    <label for="exampleInputPassword1">Password</label>
                      <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"/>
                  </div>
                <p><asp:Label ID="lblErrorMessage" runat="server" CssClass="error" /></p>
                <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary" Text="Login" OnClick="btnLogin_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
