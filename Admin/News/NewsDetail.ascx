<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NewsDetail.ascx.cs" Inherits="IFSOFTOnline.Admin.News.NewsDetailControl" %>
<%@ Register Assembly="FreeTextBox" Namespace="FreeTextBoxControls" TagPrefix="FTB" %>

<div class="newsdetail-page">
<asp:MultiView ID="mul" runat="server" ActiveViewIndex="0">

    <asp:View ID="v0" runat="server">
        <div><b>LIST NEWS DETAIL</b></div>
        <asp:DropDownList ID="drpNewsCategory1" runat="server" OnSelectedIndexChanged="drpNewsCategory1_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
        <asp:Repeater ID="rptNewsDetails" runat="server" OnItemCommand="rptNewsDetails_ItemCommand">
            <HeaderTemplate>
                <table style="width:100%;">
                    <tr class="rptHed">
                        <td style="width:100px;">Image</td>
                        <td style="width:400px;">Title</td>
                        <td style="width:100px;">Author</td>
                        <td style="width:100px;">Active</td>
                        <td></td>
                    </tr>
            </HeaderTemplate>

            <ItemTemplate>
                    <tr class="rptItem">
                        <td>
                            <img src='/image/<%#: Eval("vImage") %>' width="100px"/>
                        </td>
                        <td><%#: Eval("vTitle") %></td>
                        <td><%#: Eval("vAuthor") %></td>
                        <td><%#: Eval("Active") %></td>
                        <td>
                            <asp:LinkButton ID="linkUpdate" runat="server" CommandName="update" CommandArgument='<%#: Eval("NewsDetailID") %>'>Cập nhật</asp:LinkButton>
                            &nbsp;|&nbsp;
                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#: Eval("NewsDetailID") %>' OnLoad="msgDel">Xóa</asp:LinkButton>
                        </td>
                    </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr class="rptAlt">
    <td>
        <img src='/image/<%#: Eval("vImage") %>' width="100px" />
    </td>
    <td><%#: Eval("vTitle") %></td>
    <td><%#: Eval("vAuthor") %></td>
    <td><%#: Eval("Active") %></td>
    <td>
        <asp:LinkButton ID="linkUpdate" runat="server" CommandName="update" CommandArgument='<%#: Eval("NewsDetailID") %>'>Cập nhật</asp:LinkButton>
        &nbsp;|&nbsp;
        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="delete" CommandArgument='<%#: Eval("NewsDetailID") %>' OnLoad="msgDel">Xóa</asp:LinkButton>
    </td>
</tr>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>

        <asp:HiddenField ID="hdInsert" runat="server" />
        <asp:HiddenField ID="hdNewsDetailID" runat="server" />
        <asp:HiddenField ID="hdImage" runat="server" />

        <div>
            <asp:LinkButton ID="lnkUpdate" runat="server" OnClick="lnkUpdate_Click1">Add New</asp:LinkButton>
        </div>

    </asp:View>

    <asp:View ID="v1" runat="server">
        <div><b> ADD NEW / UPFATE NEWS DETAIL</b></div>
        <table class="newsdetail-form">
            <tr>
                <td style="width:100px;">News Category</td>
                <td>
                    <asp:DropDownList ID="drpNewsCategory" runat="server"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Title</td>
                <td>
                    <asp:TextBox ID="txtTitle" runat="server" style="width:500px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Desc</td>
                <td>
                    <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" style="width:500px; height:60px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Content</td>
                <td>
                    <FTB:FreeTextBox ID="txtContent" runat="server" Width="1000px" Height="300px" ToolbarLayout="ParagraphMenu,FontForeColorsMenu,Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat,JustifyLeft,JustifyRight,JustifyCenter,JustifyFull,BulletedList,NumberedList,Indent,Outdent,CreateLink,Unlink,InsertImage,InsertRule"/>
                </td>
            </tr>
            <tr>
                <td>Image</td>
                <td>
                    <asp:FileUpload ID="FileUpload" runat="server" />
                </td>
            </tr>
            <tr>
                <td>Author</td>
                <td>
                    <asp:TextBox ID="txtAuthor" runat="server" style="width:500px;"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Active</td>
                <td>
                    <asp:CheckBox ID="chkActive" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
                </td>
            </tr>
        </table>
    </asp:View>
</asp:MultiView>
    </div>
