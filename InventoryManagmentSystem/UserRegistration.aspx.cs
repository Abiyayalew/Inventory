using System;
using System.Web.UI.WebControls;

using DALayer;
using System.Data;

namespace InventoryManagmentSystem
{
    public partial class UserRegistration : System.Web.UI.Page
    {
          clsUser Dal = new clsUser();
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
            BLayer.User obj = InitalizeObject();
            Dal.AddNewUser(obj);
            LoadGrid();
            ClearAll();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            BLayer.User obj = new  BLayer.User();
            obj = InitalizeObject();
            Dal.UpdateUser(obj);
            LoadGrid();
            ClearAll();
      
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            BLayer.User obj = InitalizeObject();
            int userId = Convert.ToInt16(ViewState["userId"]);
            Dal.DeleteUser(userId);
            LoadGrid();
            ClearAll();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GridViewRow row = GridView1.SelectedRow;
            ViewState["userId"] = row.Cells[1].Text;
            txtUserName.Text = row.Cells[2].Text;
            txtEmail.Text = row.Cells[3].Text;
            txtPassword.Text = row.Cells[4].Text;
            txtConfirmpassword.Text = row.Cells[4].Text;
            if (row.Cells[5].Text == "True")
            {
                ChkStatus.Checked = true;
            }
            else
            {
                ChkStatus.Checked = false;
            }
            BtnSave.Enabled = false;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GridView1.PageIndex = e.NewPageIndex;
            LoadGrid();
        }

        private BLayer.User InitalizeObject()
        {


            BLayer.User obj = new BLayer.User();
            obj.UserId = Convert.ToInt16(ViewState["userId"]);
            obj.username = txtUserName.Text;
            obj.email = txtEmail.Text;
            obj.password = txtPassword.Text;
            if (ChkStatus.Checked == true)
            {
                obj.IsAdmin = true;
            }
            else
            {
                obj.IsAdmin = false;
            }

            return obj;
        }

        public void ClearAll()
        {

            txtUserName.Text = "";
            txtEmail.Text = "";
            txtPassword.Text = "";
            txtConfirmpassword.Text = "";
            ChkStatus.Checked = false;
            BtnSave.Enabled = true;

        }
        private void LoadGrid()
        {

            DataSet users = Dal.LoadUser();
            GridView1.DataSource = users.Tables[0];
            GridView1.DataBind();
        }
       
    }
}