<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsCategory.ascx.cs" Inherits="IFSOFTOnline.Admin.News.NewCategory" %>

<div class="category-page">
<div class="category-page-title">DANH SÁCH TIN TỨC</div> 
<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">
    
    <%-- View 1: Chỉ chứa Repeater và nút Add New --%>
    <asp:View ID="v1" runat="server">
        <asp:Repeater ID="rptNewsCategory" runat="server" OnItemCommand="rptNewsCategory_ItemCommand">
            <HeaderTemplate>
                <table>
                    <tr>
                        <td style="width: 300px">Category Name</td>
                        <td style="width: 50px">Order</td>
                        <td style="width: 100px">Active</td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><asp:LinkButton ID="lnkUpdate" runat="server" CommandName="update" CommandArgument='<%#:Eval("CategoryID")%>'><%#:Eval("CategoryName") %></asp:LinkButton></td>
                    <td><%#:Eval("Order") %></td>
                    <td><%#:Eval("Active") %></td>
                    <td><asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#:Eval("CategoryID")%>' Onload="msgDel">Xóa</asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        
        <div>
            <asp:LinkButton ID="lnkAddNew" runat="server" OnClick="lnkAddNew_Click">Add New</asp:LinkButton>
        </div>
    </asp:View> 

    <%-- View 2: Chỉ chứa Form nhập liệu --%>
    <asp:View ID="v2" runat="server">
        <asp:HiddenField ID="hdCategoryID" runat="server" />
        <asp:HiddenField ID="hdInsert" runat="server" />
        <table>
            <tr>
                <td>Category Name</td>
                <td><asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Order</td>
                <td><asp:TextBox ID="txtOrder" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Active</td>
                <td><asp:CheckBox ID="chkActive" runat="server" Checked="true" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnSave" runat="server" Text="Cập nhật" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    </asp:View>

</asp:MultiView>
    </div>
