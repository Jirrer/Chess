namespace ChessBackendDevelopment;

using System;
using System.ComponentModel.Design;
using System.Data;
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
            if (playerTurn == 0) { npc1.makeMove(board); playerTurn = 1; npc2.checkForMate(); }
            else if (playerTurn == 1) { npc2.makeMove(board); playerTurn = 0; npc1.checkForMate(); }

            if (playerTurn == 0) { updateNPCBoard(npc1, npc2); }
            else { updateNPCBoard(npc2, npc1); }

            Console.WriteLine($"Turn Move: {playerTurn}");
            Console.Write("Next Move");
            Console.ReadLine();
        }

    }

    static void updateNPCBoard(NPC defender, NPC attacker)
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                board[row, col].Item1 = null;
            }
        }

        for (int pieceIndex = 0; pieceIndex < 16; pieceIndex++)
            {
                if (defender.pieces[pieceIndex] != null)
                {
                    board[defender.pieces[pieceIndex].x, defender.pieces[pieceIndex].y] = (defender, pieceIndex);
                }
            }

        for (int pieceIndex = 0; pieceIndex < 16; pieceIndex++)
        {
            if (attacker.pieces[pieceIndex] != null)
            {
                if (board[attacker.pieces[pieceIndex].x, attacker.pieces[pieceIndex].y].Item1 != null) { defender.removePiece(attacker.pieces[pieceIndex].x, attacker.pieces[pieceIndex].y); }
                
                board[attacker.pieces[pieceIndex].x, attacker.pieces[pieceIndex].y] = (attacker, pieceIndex);
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
                if (board[row, col].Item1 == null)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("O" + "\t");
                }

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