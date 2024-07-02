using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Codingame.Medium.SudokuSolver;

[TestClass]
public class SudokuSolverTests
{
    [TestMethod]
    [DynamicData(nameof(Solve_HasSolution_ReturnsSolution_Data), DynamicDataSourceType.Method)]
    public void Solve_HasSolution_ReturnsSolution(int[,] grid, int[,] expected)
    {
        // Arrange
        SudokuSolver sudokuSolver = new();

        // Act
        var result = sudokuSolver.Solve(grid);

        // Assert
        CollectionAssert.AreEqual(expected, result);
    }

    public static IEnumerable<object[]> Solve_HasSolution_ReturnsSolution_Data()
    {
        // Very easy
        yield return new object[] {
            new int[9, 9]
            {
                { 1, 2, 0, 0, 7, 0, 5, 6, 0 },
                { 5, 0, 7, 9, 3, 2, 0, 8, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 1, 0, 2, 4, 0, 0, 5, 0 },
                { 3, 0, 8, 0, 0, 0, 4, 0, 2 },
                { 0, 7, 0, 0, 8, 5, 0, 1, 0 },
                { 0, 0, 0, 7, 0, 0, 0, 0, 0 },
                { 0, 8, 0, 4, 2, 3, 7, 0, 1 },
                { 0, 3, 4, 0, 1, 0, 0, 2, 8 },
            },
            new int[9, 9]
            {
                { 1, 2, 3, 8, 7, 4, 5, 6, 9 },
                { 5, 6, 7, 9, 3, 2, 1, 8, 4 },
                { 8, 4, 9, 6, 5, 1, 2, 3, 7 },
                { 9, 1, 6, 2, 4, 7, 8, 5, 3 },
                { 3, 5, 8, 1, 9, 6, 4, 7, 2 },
                { 4, 7, 2, 3, 8, 5, 9, 1, 6 },
                { 2, 9, 1, 7, 6, 8, 3, 4, 5 },
                { 6, 8, 5, 4, 2, 3, 7, 9, 1 },
                { 7, 3, 4, 5, 1, 9, 6, 2, 8 },
            }
        };

        // Easy
        yield return new object[] {
            new int[9, 9]
            {
                { 0, 0, 6, 0, 0, 0, 0, 5, 0 },
                { 0, 0, 3, 7, 0, 0, 0, 0, 0 },
                { 7, 0, 0, 0, 3, 5, 0, 0, 8 },
                { 0, 0, 0, 0, 7, 0, 0, 1, 2 },
                { 0, 0, 0, 9, 4, 2, 0, 0, 0 },
                { 6, 2, 0, 0, 8, 0, 0, 0, 0 },
                { 9, 0, 0, 1, 2, 0, 0, 0, 3 },
                { 0, 0, 0, 0, 0, 3, 6, 0, 0 },
                { 0, 5, 0, 0, 0, 0, 7, 0, 0 },
            },
            new int[9, 9]
            {
                { 8, 1, 6, 2, 9, 4, 3, 5, 7 },
                { 5, 4, 3, 7, 1, 8, 2, 6, 9 },
                { 7, 9, 2, 6, 3, 5, 1, 4, 8 },
                { 4, 3, 8, 5, 7, 6, 9, 1, 2 },
                { 1, 7, 5, 9, 4, 2, 8, 3, 6 },
                { 6, 2, 9, 3, 8, 1, 4, 7, 5 },
                { 9, 6, 4, 1, 2, 7, 5, 8, 3 },
                { 2, 8, 7, 4, 5, 3, 6, 9, 1 },
                { 3, 5, 1, 8, 6, 9, 7, 2, 4 },
            }
        };

        // World's hardest sudoku
        yield return new object[] {
            new int[9, 9]
            {
                { 8, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 3, 6, 0, 0, 0, 0, 0 },
                { 0, 7, 0, 0, 9, 0, 2, 0, 0 },
                { 0, 5, 0, 0, 0, 7, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 5, 7, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 3, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 6, 8 },
                { 0, 0, 8, 5, 0, 0, 0, 1, 0 },
                { 0, 9, 0, 0, 0, 0, 4, 0, 0 },
            },
            new int[9, 9]
            {
                { 8, 1, 2, 7, 5, 3, 6, 4, 9 },
                { 9, 4, 3, 6, 8, 2, 1, 7, 5 },
                { 6, 7, 5, 4, 9, 1, 2, 8, 3 },
                { 1, 5, 4, 2, 3, 7, 8, 9, 6 },
                { 3, 6, 9, 8, 4, 5, 7, 2, 1 },
                { 2, 8, 7, 1, 6, 9, 5, 3, 4 },
                { 5, 2, 1, 9, 7, 4, 3, 6, 8 },
                { 4, 3, 8, 5, 2, 6, 9, 1, 7 },
                { 7, 9, 6, 3, 1, 8, 4, 5, 2 },
            }
        };
    }
    [TestMethod]
    [DynamicData(nameof(Solve_NoSolution_ReturnsNull_Data), DynamicDataSourceType.Method)]
    public void Solve_NoSolution_ReturnsNull(int[,] grid)
    {
        // Arrange
        SudokuSolver sudokuSolver = new();

        // Act
        var result = sudokuSolver.Solve(grid);

        // Assert
        Assert.IsNull(result);
    }

    public static IEnumerable<object[]> Solve_NoSolution_ReturnsNull_Data()
    {
        yield return new object[] {
            new int[9, 9]
            {
                { 5, 1, 6, 8, 4, 9, 7, 3, 2 },
                { 3, 0, 7, 6, 0, 5, 0, 0, 0 },
                { 8, 0, 9, 7, 0, 0, 0, 6, 5 },
                { 1, 3, 5, 0, 6, 0, 9, 0, 7 },
                { 4, 7, 2, 5, 9, 1, 0, 0, 6 },
                { 9, 6, 8, 3, 7, 0, 0, 5, 0 },
                { 2, 5, 3, 1, 8, 6, 0, 7, 4 },
                { 6, 8, 4, 2, 0, 7, 5, 0, 0 },
                { 7, 9, 1, 0, 5, 0, 6, 0, 8 },
            }
        };

        yield return new object[] {
            new int[9, 9]
            {
                { 7, 8, 1, 5, 4, 3, 9, 2, 6 },
                { 0, 0, 6, 1, 7, 9, 5, 0, 0 },
                { 9, 5, 4, 6, 2, 8, 7, 3, 1 },
                { 6, 9, 5, 8, 3, 7, 2, 1, 4 },
                { 1, 4, 8, 2, 6, 5, 3, 7, 9 },
                { 3, 2, 7, 9, 1, 4, 8, 0, 0 },
                { 4, 1, 3, 7, 5, 2, 6, 9, 8 },
                { 0, 0, 2, 0, 0, 0, 4, 0, 0 },
                { 5, 7, 9, 4, 8, 6, 1, 0, 3 },
            }
        };
    }
}
