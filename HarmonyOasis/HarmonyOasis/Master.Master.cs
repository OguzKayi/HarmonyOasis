using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HarmonyOasis
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["uye"] != null)
            {
                Uyeler uye = (Uyeler)Session["uye"];
                kullanici_lbl.Text = uye.KullaniciAdi;
                pnl_girisVar.Visible = true;
                pnl_girisYok.Visible = false;
            }
            else
            {
                pnl_girisYok.Visible = true;
                pnl_girisVar.Visible = false;
            }
        }

        protected void cikisButton_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}