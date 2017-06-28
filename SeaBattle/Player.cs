using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattle
{
    public abstract class Player
    {
        protected Player() { }
        protected string name;
        protected Field my;
        protected Field opponent;
        protected Ship[] myShips;
        public abstract void setMyDesk();
        public abstract void attack();
    }
}
