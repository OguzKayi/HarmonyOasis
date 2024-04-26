using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataAccessLayer;

namespace HarmonyOasis.AdminPanel
{
    public partial class Default : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            int askida = dm.DurumAdmin(false);
            int degil = dm.DurumAdmin(true);
            int toplam = askida + degil;

            lbl_adminAskida.Text = askida.ToString();
            lbl_adminDegil.Text = degil.ToString();
            lbl_adminToplam.Text = toplam.ToString();

            askida = dm.DurumUye(false);
            degil = dm.DurumUye(true);
            toplam = askida + degil;

            lbl_uyeAskida.Text = askida.ToString();
            lbl_uyeDegil.Text = degil.ToString();
            lbl_uyeToplam.Text = toplam.ToString();

            askida = dm.DurumYorum(false);
            degil = dm.DurumYorum(true);
            toplam = askida + degil;

            lbl_yorumAskida.Text = askida.ToString();
            lbl_yorumDegil.Text = degil.ToString();
            lbl_yorumToplam.Text = toplam.ToString();

            askida = dm.DurumKategori(false);
            degil = dm.DurumKategori(true);
            toplam = askida + degil;

            lbl_katAskida.Text = askida.ToString();
            lbl_katDegil.Text = degil.ToString();
            lbl_katToplam.Text = toplam.ToString();

            askida = dm.DurumMuzisyen(false);
            degil = dm.DurumMuzisyen(true);
            toplam = askida + degil;

            lbl_muzAskida.Text = askida.ToString();
            lbl_muzDegil.Text = degil.ToString();
            lbl_muzToplam.Text = toplam.ToString();

            askida = dm.DurumParca(false);
            degil = dm.DurumParca(true);
            toplam = askida + degil;

            lbl_parAskida.Text = askida.ToString();
            lbl_parDegil.Text = degil.ToString();
            lbl_parToplam.Text = toplam.ToString();
        }
    }
}