<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="FilterUnwantedMSG_OSN._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .Post
        {
            background-color: #819FF7;
            font-family: @BatangChe;
            font-size: medium;
            font-style: italic;
            color: #FFFFFF;
            border-radius: 10px;
        }
        .Style1
        {
            width: 100px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <asp:Repeater ID="rp" runat="server" OnItemDataBound="rp_ItemDataBound" OnItemCommand="rp_ItemCommand"
            ViewStateMode="Inherit">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <div class="Post">
                    <table>
                        <tr>
                            <td class="Style1">
                                <asp:Image ID="Image1" runat="server" Height="50px" Width="50px" ImageUrl='<%#Eval("Photo")%>' />
                            </td>
                            <td>
                                Name :
                                <%#Eval("Name")%>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Post :
                            </td>
                            <td>
                                <div>
                                    <p>
                                        <%#Eval("PostContent")%></p>
                                </div>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Comments :
                            </td>
                            <td>
                                <asp:Repeater ID="rpComments" runat="server">
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
                        <tr>
                            <td>
                            </td>
                            <td>
                                <asp:TextBox ID="txtComment" runat="server" Width="250px" placeholder="Your Comment..."></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnPost" runat="server" CommandName="Comment" CommandArgument='<%#Eval("PostId") %>'
                                    Text="Post" CausesValidation="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Posted Date :
                            </td>
                            <td>
                                <%#string.Format("{0:d/M/yyyy}", (Eval("Date")))%>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </div>
                <br />
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
