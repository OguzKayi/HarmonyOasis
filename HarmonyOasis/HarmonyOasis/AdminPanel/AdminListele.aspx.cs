using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class AdminListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            Adminler admin = (Adminler)Session["admin"];
            if (admin == null)
            {
                Response.Redirect("AdminGiris.aspx");
            }
            else if (admin.Tur == "Admin")
            {
                pnl_secenekYok.Visible = false;
                lv_AdminlerSecenekli.DataSource = dm.AdminGetir();
                lv_AdminlerSecenekli.DataBind();
                pnl_secenekVar.Visible = true;
            }
            else if (admin.Tur == "Moderator")
            {
                pnl_secenekVar.Visible = false;
                lv_AdminlerSeceneksiz.DataSource = dm.AdminGetir();
                lv_AdminlerSeceneksiz.DataBind();
                pnl_secenekYok.Visible = true;
            }
        }

        protected void lv_Adminler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.AdminSil(id))
                {
                    Response.Redirect("AdminListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Admin Silinirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            if (e.CommandName == "durum")
            {
                if (dm.AdminDurum(id))
                {
                    Response.Redirect("AdminListele.aspx");
                }
                else
                {
                    lbl_fail.Text = "Aktiflik Durumu Değiştirilirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
        }
    }
}