using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeaBattle
{
    public class Computer : Player
    {
        public Computer(Field myField, Field opponentField) 
        { 
            my = myField; 
            opponent = opponentField;
            myShips = new Ship[10];
            int count=0;
            for (int i = 4; i > 0; --i)
                for (int j = 0; j < 5 - i;++j )
                {
                   
                    myShips[count] = new Ship(i);
                    count++;
                }
        }
        public override void setMyDesk() 
        {
            bool notset = true;
            while (true)
            {
                my.eraseSea();
                for (int i = 0; i < myShips.Length; ++i)
                {
                    Random rnd = new Random();
                    while (notset)
                    {
                        if (i % 2 == 0) myShips[i].orientation = 1; else myShips[i].orientation = 0;
                        myShips[i].head.x = rnd.Next(0, 10);
                        myShips[i].head.y = rnd.Next(0, 10);
                        if (my.checkShip(myShips[i]))
                        {
                            notset = false;
                            my.setShip(myShips[i]);
                            //my.printSea();
                            //Console.WriteLine();
                        }
                    }
                    notset = true;
                }
               // my.printSea();
               // Console.ReadKey();
               // Console.Clear();
                Console.WriteLine("Computer setted his desk!");
                return;
            }
            
        }
        public override void attack()
        {
            Random rnd = new Random();
            int x;
            int y;
            int checkelement;
            while (true)
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
                checkelement = opponent.getCell(x, y);
                if (checkelement == 0 || checkelement == 1)
                {
                    if (checkelement == 0)
                    {
                        opponent.setCell(x, y, -1);
                        return;
                    }
                    if (checkelement == 1)
                    {
                        opponent.setCell(x, y, -2);
                        opponent.count++;
                        return;
                    }
                }
            
            }
        }
    }
}
