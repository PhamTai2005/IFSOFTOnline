<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Login.ascx.cs" Inherits="IFSOFTOnline.Admin.Login" %>

<div class="login-wrapper">
    <div class="login-card">
        <div class="login-logo">IFSOFT</div>
        <h1 class="login-title">Đăng nhập quản trị</h1>

        <div class="login-field">
            <label for="txtUserName">Tên đăng nhập</label>
            <asp:TextBox ID="txtUserName" runat="server" CssClass="login-input" placeholder="Nhập tên đăng nhập"></asp:TextBox>
        </div>

        <div class="login-field">
            <label for="txtPassword">Mật khẩu</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="login-input" placeholder="Nhập mật khẩu"></asp:TextBox>
        </div>

        <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" OnClick="btnLogin_Click" CssClass="login-btn" />
    </div>
</div>