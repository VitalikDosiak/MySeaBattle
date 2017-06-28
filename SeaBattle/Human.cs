using System;

namespace SeaBattle
{
    public class Human : Player
    {
        public Human() { }
        private Field strategyField = new Field();
        public Human(Field myField, Field opponentField) 
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
        protected Field temp;
        override public void setMyDesk()
        {

            for (int i = 0; i < myShips.Length; ++i)
            {
                move(ref myShips[i]);
            }
            Console.WriteLine("finished setting your field!");
            //my.printSea();
        }
        override public  void attack()
        {
            strategyField.printSea();
            Console.WriteLine();
            my.printSea();
            bool notCheck=true;
            //strategyField.printSea();
            while (notCheck)
            {
                int tempSymbol = strategyField.getCell(0, 0);
                point tempHead = new point(0, 0);
                point head = new point(0, 0);
                strategyField.setCell(tempHead.x, tempHead.y, 9);
                
                while (true)
                {
                    var check = Console.ReadKey();
                    Console.Clear();

                    switch (check.Key)
                    {
                        case ConsoleKey.D:
                            {
                                if (tempHead.y + 1 < 10)
                                {
                                    strategyField.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = strategyField.getCell(tempHead.x, tempHead.y + 1);
                                    tempHead.y = tempHead.y + 1;
                                    strategyField.setCell(tempHead.x, tempHead.y, 9);
                                }
                                break;
                            }
                        case ConsoleKey.A:
                            {
                                if (tempHead.y - 1 >= 0)
                                {
                                    strategyField.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = strategyField.getCell(tempHead.x, tempHead.y - 1);
                                    tempHead.y = tempHead.y - 1;
                                    strategyField.setCell(tempHead.x, tempHead.y, 9);
                                }
                                break;
                            }
                        case ConsoleKey.W:
                            {
                                if (tempHead.x - 1 >= 0)
                                {
                                    strategyField.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = strategyField.getCell(tempHead.x - 1, tempHead.y);
                                    tempHead.x = tempHead.x - 1;
                                    strategyField.setCell(tempHead.x, tempHead.y, 9);
                                }
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                if (tempHead.x + 1 < 10)
                                {
                                    strategyField.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = strategyField.getCell(tempHead.x + 1, tempHead.y);
                                    tempHead.x = tempHead.x + 1;
                                    strategyField.setCell(tempHead.x, tempHead.y, 9);
                                }
                                break;
                            }

                        case ConsoleKey.F:
                            {
                                strategyField.setCell(tempHead.x, tempHead.y, tempSymbol);
                                if (strategyField.getCell(tempHead.x, tempHead.y) != -1 && strategyField.getCell(tempHead.x, tempHead.y) != -2)
                                {
                                    if (opponent.getCell(tempHead.x, tempHead.y) == 0)
                                    {
                                        strategyField.setCell(tempHead.x, tempHead.y, -1);
                                        return;
                                    }
                                    if (opponent.getCell(tempHead.x, tempHead.y) == 1)
                                    {
                                        strategyField.setCell(tempHead.x, tempHead.y, -2);
                                        opponent.setCell(tempHead.x, tempHead.y, -2);
                                        opponent.count++;
                                        return;
                                    }

                                    tempHead.x = 0;
                                    tempHead.y = 0;
                                    tempSymbol = strategyField.getCell(0, 0);
                                    notCheck = false;
                                }
                                break;

                            }
                    }
                    strategyField.printSea();
                    Console.WriteLine();
                    my.printSea();
                    }
               // strategyField.printSea();
                    
                    if (!notCheck) break;
                }

            }
        private void move(ref Ship argShip)
        {
            
            bool notset=true;
            while (notset)
            {
                int tempSymbol = my.getCell(0, 0);
                point tempHead = new point(0, 0);
                point head = new point(0, 0);
                my.setCell(tempHead.x, tempHead.y, 7);
                
                while (true)
                {
                    var check = Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine("Size of ship=" + argShip.size + " orientation=" + (argShip.orientation == 0 ? "Horizontal" : "Vertical"));
                    switch (check.Key)
                    {
                        case ConsoleKey.D:
                            {
                                if (tempHead.y + 1 < 10)
                                {
                                    my.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = my.getCell(tempHead.x, tempHead.y + 1);
                                    tempHead.y = tempHead.y + 1;
                                    my.setCell(tempHead.x, tempHead.y, 7);
                                }
                                break;
                            }
                        case ConsoleKey.A:
                            {
                                if (tempHead.y - 1 >= 0)
                                {
                                    my.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = my.getCell(tempHead.x, tempHead.y - 1);
                                    tempHead.y = tempHead.y - 1;
                                    my.setCell(tempHead.x, tempHead.y, 7);
                                }
                                break;
                            }
                        case ConsoleKey.W:
                            {
                                if (tempHead.x - 1 >= 0)
                                {
                                    my.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = my.getCell(tempHead.x - 1, tempHead.y);
                                    tempHead.x = tempHead.x - 1;
                                    my.setCell(tempHead.x, tempHead.y, 7);
                                }
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                if (tempHead.x + 1 < 10)
                                {
                                    my.setCell(tempHead.x, tempHead.y, tempSymbol);
                                    tempSymbol = my.getCell(tempHead.x + 1, tempHead.y);
                                    tempHead.x = tempHead.x + 1;
                                    my.setCell(tempHead.x, tempHead.y, 7);
                                }
                                break;
                            }
                        case ConsoleKey.E:
                            {
                                argShip.orientation = argShip.orientation == 0 ? 1 : 0;
                                Console.WriteLine("Size of ship=" + argShip.size + " orientation=" + (argShip.orientation == 0 ? "Horizontal" : "Vertical"));
                                break;
                            }
                        case ConsoleKey.F:
                            {
                                my.setCell(tempHead.x, tempHead.y, tempSymbol);
                                argShip.head.x = tempHead.x;
                                argShip.head.y = tempHead.y;
                                if (my.checkShip(argShip))
                                {
                                    notset = false;
                                    my.setShip(argShip);
                                    tempHead.x = 0;
                                    tempHead.y = 0;
                                    tempSymbol = my.getCell(0, 0);
                                    break;
                                }
                                break;
                            }
                        default: break;
                    }
                    my.printSea();
                    if (!notset) break;
                }

            }
        
        }
       
    }
}
