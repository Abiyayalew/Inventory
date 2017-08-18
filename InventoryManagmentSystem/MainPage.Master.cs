using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InventoryManagmentSystem
{
    public partial class MainPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Convert.ToBoolean(Session["IsAdmin"]) != true)
            {
                user.HRef = "javascript:void(0);";
                user.Attributes.Add("class", "disable-link");
                price.HRef = "javascript:void(0);";
                price.Attributes.Add("class", "disable-link");
                
            }
            loginuser.Text = Session["UserName"].ToString()+ "..."; 

        }

        protected void btnlogout_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

     }
}