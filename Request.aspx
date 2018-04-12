<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Request.aspx.cs" Inherits="FilterUnwantedMSG_OSN.WebForm5" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <center>
        <div>
        <asp:Label ID="lblShow" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" 
                GridLines="None" Width="748px" AutoGenerateColumns="false">
                <Columns>
                <asp:BoundField HeaderText="ID" DataField="ID" />
                <asp:BoundField HeaderText="FromUser" DataField="FromUser" />
                <asp:BoundField HeaderText="Name" DataField="Name" />
                <asp:BoundField HeaderText="Email" DataField="Email" />
                <asp:TemplateField>
                <ItemTemplate>
                <asp:Button ID="btnAccept" runat="server" Text="Accept" CommandArgument='<%#Eval("ID") %>' OnCommand="btnAccept_OnCommand" CommandName="Accept"/>
                </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                <ItemTemplate>
                <asp:Button ID="btnReject" runat="server" Text="Reject" CommandArgument='<%#Eval("ID") %>' OnCommand="btnReject_OnCommand" CommandName="Reject"/>
                </ItemTemplate>
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
        </center>
    </div>
</asp:Content>
