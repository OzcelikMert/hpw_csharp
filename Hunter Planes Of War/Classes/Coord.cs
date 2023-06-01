using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_Planes_Of_War.Classes {
    class Coord {

        private byte x = 0;
        private byte y = 0;
        public Coord(byte x, byte y) { this.x = x; this.y = y; }
        public byte X { get { return x; } set { x = value; } }
        public byte Y { get { return y; } set { y = value; } }
        public double CanvasX { get { return x * 17; } }
        public double CanvasY { get { return y * 30; } }

    }
}
