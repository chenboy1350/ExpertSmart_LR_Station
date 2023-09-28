using System;
using System.Web.UI;

namespace LR_Station
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignin_Click(object sender, EventArgs e)
        {
            if (txtUsername.Value == "admin" && txtPassword.Value == "admin")
            {
                Response.Redirect("Index.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "Modal_Danger", "$(window).on('load', function () { $('#DialogIconedDanger').modal('show'); }); ", true);
            }

        }
    }
}