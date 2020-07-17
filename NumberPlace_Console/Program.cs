using System;

namespace NumberPlace_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Number Place Console Version");

            Board testBoard = new Board();

			/*
			testBoard.SetNumbers(0,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(1,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(2,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(3,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(4,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(5,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(6,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(7,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(8,  0, 0, 0, 0, 0, 0, 0, 0, 0 );	
			*/

			
			testBoard.SetNumbers(0,  9, 0, 0, 3, 2, 0, 0, 7, 0 );
			testBoard.SetNumbers(1,  0, 0, 0, 0, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(2,  0, 0, 0, 0, 1, 0, 2, 0, 0 );
			testBoard.SetNumbers(3,  0, 0, 0, 8, 0, 5, 4, 0, 0 );
			testBoard.SetNumbers(4,  0, 8, 0, 7, 0, 0, 0, 0, 0 );
			testBoard.SetNumbers(5,  3, 0, 5, 0, 0, 0, 0, 0, 7 );
			testBoard.SetNumbers(6,  7, 0, 0, 0, 0, 2, 6, 3, 0 );
			testBoard.SetNumbers(7,  0, 9, 0, 0, 0, 0, 0, 8, 0 );
			testBoard.SetNumbers(8,  1, 0, 6, 0, 0, 7, 0, 4, 0 );	
			

			/*
			testBoard.SetNumbers(0,  0, 0, 0, 0, 0, 0, 0, 8, 7);
			testBoard.SetNumbers(1,  0, 0, 0, 0, 0, 0, 0, 0, 0);
			testBoard.SetNumbers(2,  0, 0, 1, 2, 3, 0, 0, 0, 0);
			testBoard.SetNumbers(3,  0, 0, 2, 0, 0, 4, 0, 0, 0);
			testBoard.SetNumbers(4,  0, 0, 3, 0, 0, 0, 5, 0, 0);
			testBoard.SetNumbers(5,  0, 0, 0, 8, 0, 5, 0, 6, 0);
			testBoard.SetNumbers(6,  0, 0, 0, 0, 1, 0, 3, 0, 0);
			testBoard.SetNumbers(7,  8, 0, 0, 0, 0, 7, 0, 0, 0);
			testBoard.SetNumbers(8,  6, 0, 0, 0, 0, 0, 0, 0, 0);
			*/

			/*
			testBoard.SetNumbers(0,  4, 0, 0, 1 );
			testBoard.SetNumbers(1,  0, 3, 0, 0 );
			testBoard.SetNumbers(2,  0, 0, 0, 0 );
			testBoard.SetNumbers(3,  3, 0, 0, 0 );
			*/

			testBoard.PrintBoard();


			testBoard.CrossCheckOff();

			testBoard.FillNumber();

		
			if (testBoard.GetSuccessCount() == 1)
			{
				Console.WriteLine("Complete Number Place !!");
			}
			else if (testBoard.GetSuccessCount() > 1)
			{
				Console.WriteLine("Too Many Answer !!");
			}
			else
			{
				Console.WriteLine("No Answer");
			}

			testBoard.PrintBoard();


		}
	}
}
