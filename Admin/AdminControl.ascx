<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdminControl.ascx.cs" Inherits="IFSOFTOnline.Admin.AdminControl" %>
<%@ Register src="Menu.ascx" tagname="Menu" tagprefix="uc1" %>

<div class="admin-shell">
    <div class="admin-banner">
        Banner Admin UserName:[<%=Session["username"] %>]&nbsp;<asp:LinkButton ID="lnkExit" runat="server" OnClick="lnkExit_Click">Exit</asp:LinkButton>
    </div>
    <table cellspacing="0" cellpadding="0" class="admin-layout">
        <tr>
            <td class="admin-layout-menu"><uc1:Menu ID="Menu1" runat="server" /></td>
            <td class="admin-layout-gap">&nbsp;</td>
            <td class="admin-layout-content"><asp:PlaceHolder ID="plLoad" runat="server"></asp:PlaceHolder></td>
        </tr>
    </table>
</div>