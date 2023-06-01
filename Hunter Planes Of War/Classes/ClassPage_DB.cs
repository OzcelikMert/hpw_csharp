using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace Hunter_Planes_Of_War.Classes {
    class ClassPage_DB {

     private static string Database_HPW = "db_a426ac_hpw";
     private static MySqlConnection Connect = new MySqlConnection("Server=MYSQL6002.site4now.net;Database="+Database_HPW+";Uid=a426ac_hpw;Pwd=26108920qwe");
     public static string RoomName_Public { get; set; } 

        public static void AddRoom(string RoomName) {
            RoomName_Public = RoomName;
            Connect.Open();
            MySqlCommandBuilder GuardB = new MySqlCommandBuilder();
            string TName = GuardB.QuoteIdentifier(RoomName);
            MySqlCommand AddRoomC1 = new MySqlCommand(null,Connect);
            AddRoomC1.CommandText = "create table " + TName+ " ( " +
                "`RoomAdmin` bool," +
                "`NickName` varchar(20)," +
                "`Health` smallint," +
                "`Energy` tinyint," +
                "`Damage` tinyint," +
                "`Status` tinyint(1)," +
                "`X` tinyint," +
                "`Y` tinyint," +             
                "`NukeX` tinyint," +
                "`NukeY_1` tinyint," +           
                "`PowerNukeX` tinyint," +
                "`PowerNukeY` tinyint" +
                ")";
             AddRoomC1.ExecuteNonQuery();
             Connect.Close();
             UserSortInfo(RoomName);
            
        }

        public static ArrayList RoomsList = new ArrayList();
        public static byte MaxUser { get; set; }

        public static void FindRoom() {
            ArrayList BeforeList = new ArrayList();
            RoomsList.Clear();
            Connect.Open();
            MySqlCommand RoomsListCommand = new MySqlCommand(null,Connect);
            RoomsListCommand.CommandText = "SHOW TABLES";
            MySqlDataReader Reader = RoomsListCommand.ExecuteReader();
            while(Reader.Read()) {
                BeforeList.Add(Reader["Tables_in_" + Database_HPW + ""].ToString());
            }
            Reader.Close();
            for (int i = 0; i < BeforeList.Count; i++) {
                MySqlCommand AddArrayListItemControl = new MySqlCommand(null, Connect);
                MySqlCommandBuilder TableNameConverter = new MySqlCommandBuilder();
                string TableName = TableNameConverter.QuoteIdentifier(BeforeList[i].ToString());
                AddArrayListItemControl.CommandText = "select count(*) as Sort from " + TableName + "";
                byte Sort = Convert.ToByte(AddArrayListItemControl.ExecuteScalar());
                if (Sort > 0 && Sort < MaxUser) {
                    RoomsList.Add(BeforeList[i].ToString());
                }
            }
            Connect.Close();

        }

        public static byte UserSortValue = 0;
        public static byte X_Sort { get; set; }
        public static byte Y_Sort { get; set; }
        public static byte X_2_Sort { get; set; }
        public static byte Y_2_Sort { get; set; }
        public static void UserSortInfo(string RoomName) {

            Connect.Open();
            MySqlCommand SortInfo = new MySqlCommand(null,Connect);
            MySqlCommandBuilder TableNameConverter = new MySqlCommandBuilder();
            string TableName = TableNameConverter.QuoteIdentifier(RoomName);
            SortInfo.CommandText = "select count(*) as UserSort from "+TableName+"";
            byte Sort = Convert.ToByte(SortInfo.ExecuteScalar());
            if (Sort == 0) {
                UserSortValue = 1;
                X_Sort = 2;
                Y_Sort = 6;
            } else if (Sort == 1){
                UserSortValue = 2;
                X_Sort = 39;
                Y_Sort = 6;
            } else {
                ;
            }
            Connect.Close();
            UserAddtoRoom(UserSortValue, RoomName);

        }

        public static void UserAddtoRoom(byte UserSort, string RoomName) {

            bool RoomAut = false;
            ClassPage_DB_2.UserInfo(ClassPage_DB_2.Username, ClassPage_DB_2.Userpw);
            Connect.Open();
            MySqlCommand AddtoRoom = new MySqlCommand(null, Connect);
            MySqlCommandBuilder TableNameConverter = new MySqlCommandBuilder();
            string TableName = TableNameConverter.QuoteIdentifier(RoomName);
            AddtoRoom.CommandText = "insert into "+TableName+" " +  
            "values " +
            "(@Stat,@Admin,@Name, @HP, @Energy, @DMG, @X, @Y, @NX, @NY, @PNX, @PNY)";
            AddtoRoom.Parameters.AddWithValue("@Stat", 2);
            AddtoRoom.Parameters.AddWithValue("@Admin", RoomAut);
            AddtoRoom.Parameters.AddWithValue("@Name", ClassPage_DB_2.NickName);
            AddtoRoom.Parameters.AddWithValue("@HP", ClassPage_DB_2.PlayerHealth);
            AddtoRoom.Parameters.AddWithValue("@Energy", ClassPage_DB_2.PlayerEnergy);
            AddtoRoom.Parameters.AddWithValue("@DMG", ClassPage_DB_2.PlayerDamage);
            AddtoRoom.Parameters.AddWithValue("@X", X_Sort);
            AddtoRoom.Parameters.AddWithValue("@Y", Y_Sort);
            AddtoRoom.Parameters.AddWithValue("@NX", X_Sort);
            AddtoRoom.Parameters.AddWithValue("@NY", Y_Sort);
            AddtoRoom.Parameters.AddWithValue("@PNY", X_Sort);
            AddtoRoom.Parameters.AddWithValue("@PNX", Y_Sort);
            AddtoRoom.ExecuteNonQuery();
            Connect.Close();
            ClassPage_2.TittleText = "Online Oyun Modu - Oda Adı: " + RoomName_Public;
          
        }














       public static void UserKicktoRoom(byte UserSort, string RoomName) {

            Connect.Open();
            MySqlCommand AddtoRoom = new MySqlCommand(null, Connect);
            MySqlCommandBuilder TableNameConverter = new MySqlCommandBuilder();
            string TableName = TableNameConverter.QuoteIdentifier(RoomName);
            AddtoRoom.CommandText = "update " + TableName + " set " +
            "Health_" + UserSort.ToString() + " = @HP, Energy_" + UserSort.ToString() + " = @Energy, Damage_" + UserSort.ToString() + " = @DMG, X_" + UserSort.ToString() + " = @X," +
            " Y_" + UserSort.ToString() + " = @Y, CanvasX_" + UserSort.ToString() + " = @CX, CanvasY_" + UserSort.ToString() + " = @CY, NukeX_" + UserSort.ToString() + " = @NX," +
            " NukeY_" + UserSort.ToString() + " = @NY, NukeCanvasX_" + UserSort.ToString() + " = @NCX, NukeCanvasY_" + UserSort.ToString() + " = @NCY, PowerNukeX_" + UserSort.ToString() + " = @PNX," +
            " PowerNukeY_" + UserSort.ToString() + " = @PNY, PowerNukeCanvasX_" + UserSort.ToString() + " = @PNCX, PowerNukeCanvasY_" + UserSort.ToString() + " = @PNCY";
            AddtoRoom.Parameters.AddWithValue("@HP", 0);
            AddtoRoom.Parameters.AddWithValue("@Energy", 0);
            AddtoRoom.Parameters.AddWithValue("@DMG", 0);
            AddtoRoom.Parameters.AddWithValue("@X", 0);
            AddtoRoom.Parameters.AddWithValue("@Y", 0);
            AddtoRoom.Parameters.AddWithValue("@CX", 0);
            AddtoRoom.Parameters.AddWithValue("@CY", 0);
            AddtoRoom.Parameters.AddWithValue("@NX", 0);
            AddtoRoom.Parameters.AddWithValue("@NY", 0);
            AddtoRoom.Parameters.AddWithValue("@NCX", 0);
            AddtoRoom.Parameters.AddWithValue("@NCY", 0);
            AddtoRoom.Parameters.AddWithValue("@PNY", 0);
            AddtoRoom.Parameters.AddWithValue("@PNX", 0);
            AddtoRoom.Parameters.AddWithValue("@PNCX", 0);
            AddtoRoom.Parameters.AddWithValue("@PNCY", 0);
            AddtoRoom.ExecuteNonQuery();
            Connect.Close();

        }

        public static void DBSettings(bool OpCl) {

            if (OpCl) {
                Connect.Open();
            } else if (!OpCl) {
                Connect.Close();
            }

        }

    }
}
