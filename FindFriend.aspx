<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FindFriend.aspx.cs" Inherits="FilterUnwantedMSG_OSN.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center">
        <center>
        <div>
            <div>
            
<asp:Label ID="lblShow" runat="server" Font-Bold="True" ForeColor="#339933"></asp:Label>
                
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
                        Search Friend Here :
                    </td>
                    <td>
                        <asp:TextBox ID="txtSearch" runat="server" Height="28px" Width="155px"></asp:TextBox>
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSearch" runat="server" Height="33px" Text="Search" 
                            Width="79px" onclick="btnSearch_Click" />
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
                Width="774px" AutoGenerateColumns="False" OnRowCommand = "OnRowCommand">
                <Columns>
                <asp:BoundField DataField="User_id" HeaderText="ID" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                 <asp:BoundField DataField="Fname" HeaderText="First Name" >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                  <asp:BoundField DataField="Lname" HeaderText="Last Name " >
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                   <asp:BoundField DataField="Email" HeaderText="Email" >
               
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
               
                   <asp:ImageField HeaderText="Profile Picture" DataImageUrlFormatString="~/{0}" DataImageUrlField="Photo" ItemStyle-Height="100px"
                    ItemStyle-Width="100px" ControlStyle-Height="100px" ControlStyle-Width="100px">
                                        <ControlStyle Height="100px" Width="100px"></ControlStyle>
                        <ItemStyle Height="100px" Width="100px" HorizontalAlign="Center"></ItemStyle>
                                        </asp:ImageField>
                  <asp:TemplateField>
        <ItemTemplate>
         <asp:Button ID="Button1" runat="server" Text="Send Request"
          CommandArgument=
          '<%#Eval("User_id")%>'
              OnCommand="Button1_OnCommand"/>
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
        </div>
        </center>
    </div>
</asp:Content>
