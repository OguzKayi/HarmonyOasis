using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HarmonyOasis.AdminPanel
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"]!=null)
            {
                Adminler admin = (Adminler)Session["admin"];
                lbl_kullanici.Text = admin.KullaniciAdi + "(" + admin.Tur + ")";
            }
            else
            {
                Response.Redirect("AdminGiris.aspx");
            }
            
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["admin"] = null;
            Response.Redirect("AdminGiris.aspx");
        }
    }
}