using System;
using System.Collections.Generic;
using TelephoneNumbers;

namespace Algorithms
{
    class Program
    {

        static void Main(string[] args)
        {
            // Telephone numbers
            TelephoneNumbersSolver telephoneNumbersSolver = new TelephoneNumbersSolver();
            Console.WriteLine(telephoneNumbersSolver.GetNumberOfRequiredNodes(new string[] { "0467123456" }));

            //// Speed calculator
            //SpeedCalculator speedCalculator = new SpeedCalculator();
            //Console.WriteLine(speedCalculator.FindMaxPossibleSpeed(50, new TrafficLight[]
            //{
            //    new TrafficLight
            //    {
            //        Distance = 200,
            //        Duration = 15,
            //    },
            //}));

            //// 3-N tiling
            //ThreeNTiling threeNTiling = new ThreeNTiling();
            //int width = 136;
            //Console.WriteLine("Width " + width);
            //Console.WriteLine(threeNTiling.GetNumberOfValidLayouts(width, 3));

            //// Robbery optimisation
            //RobberyOptimisation robberyOptimisation = new RobberyOptimisation();
            //Console.WriteLine(robberyOptimisation.GetMaximumAmount(new long[] { 1, 2, 3 }));

            //// Goro want chocolate
            //GoroWantChocolate goroWantChocolateSolver = new GoroWantChocolate();
            //Console.WriteLine(goroWantChocolateSolver.GetMinimalNumberOfSquares(5, 3));

            //// Skynet revolution
            //SkynetGraph skynetGraph = new SkynetGraph();
            //skynetGraph.AddLink(11, 6);
            //skynetGraph.AddLink(0, 9);
            //skynetGraph.AddLink(1, 2);
            //skynetGraph.AddLink(0, 1);
            //skynetGraph.AddLink(10, 1);
            //skynetGraph.AddLink(11, 5);
            //skynetGraph.AddLink(2, 3);
            //skynetGraph.AddLink(4, 5);
            //skynetGraph.AddLink(8, 9);
            //skynetGraph.AddLink(6, 7);
            //skynetGraph.AddLink(7, 8);
            //skynetGraph.AddLink(0, 6);
            //skynetGraph.AddLink(3, 4);
            //skynetGraph.AddLink(0, 2);
            //skynetGraph.AddLink(11, 7);
            //skynetGraph.AddLink(0, 8);
            //skynetGraph.AddLink(0, 4);
            //skynetGraph.AddLink(9, 10);
            //skynetGraph.AddLink(0, 5);
            //skynetGraph.AddLink(0, 7);
            //skynetGraph.AddLink(0, 3);
            //skynetGraph.AddLink(0, 10);
            //skynetGraph.AddLink(5, 6);
            //skynetGraph.SetGateway(0);
            //(int source, int target) = skynetGraph.FindLinkToCut(11);
            //Console.WriteLine(source + " " + target);

            //// Binary search tree
            ////      4
            ////     / \
            ////    /   \
            ////   2     6
            ////  / \   / \
            //// 1   3 5   7
            //BinarySearchTree<int> tree = new BinarySearchTree<int>();
            //tree.Insert(4);
            //tree.Insert(2);
            //tree.Insert(3);
            //tree.Insert(1);
            //tree.Insert(6);
            //tree.Insert(5);
            //tree.Insert(7);
            //Console.WriteLine(" Pre: " + string.Join('-', tree.TraversePreOrder(tree.Root).Select(n => n.Value)));
            //Console.WriteLine("  In: " + string.Join('-', tree.TraverseInOrder(tree.Root).Select(n => n.Value)));
            //Console.WriteLine("Post: " + string.Join('-', tree.TraversePostOrder(tree.Root).Select(n => n.Value)));
            //Console.WriteLine("  BF: " + string.Join('-', tree.TraverseBreadFirst(tree.Root).Select(n => n.Value)));
            //for (int i = 1; i <= 15; i++)
            //{
            //    Console.WriteLine("Find " + i + ": " + (tree.Find(i) == null ? "not found" : "found!"));
            //}

            //// Longest common subsequence
            //LongestCommonSubSequence longestCommonSubSequenceSolver = new LongestCommonSubSequence();
            //string string1 = "ABCDGH";
            //string string2 = "AEDFHR";
            //Console.Write("Memoization: ");
            //Console.WriteLine(longestCommonSubSequenceSolver.Memoization(string1, string2));
            //Console.Write("Recursion: ");
            //Console.WriteLine(longestCommonSubSequenceSolver.Recursion(string1, string2));

            //// Water jug
            //WaterJug waterJugSolver = new WaterJug();
            //var path = waterJugSolver.Solve(7, 5, 2);
            //if (path == null)
            //{
            //    Console.WriteLine("No solution");
            //}
            //else
            //{
            //    Console.WriteLine(string.Join("->", path.ToArray()));
            //}

            //// Fibonacci
            //long number = 150;
            //Console.WriteLine("Fibonacci(" + number + ")");
            //Console.Write("Memoization: ");
            //Console.WriteLine(Fibonacci.Memoization(number));
            //Console.Write("Tabulation: ");
            //Console.WriteLine(Fibonacci.Tabulation(number));
            //Console.Write("Simple loop: ");
            //Console.WriteLine(Fibonacci.SimpleLoop(number));
            //Console.Write("Recursion: ");
            //Console.WriteLine(Fibonacci.Recursion(number));

            //// Maze
            //int[,] maze = new int[,]
            //{
            //    {1, 1, 0, 0, 0, 0, 0, 0},
            //    {0, 1, 1, 0, 0, 0, 0, 0},
            //    {0, 1, 0, 0, 0, 0, 0, 0},
            //    {0, 1, 1, 1, 1, 1, 1, 0},
            //    {0, 0, 0, 0, 1, 0, 1, 1},
            //};
            //MazeSolver mazeSolver = new MazeSolver();
            //mazeSolver.Solve(maze);

            //// Knight's tour
            //KnightTour knightTourSolver = new KnightTour();
            //knightTourSolver.Solve(7);

            //// Sudoku
            //int[,] board = new int[9, 9]
            //{
            //    //{1,2,0,0,7,0,5,6,0},
            //    //{5,0,7,9,3,2,0,8,0},
            //    //{0,0,0,0,0,1,0,0,0},
            //    //{0,1,0,2,4,0,0,5,0},
            //    //{3,0,8,0,0,0,4,0,2},
            //    //{0,7,0,0,8,5,0,1,0},
            //    //{0,0,0,7,0,0,0,0,0},
            //    //{0,8,0,4,2,3,7,0,1},
            //    //{0,3,4,0,1,0,0,2,8}
            //    {0,8,0,7,0,0,6,0,3},
            //    {0,0,0,0,0,0,7,0,0},
            //    {0,0,7,0,2,8,0,4,0},
            //    {0,1,2,5,0,0,0,8,0},
            //    {0,0,5,0,9,0,2,0,0},
            //    {0,4,0,0,0,7,1,5,0},
            //    {0,7,0,4,1,0,9,0,0},
            //    {0,0,3,0,0,0,0,0,0},
            //    {6,0,1,0,0,5,0,7,0},
            //};
            //Sudoku sudokuSolver = new Sudoku();
            //sudokuSolver.Solve(board);

            //// War
            //Queue<int> player1Cards = new Queue<int>();
            //Queue<int> player2Cards = new Queue<int>();
            ////player1Cards = new Queue<int>(new int[] { 5, 3, 2, 7, 8, 7, 5, 5, 6, 5, 4, 6, 6, 3, 3, 7, 4, 4, 7, 4, 2, 6, 8, 3, 2, 2 });
            ////player2Cards = new Queue<int>(new int[] { 14, 9, 13, 13, 13, 13, 10, 10, 9, 12, 11, 10, 8, 12, 11, 14, 11, 14, 12, 14, 11, 10, 9, 8, 12, 9 });
            //player1Cards = new Queue<int>(new int[] { 6, 7, 6, 12, 7, 8, 6, 5, 6, 12, 4, 3, 7, 3, 4, 5, 12, 5, 3, 3, 8, 4, 4, 12, 5, 7 });
            //player2Cards = new Queue<int>(new int[] { 11, 14, 13, 14, 9, 2, 2, 11, 10, 13, 10, 11, 11, 9, 9, 13, 14, 13, 10, 8, 2, 10, 8, 14, 2, 9 });
            ////player1Cards = new Queue<int>(new int[] { 10, 9, 8, 13, 7, 5, 6 });
            ////player2Cards = new Queue<int>(new int[] { 10, 7, 5, 12, 2, 4, 6 });
            ////player1Cards = new Queue<int>(new int[] { 8, 13, 14, 12, 3, 13, 14, 12, 6 });
            ////player2Cards = new Queue<int>(new int[] { 8,2, 3, 4, 3, 2, 3, 4, 7 });
            ////player1Cards = new Queue<int>(new int[] { 8, 13, 14, 12, 2 });
            ////player2Cards = new Queue<int>(new int[] { 8, 2, 3, 4, 3 });
            //War war = new War();
            //(int winner, int nbRounds) = war.Play(player1Cards, player2Cards);
            //if (winner == 0)
            //{
            //    Console.WriteLine("PAT");
            //}
            //else
            //{
            //    Console.WriteLine("" + winner + " " + nbRounds);
            //}
        }
    }
}
