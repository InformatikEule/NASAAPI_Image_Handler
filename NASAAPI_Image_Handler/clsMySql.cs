using MySql.Data;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls.Crypto;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

namespace NASAAPI_Image_Handler
{
    //class clsMySql { 
    //    public void returnSecrets
    //    {
    //        string server = "localhost";
    //        string db = "test";
    //        string user = "root";
    //        string pw = "";
    //        string conn = string.Format("server={0};db={1};user={2};password={3}", server, db, user, password);
    //    }
    //}
    //class clsMySql
    //{
    //    public MySqlConnection conn;
    //    public void connect()
    //    {
    //        string server = "localhost";
    //        string db = "test";
    //        string user = "root";
    //        string pw = "";
    //        string connString = string.Format("server={0};db={1};user={2};password={3}", server, db, user, pw);


    //        conn = new MySqlConnection(connString);
    //        try
    //        {
    //            conn.Open();
    //        }
    //        catch (Exception e)
    //        {
    //            MessageBox.Show("Error opening MySQL Connection: " + e);
    //        }
    //    }
    //}
}


        //public static SqlConnection? conn;
        //public void OpenSqlConnection()
        //{
        //    try
        //    {
        //        string connString = clsSecrets.returnSecrets(); // remove the part behind the = and replace it with your own connection string!
        //        conn = new SqlConnection(connString);
        //        conn.Open();
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show("Error opening SQL Connection: " + e);
        //    }
        //}
