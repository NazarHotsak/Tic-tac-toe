using System;
using System.Collections.Generic;

namespace tic_tac_toe 
{
    class Computer
    {
        char computer;

        char player;


        public int ComputerTapIndexOfMove(char[] field, bool turn)
        {
            List<int> moves = new List<int>();
            List<int> movesDraw = new List<int>();

            computer = turn ? 'X' : 'O';

            player = turn ? 'O' : 'X';

            for (int numberOfBoard = 0; numberOfBoard < 9; numberOfBoard++)
            {
                if (field[numberOfBoard] == '\0')
                {
                    field[numberOfBoard] = computer;

                    int score = Minimax(field, player);

                    if (score == 10)
                    {
                        moves.Add(numberOfBoard);
                    }
                    if (score == 0)
                    {
                        movesDraw.Add(numberOfBoard);
                    }

                    field[numberOfBoard] = '\0';
                }
            }



            Random random = new Random();

            if (moves.Count > 0)
            {
                int s = random.Next(0, moves.Count);
                return moves[s];
            }
            if (movesDraw.Count > 0)
            {
                int s = random.Next(0, movesDraw.Count);
                return movesDraw[s];
            }

            return 1000;
        }



        private int Minimax(char[] field, char playNow)
        {
            if (Winning(ref field, computer))
            {
                return 10;
            }
            else if (Winning(ref field, player))
            {
                return -10;
            }
            else if (Draw(ref field))
            {
                return 0;
            }

            int[] score = new int[8];
            byte countScore = 0;


            if (playNow == computer)
            {
                for (int numberOfBoard = 0; numberOfBoard < 9; numberOfBoard++)
                {
                    if (field[numberOfBoard] == '\0')
                    {
                        field[numberOfBoard] = computer;

                        score[countScore] = Minimax(field, player);
                        countScore++;

                        field[numberOfBoard] = '\0';
                    }
                }
            }


            if (playNow == player)
            {
                for (int numberOfBoard = 0; numberOfBoard < 9; numberOfBoard++)
                {
                    if (field[numberOfBoard] == '\0')
                    {
                        field[numberOfBoard] = player;

                        score[countScore] = Minimax(field, computer);
                        countScore++;

                        field[numberOfBoard] = '\0';
                    }
                }
            }


            if (playNow == computer)
            {
                int maxItem = -100;
                for (int index = 0; index < countScore; index++)
                {
                    if (maxItem < score[index])
                    {
                        maxItem = score[index];
                    }
                }
                return maxItem;
            }


            if (playNow == player)
            {
                int minItem = 100;
                for (int index = 0; index < countScore; index++)
                {
                    if (minItem > score[index])
                    {
                        minItem = score[index];
                    }
                }
                return minItem;
            }


            throw new Exception("What is it");
        }

        private bool Draw(ref char[] board)
        {
            for (int numberOfBoard = 0; numberOfBoard < 9; numberOfBoard++)
            {
                if (board[numberOfBoard] == '\0')
                {
                    return false;
                }
            }
            return true;
        }

        private bool Winning(ref char[] board, char player)
        {
            if ((board[0] == player && board[1] == player && board[2] == player) ||
                (board[3] == player && board[4] == player && board[5] == player) ||
                (board[6] == player && board[7] == player && board[8] == player) ||
                (board[0] == player && board[3] == player && board[6] == player) ||
                (board[1] == player && board[4] == player && board[7] == player) ||
                (board[2] == player && board[5] == player && board[8] == player) ||
                (board[0] == player && board[4] == player && board[8] == player) ||
                (board[2] == player && board[4] == player && board[6] == player))
            {
                return true;
            }
            return false;
        }
    }
}










