using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI.WebControls;
using System.Runtime.CompilerServices;

namespace Store
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection myCon = new SqlConnection();
        DataSet dsAlbume = new DataSet();
        DataSet dsCantece = new DataSet();
        public WebService1()
        {

            myCon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Ciceu\OneDrive\Desktop\AN 3\sem2\informatica industriala\Vinyl Store\Vinyl Store\MusicStore.mdf;Integrated Security=True";
            myCon.Open();
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World!";

        }
        [WebMethod]
        public DataSet GetAlbums()
        {
            SqlDataAdapter daAlbume = new SqlDataAdapter("SELECT * FROM ALBUME", myCon);
            daAlbume.Fill(dsAlbume, "Albume");
            return dsAlbume;

        }
        [WebMethod]
        public DataSet GetSongs()
        {
            SqlDataAdapter daCantece = new SqlDataAdapter("SELECT * FROM CANTECE", myCon);
            daCantece.Fill(dsCantece, "Cantece");
            return dsCantece;
        }
        [WebMethod]
        public void AddAlbums(int Id_Album, string NumeAlbum, string CuloareCd)
        {
            try
            {
 
                SqlCommand command = new SqlCommand("INSERT INTO ALBUME (Id_Album, NumeAlbum, CuloareCd) VALUES (@Id_Album, @NumeAlbum, @CuloareCd)", myCon);

                command.Parameters.Add("@Id_Album", SqlDbType.Int).Value = Id_Album;
                command.Parameters.Add("@NumeAlbum", SqlDbType.Text).Value = NumeAlbum;
                command.Parameters.Add("@CuloareCd", SqlDbType.Text).Value = CuloareCd;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;

            }
            myCon.Close();

        }
        [WebMethod]
        public void AddSongs(int Id_Cantec, string TitluCantec, string Album)
        {
            try
            {
              
                SqlCommand command = new SqlCommand("INSERT INTO CANTECE (Id_Cantec, TitluCantec,Album) VALUES (@Id_Cantec, @TitluCantec, @Album)", myCon);

                command.Parameters.Add("@Id_Cantec", SqlDbType.Int).Value = Id_Cantec;
                command.Parameters.Add("@TitluCantec", SqlDbType.Text).Value = TitluCantec;
                command.Parameters.Add("@Album", SqlDbType.Text).Value = Album;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            myCon.Close();

        }
        [WebMethod]
        public void DeleteAlbum(int Id_Album)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM ALBUME WHERE Id_Album=@Id_Album", myCon);
                command.Parameters.Add("@Id_Album", SqlDbType.Int).Value = Id_Album;
                command.ExecuteNonQuery();
            }catch(Exception ex)
            {
                throw ex;
            }
            myCon.Close();


        }
        [WebMethod]
        public void DeleteSong(int Id_Cantec)
        {
            try
            {
                SqlCommand command = new SqlCommand("DELETE FROM CANTECE WHERE Id_Cantec=@Id_Cantec", myCon);
                command.Parameters.Add("@Id_Cantec", SqlDbType.Int).Value = Id_Cantec;
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            myCon.Close();


        }
        
    }
}
