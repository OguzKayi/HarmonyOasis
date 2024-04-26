using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class YorumListeKontrolYapilmadi : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_kontrolyapilmadiYorumlar.DataSource = dm.KontrolyorumlariGetir(false);
            lv_kontrolyapilmadiYorumlar.DataBind();
        }

        protected void lv_kontrolyapilmadiYorumlar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.YorumSil(id))
                {
                    Response.Redirect("YorumListeKontrolYapilmadi.aspx");
                }
                else
                {
                    lbl_fail.Text = "Yorum Silinirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }

            if (e.CommandName == "durum")
            {
                if (dm.YorumDurum(id))
                {
                    Response.Redirect("YorumListeKontrolYapilmadi.aspx");
                }
                else
                {
                    lbl_fail.Text = "Yorum Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }

            if (e.CommandName=="kontrol")
            {
                if (dm.YorumKontrol(id))
                {
                    Response.Redirect("YorumListeKontrolYapilmadi.aspx");
                }
                else
                {
                    lbl_fail.Text = "Yorum Kontrol Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
        }
    }
}