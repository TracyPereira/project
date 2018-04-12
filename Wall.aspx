<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Wall.aspx.cs" Inherits="FilterUnwantedMSG_OSN.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <h2>
                Post On Wall</h2>
        </div>
        <br />
        <table>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Select Friend Name :
                </td>
                <td>
                    <asp:DropDownList ID="ddlFriend" runat="server" Height="26px" Width="180px" DataTextField="ReciverName"
                        DataValueField="ToUser">
                    </asp:DropDownList>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:TextBox ID="txtPost" runat="server" Height="123px" Width="334px" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnPost" runat="server" Text="Post" Font-Bold="True" Height="37px"
                        Width="85px" OnClick="btnPost_Click" />
                </td>
                <td>
                </td>
            </tr>
        </table>
        <br />
        <div>
            <asp:Repeater ID="rpParent" runat="server" OnItemDataBound="rpParent_ItemDataBound">
                <HeaderTemplate>
                </HeaderTemplate>
                <ItemTemplate>
                    <div class="Post">
                        <table>
                            <tr>
                                <td>
                                    Post date :
                                </td>
                                <td>
                                    <%#Eval("date") %>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Post Content :
                                </td>
                                <td>
                                    <%#Eval("PostContent")%>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Comments:
                                </td>
                                <td>
                                    <asp:Repeater ID="rpChild" runat="server">
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div>
                                                <table>
                                                    <tr>
                                                        <td>
                                                            <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" ImageUrl='<%#Eval("Photo")%>' />
                                                        </td>
                                                        <td>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>' ForeColor="Blue"></asp:Label>
                                                            <br />
                                                            <%#Eval("Comment")%>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
