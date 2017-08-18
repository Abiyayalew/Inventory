using System;
using System.Collections.Generic;
using System.Linq;

using System.Web.UI.WebControls;
using DALayer;

using System.Data;


namespace InventoryManagmentSystem
{
    public partial class Sales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               

                LoadProduct();
                LoadManuf();
                LoadSupplier();
                ClearAll();
                


            }
        }




        protected void BtnSave_Click(object sender, EventArgs e)
        {

            clsSales Dal = new clsSales();
            BLayer.Sales obj = InitalizeObject();
            Dal.AddNewSales(obj);
            obj.Qty = -(obj.Qty);
            Dal.AddNewProductDetail(obj);
            LoadGrid();

            clearAfterSave();

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            BLayer.Sales obj = InitalizeObject();
            clsSales Dal = new clsSales();
            Dal.UpdateSales(obj);
            Dal.UpdateProductDetail(obj);
            LoadGrid();
            ClearAll();


        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            //int selectedrow = GridView1.SelectedRow.RowIndex;
            //SelectedRecord = receives[selectedrow];

            txtSalesId.Text = row.Cells[1].Text;
            
            txtSalesDate.Text = row.Cells[2].Text;
            ddlSuppliers.SelectedIndex = ddlSuppliers.Items.IndexOf(ddlSuppliers.Items.FindByText(row.Cells[3].Text));
            ddlManufacturer.SelectedIndex = ddlManufacturer.Items.IndexOf(ddlManufacturer.Items.FindByText(row.Cells[4].Text));
            //ddlSupplier.SelectedIndex = ddlSupplier.Items.IndexOf(ddlSupplier.Items.FindByText(row.Cells[4].Text));
            ddlProduct.SelectedIndex = ddlProduct.Items.IndexOf(ddlProduct.Items.FindByText(row.Cells[5].Text));
            txtUnitPrice.Text = row.Cells[7].Text;
            txtQty.Text = row.Cells[6].Text;

            BtnSave.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
        }

        private void LoadManuf()
        {
            clsReceive Dal = new clsReceive();
            DataSet Manuf = Dal.FillManufacturer();
            ddlManufacturer.DataTextField = "ManufacturerName";
            ddlManufacturer.DataValueField = "ManufacturerID";
            
            ddlManufacturer.DataSource = Manuf.Tables[0];
            ddlManufacturer.DataBind();
            ddlManufacturer.Items.Insert(0, "-- Select--");
            ddlManufacturer.Items[0].Value = "0";
           
        }
        private void LoadSupplier()
        {
            clsReceive Dal = new clsReceive();
            DataSet supplier = Dal.FillSupplier();
           ddlSuppliers.DataTextField = "SupplierName";
           ddlSuppliers.DataValueField = "SupplierId";
           ddlSuppliers.DataSource = supplier.Tables[0];
           ddlSuppliers.DataBind();
           ddlSuppliers.Items.Insert(0, "-- Select--");
           ddlSuppliers.Items[0].Value = "0";

        }
        private void LoadProduct()
        {
            clsProduct Dal = new clsProduct();
            DataSet product = Dal.FillProduct();
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductId";
            ddlProduct.DataSource = product.Tables[0];
            ddlProduct.DataBind();

            ddlProduct.Items.Insert(0, "--Select--");
            ddlProduct.Items[0].Value = "0";

        }
        private void LoadGrid()
        {

            string SalesId = ViewState["SalesId"].ToString();
            FindSaleBySalesId(SalesId);
        }
        //private void LoadGridinMemory()
        //{

        //    GridView1.DataSource = receives;   
        //    GridView1.DataBind();

        private void ClearAll()
        {
            txtSalesId.Focus();
            txtSalesId.Text = "";
            txtSalesDate.Text = "";
            ddlSuppliers.ClearSelection();
            ddlManufacturer.ClearSelection();

            ddlProduct.ClearSelection();
            txtQty.Text = "";
            txtavalQty.Text = "";
            txtUnitPrice.Text = "";

            // SelectedRecord = new BLayer.Receive();
            BtnSave.Enabled = true;

        }
        private void clearAfterSave()
        {
            ddlProduct.Focus();
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = "";
            txtavalQty.Text = "";
            txtUnitPrice.Text = "";
            BtnSave.Enabled = true;
        }
        private BLayer.Sales InitalizeObject()
        {
            BLayer.Sales obj = new BLayer.Sales();
            // DateTime d = DateTime.Pse(txtRecDate.Text,"MM/dd/yyyy");
            ViewState["SalesId"] = txtSalesId.Text;
            obj.SalesId = txtSalesId.Text;
            obj.SalesDate = Convert.ToDateTime(txtSalesDate.Text);
            obj.SupplierId = ddlSuppliers.SelectedValue;
            obj.SupplierName = ddlSuppliers.SelectedItem.Text;
            obj.ManufId = ddlManufacturer.SelectedValue;
            obj.ManufacturerName = ddlManufacturer.SelectedItem.Text;
            obj.ProductId = ddlProduct.SelectedValue;
            obj.ProductName = ddlProduct.SelectedItem.Text;
            obj.Qty = Convert.ToInt16(txtQty.Text);
            obj.UnitPrice = Convert.ToDecimal(txtUnitPrice.Text);
            return obj;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            string SalesId = txtSalesId.Text;
            FindSaleBySalesId(SalesId);

        }

        private void FindSaleBySalesId(string SalesId)
        {
            clsSales Dal = new clsSales();
            DataSet Sales = Dal.LoadSales(SalesId);

            if (Sales.Tables[0].Rows.Count != 0)
            {
                GridView1.DataSource = Sales.Tables[0];
                GridView1.DataBind();
                decimal total = Sales.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("Amount"));
                GridView1.FooterRow.Cells[5].Text = "Total";
                GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                GridView1.FooterRow.Cells[6].Text = total.ToString("N2");
            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsProductDetail Dal = new clsProductDetail();
            DataSet ds = Dal.FindPriceandAvaliableQty(ddlProduct.SelectedValue, ddlSuppliers.SelectedValue, ddlManufacturer.SelectedValue);
            if (ds.Tables[0].Rows.Count != 0)
            {
                txtavalQty.Text = (ds.Tables[0].Rows[0]["Qty"]).ToString();
                txtUnitPrice.Text = (ds.Tables[0].Rows[0]["CurrentCost"]).ToString();
                txtQty.Focus();
            }
            else
            {
                txtavalQty.Text = "0";
            }

        }

        protected void ddlProduct_TextChanged(object sender, EventArgs e)
        {

        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            GridView1.DataSource = null;
            clsSales Dal = new clsSales();
            DataSet obj = new DataSet();
            obj = Dal.GenerateNewSalesId();
            txtSalesId.Text= (obj.Tables[0].Rows[0][0]).ToString();
            
        }

        protected void BtnVoid_Click(object sender, EventArgs e)
        {
            clsSales Dal = new clsSales();
            ViewState["SalesId"] = txtSalesId.Text;
            Dal.VoidSales(txtSalesId.Text);
            LoadGrid();
            GridView1.DataSource = null;
            GridView1.DataBind();

        }

       

     
    }
} 