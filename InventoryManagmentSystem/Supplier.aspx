<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Supplier.aspx.cs" Inherits="InventoryManagmentSystem.Supplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <div class="container">
        <h1>Supplier Registration Form</h1>
        <table class="form">
            <tr>
                <td>Supplier_ID</td>
                <td>
                    <asp:TextBox ID="txtSupplierId" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvSupplierId" runat="server"
                        ErrorMessage="SupplierId is Required"
                        ControlToValidate="txtSupplierId">

                    </asp:RequiredFieldValidator></td>
            </tr>
            
            <tr>
                <td>SupplierName</td>
                <td>
                    <asp:TextBox ID="txtSupplierName" CssClass="textboxs" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvSupplierName" runat="server"
                        ErrorMessage="SupplierName is Required"
                        ControlToValidate="txtSupplierName"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Address</td>
                <td>
                    <asp:TextBox ID="txtAddress" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RfvAddress" runat="server"
                        ErrorMessage="Address is Required"
                        ControlToValidate="txtAddress"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>PhoneNumber</td>
                <td>
                    <asp:TextBox ID="txtPhoneNumber" CssClass="textboxs" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RFVPhoneNumber" runat="server"
                        ErrorMessage="Phone Number is Required"
                        ControlToValidate="txtPhoneNumber"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="REVPhoneNumber"
                       runat="server" ErrorMessage="Invalid Phone Number."
                     ControlToValidate ="txtPhoneNumber"
                     ValidationExpression="^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$" />
                </td>
            </tr>
            <tr>
                <td>Email Address</td>
                <td>
                    <asp:TextBox ID="txtEmail" CssClass="textboxs" runat="server" TextMode="Email"></asp:TextBox></td>
                <td>
                   <asp:RegularExpressionValidator ID="validateEmail"
                       runat="server" ErrorMessage="Invalid Email Address."
                     ControlToValidate ="txtEmail"
                     ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" />
                    <asp:RequiredFieldValidator ID="RfvEmail" runat="server"
                        ErrorMessage="Email Address is Required"
                        ControlToValidate="txtEmail">
                    </asp:RequiredFieldValidator>
                   </td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" CssClass="btn" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnDelete" CssClass="btn" runat="server" Text="Delete" OnClick="BtnDelete_Click" />
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
                    <asp:BoundField DataField="SupplierId"
                        HeaderText="Supplier_ID"
                        InsertVisible="False" ReadOnly="True"
                        SortExpression="" />
                    <asp:BoundField DataField="SupplierName"
                        HeaderText="Supplier_Name"
                        SortExpression="SupplierName" />
                    <asp:BoundField DataField="Address"
                        HeaderText="Address"
                        SortExpression="Address" />
                    <asp:BoundField DataField="PhoneNumber"
                        HeaderText="Phone_Number"
                        SortExpression="PhoneNumber" />
                    <asp:BoundField DataField="Email"
                        HeaderText="Email-Address"
                        SortExpression="" />
                    
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

