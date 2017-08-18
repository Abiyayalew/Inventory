using System;
using System.Web.UI.WebControls;
using DALayer;
using System.Data;

namespace InventoryManagmentSystem
{
    public partial class PriceConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProduct();
                LoadReciveId();
                ClearAll();
                BtnChange.Enabled = false;

            }

        }
        private void LoadProduct()
        {
            clsProduct Dal = new clsProduct();
            DataSet product = Dal.FillProduct();
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductId";
            ddlProduct.DataSource = product.Tables[0];
            ddlProduct.DataBind();

            ddlProduct.Items.Insert(0, "Select");
            ddlProduct.Items[0].Value = "0";

        }
        private void LoadReciveId()
        {
            clsProductDetail Dal = new clsProductDetail();
            DataSet pdetail = Dal.FillReceiveAvalibleforPricing();
            ddlRecId.DataValueField = "RecId";
            ddlRecId.DataSource = pdetail.Tables[0];
            ddlRecId.DataBind();

            ddlRecId.Items.Insert(0, "Select");
            ddlRecId.Items[0].Value = "0";

        }
        private void ClearAll()
        {
            ddlRecId.Focus();
            ddlRecId.SelectedIndex=0;
            ddlProduct.SelectedIndex = 0;
            txtQty.Text = "";
            txtRecCost.Text = "";
            txtCurrentCost.Text="";
            BtnChange.Enabled = false;

            // SelectedRecord = new BLayer.Receive();
            

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string recId = ddlRecId.Text;
            FindReceiveByRecId(recId);
        }

        
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            

            ddlRecId.Text = row.Cells[1].Text;
            ddlProduct.SelectedIndex = ddlProduct.Items.IndexOf(ddlProduct.Items.FindByText(row.Cells[2].Text));
            ddlProduct.SelectedItem.Text = row.Cells[2].Text;
            txtRecCost.Text = row.Cells[4].Text;
            txtQty.Text = row.Cells[3].Text;
            txtCurrentCost.Text = "0";
            
            

        }

        private void LoadGrid()
        {

            string recId = ViewState["recId"].ToString();
            FindReceiveByRecId(recId);
        }

        private BLayer.Receive InitalizeObject()
        {
       
            BLayer.Receive obj = new BLayer.Receive();
            // DateTime d = DateTime.Parse(txtRecDate.Text,"MM/dd/yyyy");
            ViewState["recId"] = ddlRecId.Text;
            obj.ReceiveId = ddlRecId.Text;
            obj.ProductId = ddlProduct.SelectedValue;
            obj.ProductName = ddlProduct.SelectedItem.Text;
            obj.Qty = Convert.ToInt16(txtQty.Text);
            obj.UnitCost = Convert.ToDecimal(txtRecCost.Text);
            obj.CurrentCost = Convert.ToDecimal(txtCurrentCost.Text);
            return obj;
        }
        private void FindReceiveByRecId(string recId)
        {
            clsProductDetail Dal = new clsProductDetail(); 
            
            DataSet Pdetail = Dal.LoadProductDetail(recId); 

            GridView1.DataSource = Pdetail.Tables[0];
            GridView1.DataBind();
            
        }

        protected void BtnChange_Click(object sender, EventArgs e)
        {
            BLayer.Receive obj = InitalizeObject();
            clsProductDetail Dal = new clsProductDetail();
            Dal.SaveCurrentCost( obj);
            LoadGrid();
            ClearAll();
        }

        protected void btnCalc_Click(object sender, EventArgs e)
        {
            if (txtQty.Text != "" || txtRecCost.Text != "")
            {
                clsProductDetail Dal = new clsProductDetail();
                BLayer.Receive obj = InitalizeObject();
                txtCurrentCost.Text = Dal.CalculatePrice(obj).ToString();
                BtnChange.Enabled = true;
            }


        }

        protected void ddlRecId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadReciveId();
            //BtnChange.Focus();
        }
    }
}