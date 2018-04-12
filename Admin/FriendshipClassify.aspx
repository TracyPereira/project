<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true"
    CodeBehind="FriendshipClassify.aspx.cs" Inherits="FilterUnwantedMSG_OSN.Admin.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div>
            <center>
                <h2>
                    Select User :
                </h2>
                <asp:DropDownList ID="ddlUsers" DataTextField="Name" DataValueField="User_id" AutoPostBack="true"
                    runat="server" Height="25px" Width="134px" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged">
                </asp:DropDownList>
                <br />
                <br />
                <asp:Button ID="btnClassify" runat="server" Text="Classify" Height="31px" Width="91px"
                    OnClick="btnClassify_Click" />
            </center>
        </div>
        <br />
        <div>
            <%--<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <asp:BoundField DataField="PostId" HeaderText="PostId">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Comment" HeaderText="Comment">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Polarity" HeaderText="Polarity">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                     <asp:BoundField DataField="freindtype" HeaderText="FriendShipType">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>--%>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                <Columns>
                    <%--  <asp:BoundField DataField="PostId" HeaderText="PostId">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>--%>
                    <asp:BoundField DataField="Comment" HeaderText="Comment">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" HeaderText="Name">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="polarity" HeaderText="Polarity">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
