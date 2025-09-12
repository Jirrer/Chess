namespace ChessBackendDevelopment;

using System;
using System.ComponentModel.Design;
using System.Security;

static class Program
{
    static NPC?[,] board = new NPC?[8, 8];
    static void Main()
    {
        startBotGame(new NPC(0), new NPC(1));
    }


    static void startBotGame(NPC npc1, NPC npc2)
    {
        createNPCBoard(npc1, npc2);
        int playerTurn = 0;

        while (!npc1.checkMate && !npc2.checkMate)
        {
            printBoard(npc1, npc2);

            if (playerTurn == 0) { board = npc1.makeMove(board); playerTurn = 1; npc2.checkForMate(); }
            else if (playerTurn == 1) { board = npc2.makeMove(board); playerTurn = 0; npc1.checkForMate(); }

            Console.WriteLine($"Turn Move: {playerTurn}");
            Console.Write("Next Move");
            var temp = Console.ReadLine();
        }

    }
    
    static void createNPCBoard(NPC npc1, NPC npc2)
    {

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                board[row, col] = null;

                if (npc1.pieces.ContainsKey((row, col))) { board[row, col] = npc1; }
                if (npc2.pieces.ContainsKey((row, col))){ board[row, col] = npc2; } 
            }
        }
    }
    static void printBoard(NPC npc1, NPC npc2)
    {
        Console.Clear();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (board[row, col] == null) { Console.Write("O" + "\t"); }

                else
                {
                    if (board[row, col].color == 0) { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (board[row, col].color == 1) { Console.ForegroundColor = ConsoleColor.Green; }

                    Console.Write(board[row, col].pieces[(row, col)].pieceType + "\t");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }


    
}