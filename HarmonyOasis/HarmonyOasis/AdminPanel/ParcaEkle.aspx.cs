using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class ParcaEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategori.DataSource = dm.KategoriGetir();
                ddl_kategori.DataBind();
                ddl_muzisyen.DataSource = dm.MuzisyenGetir();
                ddl_muzisyen.DataBind();
            }
        }

        protected void btn_ParcaEkle_Click(object sender, EventArgs e)
        {
            Parcalar parca = new Parcalar();
            parca.Isim = tb_isim.Text;
            parca.Tarih = Convert.ToDateTime(tb_tarih.Text);
            parca.Muzisyen_ID = Convert.ToInt32(ddl_muzisyen.SelectedItem.Value);
            parca.Kategori_ID = Convert.ToInt32(ddl_kategori.SelectedItem.Value);
            parca.Nota = tb_content.Text;
            parca.Durum = cb_yayin.Checked;
            if (!string.IsNullOrEmpty(parca.Isim) && parca.Muzisyen_ID != 0 && parca.Kategori_ID != 0 && !string.IsNullOrEmpty(parca.Nota))
            {
                if (dm.ParcaEkle(parca))
                {
                    failed_pnl.Visible = false;
                    successful_pnl.Visible = true;
                }
                else
                {
                    successful_pnl.Visible = false;
                    lbl_fail.Text = "Parça Eklenirken Bir Hata Oluştu";
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