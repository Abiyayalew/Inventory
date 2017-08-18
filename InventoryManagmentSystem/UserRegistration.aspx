<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="InventoryManagmentSystem.UserRegistration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <h1>User Registration Form</h1>
        <table class="form">
            <tr>
                <td>User Name</td>
                <td>
                    <asp:TextBox ID="txtUserName" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvUserName" runat="server"
                        ErrorMessage="UserName is Required"
                        ControlToValidate="txtUserName">

                    </asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Email Address&nbsp;</td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textboxs" runat="server" TextMode="Email"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server"
                        ErrorMessage="Email Address is Required"
                        ControlToValidate="txtEmail">
                    </asp:RequiredFieldValidator>
                   <asp:RegularExpressionValidator ID="validateEmail"
                       runat="server" ErrorMessage="Invalid email."
                     ControlToValidate ="txtEmail"
                     ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" /></td>
            </tr>
            <tr>
                <td>Password</td>
                <td>
                    <asp:TextBox ID="txtPassword" CssClass="textboxs" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvPassword" runat="server"
                        ErrorMessage="Password is Required"
                        ControlToValidate="txtPassword"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Confirm Password</td>
                <td>
                    <asp:TextBox ID="txtConfirmpassword" CssClass="textboxs" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvConfirmPassword" runat="server"
                        ErrorMessage="Confrim your password"
                        ControlToValidate="txtConfirmpassword"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>&nbsp;IsAdmin</td>
                <td>
                    <asp:CheckBox ID="ChkStatus" runat="server" Checked="true" />
                </td>

                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" CssClass="btn" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnDelete" CssClass="btn" runat="server" Text="Delete" OnClick="BtnDelete_Click" CausesValidation="False" />
        </div>
        <div class="Grid">
            <asp:GridView ID="GridView1" runat="server"
                AutoGenerateColumns="False"
                AutoGenerateSelectButton="True"
                BorderStyle="None"
                CssClass="Grid"
                EditRowStyle-ForeColor="#0066FF"
                Width="650px"
                BackColor="White"
                BorderColor="#CCCCCC"
                BorderWidth="1px"
                CellPadding="3"
                Height="20px"
                OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                AllowPaging="True"
                PageSize="5"
                OnPageIndexChanging="GridView1_PageIndexChanging">
                <Columns>
                    <asp:BoundField DataField="UserId"
                        HeaderText="User_ID"
                        InsertVisible="False" ReadOnly="True"
                        SortExpression="" />
                    <asp:BoundField DataField="UserName"
                        HeaderText="UserName"
                        SortExpression="UserName" />
                    <asp:BoundField DataField="Email"
                        HeaderText="Email-Address"
                        SortExpression="" />
                    <asp:BoundField DataField="Password"
                        HeaderText="Password"
                        SortExpression="Password" />
                    <asp:BoundField DataField="IsAdmin"
                        HeaderText="IsAdmin"
                        SortExpression="Status" />
                </Columns>

                <EditRowStyle ForeColor="#0066FF" />

                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />

            </asp:GridView>
        </div>
    </div>
</asp:Content>

