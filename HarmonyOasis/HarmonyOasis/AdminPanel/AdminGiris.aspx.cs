using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class AdminGiris : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_sign_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_kullaniciadi.Text))
            {
                if (!string.IsNullOrEmpty(tb_email.Text))
                {
                    if (!string.IsNullOrEmpty(tb_sifre.Text))
                    {
                        Adminler admin = new Adminler();
                        admin = dm.adminGiris(tb_kullaniciadi.Text, tb_email.Text, tb_sifre.Text);
                        if (admin != null)
                        {
                            if (admin.ID != 0)
                            {
                                if (admin.Durum)
                                {
                                    Session["admin"] = admin;
                                    Response.Redirect("Default.aspx");
                                }
                                else
                                {
                                    lbl_fail.Text = "Hesabınız Askıya Alınmıştır";
                                    failed_pnl.Visible = true;
                                }
                            }
                            else
                            {
                                lbl_fail.Text = "Kullanıcı Bulunamadı";
                                failed_pnl.Visible = true;
                            }
                        }
                        else
                        {
                            lbl_fail.Text = "Bir Hata Oluştu";
                            failed_pnl.Visible = true;
                        }
                    }
                    else
                    {
                        lbl_fail.Text = "Şifre Boş Bırakılamaz";
                        failed_pnl.Visible = true;
                    }
                }
                else
                {
                    lbl_fail.Text = "Email Boş Bırakılamaz";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                lbl_fail.Text = "Kullanıcı Adı Boş Bırakılamaz";
                failed_pnl.Visible = true;
            }
        }
    }
}