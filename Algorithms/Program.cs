﻿using Codingame.Hard.AlternativeVote;
using Codingame.Easy.Asteroids;
using Codingame.Hard.Candies;
using Codingame.Medium.DiceProbabilityCalculator;
using Codingame.Hard.Hangman;
using Codingame.Hard.HanoiTower;
using Codingame.Expert.HeartOfTheCity;
using Codingame.Hard.HungryDuck;
using Codingame.Easy.LargestNumber;
using Codingame.Hard.LongestPalindrome;
using Codingame.Hard.OrderOfOopserations;
using Codingame.Hard.Staircases;
using Codingame.Expert.TheLuckyNumber;
using Fundamentals.BreadthFirstSearch;
using Fundamentals.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Codingame.Hard.ClosestNumber;
using Codingame.Medium.ShadowsOfTheKnight1;
using Codingame.Easy.MimeType;
using Algorithms.AdventOfCode._2024;
using Codingame.Expert.RecurringDecimals;

namespace Algorithms;

class Program
{

    static void Main(string[] args)
    {
        //// List of depths
        //BinaryTreeNode root = new BinaryTreeNode(0);  // depth 0

        //BinaryTreeNode node1 = new BinaryTreeNode(1); // depth 1
        //BinaryTreeNode node2 = new BinaryTreeNode(2); // depth 1
        //root.LeftChild = node1;
        //root.RightChild = node2;

        //BinaryTreeNode node3 = new BinaryTreeNode(3); // depth 2
        //BinaryTreeNode node4 = new BinaryTreeNode(4); // depth 2
        //BinaryTreeNode node5 = new BinaryTreeNode(5); // depth 2
        //BinaryTreeNode node6 = new BinaryTreeNode(6); // depth 2
        //node1.LeftChild = node3;
        //node1.RightChild = node4;
        //node2.LeftChild = node5;
        //node2.RightChild = node6;

        //BinaryTreeNode node7 = new BinaryTreeNode(7); // depth 3
        //BinaryTreeNode node8 = new BinaryTreeNode(8); // depth 3
        //BinaryTreeNode node9 = new BinaryTreeNode(9); // depth 3
        //node3.LeftChild = node7;
        //node3.RightChild = node8;
        //node4.LeftChild = node9;

        //LinkedListNode[] depthLists = ListOfDepths.GetDepthLists(root);

        //for (int i = 0; i < depthLists.Length; i++)
        //{
        //    Console.Write("Depth " + i + ": ");
        //    LinkedListNode current = depthLists[i];
        //    while (current is not null)
        //    {
        //        Console.Write(current.Value + " ");
        //        current = current.Next;
        //    }
        //    Console.WriteLine();
        //}

        //// Minimal tree
        //int[] elements = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        //Node root = MinimalTree.GetMinimalBinarySearchTree(elements);

        //// Loop detection
        //LinkedListNode current;
        //LinkedListNode start = new LinkedListNode(1);
        //current = start;
        //current.Next = new LinkedListNode(2);
        //current = current.Next;
        //LinkedListNode loopStart = current;
        //current.Next = new LinkedListNode(3);
        //current = current.Next;
        //current.Next = new LinkedListNode(4);
        //current = current.Next;
        //current.Next = new LinkedListNode(5);
        //current = current.Next;
        //current.Next = new LinkedListNode(6);
        //current = current.Next;
        //current.Next = new LinkedListNode(7);
        //current = current.Next;
        //current.Next = loopStart;
        //Console.WriteLine(LoopDetection.GetLoopStart(start));

        //// Intersection
        // var intersection = new Intersection();
        // LinkedListNode? current;
        // LinkedListNode start1 = new LinkedListNode(1);
        // current = start1;
        // current.Next = new LinkedListNode(2);
        // current = current.Next;
        // current.Next = new LinkedListNode(3);
        // current = current.Next;
        // current.Next = new LinkedListNode(4);
        // current = current.Next;
        // current.Next = new LinkedListNode(5);
        // current = current.Next;
        // LinkedListNode? intersectionNode = current;
        // current.Next = new LinkedListNode(6);
        // current = current.Next;
        // current.Next = new LinkedListNode(7);

        // Console.WriteLine("List 1");
        // current = start1;
        // while (current is not null)
        // {
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        // }
        // Console.WriteLine();

        // LinkedListNode start2 = new LinkedListNode(99);
        // current = start2;
        // current.Next = new LinkedListNode(98);
        // current = current.Next;
        // current.Next = new LinkedListNode(97);
        // current = current.Next;
        // current.Next = new LinkedListNode(96);
        // current = current.Next;
        // current.Next = intersectionNode;

        // Console.WriteLine("List 2");
        // current = start2;
        // while (current is not null)
        // {
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        // }
        // Console.WriteLine();

        // intersectionNode = intersection.GetIntersection(start1, start2);
        // if (intersectionNode is null)
        // {
        //    Console.WriteLine("No intersection");
        // }
        // else
        // {
        //    Console.WriteLine("Intersection at " + intersectionNode.Value);
        // }

        //// Sum lists
        //LinkedListNode startNumber1 = new LinkedListNode(6);
        //LinkedListNode current = startNumber1;
        //current.Next = new LinkedListNode(1);
        //current = current.Next;
        //current.Next = new LinkedListNode(7);

        //LinkedListNode startNumber2 = new LinkedListNode(2);
        //current = startNumber2;
        //current.Next = new LinkedListNode(9);
        //current = current.Next;
        //current.Next = new LinkedListNode(5);

        //Console.WriteLine("Sum list");
        //current = SumLists.SumForwardOrderNumbers(startNumber1, startNumber2);
        //while (current is not null)
        //{
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        //}
        //Console.WriteLine();

        //// Guessing digits
        //GuessingDigits guessingDigits = new GuessingDigits();
        //var guess = guessingDigits.GuessDigits(8, 9);
        //Console.WriteLine($"Guess: {guess.Pair.Low}/{guess.Pair.High}, by player {guess.Player} on turn {guess.Turn}");

        //// Partition
        // LinkedListNode? start = new LinkedListNode(3);
        // LinkedListNode? current = start;
        // current.Next = new LinkedListNode(5);
        // current = current.Next;
        // current.Next = new LinkedListNode(8);
        // current = current.Next;
        // current.Next = new LinkedListNode(5);
        // current = current.Next;
        // current.Next = new LinkedListNode(10);
        // current = current.Next;
        // current.Next = new LinkedListNode(2);
        // current = current.Next;
        // current.Next = new LinkedListNode(1);
        // current = current.Next;
        // Console.WriteLine("Initial list");
        // current = start;
        // while (current is not null)
        // {
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        // }
        // Console.WriteLine();

        // Partition partition = new();
        // int threshold = 5;
        // Console.WriteLine($"Threshold: {threshold}");
        // start = partition.PartitionAroundThreshold(start, threshold);
        // Console.WriteLine("After partitioning");
        // current = start;
        // while (current is not null)
        // {
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        // }
        // Console.WriteLine();

        //// Delete middle node
        //LinkedListNode start = new LinkedListNode("node 1");
        //LinkedListNode current = start;
        //LinkedListNode nodeToDelete = null;
        //LinkedListNode next;
        //for (int i = 2; i <= 10; i++)
        //{
        //    next = new LinkedListNode($"node {i}");
        //    current.Next = next;

        //    if (i == 6)
        //    {
        //        nodeToDelete = next;
        //    }

        //    current = next;
        //}

        //Console.WriteLine("Initial list");
        //current = start;
        //while (current is not null)
        //{
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        //}
        //Console.WriteLine();

        //DeleteMiddleNode.Delete(nodeToDelete);

        //Console.WriteLine("Updated list");
        //current = start;
        //while (current is not null)
        //{
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        //}
        //Console.WriteLine();

        //// Remove dups
        //// a) initial list
        //LinkedListNode start = new LinkedListNode("node 1");
        //LinkedListNode current = start;
        //LinkedListNode next;
        //for (int i = 2; i <= 10; i++)
        //{
        //    next = new LinkedListNode($"node {i}");
        //    current.Next = next;
        //    current = next;
        //}
        //next = new LinkedListNode($"node 3");
        //current.Next = next;
        //current = next;
        //next = new LinkedListNode($"node 8");
        //current.Next = next;
        //current = next;
        //next = new LinkedListNode($"node 2");
        //current.Next = next;
        //current = next;
        //next = new LinkedListNode($"node 2");
        //current.Next = next;
        //current = next;
        //next = new LinkedListNode($"node 7");
        //current.Next = next;
        //current = next;
        //next = new LinkedListNode($"node 14");
        //current.Next = next;
        //current = next;
        //next = new LinkedListNode($"node 3");
        //current.Next = next;
        //current = next;

        //Console.WriteLine("Initial list");
        //current = start;
        //while (current is not null)
        //{
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        //}
        //Console.WriteLine();
        //// b) list without duplicates
        //Console.WriteLine("List without duplicates");
        //RemoveDups.RemoveDuplicatesWithoutBuffer(start);
        //current = start;
        //while (current is not null)
        //{
        //    Console.WriteLine(current.Value);
        //    current = current.Next;
        //}

        //// Stock exchange losses
        //StockExchangeLosses stockExchangeLosses = new StockExchangeLosses();
        //Console.WriteLine(stockExchangeLosses.FindMaxPossibleLoss(new int[] { 5, 3, 4, 2, 3, 1 }));

        //// The gift
        //TheGift theGift = new TheGift();
        //int[] budgets = new int[] { 100, 1, 60 };
        //var result = theGift.ComputeContributions(budgets, 100);
        //Console.WriteLine(result.IsSolvable);
        //Console.WriteLine(string.Join('-', result.Contributions));

        //// The last crusade
        //int[,] rooms = new int[2, 4]
        //{
        //    { 4, 12, 11, 2 },
        //    { 3, 10, 5, 3 },
        //};
        //TheFall1 theFall1 = new TheFall1(rooms);
        //Console.WriteLine(theFall1.FindNextRoom(1, 0, "TOP"));
        //Console.WriteLine(theFall1.FindNextRoom(1, 1, "TOP"));

        //// Network cabling
        //long[] xPositions = new long[] { -5, -9, 3 };
        //long[] yPositions = new long[] { -3, 2, -4 };
        //NetworkCabling networkCabling = new NetworkCabling();
        //var length = networkCabling.GetMinimumCableLength(xPositions, yPositions);
        //Console.WriteLine(length);

        //// Conway sequence
        //ConwaySequence conwaySequence = new ConwaySequence();
        //var nthLine = conwaySequence.GetNthLine(1, 6);
        //Console.WriteLine(string.Join(" ", nthLine));

        //// Blunder1
        //string[] rows = new string[] {
        //    "###############",
        //    "#  #@#I  T$#  #",
        //    "#  #    IB #  #",
        //    "#  #     W #  #",
        //    "#  #      ##  #",
        //    "#  #B XBN# #  #",
        //    "#  ##      #  #",
        //    "#  #       #  #",
        //    "#  #     W #  #",
        //    "#  #      ##  #",
        //    "#  #B XBN# #  #",
        //    "#  ##      #  #",
        //    "#  #       #  #",
        //    "#  #     W #  #",
        //    "#  #      ##  #",
        //    "#  #B XBN# #  #",
        //    "#  ##      #  #",
        //    "#  #       #  #",
        //    "#  #       #  #",
        //    "#  #      ##  #",
        //    "#  #  XBIT #  #",
        //    "#  #########  #",
        //    "#             #",
        //    "# ##### ##### #",
        //    "# #     #     #",
        //    "# #     #  ## #",
        //    "# #     #   # #",
        //    "# ##### ##### #",
        //    "#             #",
        //    "###############",
        //};
        //Blunder1 blunder1 = new Blunder1();
        //var result = blunder1.Traverse(rows);
        //if (result.IsStuckInInfiniteLoop)
        //{
        //    Console.WriteLine("LOOP");
        //}
        //else
        //{
        //    foreach (var direction in result.Path)
        //    {
        //        Console.WriteLine(direction);
        //    }
        //}

        //// Telephone numbers
        //TelephoneNumbersSolver telephoneNumbersSolver = new TelephoneNumbersSolver();
        //Console.WriteLine(telephoneNumbersSolver.GetNumberOfRequiredNodes(new string[] { "0467123456" }));

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

        //// Death first search
        //DeathFirstSearch1 deathFirstSearch1 = new DeathFirstSearch();
        //deathFirstSearch1.AddLink(11, 6);
        //deathFirstSearch1.AddLink(0, 9);
        //deathFirstSearch1.AddLink(1, 2);
        //deathFirstSearch1.AddLink(0, 1);
        //deathFirstSearch1.AddLink(10, 1);
        //deathFirstSearch1.AddLink(11, 5);
        //deathFirstSearch1.AddLink(2, 3);
        //deathFirstSearch1.AddLink(4, 5);
        //deathFirstSearch1.AddLink(8, 9);
        //deathFirstSearch1.AddLink(6, 7);
        //deathFirstSearch1.AddLink(7, 8);
        //deathFirstSearch1.AddLink(0, 6);
        //deathFirstSearch1.AddLink(3, 4);
        //deathFirstSearch1.AddLink(0, 2);
        //deathFirstSearch1.AddLink(11, 7);
        //deathFirstSearch1.AddLink(0, 8);
        //deathFirstSearch1.AddLink(0, 4);
        //deathFirstSearch1.AddLink(9, 10);
        //deathFirstSearch1.AddLink(0, 5);
        //deathFirstSearch1.AddLink(0, 7);
        //deathFirstSearch1.AddLink(0, 3);
        //deathFirstSearch1.AddLink(0, 10);
        //deathFirstSearch1.AddLink(5, 6);
        //deathFirstSearch1.SetGateway(0);
        //(int source, int target) = deathFirstSearch1.FindLinkToCut(11);
        //Console.WriteLine(source + " " + target);

        // // Binary search tree
        // //      4
        // //     / \
        // //    /   \
        // //   2     6
        // //  / \   / \
        // // 1   3 5   7
        // BinarySearchTree<int> tree = new BinarySearchTree<int>();
        // tree.Insert(4);
        // tree.Insert(2);
        // tree.Insert(3);
        // tree.Insert(1);
        // tree.Insert(6);
        // tree.Insert(5);
        // tree.Insert(7);
        // Console.WriteLine(" Pre: " + string.Join('-', tree.TraversePreOrder(tree.Root).Select(n => n.Value)));
        // Console.WriteLine("  In: " + string.Join('-', tree.TraverseInOrder(tree.Root).Select(n => n.Value)));
        // Console.WriteLine("Post: " + string.Join('-', tree.TraversePostOrder(tree.Root).Select(n => n.Value)));
        // Console.WriteLine("  BF: " + string.Join('-', tree.TraverseBreadFirst(tree.Root).Select(n => n.Value)));
        // for (int i = 1; i <= 15; i++)
        // {
        //    Console.WriteLine("Find " + i + ": " + (tree.Find(i) is null ? "not found" : "found!"));
        // }

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
        //if (path is null)
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
        //Maze mazeSolver = new Maze();
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

        //string[] picture = new string[9];
        //picture[8] = "                   #         #                                     #####     ";
        //picture[7] = "                  ###       ###                                    #####     ";
        //picture[6] = "                  ###       ###                                    #####     ";
        //picture[5] = "                  ###   #   ###                                    #####     ";
        //picture[4] = "         ###      ### ##### ###                      #####        #######    ";
        //picture[3] = "    ##  #####     #############                      #####       #########   ";
        //picture[2] = " #####  #####     #############  ################    #####    ###############";
        //picture[1] = " #####  #####     #############  ################    #####    ###############";
        //picture[0] = " #####  #####     #############  ################    #####    ###############";
        //HighestBuilding highestBuilding = new HighestBuilding();
        //var highestBuildings = highestBuilding.GetHighestBuildings(picture);

        //int index = 1;
        //StringBuilder currentFloor = new StringBuilder();
        //foreach (var building in highestBuildings)
        //{
        //    for (int i = building.Height; i > 0; i--)
        //    {
        //        for (int j = 0; j < building.Width; j++)
        //        {
        //            currentFloor.Append(building.Heights[j] >= i ? "#" : " ");
        //        }
        //        Console.WriteLine(currentFloor.ToString().TrimEnd());
        //        currentFloor.Clear();
        //    }

        //    if (index < highestBuildings.Count) Console.WriteLine();
        //    index++;
        //}

        //HungryDuck hungryDuck = new HungryDuck();
        //int width = 3;
        //int height = 3;
        //int[][] foods = new int[height][];
        //for (int i = 0; i < height; i++)
        //{
        //    foods[i] = new int[width];
        //}
        //foods[0][0] = 1;
        //foods[0][1] = 2;
        //foods[0][2] = 3;
        //foods[1][0] = 4;
        //foods[1][1] = 5;
        //foods[1][2] = 6;
        //foods[2][0] = 7;
        //foods[2][1] = 8;
        //foods[2][2] = 9;
        //Console.WriteLine(hungryDuck.GetMaximumFoodAmount(foods));

        //HanoiTower hanoiTower = new HanoiTower();
        //var stacks = hanoiTower.GetPosition(10, 436);
        //foreach (var row in HanoiTower.Draw(stacks))
        //{
        //    Console.WriteLine(row);
        //}

        //Hangman hangman = new Hangman();
        //var result = hangman.Solve("hangman", new char[] { 'a', 'e', 's', 'm', 'g', 'n', 'h' });
        //foreach (var row in Hangman.Draw(result.NbFails))
        //{
        //    Console.WriteLine(row);
        //}
        //Console.WriteLine(result.Word);

        //LongestPalindrome longestPalindrome = new LongestPalindrome();
        //foreach (var palindrome in longestPalindrome.GetLongestPalindromes("ladamant"))
        //{
        //    Console.WriteLine(palindrome);
        //}

        // Candies candies = new Candies();
        // var sequences = candies.GetSequences(5, 2);

        // Sorting sorting = new();
        // int[] elements = [3, 5, 8, -1, 2, -6];
        // Console.WriteLine(string.Join(" - ", sorting.QuickSort(elements)));

        // BreadthFirstSearch breadthFirstSearch= new();
        // Node<string> a = new("A");
        // Node<string> b = new("B");
        // Node<string> c = new("C");
        // Node<string> d = new("D");
        // Node<string> e = new("E");
        // Node<string> f = new("F");
        // Node<string> g = new("G");
        // Node<string> h = new("H");
        // Node<string> i = new("I");
        // a.AddNeighbors([b, c, d]);
        // b.AddNeighbor(e);
        // c.AddNeighbors([e, g]);
        // e.AddNeighbor(f);
        // h.AddNeighbor(i);
        // i.AddNeighbor(h);
        // Console.WriteLine($"Has path from a to f: {breadthFirstSearch.HasPath(a, f)}");
        // Console.WriteLine($"Has path from h to i: {breadthFirstSearch.HasPath(h, i)}");
        // Console.WriteLine($"Has path from a to h: {breadthFirstSearch.HasPath(a, h)}");

        // HeartOfTheCity heartOfTheCity= new();
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(1999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(2999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(3999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(4999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(5999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(6999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(7999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(8999999));
        // Console.WriteLine(heartOfTheCity.GetNumberOfVisibleBuildings(9999999));

        // var luckyNumber = new TheLuckyNumber();
        // long min = 1;
        // long max = 7328;
        // Console.WriteLine($"{min} to {max} -> {luckyNumber.Count(min, max)} lucky number(s)");
        // Console.WriteLine($"Total: {count.Total}");
        // Console.WriteLine($"Lucky: {count.LuckySix + count.LuckyEight}");
        // Console.WriteLine($"Unlucky none: {count.UnluckyNone}");
        // Console.WriteLine($"Unlucky two: {count.UnluckyTwo}");
        // long min = 58;
        // long max = 72;
        // long nbLuckyMin = luckyNumber.GetNbLucky(min);
        // long nbLuckyMax = luckyNumber.GetNbLucky(max);
        // Console.WriteLine($"{min - 1} => {nbLuckyMin} lucky numbers");
        // Console.WriteLine($"{max} => {nbLuckyMax} lucky numbers");
        // Console.WriteLine($"{nbLuckyMax - nbLuckyMin} lucky numbers between");

        // DiceProbabilityCalculator diceProbabilityCalculator = new();
        // string input = "(2>5)+2*(5>2)+4*(10>5)";
        // // string input = "d9-2*d4";
        // // string input = "12-d2*d6";
        // var probabilities = diceProbabilityCalculator.ComputeProbabilities(input);
        // foreach (var k in probabilities.Keys.Order())
        // {
        //     Console.WriteLine($"{k}: {Math.Round(probabilities[k] * 100, 2)}");
        // }

        // Asteroids asteroids = new();
        // // char[][] state1 = [
        // //     ['A', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // // ];
        // // char[][] state2 = [
        // //     ['.', 'A', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.'],
        // // ];
        // // var state3 = asteroids.GetState3(1, state1, 2, state2, 3);

        // // char[][] state1 = [
        // //     ['.', '.', 'H', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.', '.'],
        // //     ['E', '.', '.', '.', 'G', '.'],
        // //     ['.', '.', '.', '.', '.', '.'],
        // //     ['.', '.', 'F', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.', '.'],
        // // ];
        // // char[][] state2 = [
        // //     ['.', '.', '.', '.', '.', '.'],
        // //     ['.', '.', 'H', '.', '.', '.'],
        // //     ['.', 'E', '.', 'G', '.', '.'],
        // //     ['.', '.', 'F', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.', '.'],
        // //     ['.', '.', '.', '.', '.', '.'],
        // // ];
        // // var state3 = asteroids.GetState3(1, state1, 2, state2, 3);

        // char[][] state1 = [
        //     ['A', '.', '.'],
        //     ['B', '.', '.'],
        //     ['C', '.', '.'],
        // ];
        // char[][] state2 = [
        //     ['B', 'A', '.'],
        //     ['.', '.', '.'],
        //     ['.', '.', 'C'],
        // ];
        // var state3 = asteroids.GetState3(1, state1, 2, state2, 3);
        // foreach (var row in state3)
        // {
        //     Console.WriteLine(string.Join("", row));
        // }

        // OrderOfOopserations orderOfOopserations = new();
        // // Console.WriteLine(orderOfOopserations.ComputeExpression("6+-3*5"));
        // Console.WriteLine(orderOfOopserations.ComputeExpression("-3+6"));

        // LargestNumber largestNumber = new();
        // Console.WriteLine(largestNumber.GetLargest(72659, 5));

        // AlternativeVote alternativeVote = new();
        // var candidateNames = new List<string> { "Thierry", "Peter", "Sandra", "Catherine", "Aude" };
        // var preferences = new List<List<int>>
        // {
        //     new List<int> { 1, 5, 2, 4, 3 },
        //     new List<int> { 5, 3, 2, 4, 1 },
        //     new List<int> { 5, 3, 1, 2, 4 },
        //     new List<int> { 4, 5, 3, 1, 2 },
        //     new List<int> { 4, 3, 5, 1, 2 },
        //     new List<int> { 2, 3, 5, 1, 4 },
        //     new List<int> { 5, 3, 2, 1, 4 },
        //     new List<int> { 2, 3, 5, 1, 4 },
        //     new List<int> { 5, 3, 2, 1, 4 },
        //     new List<int> { 5, 1, 3, 2, 4 },
        // };
        // var eliminations = alternativeVote.GetEliminations(candidateNames, preferences);
        // foreach (var e in eliminations)
        // {
        //     Console.WriteLine(e);
        // }

        // ShadowsOfTheKnight1 shadowsOfTheKnight = new();
        // // var moves = shadowsOfTheKnight.GetMoves(4, 8, 2, 3, 40, new ConsoleInput());
        // var moves = shadowsOfTheKnight.GetMoves(4, 8, 2, 3, 40, new AutomatedInput(3, 7));
        // Console.WriteLine("Bomb defused! Moves:");
        // foreach (var move in moves)
        // {
        //     Console.WriteLine(move);
        // }

        // MimeType mimeType = new();
        // var descriptions = new Dictionary<string, string>()
        // {
        //     { "html", "text/html" },
        //     { "png", "image/png" },
        //     { "gif", "image/gif" },
        // };
        // var filenames = new List<string>()
        // {
        //     "animated.gif",
        //     "portrait.png",
        //     "index.html",
        // };
        // var mimeTypes = mimeType.GetMimeTypes(descriptions, filenames);
        // foreach (var m in mimeTypes)
        // {
        //     Console.WriteLine(m);
        // }

        // ClosestNumber closestNumber = new();
        // string target = "590";
        // string source = "506";
        // Console.WriteLine($"Target: {target}");
        // Console.WriteLine($"Source: {source}");
        // Console.WriteLine($"=> Closest: {closestNumber.GetClosestPermutation(target, source)}");

        // RecurringDecimals recurringDecimals = new();
        // Console.WriteLine(recurringDecimals.Invert(44));

        // Day9DiskFragmenter day9DiskFragmenter = new();
        // var result = day9DiskFragmenter.CalculateChecksumWithFileDefragmentation("2333133121414131402");

        // Day11PlutonianPebbles day11PlutonianPebbles = new();
        // Console.WriteLine(day11PlutonianPebbles.CalculateNumberOfStonesWithMemoization([125, 17], 6));
        // Console.WriteLine(day11PlutonianPebbles.CalculateNumberOfStonesWithMemoization([125, 17], 25));
        // Console.WriteLine(day11PlutonianPebbles.CalculateNumberOfStonesWithMemoization([5688, 62084, 2, 3248809, 179, 79, 0, 172169], 25));
        // Console.WriteLine(day11PlutonianPebbles.CalculateNumberOfStonesWithMemoization([5688, 62084, 2, 3248809, 179, 79, 0, 172169], 75));

        // Day12GardenGroups day12GardenGroups = new();
        // Console.WriteLine(day12GardenGroups.CalculateBulkDiscountPrice([
        //     "RRRRIICCFF",
        //     "RRRRIICCCF",
        //     "VVRRRCCFFF",
        //     "VVRCCCJFFF",
        //     "VVVVCJJCFE",
        //     "VVIVCCJJEE",
        //     "VVIIICJJEE",
        //     "MIIIIIJJEE",
        //     "MIIISIJEEE",
        //     "MMMISSJEEE",
        // ]));

        ClosestNumber closestNumber = new();
        Console.WriteLine(closestNumber.GetClosestPermutation("3204", "111"));
        // Console.WriteLine(closestNumber.GetClosestPermutation("284512", "2749"));
        // Console.WriteLine(closestNumber.GetClosestPermutation("4000007", "8732"));
        // Console.WriteLine(closestNumber.GetClosestPermutation("57645", "64545"));
        // Console.WriteLine(closestNumber.GetClosestPermutation("95", "77"));
        // Console.WriteLine(closestNumber.GetClosestPermutation("506", "590"));
        // Console.WriteLine(closestNumber.GetClosestPermutation("95", "77"));
    }
}
