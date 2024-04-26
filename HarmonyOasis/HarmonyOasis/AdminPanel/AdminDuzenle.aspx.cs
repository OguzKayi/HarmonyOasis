using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class AdminDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_tur.DataSource = dm.TurGetir();
                ddl_tur.DataBind();
                if (Request.QueryString.Count != 0)
                {
                    int id = Convert.ToInt32(Request.QueryString["adminID"]);
                    Adminler admin = dm.AdminGetir(id);
                    tb_kullanici.Text = admin.KullaniciAdi;
                    tb_isim.Text = admin.Isim;
                    tb_soyisim.Text = admin.SoyIsim;
                    tb_email.Text = admin.Email;
                    tb_sifre.Text = admin.Sifre;
                    cb_yayin.Checked = admin.Durum;
                    ddl_tur.SelectedValue = Convert.ToString(admin.Tur_ID);
                }
                else
                {
                    Response.Redirect("AdminListele.aspx");
                }
            }
        }

        protected void btn_adminDuzenle_Click(object sender, EventArgs e)
        {
            Adminler admin = new Adminler();
            admin.ID = Convert.ToInt32(Request.QueryString["adminID"]);
            admin.Tur_ID = Convert.ToInt32(ddl_tur.SelectedItem.Value);
            admin.KullaniciAdi = tb_kullanici.Text;
            admin.Isim = tb_isim.Text;
            admin.SoyIsim = tb_soyisim.Text;
            admin.Email = tb_email.Text;
            admin.Sifre = tb_sifre.Text;
            admin.Durum = cb_yayin.Checked;

            if ((!string.IsNullOrEmpty(admin.KullaniciAdi)) && (!string.IsNullOrEmpty(admin.Isim)) && (!string.IsNullOrEmpty(admin.SoyIsim)) && (!string.IsNullOrEmpty(admin.Email)) && (!string.IsNullOrEmpty(admin.Sifre)))
            {
                if (dm.AdminDuzenle(admin))
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