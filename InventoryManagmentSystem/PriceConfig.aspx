<%@ Page Title="" Language="C#" MasterPageFile="~/MainPage.Master" AutoEventWireup="true" CodeBehind="PriceConfig.aspx.cs" Inherits="InventoryManagmentSystem.PriceConfig" %>
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
               
                           
            <%=ddlProduct.UniqueID %>:
               {
                                
                   CheckDropDownList:true  
               },
            <%= txtQty.UniqueID %>:
                {
                                
                    required: true,
                    digits: true
                },
            <%= txtRecCost.UniqueID %>:
                {
                                
                    required: true,
                    number: true
                }
        },
        messages: 
                {
                   
                    
                    <%= txtQty.UniqueID %>:
                    {
                                
                      required: 'Quantity is Required.'
                     
                   
                     },
                    <%= txtRecCost.UniqueID %>:
                    {
                                
                    required: 'UnitCost is Required.',
                    number:    'Decimal number only.'
                  
                    }
               

                }
    });
    });
</script>

    
    <style>
       label.error {color:red;}
    </style>

    <div class="container">
        <h2>Price Configration From</h2>
        <table class="frmRS">
            <tr>
                <td>Receive ID</td>
                <td>
                    
                    <asp:DropDownList ID="ddlRecId"  CssClass="textboxs" runat="server" width="130"  AppendDataBoundItems="True" OnSelectedIndexChanged="ddlRecId_SelectedIndexChanged" ></asp:DropDownList>
                     <asp:Button ID="btnSearch" CssClass="Buttons" runat="server" formnovalidate="formnovalidate" Text="Find" OnClick="btnSearch_Click"   /></td>
                <td>
                    &nbsp;</td>
            </tr>
            
            <tr>
                <td>Product Name</td>
                <td><asp:DropDownList ID="ddlProduct" CssClass="textboxs" runat="server" width="130" AppendDataBoundItems="True" Enabled="False" ></asp:DropDownList></td>       
            </tr>
            <tr>
                <td>Rec_Quantity</td>
                <td><asp:TextBox ID="txtQty" CssClass="textboxs" runat="server" width="130" Enabled="False"></asp:TextBox></td>  
            </tr>
            <tr>
                <td>Rec_Cost</td>
                <td><asp:TextBox ID="txtRecCost" CssClass="textboxs" runat="server" width="130" Enabled="False"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Current_Cost</td>
                <td><asp:TextBox ID="txtCurrentCost" CssClass="textboxs" runat="server" width="130" Enabled="False"></asp:TextBox>
                     <asp:Button ID="btnCalc" CssClass="Buttons" runat="server" formnovalidate="formnovalidate" Text="Calculate" OnClick="btnCalc_Click" /></td>
            </tr>
        </table>
        <div class="btns">
            <asp:Button ID="BtnChange" CssClass="btn" runat="server" Text="ChangePrice" OnClick="BtnChange_Click" Width="86px"/>
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
                    <asp:BoundField DataField="ProductName" HeaderText="Product_Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Rec_Quantity" />
                    <asp:BoundField DataField="UnitCost" HeaderText="Receive_Cost" />
                    <asp:BoundField DataField="CurrentCost" HeaderText="CurrentCost" />
                       
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
