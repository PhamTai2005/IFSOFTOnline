<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminUsers.ascx.cs" Inherits="IFSOFTOnline.Admin.User.AdminUsers" %>

<div class="adminusers-page">
<table style="width:100%">
    <tr>
        <td style="width:100px">UserName</td>
        <td style="width:10px"></td>
        <td>
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width:100px">Password</td>
        <td style="width:10px"></td>
        <td>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width:100px">FullName</td>
        <td style="width:10px"></td>
        <td>
            <asp:TextBox ID="txtFullName" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width:100px">Address</td>
        <td style="width:10px"></td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width:100px">Role</td>
        <td style="width:10px"></td>
        <td>
            <asp:DropDownList ID="drpRole" runat="server">
                <asp:ListItem Value="1">Administrator</asp:ListItem>
                <asp:ListItem Value="2">Post News</asp:ListItem>
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width:100px">Active</td>
        <td style="width:10px"></td>
        <td>
            <asp:CheckBox ID="chkActive" runat="server" Checked="true" />
        </td>
    </tr>
    <tr>
        <td style="width:100px"></td>
        <td style="width:10px"></td>
        <td>
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
        </td>
    </tr>
</table>
    </div>