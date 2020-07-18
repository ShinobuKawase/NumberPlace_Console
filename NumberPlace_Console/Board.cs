using System;

namespace NumberPlace_Console
{
    public class Board
    {
        const int matrixSize = 9;
        const int blockSize = 3;
        const int emptyNumber = 0;
        const int maxSuccess = 16;

        bool crossCheck;
        int successCount;
        int[,] matrix;
        System.Text.StringBuilder boarderLine;


        public Board()
        {
            crossCheck = false;
            successCount = 0;

            matrix = new int[matrixSize, matrixSize];

            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix[i, j] = emptyNumber;
                }

            }

            boarderLine = new System.Text.StringBuilder();
            boarderLine.Clear();
            boarderLine.Append("  ");
            for (int i = 0; i < matrixSize; i++)
            {
                if (i != 0 && i % blockSize == 0)
                {
                    boarderLine.Append("-+");
                }
                boarderLine.Append("--");
            }
            boarderLine.Append("-");
        }



        public int GetMatrixSize()
        {
            return matrixSize;
        }

        public int GetBlockSize()
        {
            return blockSize;
        }

        public int GetSuccessCount()
        {
            return successCount;
        }


        public void CrossCheckOn()
        {
            crossCheck = true;
        }

        public void CrossCheckOff()
        {
            crossCheck = false;
        }


        public int GetNumber(int i, int j)
        {
            return matrix[i, j];
        }

        public int GetNumber(Location loc)
        {
            return GetNumber(loc.GetX(), loc.GetY());
        }


        public void SetNumber(int i, int j, int n)
        {
            matrix[i, j] = n;
        }

        public void SetNumber(Location loc, int n)
        {
            SetNumber(loc.GetX(), loc.GetY(), n);
        }


        public void ClearNumber(int i, int j)
        {
            matrix[i, j] = emptyNumber;
        }

        public void ClearNumber(Location loc)
        {
            ClearNumber(loc.GetX(), loc.GetY());
        }


        public void SetNumbers(int i, params int[] mx)
        { 
            for (int j = 0; j < mx.Length && j < matrixSize; j++)
            {
                SetNumber(i, j, mx[j]);
            }
        }

        public bool SearchEmptyLocation(Location loc)
        {
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = 0; j < matrixSize; j++)
                {
                    if (matrix[i, j] == emptyNumber)
                    {
                        loc.SetXY(i, j);
                        return true;
                    }
                }
            }

            return false;
        }

        public bool CheckSingleNumber(int i, int j, int n)
        {
            for (int k = 0; k < matrixSize; k++)
            {
                if (matrix[i, k] == n || matrix[k, j] == n)
                {
                    return false;
                }
            }

            int iB = (i / blockSize) * blockSize;
            for (int k = 0; k < blockSize; k++, iB++)
            {
                int jB = (j / blockSize) * blockSize;
                for (int l = 0; l < blockSize; l++, jB++)
                {
                    if (matrix[iB, jB] == n)
                    {
                        return false;
                    }
                }
            }

            if (crossCheck)
            {
                if (i == j)
                {
                    for (int k = 0; k < matrixSize; k++)
                    {
                        if (matrix[k, k] == n)
                        {
                            return false;
                        }

                    }
                }

                int l = matrixSize - 1;
                if (i + j == l)
                {
                    for (int k = 0; k < matrixSize; k++, l--)
                    {
                        if (matrix[k, l] == n)
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        public bool CheckSingleNumber(Location loc, int n)
        {
            return CheckSingleNumber(loc.GetX(), loc.GetY(), n);
        }


        public Boolean FillNumber()
        {
            var loc = new Location();

            if (SearchEmptyLocation(loc) == false)
            {
                successCount++;
                var msg = new System.Text.StringBuilder();
                msg.AppendFormat("Success No.{0} !!", successCount);
                PrintBoard(msg);
                if (successCount >= maxSuccess)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            for( int n = 1; n <= matrixSize; n++)
            {
                if(CheckSingleNumber(loc, n))
                {
                    SetNumber(loc, n);
                    if (FillNumber())
                    {
                        return true;
                    }
                    ClearNumber(loc);
                }
            }

            return false;
        }


        public void PrintBoard(System.Text.StringBuilder msg)
        {
            var numberLine = new System.Text.StringBuilder();

            Console.WriteLine(msg);
            for(int i = 0; i < matrixSize; i++)
            {
                numberLine.Clear();
                numberLine.Append("  ");
                for(int j = 0; j < matrixSize; j++)
                {
                    if(j != 0 && j % blockSize == 0)
                    {
                        numberLine.Append(" |");
                    }
                    numberLine.Append(" ");
                    numberLine.Append(matrix[i, j]);
                }
                if(i != 0 && i % blockSize == 0)
                {
                    Console.WriteLine(boarderLine);
                }
                Console.WriteLine(numberLine);
            }
            Console.WriteLine(" ");
        }

        public void PrintBoard( string msg)
        {
            var sbMsg = new System.Text.StringBuilder();

            sbMsg.Append(msg);
            PrintBoard(sbMsg);
        }

        public void PrintBoard()
        {
            PrintBoard(" ");
        }
    }


    public class Location
    {
        int x;
        int y;

        public Location()
        {
            x = 0;
            y = 0;
        }

        public void SetXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int GetX()
        {
            return this.x;
        }

        public int GetY()
        {
            return this.y;
        }
    }


}
