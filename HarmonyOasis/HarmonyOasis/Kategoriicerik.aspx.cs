using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HarmonyOasis
{
    public partial class Kategoriicerik : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int id = Convert.ToInt32(Request.QueryString["kategoriID"]);
                Kategori kat = dm.KategoriGetir(id);
                ltrl_isim.Text = kat.Isim;
                rp_parca.DataSource = dm.ParcaGetirKategori(id);
                rp_parca.DataBind();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}