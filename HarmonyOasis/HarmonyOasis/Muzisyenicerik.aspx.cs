using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis
{
    public partial class Muzisyenicerik : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["muzisyenID"]);
                rp_muzisyen.DataSource = dm.NeDemekQuerystringIcindeQueryStringOlamazBizimZamanımızdaOluyodu(id);
                rp_muzisyen.DataBind();

                rp_parcalar.DataSource = dm.ParcaGetirMuziyen(id);
                rp_parcalar.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}