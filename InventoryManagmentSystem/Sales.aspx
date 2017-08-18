<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="InventoryManagmentSystem.Sales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">
    <script>
        function printGrid() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
             var windowUrl = 'about:Sales Invoices';

             //set print document name for gridview
             var uniqueName = new Date();
             var windowName = 'Print_' + uniqueName.getTime();

             var prtWindow = window.open(windowUrl, windowName,
             'left=100,top=100,right=100,bottom=100,width=700,height=500');
             prtWindow.document.write('<html><head></head>');
             prtWindow.document.write('<body style="background:none !important">');
             prtWindow.document.write(gridData.outerHTML);
             prtWindow.document.write('</body></html>');
             prtWindow.document.close();
             prtWindow.focus();
             prtWindow.print();
             prtWindow.close();
         }


        $(function () {
            debugger;
            $("#<%= txtSalesDate.ClientID %>").datepicker({
                changeMonth: true,
                changeYear: true,
            });
        });


        $(document).ready(function() {

            //$.validator.addMethod("match", function(value, element)   
            //{  
            //    return this.optional(element) || /^[0-9]{5}$/i.test(value);  
            //}, "Please enter 5 digit invoice number."); 

            $.validator.addMethod("CheckDropDownList", function (value, element) {  
                if (value == '0')  
                    return false;  
                else  
                    return true; 
        
            },"Please select from dropdown list .");
        
            $.validator.addMethod("rdate",function(value,element){
                if (value=='')
                    return false;
                else
                    return true;
            },"ReceiveDate is Required.");
            $.validator.addMethod('le', function(value, element, param) {
                return this.optional(element) || value <= $(param).val();
            }, 'Invalid value');

            $("#form1").validate({
                rules: {
                    <%= txtSalesId.UniqueID %>:
                {
                    required: true,
                   // match: true
                },
                            
                    <%= txtSalesDate.UniqueID %>:
                {
                    rdate:true,
                    date: true
                },
                    <%=ddlManufacturer.UniqueID %>:
                {
                    CheckDropDownList:true  
                },
                    <%=ddlSuppliers.UniqueID %>:
                {
                    CheckDropDownList:true
                },
                    <%=ddlProduct.UniqueID %>:
               {
                                
                   CheckDropDownList:true  
               },
                    <%= txtQty.UniqueID %>:
                {
                                
                    required: true,
                    digits: true,
                    le:"#<%=txtavalQty.ClientID %>"
                },
                    <%= txtUnitPrice.UniqueID %>:
                {
                                
                    required: true,
                    number: true
                }
                },
                messages: 
                        {
                            <%= txtSalesId.UniqueID %>: 
                  {
                      required:'SalesID is Required.'
                  },
                            <%=ddlManufacturer.UniqueID %>:
                   {
                       CheckDropDownList:'Please select Manufacturer.'
                   },
                            <%=ddlProduct.UniqueID %>:
                   {
                       CheckDropDownList:'Please select Product.'
                   },
                            <%=ddlSuppliers.UniqueID %>:
                   {
                       CheckDropDownList:'Please select Suppliers.'
                   },
                            <%= txtQty.UniqueID %>:
                  {
                                
                      required: 'Quantity is Required.',
                      le:'Less or equal to available Quantity.'
                     
                   
                  },
                            <%= txtUnitPrice.UniqueID %>:
                {
                                
                    required: 'Quantity is Required.'
                    
                  
                }
               

                        }
            });
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
        <h2>Sales From</h2>
        <table class="frmRS">
            <tr>
                <td>Sales ID</td>
                <td>
                    <asp:TextBox ID="txtSalesId" CssClass="textboxs" runat="server" Width="130"></asp:TextBox>
                    <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" formnovalidate="formnovalidate" Text="Find" OnClick="btnSearch_Click" /></td>

            </tr>
            <tr>
                <td>Sales Date</td>
                <td>
                    <asp:TextBox ID="txtSalesDate" CssClass="textboxs" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Supplier Name</td>
                <td>
                    <asp:DropDownList ID="ddlSuppliers" CssClass="textboxs" runat="server" AppendDataBoundItems="True" AutoPostBack="True" >
                    </asp:DropDownList></td>


            </tr>
            <tr>
                <td>Manufacurer Name</td>
                <td>
                    <asp:DropDownList ID="ddlManufacturer" CssClass="textboxs" runat="server" AppendDataBoundItems="True" AutoPostBack="True" >
                    </asp:DropDownList></td>

                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>Product Name</td>
                <td>
                    <asp:DropDownList ID="ddlProduct" CssClass="textboxs" runat="server" AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="ddlProduct_SelectedIndexChanged" ViewStateMode="Enabled">
                    </asp:DropDownList></td>


            </tr>
            <tr>
                <td>Avaliable_Qty</td>
                <td>
                    <asp:TextBox ID="txtavalQty" CssClass="textboxs" runat="server" Enabled="False"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
             <tr>
                <td>Quantity</td>
                <td>
                    <asp:TextBox ID="txtQty" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>UnitPrice</td>
                <td>
                    <asp:TextBox ID="txtUnitPrice" CssClass="textboxs" runat="server"></asp:TextBox></td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnNew" CssClass="btn" runat="server" formnovalidate="formnovalidate" Text="New" OnClick="BtnNew_Click" />
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="BtnSave_Click" />
            
            <asp:Button ID="BtnVoid" CssClass="btn" runat="server" formnovalidate="formnovalidate" Text="Void" OnClick="BtnVoid_Click"/>
            <asp:Button ID="btnPrint" CssClass="btn" runat="server" Text="Print" OnClientClick="printGrid()" />

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
                    <asp:BoundField DataField="SalesId" HeaderText="Sales_ID" />
                    <asp:BoundField DataField="SalesDate" HeaderText="Sales_Date" />
                    <asp:BoundField DataField="SupplierName" HeaderText="Supplier_Name" />
                    <asp:BoundField DataField="ManufacturerName" HeaderText="Manufacturer_Name" />
                    <asp:BoundField DataField="ProductName" HeaderText="Product_Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" />
                    <asp:BoundField DataField="Amount" HeaderText ="Amount" />

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
