using System;
using DALayer;
using System.Data;
using System.Web.Security;

namespace InventoryManagmentSystem
{ 
    public partial class Login : System.Web.UI.Page
    {
         
          

        protected void Page_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();  
        }

        
        protected void btnLogin_Click1(object sender, EventArgs e)
        {
            clsUser Dal = new clsUser();
            BLayer.User obj = InitUser();
            DataSet ds = new DataSet();
            ds = Dal.ISValid(obj);
            if (ds.Tables[0].Rows.Count == 1)
            {
               FormsAuthentication.RedirectFromLoginPage(obj.username, true);
               Session["IsAdmin"] =ds.Tables[0].Rows[0]["IsAdmin"];
               Session["UserName"] = ds.Tables[0].Rows[0]["UserName"];
            }

            else
            {
            lblmessage.Text="Invalid UserName or Password";
            }
        }

        private BLayer.User InitUser()
        {
            BLayer.User obj = new BLayer.User();
            obj.username = txtUserName.Text;
            obj.password = txtPassword.Text;
            return obj;
        }
    }
}