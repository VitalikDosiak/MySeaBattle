using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattle
{
    public struct point {
        public point(int argX, int argY) { x = argX; y = argY; }
        public int x;
        public int y;
    }
    public class Ship
    {
       public  Ship(int argSize) { orientation = 0; size = argSize; head = new point(); }
        public Ship(int argSize, int argOrientation, int argX, int argY) { 
            size = argSize; 
            orientation = argOrientation;
            head = new point(argX, argY); 
        }
        //horizontal = 0;
        //vertical = 1;
        public point head;
        public int orientation { get; set; }
        public int size { get; set; }
    }
}
