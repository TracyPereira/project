<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FriendList.aspx.cs" Inherits="FilterUnwantedMSG_OSN.WebForm6" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <center>
<div>
<asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
        GridLines="None" Width="803px" AutoGenerateColumns="False" 
        OnRowDataBound="GridView1_RowDataBound">
        <Columns>
        <asp:BoundField DataField="ToUser" HeaderText="Friend ID" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
        <asp:BoundField DataField="ReciverName" HeaderText="Name" >
            <ItemStyle HorizontalAlign="Center" />
            </asp:BoundField>
       <asp:TemplateField HeaderText="Profile Picture">
       <ItemTemplate>
       <asp:Image ID="Image1" runat="server"  Height="50px" Width="50px"/>
       </ItemTemplate>
           <ItemStyle HorizontalAlign="Center" />
       </asp:TemplateField>
        </Columns>
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
</div>
</center>
    </div>
</asp:Content>
