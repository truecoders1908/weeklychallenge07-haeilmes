using System;
using System.Collections.Generic;
using System.Linq;

namespace weeklyChallenges07
{
    public class ChallengesSet07
    {

        public int CountOfBusinessesWithNegativeNetProfit(List<Business> businesses)
        {
            int num = 0;

            if (businesses == null)
                return 0;

            foreach (Business business in businesses)
            {
                if (business.TotalRevenue < business.TotalExpenses)
                    num++;
            }

            return num;
        }

        public string GetCommaSeparatedListOfProfitableBusinesses(List<Business> businesses)
        {
            if (businesses == null)
                return "";

            string profitableBuisnesses = "";

            foreach (Business business in businesses)
            {
                if (business.TotalRevenue > business.TotalExpenses)
                {
                    profitableBuisnesses += $"{business.Name},";
                }
            }

            return profitableBuisnesses.Trim(',');
        }

        public string GetNameOfHighestParentCompany(Business business)
        {
            string parent = business.Name;

            while (business.ParentCompany != null)
            {
                parent = business.ParentCompany.Name;
                business = business.ParentCompany;
            }

            return parent;
        }

        public enum TicTacToeResult { X, O, Draw }

        public TicTacToeResult GetTicTacToeWinner(char[,] finalBoard)
        {
            if (checkWinner(finalBoard[0, 0], finalBoard[1, 1], finalBoard[2, 2]) || checkWinner(finalBoard[0, 2], finalBoard[1, 1], finalBoard[2, 0]))
            {
                return returnWinner(finalBoard[1, 1]);
            }

            for (int i = 0; i < finalBoard.GetLength(0); i++)
            {
                if (checkWinner(finalBoard[i, 0], finalBoard[i, 1], finalBoard[i, 2]))
                {
                    return returnWinner(finalBoard[i, 0]);
                }

                else if (checkWinner(finalBoard[0, i], finalBoard[1, i], finalBoard[2, i]))
                {
                    return returnWinner(finalBoard[0, i]);
                }
            }

            return TicTacToeResult.Draw;
        }

        private bool checkWinner(char a, char b, char c)
        {
            return (a == b && b == c);
        }

        private TicTacToeResult returnWinner(char c)
        {
            if (c == 'X')
            {
                return TicTacToeResult.X;
            }

            else
            {
                return TicTacToeResult.O;
            }
        }

        public bool EachArrayInJaggedArrayContainsTargetNumber(int[][] numbers, int targetNumber)
        {
            if (numbers == null || numbers.Length == 0)
            {
                return false;
            }

            bool hasTarget = true;

            foreach (int[] nums in numbers)
            {
                if (!nums.Contains(targetNumber))
                {
                    hasTarget = false;
                }
            }
            return hasTarget;
        }

    }

}

