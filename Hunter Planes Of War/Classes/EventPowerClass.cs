using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Hunter_Planes_Of_War.Classes {
    class EventPowerClass {

        public static byte FPDamage = 50;
        public static short FPHealth = 20;
        public static byte SPDamage = 50;
        public static short SPHealth = 20;

        public static void HealthGiveControl(ProgressBar HealthBar, short GiveHealth) {

            double NewValue = GiveHealth;
            double MaximumControl = HealthBar.Value + GiveHealth;
            double MaximumControl_2 = HealthBar.Maximum - MaximumControl;
            if (MaximumControl_2 < 0) {
                NewValue = GiveHealth + MaximumControl_2;
            }
            HealthBar.Value += NewValue;

        }

    }
}
