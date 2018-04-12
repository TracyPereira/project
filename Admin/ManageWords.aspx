<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Site1.Master" AutoEventWireup="true"
    CodeBehind="ManageWords.aspx.cs" Inherits="FilterUnwantedMSG_OSN.Admin.WebForm3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h2>
            Words Master</h2>
        <center>
        <div>
            <table>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Label ID="lblShow" runat="server" ForeColor="#009933"></asp:Label>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        Add New Word :*</td>
                    <td>
                        <asp:TextBox ID="txtWord" runat="server" Height="25px" Width="153px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                            ErrorMessage="Please Add Word" ForeColor="Red" ControlToValidate="txtWord"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnAdd" runat="server" Height="29px" Text="Add" Width="86px" 
                            onclick="btnAdd_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" 
                AutoGenerateColumns="False" CellPadding="4"  
                ForeColor="#333333" GridLines="None" Width="655px" style="margin-top: 0px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="bId" HeaderText="bId" InsertVisible="False" 
                    ReadOnly="True" SortExpression="bId">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:BoundField DataField="Word" HeaderText="Word" SortExpression="Word">
                <ItemStyle HorizontalAlign="Center" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Manage">
                <ItemTemplate>
                <asp:Button ID="btnDelete" runat="server" Text="Delete" OnCommand="btnDelete_Click" CausesValidation="false" CommandArgument=<%#Eval("bId") %> />
                </ItemTemplate>
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
            </Columns>
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
