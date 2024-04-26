using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnkategoriEkle_Click(object sender, EventArgs e)
        {
            Kategori kat = new Kategori();
            kat.Isim = tb_isim.Text;
            kat.Aciklama = tb_aciklama.Text;
            kat.Durum = cb_yayin.Checked;

            if (!string.IsNullOrEmpty(kat.Isim))
            {
                if (!string.IsNullOrEmpty(kat.Aciklama))
                {
                    if (dm.KategoriEkle(kat))
                    {
                        failed_pnl.Visible = false;
                        successful_pnl.Visible = true;
                    }
                    else
                    {
                        successful_pnl.Visible = false;
                        lbl_fail.Text = "Kategori Eklenirken Bir Hata Oluştu";
                        failed_pnl.Visible = true;
                    }
                }
                else
                {
                    successful_pnl.Visible = false;
                    lbl_fail.Text = "Açıklama Boş Bırakılamaz";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                successful_pnl.Visible = false;
                lbl_fail.Text = "Kategori İsmi Boş Bırakılamaz";
                failed_pnl.Visible = true;
            }
        }
    }
}