using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                    Kategori kat = dm.KategoriGetir(id);
                    if (kat != null)
                    {
                        tb_isim.Text = kat.Isim;
                        tb_aciklama.Text = kat.Aciklama;
                        cb_yayin.Checked = kat.Durum;
                    }
                    else
                    {
                        successful_pnl.Visible = false;
                        lbl_fail.Text = "Kategori Bilgisi Alınırken Bir Hata Oluştu";
                        failed_pnl.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void btnkategoriDuzenle_Click(object sender, EventArgs e)
        {
            Kategori kat = new Kategori();
            kat.ID = Convert.ToInt32(Request.QueryString["kategoriID"]);
            kat.Isim = tb_isim.Text;
            kat.Aciklama = tb_aciklama.Text;
            kat.Durum = cb_yayin.Checked;

            if (!string.IsNullOrEmpty(kat.Isim))
            {
                if (!string.IsNullOrEmpty(kat.Aciklama))
                {
                    if (dm.KategoriDuzenle(kat))
                    {
                        failed_pnl.Visible = false;
                        lbl_success.Text = "Kategori Başarıyla Düzenlendi";
                        successful_pnl.Visible = true;
                    }
                    else
                    {
                        successful_pnl.Visible = false;
                        lbl_fail.Text = "Kategori Düzenlenirken Bir Hata Oluştu";
                        failed_pnl.Visible = true;
                    }
                }
                else
                {
                    successful_pnl.Visible = false;
                    lbl_fail.Text = "Kategori Açıklaması Boş Bırakılamaz";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                successful_pnl.Visible = false;
                lbl_fail.Text = "Kategori Adı Boş Bırakılamaz";
                failed_pnl.Visible = true;
            }
        }
    }
}