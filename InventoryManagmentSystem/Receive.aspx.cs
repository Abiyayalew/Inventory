using System;

using System.Linq;
using System.Web.UI.WebControls;
using System.Data;
using DALayer;

namespace InventoryManagmentSystem
{
    public partial class Receive : System.Web.UI.Page
    {
         

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtQty.Attributes.Add("onkeypress", "return controlEnter('" + txtUnitCost.ClientID + "', event)");
               
                LoadProduct();
                LoadManuf();
                LoadSupplier();
                ClearAll();
                
        

             }
        }

       
        

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            
            //BLayer.Receive obj = InitalizeObject();
            //receives.Add(obj);
            //LoadGridinMemory();
            //ClearAll();

            clsReceive Dal = new clsReceive();
            BLayer.Receive obj = InitalizeObject();
            Dal.AddNewReceive(obj);
            Dal.AddNewProductDetail(obj);
            LoadGrid();
           
            clearAfterSave();

        }

        protected void BtnUpdate_Click(object sender, EventArgs e)

        {
            BLayer.Receive obj = InitalizeObject();
            clsReceive Dal = new clsReceive();
            Dal.UpdateReceive(obj);
            Dal.UpdateProductDetail(obj);
            LoadGrid();
            ClearAll();


        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            clsReceive Dal = new clsReceive();
           string Recid= txtRecId.Text;
           bool IsPriced = Dal.IsProductsGotPrice(Recid);
            if (IsPriced== false)
            {
                Dal.DeleteReceive(Recid);
                Dal.DeleteReceiveDetail(Recid);
                ClearAll();
                GridView1.DataSource = null;
                GridView1.DataBind();
            }
            else
            {
               errorLabel .Text =" you are unable to delete. Those products ready for sale";
            }
          


        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            //int selectedrow = GridView1.SelectedRow.RowIndex;
            //SelectedRecord = receives[selectedrow];
           
            txtRecId.Text = row.Cells[1].Text;
            txtRecDate.Text = row.Cells[2].Text;
            ddlSupplier.SelectedIndex = ddlSupplier.Items.IndexOf(ddlSupplier.Items.FindByText(row.Cells[3].Text));
            ddlProdManfacturer.SelectedIndex = ddlProdManfacturer.Items.IndexOf(ddlProdManfacturer.Items.FindByText(row.Cells[4].Text));
            ddlProduct.SelectedIndex = ddlProduct.Items.IndexOf(ddlProduct.Items.FindByText(row.Cells[5].Text));
            txtUnitCost.Text =  row.Cells[7].Text;
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
            ddlProdManfacturer.DataTextField = "ManufacturerName";
            ddlProdManfacturer.DataValueField = "ManufacturerID";
            ddlProdManfacturer.DataSource = Manuf.Tables[0];
            ddlProdManfacturer.DataBind();
            ddlProdManfacturer.Items.Insert(0, "--Please Make Selection--");
            ddlProdManfacturer.Items[0].Value = "0";

        }
        private void LoadSupplier()
        {
            clsReceive Dal = new clsReceive();
            DataSet supplier = Dal.FillSupplier();
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataValueField = "SupplierId";
            ddlSupplier.DataSource = supplier.Tables[0];
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, "--Please Make Selection--");
            ddlSupplier.Items[0].Value = "0";

        }
        private void LoadProduct()
        {
            clsProduct Dal = new clsProduct();
            DataSet product = Dal.FillProduct();
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductId";
            ddlProduct.DataSource = product.Tables[0];
            ddlProduct.DataBind();

            ddlProduct.Items.Insert(0, "--Please Make Selection--");
            ddlProduct.Items[0].Value = "0";

        }
        private void LoadGrid()
        {
            
            string recId = ViewState["recId"].ToString();
            FindReceiveByRecId(recId);
        }
        //private void LoadGridinMemory()
        //{
           
        //    GridView1.DataSource = receives;   
        //    GridView1.DataBind();
            
       private  void ClearAll()
        {
            txtRecId.Focus();
            txtRecDate.Text = "";
            ddlSupplier.ClearSelection();
            ddlProdManfacturer.ClearSelection();
            
            ddlProduct.ClearSelection();
            txtQty.Text = "";
            txtUnitCost.Text = "";
            errorLabel.Text = "";
            
          
            BtnSave.Enabled = true;

        }
        private void clearAfterSave()
        {
            ddlProduct.Focus();
            ddlProduct.SelectedIndex=0;
            txtQty.Text = "";
            txtUnitCost.Text = "";
            BtnSave.Enabled = true;
        }
        private BLayer.Receive InitalizeObject()
        {
            BLayer.Receive obj = new BLayer.Receive();
        // DateTime d = DateTime.Parse(txtRecDate.Text,"MM/dd/yyyy");
            ViewState["recId"] = txtRecId.Text;
            obj.ReceiveId = txtRecId.Text;
            obj.ReceiveDate = Convert.ToDateTime(txtRecDate.Text);
            obj.SupplierId = ddlSupplier.SelectedValue;
            obj.SupplierName = ddlSupplier.SelectedItem.Text;
            obj.ManufId = ddlProdManfacturer.SelectedValue;
            obj.ManufacturerName = ddlProdManfacturer.SelectedItem.Text;
            obj.ProductId = ddlProduct.SelectedValue;
            obj.ProductName = ddlProduct.SelectedItem.Text;
            obj.Qty = Convert.ToInt16(txtQty.Text);
            obj.UnitCost = Convert.ToDecimal(txtUnitCost.Text);
            return obj;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
           
            string recId = txtRecId.Text;
            FindReceiveByRecId(recId);
            ClearAll();
             
        }

        private void FindReceiveByRecId(string recId)
        {
            clsReceive Dal = new clsReceive();
            DataSet recevie = Dal.LoadReceiveFromDB(recId);
            GridView1.DataSource = recevie.Tables[0];
            GridView1.DataBind();
            decimal total = recevie.Tables[0].AsEnumerable().Sum(row => row.Field<decimal>("UnitCost"));
            if (total != 0)
            {
               
                GridView1.FooterRow.Cells[5].Text = "Total";
                GridView1.FooterRow.Cells[5].HorizontalAlign = HorizontalAlign.Right;
                GridView1.FooterRow.Cells[6].Text = total.ToString("N2");
            }
            else
            {
                errorLabel.Text = "No Record related to this Id";
            }
        }

        protected void BtnNew_Click(object sender, EventArgs e)
        {
            ClearAll();
            GridView1.DataSource = null;
            clsReceive Dal = new clsReceive();
            DataSet obj = new DataSet();
            obj= Dal.GenerateNewReceiveId();
            txtRecId.Text = (obj.Tables[0].Rows[0][0]).ToString();
            

        }

       

    }
}  
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
                
              
                
                
             