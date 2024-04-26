using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class ParcaDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] != null)
            {
                if (!IsPostBack)
                {
                    ddl_kategori.DataSource = dm.KategoriGetir();
                    ddl_kategori.DataBind();
                    ddl_muzisyen.DataSource = dm.MuzisyenGetir();
                    ddl_muzisyen.DataBind();
                    if (Request.QueryString.Count != 0)
                    {
                        Parcalar parca = dm.ParcaDuzenleGetir(Convert.ToInt32(Request.QueryString["parcaID"]));
                        tb_isim.Text = parca.Isim;
                        tb_content.Text = parca.Nota;
                        tb_tarih.Text = parca.TarihStr;
                        cb_yayin.Checked = parca.Durum;
                        ddl_kategori.SelectedValue = Convert.ToString(parca.Kategori_ID);
                        ddl_muzisyen.SelectedValue = Convert.ToString(parca.Muzisyen_ID);
                    }
                    else
                    {
                        Response.Redirect("ParcaListele.aspx");
                    }
                }
            }
            else
            {
                Response.Redirect("AdminGiris.aspx");
            }
        }

        protected void btn_ParcaDuzenle_Click(object sender, EventArgs e)
        {
            Parcalar parca = new Parcalar();
            parca.ID = Convert.ToInt32(Request.QueryString["parcaID"]);
            parca.Isim = tb_isim.Text;
            parca.Nota = tb_content.Text;
            parca.Muzisyen_ID = Convert.ToInt32(ddl_muzisyen.SelectedItem.Value);
            parca.Kategori_ID = Convert.ToInt32(ddl_kategori.SelectedItem.Value);
            parca.Durum = cb_yayin.Checked;
            if (!string.IsNullOrEmpty(parca.Isim) && parca.Muzisyen_ID != 0 && parca.Kategori_ID != 0 && !string.IsNullOrEmpty(parca.Nota))
            {
                if (dm.ParcaDuzenle(parca))
                {
                    failed_pnl.Visible = false;
                    successful_pnl.Visible = true;
                }
                else
                {
                    successful_pnl.Visible = false;
                    lbl_fail.Text = "Parça Düzenlenirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                successful_pnl.Visible = false;
                lbl_fail.Text = "İsim, Müzisyen, Kategori VE Nota BOŞ BIRAKILAMAZ";
                failed_pnl.Visible = true;
            }
        }
    }
}