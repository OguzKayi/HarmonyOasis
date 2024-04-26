using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis
{
    public partial class Profil : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["uye"] != null)
                {
                    Uyeler uye = (Uyeler)Session["uye"];
                    tb_kullanici.Text = uye.KullaniciAdi;
                    tb_email.Text = uye.Email;
                    tb_sifre.Text = uye.Sifre;
                    kyt_tarih.Text = Convert.ToString(uye.Kayit);

                    rp_profilYorum.DataSource = dm.UyeyorumlariGetir(uye.ID);
                    rp_profilYorum.DataBind();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btn_uye_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullanici.Text))
            {
                if (!string.IsNullOrEmpty(tb_email.Text))
                {
                    if (!string.IsNullOrEmpty(tb_sifre.Text))
                    {
                        Uyeler uye = (Uyeler)Session["uye"];
                        uye.KullaniciAdi = tb_kullanici.Text;
                        uye.Email = tb_email.Text;
                        uye.Sifre = tb_sifre.Text;
                        string geridonus = dm.UyeGuncelle(uye);
                        if (geridonus == "isim")
                        {
                            successed_pnl.Visible = false;
                            lbl_fail.Text = "Bu İsim Başka Bir Hesaba Ait";
                            failed_pnl.Visible = true;
                        }
                        else if (geridonus == "email")
                        {
                            successed_pnl.Visible = false;
                            lbl_fail.Text = "Bu Email Başka Bir Hesaba Ait";
                            failed_pnl.Visible = true;
                        }
                        else if (geridonus == "hata")
                        {
                            successed_pnl.Visible = false;
                            lbl_fail.Text = "Düzenleme Sırasında Bir Hata Oluştu";
                            failed_pnl.Visible = true;
                        }
                        else if (geridonus == "duzen")
                        {
                            Session["uye"] = null;
                            Response.Redirect("KullaniciGiris.aspx");
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
                lbl_fail.Text = "Kullanıcı Adı Boş Bırakılamaz";
                failed_pnl.Visible = true;
            }
        }

        protected void profilYorum_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                if (dm.YorumSil(id))
                {
                    Response.Redirect("Profil.aspx");
                }
                else
                {
                    lblYorum_fail.Text = "Yorum Silinirkern Bir Hata Oluştu";
                    failedYorum_pnl.Visible = true;
                }
            }
        }
    }
}