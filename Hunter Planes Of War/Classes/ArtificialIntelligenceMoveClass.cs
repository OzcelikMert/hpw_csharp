using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_Planes_Of_War.Classes {
    class ArtificialIntelligenceMoveClass {

        public static ArrayList Down_Up = new ArrayList();
        static Random Random_Value = new Random();
        public static string Down_Up_Value { get; set; }

         public static void Moving() {

            byte New_Random_Value = Convert.ToByte(Random_Value.Next(0, 8));
            Down_Up_Value = Down_Up[New_Random_Value].ToString();
         }

        }
    }
