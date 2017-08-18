using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLayer;
using DALayer;
using System.Data;

namespace InventoryManagmentSystem
{
    public partial class Product1 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                LoadManuf();
                ClearAll();
            }
         

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            clsProduct Dal = new clsProduct();
            BLayer.Product obj = InitalizeObject();
            Dal.AddNewProduct(obj);
            LoadGrid();
           
            ClearAll();
      
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            clsProduct Dal = new clsProduct();
            BLayer.Product obj = InitalizeObject();

            Dal.UpdateProduct(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            clsProduct Dal = new clsProduct();
            BLayer.Product obj = InitalizeObject();

            Dal.DeleteProduct(obj);
            LoadGrid();
            ClearAll();
        }

        private BLayer.Product InitalizeObject()
        {
            BLayer.Product obj = new BLayer.Product();

            obj.ProductId = txtProductId.Text;
            obj.ProductName = txtProductName.Text;
            obj.MinQuantity = Convert.ToInt16(txtMinQty.Text);
            obj.ManufId = ddlProdManfacturer.SelectedValue;
            return obj;
        }

        public void ClearAll()
        {
            txtProductId.Text = "";
            txtProductName.Text = "";
            txtMinQty.Text = "";
            ddlProdManfacturer.SelectedIndex = 0;
            BtnSave.Enabled = true;

        }
        private void LoadGrid()
        {
            clsProduct Dal = new clsProduct();
            DataSet Products = Dal.LoadProduct();
            GridView1.DataSource = Products.Tables[0];
            GridView1.DataBind();
        }
        private void LoadManuf()
        {
            clsProduct Dal = new clsProduct();
            DataSet Manuf = Dal.FillManufacturer();
            ddlProdManfacturer.DataTextField = "ManufacturerName";
            ddlProdManfacturer.DataValueField = "ManufacturerID";
            ddlProdManfacturer.DataSource = Manuf.Tables[0];
            ddlProdManfacturer.DataBind();

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtProductId.Text = row.Cells[1].Text;
            txtProductName.Text = row.Cells[2].Text;
            txtMinQty.Text = row.Cells[3].Text;
            ddlProdManfacturer.SelectedItem.Text = row.Cells[4].Text;

            //ddlProdManfacturer.SelectedValue=ddlProdManfacturer.Items.FindByText((row.Cells[4].Text).Trim().ToString());
            BtnSave.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }
    }
}