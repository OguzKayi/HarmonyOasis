using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class MuzisyenListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Muzisyenler.DataSource = dm.MuzisyenGetir();
            lv_Muzisyenler.DataBind();
        }

        protected void lv_Muzisyenler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.MuzisyenSil(id))
                {
                    Response.Redirect("MuzisyenListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Müzisyen Silinirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            if (e.CommandName == "durum")
            {
                if (dm.MuzisyenDurum(id))
                {
                    Response.Redirect("MuzisyenListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Müzisyen Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
        }
    }
}