using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class UyeListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_uyeler.DataSource = dm.UyeListele();
            lv_uyeler.DataBind();
        }

        protected void lv_uyeler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.UyeSil(id))
                {
                    Response.Redirect("UyeListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Üye Silinirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            if (e.CommandName == "durum")
            {
                if (dm.UyeDurum(id))
                {
                    Response.Redirect("UyeListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Üyw Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
        }
    }
}