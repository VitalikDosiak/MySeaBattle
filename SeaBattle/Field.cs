using System;

namespace SeaBattle
{
    public class Field
    {
        public Field() { sea = new int[10, 10]; }
        public int count = 0;
        private int[,] sea;
        public void eraseSea() 
        { 
            for(int i=0;i<10;++i)
                for (int j = 0; j < 10; ++j)
                {
                    sea[i, j] = 0;
                }
        }
        public void setCell(int x, int y, int arg) { sea[x, y] = arg; }
        public int getCell(int x, int y) { return sea[x, y]; }
        public bool isEmpty(int x, int y) { return sea[x, y] == 0; }
        public bool checkShip(Ship argShip) 
        {
            if (argShip.head.x > 9 || argShip.head.x < 0 || argShip.head.y > 9 || argShip.head.y < 0) return false;
            //check for free space
            if (argShip.orientation == 0) 
            { 
                if (argShip.head.y + argShip.size>10) return false;
                for (int i = 0; i < argShip.size;++i )
                {
                    if (sea[argShip.head.x, argShip.head.y + i] !=0) { return false; }
                }
                //check under and on
                
                {
                    for (int i = argShip.head.y; i < argShip.head.y + argShip.size; ++i)
                    {
                        if (argShip.head.x + 1 < 10)
                        if (sea[argShip.head.x + 1, i] != 0) return false;
                        if (argShip.head.x-1>=0)
                        if (sea[argShip.head.x - 1, i] != 0) return false;
                    }
                
                //check front back
                    for (int i = argShip.head.x - 1; i <= argShip.head.x + 1; ++i)
                    {
                        if (i >= 0  &&i < 10&& argShip.head.y - 1 >= 0) 
                        if (sea[i, argShip.head.y - 1] != 0) return false;
                        
                        if (i >= 0 && i < 10 && argShip.head.y + argShip.size < 10)
                        if (sea[i, argShip.head.y + argShip.size] != 0) return false;  
                    }
                }

                return true;
            }
            
            if (argShip.orientation == 1)
            {
                if (argShip.head.x + argShip.size > 10) return false;
                for (int i = 0; i < argShip.size; ++i)
                {
                    if (sea[argShip.head.x+i, argShip.head.y] != 0) { return false; }
                }
                //check left and right
                {
                    for (int i = argShip.head.x; i < argShip.head.x + argShip.size; ++i)
                    {
                        if(argShip.head.y - 1 >= 0)
                        if (sea[i,argShip.head.y - 1] != 0)return false;
                        if (argShip.head.y + 1 < 10)
                        if( sea[i,argShip.head.y + 1] != 0) return false;
                    }
                    for (int i = argShip.head.y - 1; i <= argShip.head.y + 1; ++i)
                    {
                        if (i >= 0 && i < 10 && argShip.head.x - 1 >= 0)
                            if (sea[ argShip.head.x - 1,i] != 0) return false;

                        if (i >= 0 && i < 10 && argShip.head.x + argShip.size < 10)
                            if (sea[ argShip.head.x + argShip.size,i] != 0) return false;
                    }
                }
                return true;
            }

            return true;
        }
        public void setShip(Ship argShip) 
        {
            if (checkShip(argShip))
            {
                if (argShip.orientation == 0)
                {
                    for (int i = argShip.head.y; i < argShip.head.y + argShip.size; ++i)
                    {
                        sea[argShip.head.x, i] = 1;
                    }
                }
                else
                    for (int i = argShip.head.x; i < argShip.head.x + argShip.size; ++i)
                    {
                        sea[i, argShip.head.y] = 1;
                    }
            }
        }
        public void printSea()
        {
            Console.Write("  ");
            for (int i = 0; i < 10; ++i)
                Console.Write(i + " ");
            Console.WriteLine();
            for (int i = 0; i < 10; ++i)
            {
                Console.Write(i+"");
                for (int j = 0; j < 10; ++j)
                {
                    
                    if (sea[i, j] == 0)
                    {
                        Console.ForegroundColor= ConsoleColor.DarkBlue;
                        Console.Write("▒▓");
                        Console.ResetColor();
                    }
                    if (sea[i, j] == 1) 
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("[]");
                        Console.ResetColor(); 
                    }
                    if (sea[i, j] == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("[]");
                        Console.ResetColor();
                    }
                    if (sea[i, j] == 9)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("[]");
                        Console.ResetColor();
                    }
                    if (sea[i, j] == -1)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("oo");
                        Console.ResetColor();
                    }
                    if (sea[i, j] == -2)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[]");
                        Console.ResetColor();
                    }
                }
                Console.WriteLine();  
            }
        }
    }
}
