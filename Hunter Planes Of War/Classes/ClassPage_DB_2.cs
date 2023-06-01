using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Hunter_Planes_Of_War.Classes {
    class ClassPage_DB_2 {

        private static string Database_HPW = "db_a426ac_hpw";
        private static MySqlConnection Connect = new MySqlConnection("Server=MYSQL6002.site4now.net;Database=" + Database_HPW + ";Uid=a426ac_hpw;Pwd=26108920qwe");
        public static bool UserConnect { get; set; }
        public static string Username  { get; set; }
        public static string Userpw { get; set; }

        public static void LoginControl(string userName, string userPW) {

            Connect.Open();
            MySqlCommand LookCMD = new MySqlCommand(null,Connect);
            LookCMD.CommandText = "select * from saved_users where Account_Name = @UserN and userPw = @UserP";
            LookCMD.Parameters.AddWithValue("@UserN", userName);
            LookCMD.Parameters.AddWithValue("@UserP", userPW);
            MySqlDataReader userValuesReader = LookCMD.ExecuteReader();
            if (userValuesReader.Read()) {

                UserConnect = true;
                Username = userName;
                Userpw = userPW;
                Connect.Close();
                UserInfo(Username,Userpw);

            } else {

                UserConnect = false;
                Connect.Close();

            }
           
        }

        public static void UserInfo(string userName, string userPW) {

            Connect.Open();
            MySqlCommand LookInfoCMD = new MySqlCommand(null, Connect);
            LookInfoCMD.CommandText = "select * from saved_users where Account_Name = @UserN and userPw = @UserP";
            LookInfoCMD.Parameters.AddWithValue("@UserN", userName);
            LookInfoCMD.Parameters.AddWithValue("@UserP", userPW);
            MySqlDataReader userValuesReader = LookInfoCMD.ExecuteReader();
            if (userValuesReader.Read()) {

                NickName = userValuesReader["NickName"].ToString();
                PlayerDamage = Convert.ToByte(userValuesReader["Damage"]);
                PlayerHealth = Convert.ToInt16(userValuesReader["Health"]);
                PlayerEnergy = Convert.ToByte(userValuesReader["Energy"]);
                Gold = Convert.ToInt64(userValuesReader["gold"]);
                PC = Convert.ToInt64(userValuesReader["PitirCoin"]);
                Ranks = Convert.ToByte(userValuesReader["ranks"]);
                RankExp = Convert.ToInt32(userValuesReader["ranksExp"]);
                Matchs = Convert.ToInt32(userValuesReader["user_Match"]);
                WinMatch = Convert.ToInt32(userValuesReader["userWin_Match"]);
                LostMatch = Convert.ToInt32(userValuesReader["userLost_Match"]);
                StartTimeValue = 3;

            } else {
                ;
            }
            Connect.Close();
        }

        public static string NickName { get; set; }
        public static long Gold { get; set; }
        public static long PC { get; set; }
        public static byte Ranks { get; set; }
        public static int RankExp { get; set; }
        public static int LostMatch { get; set; }
        public static int WinMatch { get; set; }
        public static int Matchs { get; set; }
        public static byte PlayerDamage { get; set; }
        public static short PlayerHealth { get; set; }
        public static byte PlayerEnergy { get; set; }
        public static sbyte StartTimeValue { get; set; }

        public static void DBSettings(bool OpCl) {

            if (OpCl) {
                Connect.Open();
            } else if (!OpCl) {
                Connect.Close();
            }

        }




    }
}
