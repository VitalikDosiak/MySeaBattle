using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace SeaBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            Field first = new Field();
            Field second=new Field();
            Player gamer = new Human(first, second);
            Player comp = new Computer(second, first);
            comp.setMyDesk();
            gamer.setMyDesk();
            while (true)
            {
                
                gamer.attack();
                if (second.count == 20) { Console.WriteLine("Human win!"); second.printSea(); first.printSea(); Console.ReadKey(); return; }
                comp.attack();
                if (first.count == 20) { Console.WriteLine("Computer win!"); second.printSea(); first.printSea(); Console.ReadKey(); return; }
            }
           // gamer.setMyDesk();
            Console.ReadKey();
        }
    }
}