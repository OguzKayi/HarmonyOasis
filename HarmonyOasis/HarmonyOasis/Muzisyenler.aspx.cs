using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis
{
    public partial class Muzisyenler : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_Muzisyenler.DataSource = dm.MuzisyenGetir(true);
            rp_Muzisyenler.DataBind();
        }
    }
}