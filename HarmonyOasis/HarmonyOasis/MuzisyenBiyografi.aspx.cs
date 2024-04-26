using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis
{
    public partial class MuzisyenBiyografi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                Muzisyen muz = dm.MuzisyenGetir(Convert.ToInt32(Request.QueryString["muzisyenID"]));
                ltrl_isim.Text = muz.Isim;
                ltrl_ozet.Text = muz.Ozet;
                resim.ImageUrl = "/Resimler/MuzisyenResimleri/" + muz.Resim;
                ltrl_biyografi.Text = muz.Biyografi;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}