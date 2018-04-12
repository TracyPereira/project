<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Registration.aspx.cs" Inherits="FilterUnwantedMSG_OSN.WebForm2" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        function validation() {
            var Username = document.getElementById('<%=txtUsername.ClientID %>').value;
            var Password = document.getElementById('<%=txtPassword.ClientID %>').value;
            var First = document.getElementById('<%=txtFirst.ClientID %>').value;
            var Middle = document.getElementById('<%=txtMiddle.ClientID %>').value;
            var Last = document.getElementById('<%=txtLast.ClientID %>').value;
            var Address = document.getElementById('<%=txtAddress.ClientID %>').value;
            var Email = document.getElementById('<%=txtEmail.ClientID %>').value;
            var Phone = document.getElementById('<%=txtPhone.ClientID %>').value;
            var DOB = document.getElementById('<%=txtDOB.ClientID %>').value;
            var State = document.getElementById('<%=txtState.ClientID %>').value;
            var City = document.getElementById('<%=txtCity.ClientID %>').value;
            var Photo = document.getElementById('<%=FileUpload1.ClientID %>').value;

            if (Username == "") {
                alert("Enter Username")
                return false;
            }
            if (Password == "") {
                alert("Enter Password")
                return false;
            }
            if (First == "") {
                alert("Enter First Name")
                return false;
            }
            if (Middle == "") {
                alert("Enter Middle Name")
                return false;
            }
            if (Last == "") {
                alert("Enter Last Name")
                return false;
            }
            if (Address == "") {
                alert("Enter Address")
                return false;
            }
            if (Email == "") {
                alert("Enter Email ID")
                return false;
            }
            if (Phone == "") {
                alert("Enter Phone No.")
                return false;
            }
            if (DOB == "") {
                alert("Enter Birth Date")
                return false;
            }
            if (State == "") {
                alert("Enter State")
                return false;
            }
            if (City == "") {
                alert("Enter City Name")
                return false;
            }
            if (Photo == "") {
                alert("Pz. Upload Profile Pic")
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td>
                  <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                    </asp:ToolkitScriptManager>
                </td>
                <td>
                    <asp:Label ID="lblShow" runat="server" Font-Size="Medium" ForeColor="Red"></asp:Label>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Username :
                </td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" Height="25px" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Password :
                </td>
                <td>
                    <asp:TextBox ID="txtPassword" runat="server" Height="25px" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    First Name :
                </td>
                <td>
                    <asp:TextBox ID="txtFirst" runat="server" Height="25px" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Middle Name :
                </td>
                <td>
                    <asp:TextBox ID="txtMiddle" runat="server" Height="25px" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Last Name :
                </td>
                <td>
                    <asp:TextBox ID="txtLast" runat="server" Height="25px" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Address :
                </td>
                <td>
                    <asp:TextBox ID="txtAddress" runat="server" Height="86px" TextMode="MultiLine" Width="192px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Email ID :
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" Height="25px" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Phone No. :
                </td>
                <td>
                    <asp:TextBox ID="txtPhone" runat="server" Height="25px" MaxLength="10" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Birth Date :
                </td>
                <td>
                    <asp:TextBox ID="txtDOB" runat="server" Height="25px" Width="146px"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDOB">
                    </asp:CalendarExtender>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;State :
                </td>
                <td>
                    <asp:TextBox ID="txtState" runat="server" Height="25px" MaxLength="10" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    City :
                </td>
                <td>
                    <asp:TextBox ID="txtCity" runat="server" Height="25px" MaxLength="10" Width="146px"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    Image :
                </td>
                <td>
                    <asp:FileUpload ID="FileUpload1" runat="server" />
                </td>
                <td>
                </td>
            </tr>
<tr>
<td> Course:</td>
<td>
<asp:CheckBoxList ID="CheckBoxList1" runat="server" DataSourceID="SqlDataSource1" 
        DataTextField="cname" DataValueField="cid">
</asp:CheckBoxList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:facebook_recommend_380ConnectionString %>" 
        SelectCommand="SELECT * FROM [course_master]"></asp:SqlDataSource>
</td>
</tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Button ID="btnSave" runat="server" Height="30px" OnClick="btnSave_Click" Text="Save"
                        Width="73px" OnClientClick="javascript:return validation();" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnClear" runat="server" Height="30px" OnClick="btnClear_Click" Text="Clear"
                        Width="73px" />
                </td>
                <td>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
