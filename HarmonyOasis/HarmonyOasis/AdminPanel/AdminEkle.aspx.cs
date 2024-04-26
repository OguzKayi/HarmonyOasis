using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class AdminEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_tur.DataSource = dm.TurGetir();
                ddl_tur.DataBind();
            }
        }

        protected void btn_adminEkle_Click(object sender, EventArgs e)
        {
            Adminler admin = new Adminler();
            admin.Tur_ID = Convert.ToInt32(ddl_tur.SelectedItem.Value);
            admin.KullaniciAdi = tb_kullanici.Text;
            admin.Isim = tb_isim.Text;
            admin.SoyIsim = tb_soyisim.Text;
            admin.Email = tb_email.Text;
            admin.Sifre = tb_sifre.Text;
            admin.Tarih = DateTime.Now;
            admin.Durum = cb_yayin.Checked;
            if ((!string.IsNullOrEmpty(admin.KullaniciAdi)) && (!string.IsNullOrEmpty(admin.Isim)) && (!string.IsNullOrEmpty(admin.SoyIsim)) && (!string.IsNullOrEmpty(admin.Email)) && (!string.IsNullOrEmpty(admin.Sifre)))
            {
                if (dm.AdminEkle(admin))
                {
                    failed_pnl.Visible = false;
                    successful_pnl.Visible = true;
                }
                else
                {
                    successful_pnl.Visible = false;
                    lbl_fail.Text = "Admin Eklenirken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                successful_pnl.Visible = false;
                lbl_fail.Text = "Admin Eklenirken 'HİÇ BİR BİLGİ' Boş Bırakılamaz";
                failed_pnl.Visible = true;
            }
        }
    }
}