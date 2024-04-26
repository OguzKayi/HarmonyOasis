using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis
{
    public partial class KullaniciKayit : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullanici.Text))
            {
                if (!string.IsNullOrEmpty(tb_email.Text))
                {
                    if (!string.IsNullOrEmpty(tb_sifre.Text))
                    {
                        Uyeler uye = new Uyeler();
                        uye.KullaniciAdi = tb_kullanici.Text;
                        uye.Email = tb_email.Text;
                        uye.Sifre = tb_sifre.Text;
                        uye.Kayit = DateTime.Now;
                        string geridonus = dm.UyeKayit(uye);
                        if (geridonus == "kayit")
                        {
                            failed_pnl.Visible = false;
                            successed_pnl.Visible = true;
                        }
                        else if (geridonus == "email")
                        {
                            successed_pnl.Visible = false;
                            lbl_fail.Text = "Girmiş Olduğunuz Email Zaten Mevcut";
                            failed_pnl.Visible = true;
                        }
                        else if (geridonus == "kullanici")
                        {
                            successed_pnl.Visible = false;
                            lbl_fail.Text = "Girmiş Olduğunuz Kullanıcı Adı Zaten Mevcut";
                            failed_pnl.Visible = true;
                        }
                    }
                    else
                    {
                        successed_pnl.Visible = false;
                        lbl_fail.Text = "Şifre Boş Bırakılamaz";
                        failed_pnl.Visible = true;
                    }
                }
                else
                {
                    successed_pnl.Visible = false;
                    lbl_fail.Text = "Email Boş Bırakılamaz";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                successed_pnl.Visible = false;
                lbl_fail.Text = "Kullacın Adı Boş Bırakılamaz";
                failed_pnl.Visible = true;
            }
        }
    }
}