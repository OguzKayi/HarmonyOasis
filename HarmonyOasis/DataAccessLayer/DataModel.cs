using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con; SqlCommand cmd;

        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.Constr);
            cmd = con.CreateCommand();
        }

        #region Metotlar

        #region Admin

        public Adminler adminGiris(string kullaniciAdi, string email, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT A.ID, A.Tur_ID, AT.Isim, A.KullaniciAdi, A.Isim, A.SoyIsim, A.Email, A.Sifre, A.Tarih, A.Durum FROM Adminler AS A JOIN AdminTurler AS AT ON A.Tur_ID=AT.ID WHERE A.KullaniciAdi=@kadi AND A.Email=@email AND A.Sifre=@sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@sifre", sifre);
                Adminler admin = new Adminler();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    admin.ID = reader.GetInt32(0);
                    admin.Tur_ID = reader.GetInt32(1);
                    admin.Tur = reader.GetString(2);
                    admin.KullaniciAdi = reader.GetString(3);
                    admin.Isim = reader.GetString(4);
                    admin.SoyIsim = reader.GetString(5);
                    admin.Email = reader.GetString(6);
                    admin.Sifre = reader.GetString(7);
                    admin.Tarih = reader.GetDateTime(8);
                    admin.Durum = reader.GetBoolean(9);
                }
                return admin;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AdminEkle(Adminler admin)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Adminler(Tur_ID, KullaniciAdi, Isim, SoyIsim, Email, Sifre, Tarih, Durum) VALUES(@Tur_ID, @KullaniciAdi, @Isim, @SoyIsim, @Email, @Sifre, @Tarih, @Durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Tur_ID", admin.Tur_ID);
                cmd.Parameters.AddWithValue("@KullaniciAdi", admin.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Isim", admin.Isim);
                cmd.Parameters.AddWithValue("@SoyIsim", admin.SoyIsim);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@Sifre", admin.Sifre);
                cmd.Parameters.AddWithValue("@Tarih", admin.Tarih);
                cmd.Parameters.AddWithValue("@Durum", admin.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Adminler> AdminGetir()
        {
            try
            {
                List<Adminler> admins = new List<Adminler>();
                cmd.CommandText = "SELECT A.ID, A.Tur_ID, AT.Isim, A.KullaniciAdi, A.Tarih, A.Durum FROM Adminler AS A JOIN AdminTurler AS AT ON A.Tur_ID=AT.ID";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Adminler admin = new Adminler();
                    admin.ID = reader.GetInt32(0);
                    admin.Tur_ID = reader.GetInt32(1);
                    admin.Tur = reader.GetString(2);
                    admin.KullaniciAdi = reader.GetString(3);
                    admin.Tarih = reader.GetDateTime(4);
                    admin.Durum = reader.GetBoolean(5);
                    admins.Add(admin);
                }
                return admins;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Adminler AdminGetir(int id)
        {
            try
            {
                Adminler admin = new Adminler();
                cmd.CommandText = "SELECT Tur_ID, KullaniciAdi, Isim, SoyIsim, Email, Sifre, Durum FROM Adminler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    admin.Tur_ID = reader.GetInt32(0);
                    admin.KullaniciAdi = reader.GetString(1);
                    admin.Isim = reader.GetString(2);
                    admin.SoyIsim = reader.GetString(3);
                    admin.Email = reader.GetString(4);
                    admin.Sifre = reader.GetString(5);
                    admin.Durum = reader.GetBoolean(6);
                }
                return admin;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<AdminTurleri> TurGetir()
        {
            try
            {
                List<AdminTurleri> turler = new List<AdminTurleri>();
                cmd.CommandText = "SELECT ID, Isim FROM AdminTurler";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AdminTurleri tur = new AdminTurleri();
                    tur.ID = reader.GetInt32(0);
                    tur.Isim = reader.GetString(1);
                    turler.Add(tur);
                }
                return turler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AdminSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Adminler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AdminDurum(int ID)
        {
            try
            {
                cmd.CommandText = "SELECT DURUM FROM Adminler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", ID);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Adminler SET DURUM=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool AdminDuzenle(Adminler admin)
        {
            try
            {
                cmd.CommandText = "UPDATE Adminler SET Tur_ID=@Tur_ID, KullaniciAdi=@KullaniciAdi, Isim=@Isim, SoyIsim=@SoyIsim, Email=@Email, Sifre=@Sifre, Durum=@Durum WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", admin.ID);
                cmd.Parameters.AddWithValue("@Tur_ID", admin.Tur_ID);
                cmd.Parameters.AddWithValue("@KullaniciAdi", admin.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Isim", admin.Isim);
                cmd.Parameters.AddWithValue("@SoyIsim", admin.SoyIsim);
                cmd.Parameters.AddWithValue("@Email", admin.Email);
                cmd.Parameters.AddWithValue("@Sifre", admin.Sifre);
                cmd.Parameters.AddWithValue("@Durum", admin.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Müzisyen

        public bool MuzisyenEkle(Muzisyen muz)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Muzisyenler(Isim, Ozet, Biyografi, Resim, Durum) VALUES(@Isim, @Ozet, @Biyografi, @Resim, @Durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Isim", muz.Isim);
                cmd.Parameters.AddWithValue("@Ozet", muz.Ozet);
                cmd.Parameters.AddWithValue("@Biyografi", muz.Biyografi);
                cmd.Parameters.AddWithValue("@Resim", muz.Resim);
                cmd.Parameters.AddWithValue("@Durum", muz.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Muzisyen> MuzisyenGetir()
        {
            try
            {
                List<Muzisyen> muzisyenler = new List<Muzisyen>();
                cmd.CommandText = "SELECT ID, Isim, Ozet, Durum FROM Muzisyenler";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Muzisyen muz = new Muzisyen();
                    muz.ID = reader.GetInt32(0);
                    muz.Isim = reader.GetString(1);
                    muz.Ozet = reader.GetString(2);
                    muz.Durum = reader.GetBoolean(3);
                    muzisyenler.Add(muz);
                }
                return muzisyenler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Muzisyen MuzisyenGetir(int id)
        {
            try
            {
                Muzisyen muz = new Muzisyen();
                cmd.CommandText = "SELECT Isim, Ozet, Biyografi, Resim, Durum FROM Muzisyenler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    muz.Isim = reader.GetString(0);
                    muz.Ozet = reader.GetString(1);
                    muz.Biyografi = reader.GetString(2);
                    muz.Resim = reader.GetString(3);
                    muz.Durum = reader.GetBoolean(4);
                }
                return muz;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Muzisyen> NeDemekQuerystringIcindeQueryStringOlamazBizimZamanımızdaOluyodu(int id)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Ozet, Resim FROM Muzisyenler WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                List<Muzisyen> muzisyen = new List<Muzisyen>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Muzisyen muz = new Muzisyen();
                    muz.ID = reader.GetInt32(0);
                    muz.Isim = reader.GetString(1);
                    muz.Ozet = reader.GetString(2);
                    muz.Resim = reader.GetString(3);
                    muzisyen.Add(muz);
                }
                return muzisyen;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Muzisyen> MuzisyenGetir(bool Durum)
        {
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Ozet, Resim FROM Muzisyenler WHERE Durum=@Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                List<Muzisyen> muzisyenler = new List<Muzisyen>();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Muzisyen muz = new Muzisyen();
                    muz.ID = reader.GetInt32(0);
                    muz.Isim = reader.GetString(1);
                    muz.Ozet = reader.GetString(2);
                    muz.Resim = reader.GetString(3);
                    muzisyenler.Add(muz);
                }
                return muzisyenler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MuzisyenDurum(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum From Muzisyenler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "Update Muzisyenler SET Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MuzisyenSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Muzisyenler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MuzisyenDuzenle(Muzisyen muz)
        {
            try
            {
                cmd.CommandText = "UPDATE Muzisyenler SET Isim=@isim, Ozet=@ozet, Biyografi=@biyografi, Resim=@resim, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", muz.ID);
                cmd.Parameters.AddWithValue("@isim", muz.Isim);
                cmd.Parameters.AddWithValue("@ozet", muz.Ozet);
                cmd.Parameters.AddWithValue("@biyografi", muz.Biyografi);
                cmd.Parameters.AddWithValue("@resim", muz.Resim);
                cmd.Parameters.AddWithValue("@durum", muz.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Kategori

        public bool KategoriEkle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim, Aciklama, Durum) VALUES(@isim, @aciklama, @durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriGetir()
        {
            try
            {
                List<Kategori> Kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    Kategoriler.Add(kat);
                }
                Kategoriler.Reverse();
                return Kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriGetirTrue()
        {
            try
            {
                List<Kategori> Kategoriler = new List<Kategori>();
                cmd.CommandText = "SELECT ID, Isim, Aciklama, Durum FROM Kategoriler WHERE Durum=1";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori kat = new Kategori();
                    kat.ID = reader.GetInt32(0);
                    kat.Isim = reader.GetString(1);
                    kat.Aciklama = reader.GetString(2);
                    kat.Durum = reader.GetBoolean(3);
                    Kategoriler.Add(kat);
                }
                Kategoriler.Reverse();
                return Kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori KategoriGetir(int id)
        {
            try
            {
                Kategori kat = new Kategori();
                cmd.CommandText = "SELECT Isim, Aciklama, Durum FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string Isim = reader.GetString(0);
                    string Aciklama = reader.GetString(1);
                    bool Durum = reader.GetBoolean(2);
                    kat.Isim = Isim;
                    kat.Aciklama = Aciklama;
                    kat.Durum = Durum;
                }
                return kat;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriSil(int ID)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDurum(int ID)
        {
            try
            {
                cmd.CommandText = "SELECT DURUM FROM Kategoriler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", ID);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());

                cmd.CommandText = "UPDATE Kategoriler SET DURUM=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim=@isim, Aciklama=@aciklama, Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@isim", kat.Isim);
                cmd.Parameters.AddWithValue("@aciklama", kat.Aciklama);
                cmd.Parameters.AddWithValue("@durum", kat.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Parça
        public Parcalar ParcaDuzenleGetir(int ID)
        {
            try
            {
                cmd.CommandText = "SELECT Muzisyen_ID, Kategori_ID, Isim, Nota, Durum, Tarih FROM Parcalar WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", ID);
                Parcalar parca = new Parcalar();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parca.Muzisyen_ID = reader.GetInt32(0);
                    parca.Kategori_ID = reader.GetInt32(1);
                    parca.Isim = reader.GetString(2);
                    parca.Nota = reader.GetString(3);
                    parca.Durum = reader.GetBoolean(4);
                    parca.Tarih = reader.GetDateTime(5);
                    parca.TarihStr = parca.Tarih.ToShortDateString();
                }
                return parca;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Parcalar ParcaGetir(int ID)
        {
            try
            {
                Parcalar parca = new Parcalar();
                cmd.CommandText = "SELECT P.Isim, P.Muzisyen_ID, M.Isim, P.Kategori_ID, K.Isim, P.Nota,  P.Tarih, P.Durum FROM Parcalar AS P JOIN Muzisyenler AS M ON P.Muzisyen_ID=M.ID JOIN Kategoriler AS K ON P.Kategori_ID=K.ID WHERE P.ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    parca.Isim = reader.GetString(0);
                    parca.Muzisyen_ID = reader.GetInt32(1);
                    parca.Muzisyen = reader.GetString(2);
                    parca.Kategori_ID = reader.GetInt32(3);
                    parca.Kategori = reader.GetString(4);
                    parca.Nota = reader.GetString(5);
                    parca.Tarih = reader.GetDateTime(6);
                    parca.Durum = reader.GetBoolean(7);
                }
                return parca;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Parcalar> ParcaGetir()
        {
            try
            {
                List<Parcalar> parcalars = new List<Parcalar>();
                cmd.CommandText = "SELECT P.ID, P.Isim, P.Muzisyen_ID, M.Isim, P.Kategori_ID, K.Isim, P.Durum, P.Tarih FROM Parcalar AS P JOIN Muzisyenler AS M ON P.Muzisyen_ID=M.ID JOIN Kategoriler AS K ON P.Kategori_ID=K.ID";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parcalar parca = new Parcalar();
                    parca.ID = reader.GetInt32(0);
                    parca.Isim = reader.GetString(1);
                    parca.Muzisyen_ID = reader.GetInt32(2);
                    parca.Muzisyen = reader.GetString(3);
                    parca.Kategori_ID = reader.GetInt32(4);
                    parca.Kategori = reader.GetString(5);
                    parca.Durum = reader.GetBoolean(6);
                    parca.Tarih = reader.GetDateTime(7);
                    parcalars.Add(parca);
                }
                return parcalars;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Parcalar> ParcaGetirTrue()
        {
            try
            {
                List<Parcalar> parcalars = new List<Parcalar>();
                cmd.CommandText = "SELECT P.ID, P.Isim, P.Muzisyen_ID, M.Isim, P.Kategori_ID, K.Isim, P.Durum, P.Tarih FROM Parcalar AS P JOIN Muzisyenler AS M ON P.Muzisyen_ID=M.ID JOIN Kategoriler AS K ON P.Kategori_ID=K.ID WHERE P.Durum=1";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parcalar parca = new Parcalar();
                    parca.ID = reader.GetInt32(0);
                    parca.Isim = reader.GetString(1);
                    parca.Muzisyen_ID = reader.GetInt32(2);
                    parca.Muzisyen = reader.GetString(3);
                    parca.Kategori_ID = reader.GetInt32(4);
                    parca.Kategori = reader.GetString(5);
                    parca.Durum = reader.GetBoolean(6);
                    parca.Tarih = reader.GetDateTime(7);
                    parca.TarihStr = parca.Tarih.ToShortDateString();
                    parcalars.Add(parca);
                }
                parcalars.Reverse();
                return parcalars;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Parcalar> ParcaGetirKategori(int katid)
        {
            try
            {
                List<Parcalar> parcalar = new List<Parcalar>();
                cmd.CommandText = "SELECT ID, Isim, Nota, Tarih FROM Parcalar WHERE Kategori_ID=@katid AND Durum=1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@katid", katid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parcalar parca = new Parcalar();
                    parca.ID = reader.GetInt32(0);
                    parca.Isim = reader.GetString(1);
                    parca.Nota = reader.GetString(2);
                    parca.Tarih = reader.GetDateTime(3);
                    parca.TarihStr = parca.Tarih.ToShortDateString();
                    parcalar.Add(parca);
                }
                parcalar.Reverse();
                return parcalar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Parcalar> ParcaGetirMuziyen(int muzid)
        {
            try
            {
                List<Parcalar> parcalar = new List<Parcalar>();
                cmd.CommandText = "SELECT ID, Isim, Nota, Tarih FROM Parcalar WHERE Muzisyen_ID=@muzid AND Durum=1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@muzid", muzid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Parcalar parca = new Parcalar();
                    parca.ID = reader.GetInt32(0);
                    parca.Isim = reader.GetString(1);
                    parca.Nota = reader.GetString(2);
                    parca.Tarih = reader.GetDateTime(3);
                    parca.TarihStr = parca.Tarih.ToShortDateString();
                    parcalar.Add(parca);
                }
                parcalar.Reverse();
                return parcalar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ParcaEkle(Parcalar parca)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Parcalar(Muzisyen_ID, Kategori_ID, Isim, Nota, Tarih, Durum) VALUES(@Muzisyen_ID, @Kategori_ID, @Isim, @Nota, @Tarih, @Durum)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Muzisyen_ID", parca.Muzisyen_ID);
                cmd.Parameters.AddWithValue("@Kategori_ID", parca.Kategori_ID);
                cmd.Parameters.AddWithValue("@Isim", parca.Isim);
                cmd.Parameters.AddWithValue("@Nota", parca.Nota);
                cmd.Parameters.AddWithValue("@Tarih", parca.Tarih);
                cmd.Parameters.AddWithValue("@Durum", parca.Durum);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ParcaDuzenle(Parcalar parca)
        {
            try
            {
                cmd.CommandText = "UPDATE Parcalar SET Muzisyen_ID=@Muzisyen_ID, Kategori_ID=@Kategori_ID, Isim=@Isim, Nota=@Nota, Durum=@Durum WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Muzisyen_ID", parca.Muzisyen_ID);
                cmd.Parameters.AddWithValue("@Kategori_ID", parca.Kategori_ID);
                cmd.Parameters.AddWithValue("@Isim", parca.Isim);
                cmd.Parameters.AddWithValue("@Nota", parca.Nota);
                cmd.Parameters.AddWithValue("@Durum", parca.Durum);
                cmd.Parameters.AddWithValue("@ID", parca.ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ParcaDurum(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Parcalar WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Parcalar SET Durum=@Durum WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Durum", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool ParcaSil(int ID)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Parcalar WHERE ID=@ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@ID", ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Üye

        public string UyeKayit(Uyeler uye)
        {
            try
            {
                cmd.CommandText = "SELECT KullaniciAdi FROM Uyeler";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string kullaniciadi = reader.GetString(0);
                    if (kullaniciadi == uye.KullaniciAdi)
                    {
                        return "kullanici";
                    }
                }
                reader.Close();
                cmd.CommandText = "SELECT Email FROM Uyeler";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string email = reader.GetString(0);
                    if (email == uye.Email)
                    {
                        return "email";
                    }
                }
                reader.Close();
                cmd.CommandText = "INSERT INTO Uyeler(KullaniciAdi, Email, Sifre, Durum, Kayit) VALUES(@KullaniciAdi, @Email, @Sifre, 1, @Kayit)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KullaniciAdi", uye.KullaniciAdi);
                cmd.Parameters.AddWithValue("@Email", uye.Email);
                cmd.Parameters.AddWithValue("@Sifre", uye.Sifre);
                cmd.Parameters.AddWithValue("@Kayit", uye.Kayit);
                cmd.ExecuteNonQuery();
                return "kayit";
            }
            catch
            {
                return "hata";
            }
            finally
            {
                con.Close();
            }
        }

        public Uyeler UyeGiris(string kullaniciadi, string email, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT ID, KullaniciAdi, Email, Sifre, Kayit, Durum FROM Uyeler WHERE KullaniciAdi=@KullaniciAdi AND Email=@Email AND Sifre=@Sifre";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@KullaniciAdi", kullaniciadi);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Sifre", sifre);
                Uyeler uye = new Uyeler();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    uye.ID = reader.GetInt32(0);
                    uye.KullaniciAdi = reader.GetString(1);
                    uye.Email = reader.GetString(2);
                    uye.Sifre = reader.GetString(3);
                    uye.Kayit = reader.GetDateTime(4);
                    uye.Durum = reader.GetBoolean(5);
                }
                return uye;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public string UyeGuncelle(Uyeler uye)
        {
            try
            {
                cmd.CommandText = "SELECT KullaniciAdi FROM Uyeler WHERE ID!=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", uye.ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string isim = reader.GetString(0);
                    if (isim == uye.KullaniciAdi)
                    {
                        return "isim";
                    }
                }
                reader.Close();
                cmd.CommandText = "SELECT Email FROM Uyeler WHERE ID!=@id";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string email = reader.GetString(0);
                    if (email == uye.Email)
                    {
                        return "email";
                    }
                }
                reader.Close();
                cmd.CommandText = "UPDATE Uyeler SET KullaniciAdi=@kullaniciadi, Email=@email, Sifre=@sifre WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kullaniciadi", uye.KullaniciAdi);
                cmd.Parameters.AddWithValue("@email", uye.Email);
                cmd.Parameters.AddWithValue("@sifre", uye.Sifre);
                cmd.Parameters.AddWithValue("@id", uye.ID);
                cmd.ExecuteNonQuery();
                return "duzen";
            }
            catch
            {
                return "hata";
            }
            finally
            {
                con.Close();
            }
        }

        public List<Uyeler> UyeListele()
        {
            try
            {
                List<Uyeler> uyeler = new List<Uyeler>();
                cmd.CommandText = "SELECT ID, KullaniciAdi, Kayit, Durum FROM Uyeler";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uyeler uye = new Uyeler();
                    uye.ID = reader.GetInt32(0);
                    uye.KullaniciAdi = reader.GetString(1);
                    uye.Kayit = reader.GetDateTime(2);
                    uye.KayitStr = uye.Kayit.ToShortDateString();
                    uye.Durum = reader.GetBoolean(3);
                    uyeler.Add(uye);
                }
                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool UyeDurum(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Uyeler WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Uyeler SET Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("id", id);
                cmd.Parameters.AddWithValue("durum", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yorum

        public bool YorumEkleParca(Yorumlar yorum)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Yorumlar(Parca_ID, Uye_ID, Icerik, Tarih, Durum, Kontrol, Kategori_ID, Muzisyen_ID) VALUES(@Parca_ID, @Uye_ID, @Icerik, @Tarih, @Durum, @Kontrol, @Kategori_ID, @Muzisyen_ID)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Parca_ID", yorum.Parca_ID);
                cmd.Parameters.AddWithValue("@Uye_ID", yorum.Uye_ID);
                cmd.Parameters.AddWithValue("@Icerik", yorum.Icerik);
                cmd.Parameters.AddWithValue("@Tarih", yorum.Tarih);
                cmd.Parameters.AddWithValue("@Durum", yorum.Durum);
                cmd.Parameters.AddWithValue("@Kontrol", yorum.Kontrol);
                cmd.Parameters.AddWithValue("@Kategori_ID", yorum.Kategori_ID);
                cmd.Parameters.AddWithValue("@Muzisyen_ID", yorum.Muzisyen_ID);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorumlar> yorumGetir(int Parca_ID)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Parca_ID, P.Isim, Y.Uye_ID, U.KullaniciAdi, Y.Kategori_ID, K.Isim, Y.Muzisyen_ID, M.Isim, Y.Icerik, Y.Tarih FROM Yorumlar AS Y JOIN Parcalar AS P ON Y.Parca_ID=P.ID JOIN Uyeler AS U ON Y.Uye_ID=U.ID JOIN Kategoriler AS K ON Y.Kategori_ID=K.ID JOIN Muzisyenler AS M ON Y.Muzisyen_ID=M.ID WHERE Y.Parca_ID=@Parca_ID AND Y.Durum=1 AND Y.Kontrol=1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Parca_ID", Parca_ID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar();
                    yorum.ID = reader.GetInt32(0);
                    yorum.Parca_ID = reader.GetInt32(1);
                    yorum.Parca = reader.GetString(2);
                    yorum.Uye_ID = reader.GetInt32(3);
                    yorum.Uye = reader.GetString(4);
                    yorum.Kategori_ID = reader.GetInt32(5);
                    yorum.Kategori = reader.GetString(6);
                    yorum.Muzisyen_ID = reader.GetInt32(7);
                    yorum.Muzisyen = reader.GetString(8);
                    yorum.Icerik = reader.GetString(9);
                    yorum.Tarih = reader.GetDateTime(10);
                    yorumlar.Add(yorum);
                }
                yorumlar.Reverse();
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorumlar> TumyorumlariGetir()
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Uye_ID, U.KullaniciAdi, Y.Parca_ID, P.Isim, Y.Icerik, Y.Tarih, Y.Kontrol, Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID=U.ID JOIN Parcalar AS P ON Y.Parca_ID=P.ID";
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar();
                    yorum.ID = reader.GetInt32(0);
                    yorum.Uye_ID = reader.GetInt32(1);
                    yorum.Uye = reader.GetString(2);
                    yorum.Parca_ID = reader.GetInt32(3);
                    yorum.Parca = reader.GetString(4);
                    yorum.Icerik = reader.GetString(5);
                    yorum.Tarih = reader.GetDateTime(6);
                    yorum.Kontrol = reader.GetBoolean(7);
                    yorum.Durum = reader.GetBoolean(8);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorumlar> KontrolyorumlariGetir(bool kontrol)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Uye_ID, U.KullaniciAdi, Y.Parca_ID, P.Isim, Y.Icerik, Y.Tarih, Y.Kontrol, Y.Durum FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID=U.ID JOIN Parcalar AS P ON Y.Parca_ID=P.ID WHERE Kontrol=@kontrol";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("kontrol", kontrol);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar();
                    yorum.ID = reader.GetInt32(0);
                    yorum.Uye_ID = reader.GetInt32(1);
                    yorum.Uye = reader.GetString(2);
                    yorum.Parca_ID = reader.GetInt32(3);
                    yorum.Parca = reader.GetString(4);
                    yorum.Icerik = reader.GetString(5);
                    yorum.Tarih = reader.GetDateTime(6);
                    yorum.Kontrol = reader.GetBoolean(7);
                    yorum.Durum = reader.GetBoolean(8);
                    yorumlar.Add(yorum);
                }
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorumlar> UyeyorumlariGetir(int uyeid)
        {
            try
            {
                List<Yorumlar> yorumlar = new List<Yorumlar>();
                cmd.CommandText = "SELECT Y.ID, Y.Uye_ID, U.KullaniciAdi, Y.Parca_ID, P.Isim, Y.Kategori_ID, K.Isim, Y.Muzisyen_ID, M.Isim, Y.Icerik, Y.Tarih, Y.Durum, Y.Kontrol FROM Yorumlar AS Y JOIN Uyeler AS U ON Y.Uye_ID=U.ID JOIN Parcalar AS P ON Y.Parca_ID=P.ID JOIN Kategoriler AS K ON Y.Kategori_ID=K.ID JOIN Muzisyenler AS M ON Y.Muzisyen_ID=M.ID WHERE Y.Uye_ID=@uyeid";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("uyeid", uyeid);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorumlar yorum = new Yorumlar();
                    yorum.ID = reader.GetInt32(0);
                    yorum.Uye_ID = reader.GetInt32(1);
                    yorum.Uye = reader.GetString(2);
                    yorum.Parca_ID = reader.GetInt32(3);
                    yorum.Parca = reader.GetString(4);
                    yorum.Kategori_ID = reader.GetInt32(5);
                    yorum.Kategori = reader.GetString(6);
                    yorum.Muzisyen_ID = reader.GetInt32(7);
                    yorum.Muzisyen = reader.GetString(8);
                    yorum.Icerik = reader.GetString(9);
                    yorum.Tarih = reader.GetDateTime(10);
                    yorum.Durum = reader.GetBoolean(11);
                    yorum.Kontrol = reader.GetBoolean(12);
                    yorumlar.Add(yorum);
                }
                yorumlar.Reverse();
                return yorumlar;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumDurum(int id)
        {
            try
            {
                cmd.CommandText = "SELECT Durum FROM Yorumlar WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                bool durum = Convert.ToBoolean(cmd.ExecuteScalar());
                cmd.CommandText = "UPDATE Yorumlar SET Durum=@durum WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@durum", !durum);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public bool YorumKontrol(int id)
        {
            try
            {
                cmd.CommandText = "UPDATE Yorumlar SET Kontrol=1 WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Bilgi

        public int DurumAdmin(bool Durum)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Adminler WHERE Durum=@Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                con.Open();
                int toplam = Convert.ToInt32(cmd.ExecuteScalar());
                return toplam;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int DurumKategori(bool Durum)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Kategoriler WHERE Durum = @Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                con.Open();
                int toplam = Convert.ToInt32(cmd.ExecuteScalar());
                return toplam;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int DurumMuzisyen(bool Durum)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Muzisyenler WHERE Durum=@Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                con.Open();
                int toplam = Convert.ToInt32(cmd.ExecuteScalar());
                return toplam;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int DurumParca(bool Durum)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Parcalar WHERE Durum=@Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                con.Open();
                int toplam = Convert.ToInt32(cmd.ExecuteScalar());
                return toplam;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int DurumUye(bool Durum)
        {
            try
            {
                List<Uyeler> uyeler = new List<Uyeler>();
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Durum=@Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                con.Open();
                int toplam = Convert.ToInt32(cmd.ExecuteScalar());
                return toplam;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        public int DurumYorum(bool Durum)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yorumlar WHERE Durum=@Durum";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Durum", Durum);
                con.Open();
                int toplam = Convert.ToInt32(cmd.ExecuteScalar());
                return toplam;
            }
            catch
            {
                return 0;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #endregion
    }
}
