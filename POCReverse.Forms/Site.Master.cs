using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace POCReverse.Forms
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["algo"] = "cabezon";

            var id = Session["algo"].ToString();
            lbHome.HRef = $"~/?id={id}";
            lbAbout.HRef = $"~/About?id={id}";
            lbContact.HRef = $"~/Contact?id={id}";
        }
    }
}