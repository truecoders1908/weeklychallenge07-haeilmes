using System;
using System.Collections.Generic;

using Xunit;

namespace weeklyChallenges07.Tests
{
    public class ChallengesSet07Tests
    {

        [Theory]
        [InlineData(new double[] { 100, 100, 100 }, new double[] { 95, 90, 80 }, 0)]
        [InlineData(new double[] { 100, 100, 100 }, new double[] { 95, 110, 120 }, 2)]
        [InlineData(new double[] { 100 }, new double[] { 90 }, 0)]
        [InlineData(new double[] { 100 }, new double[] { 110 }, 1)]
        [InlineData(new double[] { }, new double[] { }, 0)]
        [InlineData(null, null, 0)]
        public void CountOfBusinessesWithNegativeNetProfit(double[] revenues, double[] expenses, int expected)
        {
            // Arrange
            ChallengesSet07 challenger = new ChallengesSet07();
            List<Business> businesses = new List<Business>();
            if (revenues != null)
            {
                for (int i = 0; i < revenues.Length; i++)
                {
                    businesses.Add(new Business()
                    {
                        TotalRevenue = revenues[i],
                        TotalExpenses = expenses[i]
                    });
                }
            }
            else
            {
                businesses = null;
            }

            // Act
            int actual = challenger.CountOfBusinessesWithNegativeNetProfit(businesses);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new[] { 100d, 100, 100 }, new[] { 110d, 90, 80 }, new[] { "Business A", "Business B", "Business C" }, "Business B,Business C")]
        [InlineData(new[] { 100d, 100, 100 }, new[] { 90d, 110, 110 }, new[] { "Business A", "Business B", "Business C" }, "Business A")]
        [InlineData(new[] { 100d, 100, 100 }, new[] { 110d, 110, 110 }, new[] { "Business A", "Business B", "Business C" }, "")]
        [InlineData(new[] { 100d, 100, 100, 100, 100, 100, 100 }, new[] { 110d, 90, 110, 90, 110, 110, 90 }, new[] { "A", "B", "C", "D", "E", "F", "G" }, "B,D,G")]
        public void GetCommaSeparatedListOfProfitableBusinesses(double[] revenues, double[] expenses, string[] names, string expected)
        {
            // Arrange
            ChallengesSet07 challenger = new ChallengesSet07();
            List<Business> businesses = new List<Business>();
            for (int i = 0; i < revenues.Length; i++)
            {
                businesses.Add(new Business()
                {
                    TotalRevenue = revenues[i],
                    TotalExpenses = expenses[i],
                    Name = names[i]
                });
            }

            // Act
            string actual = challenger.GetCommaSeparatedListOfProfitableBusinesses(businesses);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("A", "B", "C", "D", "E")]
        [InlineData("C", "D")]
        [InlineData("B")]
        [InlineData("A", "B", "C", "D", "E", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X")]
        [InlineData("C1", "C2", "C3", "C4", "C5", "C6", null, "C7", "C8", "C9", "C10")]
        public void GetNameOfHighestParentCompany(params string[] namesInOrder)
        {
            // Arrange
            ChallengesSet07 challenger = new ChallengesSet07();
            string expected = namesInOrder[namesInOrder.Length - 1];
            Business headNode = new Business();
            Business current = headNode;
            for (int i = 0; i < namesInOrder.Length; i++)
            {
                current.Name = namesInOrder[i];
                current.ParentCompany = i == namesInOrder.Length - 1 ? null : new Business();
                current = current.ParentCompany;
            }

            // Act
            string actual = challenger.GetNameOfHighestParentCompany(headNode);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(new char[] { 'X', 'X', 'X' }, // Top row
                    new char[] { 'O', 'O', 'X' },
                    new char[] { 'X', 'O', 'O' }, ChallengesSet07.TicTacToeResult.X)]

        [InlineData(new char[] { 'X', 'X', 'O' }, // Middle row
                    new char[] { 'O', 'O', 'O' },
                    new char[] { 'X', 'O', 'X' }, ChallengesSet07.TicTacToeResult.O)]

        [InlineData(new char[] { 'O', 'X', 'X' }, // Bottom row
                    new char[] { 'X', 'X', 'O' },
                    new char[] { 'O', 'O', 'O' }, ChallengesSet07.TicTacToeResult.O)]

        [InlineData(new char[] { 'O', 'O', 'X' }, // Left column
                    new char[] { 'O', 'X', 'X' },
                    new char[] { 'O', 'X', 'O' }, ChallengesSet07.TicTacToeResult.O)]

        [InlineData(new char[] { 'O', 'X', 'X' }, // Middle column
                    new char[] { 'X', 'X', 'O' },
                    new char[] { 'O', 'X', 'O' }, ChallengesSet07.TicTacToeResult.X)]

        [InlineData(new char[] { 'O', 'O', 'X' }, // Right column
                    new char[] { 'X', 'O', 'X' },
                    new char[] { 'O', 'X', 'X' }, ChallengesSet07.TicTacToeResult.X)]

        [InlineData(new char[] { 'X', 'O', 'X' }, // Forward diagonal
                    new char[] { 'O', 'X', 'X' },
                    new char[] { 'X', 'O', 'O' }, ChallengesSet07.TicTacToeResult.X)]

        [InlineData(new char[] { 'O', 'X', 'X' }, // Back diagonal
                    new char[] { 'X', 'O', 'X' },
                    new char[] { 'X', 'O', 'O' }, ChallengesSet07.TicTacToeResult.O)]

        [InlineData(new char[] { 'X', 'O', 'X' },
                    new char[] { 'O', 'O', 'X' },
                    new char[] { 'X', 'X', 'O' }, ChallengesSet07.TicTacToeResult.Draw)]

        [InlineData(new char[] { 'O', 'X', 'X' },
                    new char[] { 'X', 'O', 'O' },
                    new char[] { 'O', 'X', 'X' }, ChallengesSet07.TicTacToeResult.Draw)]

        [InlineData(new char[] { 'X', 'O', 'X' },
                    new char[] { 'X', 'O', 'O' },
                    new char[] { 'O', 'X', 'X' }, ChallengesSet07.TicTacToeResult.Draw)]
        public void GetTicTacToeWinner(char[] row1, char[] row2, char[] row3, ChallengesSet07.TicTacToeResult expected)
        {
            // Arrange
            ChallengesSet07 challenger = new ChallengesSet07();
            char[,] finalBoard = new char[3, 3];
            for (int col = 0; col < 3; col++) finalBoard[0, col] = row1[col];
            for (int col = 0; col < 3; col++) finalBoard[1, col] = row2[col];
            for (int col = 0; col < 3; col++) finalBoard[2, col] = row3[col];

            // Act
            ChallengesSet07.TicTacToeResult actual = challenger.GetTicTacToeWinner(finalBoard);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(true, 2, new[] { 1, 2, 3 }, new[] { 5, 2, 5, 8, 3 }, new[] { 2 })]
        [InlineData(true, 5, new[] { 1, 5, 3 }, new[] { 5, 2, 5, 8, 3 }, new[] { 2, 10, 9, 5 }, new[] { 5, 1 })]
        [InlineData(true, 1, new[] { 1, 5, 3 })]
        [InlineData(false, 5, new[] { 1, 5, 3 }, new[] { 5, 2, 5, 8, 3 }, new[] { 2, 10, 9 }, new[] { 5, 1 })]
        [InlineData(false, 2, new[] { 1, 5, 3 }, new[] { 5, 2, 5, 8, 3 }, new[] { 2, 10, 9 }, new[] { 5, 1 })]
        [InlineData(false, 3, new int[] { })]
        [InlineData(false, 4)]
        public void EachArrayInJaggedArrayContainsTargetNumber(bool expected, int targetNumber, params int[][] numbers)
        {
            // Arrange
            ChallengesSet07 challenger = new ChallengesSet07();

            // Act
            bool actual = challenger.EachArrayInJaggedArrayContainsTargetNumber(numbers, targetNumber);

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}


