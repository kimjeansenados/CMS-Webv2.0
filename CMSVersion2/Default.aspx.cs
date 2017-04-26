using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMSVersion2
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!Page.User.Identity.IsAuthenticated)
            //{
            //    FormsAuthentication.RedirectToLoginPage();
            //}
            //bool check = HttpContext.Current.User.Identity.IsAuthenticated;
            //if (check == false)
            //{
            //    Response.Redirect("~/Login.aspx");
            //}
        }
    }
}