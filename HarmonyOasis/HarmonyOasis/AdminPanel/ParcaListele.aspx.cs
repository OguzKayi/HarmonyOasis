using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class ParcaListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Parcalar.DataSource = dm.ParcaGetir();
            lv_Parcalar.DataBind();
        }

        protected void lv_Parcalar_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "durum")
            {
                if (dm.ParcaDurum(id))
                {
                    failed_pnl.Visible = false;
                    Response.Redirect("ParcaListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Parça Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            if (e.CommandName == "sil")
            {
                if (dm.ParcaSil(id))
                {
                    failed_pnl.Visible = false;
                    Response.Redirect("ParcaListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Parça Silinirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
        }
    }
}