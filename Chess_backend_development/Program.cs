namespace ChessBackendDevelopment;

using System;
using System.ComponentModel.Design;
using System.Security;

static class Program
{
    static (NPC?, int)[,] board = new (NPC?, int)[8, 8];
    static void Main()
    {
        startBotGame(new NPC(0), new NPC(1));
    }


    static void startBotGame(NPC npc1, NPC npc2)
    {
        int playerTurn = 0;

        while (!npc1.checkMate && !npc2.checkMate)
        {
            updateNPCBoard(npc1, npc2);
            // if (playerTurn == 0) { board = npc1.makeMove(board); playerTurn = 1; npc2.checkForMate(); }
            // else if (playerTurn == 1) { board = npc2.makeMove(board); playerTurn = 0; npc1.checkForMate(); }

            npc1.makeMove(board);

            Console.WriteLine($"Turn Move: {playerTurn}");
            Console.Write("Next Move");
            Console.ReadLine();
        }

    }

    static void updateNPCBoard(NPC npc1, NPC npc2)
    {
        for (int pieceIndex = 0; pieceIndex < 16; pieceIndex++)
        {
            if (npc1.pieces[pieceIndex] != null)
            {
                board[npc1.pieces[pieceIndex].x, npc1.pieces[pieceIndex].y] = (npc1, pieceIndex);
            }
        }

        for (int pieceIndex = 0; pieceIndex < 16; pieceIndex++)
        {
            if (npc2.pieces[pieceIndex] != null)
            {
                board[npc2.pieces[pieceIndex].x, npc2.pieces[pieceIndex].y] = (npc2, pieceIndex);
            }
        }

        printBoard();
    }
    static void printBoard()
    {
        Console.Clear();

        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                if (board[row, col].Item1 == null) { Console.Write("O" + "\t"); }

                else
                {
                    if (board[row, col].Item1.color == 0) { Console.ForegroundColor = ConsoleColor.Red; }
                    else if (board[row, col].Item1.color == 1) { Console.ForegroundColor = ConsoleColor.Green; }

                    Console.Write(board[row, col].Item1.pieces[board[row, col].Item2].pieceType + "\t");
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }


    
}