using System;

using System.Web.UI.WebControls;

using DALayer;
using System.Data;

namespace InventoryManagmentSystem
{
    public partial class Supplier : System.Web.UI.Page
    {
        clsSupplier Dal = new clsSupplier();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
                ClearAll();
            }


        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            BLayer.Supplier  obj = InitalizeObject();
            Dal.AddNewSupplier(obj);
            LoadGrid();
            ClearAll();

        }
        private BLayer.Supplier InitalizeObject()
        {


            BLayer.Supplier obj = new BLayer.Supplier();
             obj.SupplierId = txtSupplierId.Text;
            obj.SupplierName  = txtSupplierName.Text;
            obj.Address = txtAddress.Text;
            obj.PhoneNumber = txtPhoneNumber.Text;
            obj.Email = txtEmail.Text;
                
            return obj;
        }

        public void ClearAll()
        {

            txtSupplierId.Text = "";
            txtSupplierName.Text = "";
            txtAddress.Text = "";
            txtAddress.Text = "";
            txtPhoneNumber.Text  = "";
            txtEmail.Text = "";
            BtnSave.Enabled = true;

        }
        private void LoadGrid()
        {

            DataSet suppliers = Dal.LoadSupplier();
            GridView1.DataSource = suppliers.Tables[0];
            GridView1.DataBind();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            BLayer.Supplier obj = new  BLayer.Supplier();
            obj = InitalizeObject();
            Dal.UpdateSupplier(obj);
            LoadGrid();
            ClearAll();

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            BLayer.Supplier obj = InitalizeObject();
            string  userId = txtSupplierId.Text;
            Dal.DeleteSupplier(userId);
            LoadGrid();
            ClearAll();

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            txtSupplierId.Text = row.Cells[1].Text;
            txtSupplierName.Text = row.Cells[2].Text;
            txtAddress.Text  = row.Cells[3].Text;
            txtPhoneNumber.Text  = row.Cells[4].Text;
            txtEmail.Text = row.Cells[5].Text;
            BtnSave.Enabled = false;

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
             GridView1.PageIndex = e.NewPageIndex;
              LoadGrid();
        }

        
    }
}