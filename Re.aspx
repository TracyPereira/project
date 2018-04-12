<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Re.aspx.cs" Inherits="Re" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
<style type="text/css">
        #newtable
        {
            border: 0px;
            border-left: 0px;
            border-right: 0px;
        }
        table tbody td
        {
            border-collapse: collapse;
            border-left: 0px solid #cccccc;
            border-right: 0px solid #cccccc;
            vertical-align: top;
        }
        .style1
        {
            width: 120px;
            text-align: right;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
 <table id="newtable">
        <tr>
            <td class="style1">
            </td>
            <td>
                <asp:Label ID="lblShow" runat="server" ForeColor="Red"></asp:Label>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td>
                &nbsp;</td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style1">
            </td>
            <td>
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td class="style1">
                Select Course:
            </td>
            <td>
                &nbsp;</td>
            <td>
            </td>
        </tr>
<tr>
<td>
<asp:GridView ID="GridView1" runat="server">
    <Columns>
        <asp:BoundField DataField="cid" HeaderText="Course id" />
        <asp:BoundField DataField="course_name" HeaderText="Course Name" />
    </Columns>
</asp:GridView>
</td>
</tr>
      
        <tr>
            <td class="style1">
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td>
            </td>
        </tr>
    </table>
</asp:Content>

