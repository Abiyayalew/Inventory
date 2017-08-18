<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="InventoryManagmentSystem.Product1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Content" runat="server">

    <script>
        
        $(document).ready(function() {

            $.validator.addMethod("match", function(value, element)   
            {  
                return this.optional(element) || /^[0-9]{5}$/i.test(value);  
            }, "Please enter 5 digit invoice number."); 

            $.validator.addMethod("CheckDropDownList", function (value, element) {  
                if (value == '0')  
                    return false;  
                else  
                    return true; 
        
            },"Please select from dropdown list .");
        
       

            $("#form1").validate({
                rules: {
                    <%= txtProductId.UniqueID %>:
                {
                    required: true
                   
                },
                           
                <%=txtProductName.UniqueID %>:
               {
                     required:true 
               },
                <%= txtMinQty.UniqueID %>:
                {
                                
                    required: true,
                    digits: true
                },
                <%= ddlProdManfacturer.UniqueID %>:
                {
                                
                    CheckDropDownList: true
                    
                }
            },
            messages: 
                    {
                    <%= txtProductId.UniqueID %>: 
                      {
                          required:'ProductId is Required.'
                      },
                    <%= txtProductName.UniqueID %>: 
                      {
                          required:'Product Name is Required.'
                      },
                    
                    <%= txtMinQty.UniqueID %>:
                    {
                                
                        required: ' Minmum Quantity is Required.'
                         
                   
                    },
                    <%= ddlProdManfacturer.UniqueID %>:
                    {
                                
                        CheckDropDownList:'Please select Manufacturer Name'
                  
                    }
               

                }
        });
    });
</script>

    
    <style>
       label.error {color:red;}
    </style>


    <div class="container">
        <h1>Product Master Registration From</h1>
        <table class="form">
            <tr>
                <td>Product ID</td>
                <td>
                    <asp:TextBox ID="txtProductId" CssClass="textboxs" runat="server"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>Product Name</td>
                <td>
                    <asp:TextBox ID="txtProductName" CssClass="textboxs" runat="server"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>Minmun Quantity</td>
                <td>
                    <asp:TextBox ID="txtMinQty" CssClass="textboxs" runat="server"></asp:TextBox></td>
                
            </tr>
            <tr>
                <td>Manufacurer Name</td>
                <td>
                    <asp:DropDownList ID="ddlProdManfacturer" CssClass="textboxs" runat="server"  AppendDataBoundItems="True" ></asp:DropDownList></td>
                    
                
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
                    <asp:BoundField DataField="ProductId" HeaderText="Product_ID" />
                    <asp:BoundField DataField="ProductName" HeaderText="ProductName" />
                    <asp:BoundField DataField="MinQty" HeaderText="Minmum_Quantity"  />
                    <asp:BoundField DataField="ManufacturerName" HeaderText="Manufacturer_Name" />
                       
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
