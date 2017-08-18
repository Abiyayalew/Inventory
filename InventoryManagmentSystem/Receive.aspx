<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Receive.aspx.cs" Inherits="InventoryManagmentSystem.Receive" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script>
        $(function() {
            debugger;
            $("#<%= txtRecDate.ClientID %>").datepicker({
            changeMonth: true,
            changeYear: true,
        });
    });


    $(document).ready(function() {

        $.validator.addMethod("CheckDropDownList", function(value, element) {
            if (value == '0')
                return false;
            else
                return true;

        }, "Please select from dropdown list .");

        $.validator.addMethod("rdate", function(value, element) {
            if (value == '')
                return false;
            else
                return true;
        }, "ReceiveDate is Required.");

        $("#form1").validate({
            rules:  { <%= txtRecId.UniqueID %> : {
                          required: true

                    },<%= txtRecDate.UniqueID %> : {
                        rdate: true,
                        date: true
                    }, <%= ddlProdManfacturer.UniqueID %> : {
                        CheckDropDownList: true
                    }, <%= ddlSupplier.UniqueID %> : {
                        CheckDropDownList: true
                    }, <%= ddlProduct.UniqueID %> : {

                        CheckDropDownList: true
                    }, <%= txtQty.UniqueID %> : {

                        required: true,
                        digits: true
                    }, <%= txtUnitCost.UniqueID %> : {

                        required: true,
                        digits: true
                    }
            },
            messages: { <%= txtRecId.UniqueID %> : {
                required: 'ReceiveID is Required.'
            }, <%= ddlProdManfacturer.UniqueID %> : {
                    CheckDropDownList: 'Please select Manufacturer.'
                }, <%= txtQty.UniqueID %> : {

                    required: 'Quantity is Required.'


                }, <%= txtUnitCost.UniqueID %> : {

                    required: 'Quantity is Required.'


                }


            }
        });
    });

    // it stop redirect page to login page when we press entery key on textbox control.
    $(document).keypress(function(e) {
        var keyCode = (window.event) ? e.which : e.keyCode;
        if (keyCode && keyCode == 13) {
            e.preventDefault();
            return false;
        }
    });
</script>
    <style type="text/css">
        .ui-datepicker
        {
            font-size: 8pt !important;
        }
    </style>

    <style>
        label.error
        {
            color: red;
        }
    </style>

    <div class="container">
        <h2>Receiving From</h2>
        <table class="frmRS">
            <tr>
                <td>Receive ID</td>
                <td>
                    <asp:TextBox ID="txtRecId" CssClass="textboxs" runat="server" Width="130"></asp:TextBox>
                    <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" formnovalidate="formnovalidate" Text="Find" OnClick="btnSearch_Click" /></td>
                
            </tr>
            <tr>
                <td>Receive Date</td>
                <td>
                    <asp:TextBox ID="txtRecDate" CssClass="textboxs" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Supplier Name</td>
                <td>
                    <asp:DropDownList ID="ddlSupplier" CssClass="textboxs" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList></td>

               
            </tr>
            <tr>
                <td>Manufacurer Name</td>
                <td>
                    <asp:DropDownList ID="ddlProdManfacturer" CssClass="textboxs" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList></td>

                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Product Name</td>
                <td>
                    <asp:DropDownList ID="ddlProduct" CssClass="textboxs" runat="server" AppendDataBoundItems="True">
                    </asp:DropDownList></td>

                
            </tr>
            <tr>
                <td>Quantity</td>
                <td>
                    <asp:TextBox ID="txtQty" CssClass="textboxs" runat="server" ></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>UnitCost</td>
                <td>
                    <asp:TextBox ID="txtUnitCost" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnNew" CssClass="btn" runat="server" formnovalidate="formnovalidate" Text="New" OnClick="BtnNew_Click" />
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" CssClass="btn" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnDelete" CssClass="btn" runat="server" formnovalidate="formnovalidate" Text="Delete" OnClick="BtnDelete_Click" />
            <asp:Label ID="errorLabel" runat="server" Text=" " ForeColor="Red"></asp:Label>
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
                OnPageIndexChanging="GridView1_PageIndexChanging" ShowFooter="True">
                <Columns>
                    <asp:BoundField DataField="RecId" HeaderText="Receive_ID" />
                    <asp:BoundField DataField="RecDate" HeaderText="Receive_Date" />
                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier_Name" />
                    <asp:BoundField DataField="ManufacturerName" HeaderText="Manufacturer_Name" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product_Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="UnitCost" HeaderText="UnitCost" />

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

