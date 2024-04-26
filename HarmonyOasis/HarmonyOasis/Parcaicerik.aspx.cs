using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis
{
    public partial class Parcaicerik : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int parcaid = Convert.ToInt32(Request.QueryString["parcaID"]);
                    Parcalar parca = dm.ParcaGetir(parcaid);
                    ltrl_baslik.Text = parca.Isim;
                    ltrl_muzisyen.Text = parca.Muzisyen;
                    ltrl_kategori.Text = parca.Kategori;
                    ltrl_content.Text = parca.Nota;


                    if (Session["uye"] != null)
                    {
                        yorumYokpanel.Visible = false;
                        yorumVarpanel.Visible = true;
                        Uyeler uye = (Uyeler)Session["uye"];
                        ltrl_UyeIsim.Text = uye.KullaniciAdi;
                        ltrl_MuzIsim.Text = parca.Muzisyen;
                        ltrl_ParIsim.Text = parca.Isim;
                        ltrl_KatIsim.Text = parca.Kategori;
                        rp_Parcayorum.DataSource = dm.yorumGetir(parcaid);
                        rp_Parcayorum.DataBind();
                    }
                    else
                    {
                        yorumVarpanel.Visible = false;
                        yorumYokpanel.Visible = true;
                    }
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btn_yorum_Click(object sender, EventArgs e)
        {
            if (tb_yorum.Text.Length <= 500 && tb_yorum.Text.Length > 0)
            {
                Uyeler uye = (Uyeler)Session["uye"];
                Yorumlar yorum = new Yorumlar();
                int id = Convert.ToInt32(Request.QueryString["parcaID"]);
                Parcalar parca = dm.ParcaGetir(id);
                yorum.Parca_ID = id;
                yorum.Uye_ID = uye.ID;
                yorum.Icerik = tb_yorum.Text;
                yorum.Tarih = DateTime.Now;
                yorum.Durum = false;
                yorum.Kontrol = false;
                yorum.Kategori_ID = parca.Kategori_ID;
                yorum.Muzisyen_ID = parca.Muzisyen_ID;
                if (dm.YorumEkleParca(yorum))
                {
                    failed_pnl.Visible = false;
                    Response.Redirect("Parcaicerik.aspx?parcaID=" + id);
                }
                else
                {
                    lbl_fail.Text = "Yorum Yapılırken Bir Hata Oluştu";
                    failed_pnl.Visible = true;
                }
            }
            else
            {
                lbl_fail.Text = "Yorum 500 ile 1 Karakter Arasında Olmalıdır";
                failed_pnl.Visible = true;
            }
        }
    }
}