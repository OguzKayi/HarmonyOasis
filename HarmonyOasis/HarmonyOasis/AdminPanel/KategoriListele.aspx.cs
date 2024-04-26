using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Kategoriler.DataSource = dm.KategoriGetir();
            lv_Kategoriler.DataBind();
        }

        protected void lv_Kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.KategoriSil(id))
                {
                    Response.Redirect("KategoriListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Kategori Silinirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            if (e.CommandName == "durum")
            {
                if (dm.KategoriDurum(id))
                {
                    Response.Redirect("KategoriListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Kategori Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
        }
    }
}