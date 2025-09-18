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
            if (playerTurn == 0)
            {
                npc1.makeMove(board);
                playerTurn = 1;
                updateNPCBoard(npc2, npc1);
            }

            else if (playerTurn == 1)
            {
                npc2.makeMove(board);
                playerTurn = 0;
                updateNPCBoard(npc1, npc2);
            }

            npc1.checkForMate();
            npc2.checkForMate();

            Console.WriteLine($"Turn Move: {playerTurn}");
            Console.Write("Next Move");
            Console.ReadLine();
        }

    }

    static void updateNPCBoard(NPC defender, NPC attacker)
    {
        clearBoard();
        placeDefender(defender);
        placeAttacker(attacker, defender);
        printBoard();
    }

    static void clearBoard()
    {
        for (int row = 0; row < 8; row++)
        {
            for (int col = 0; col < 8; col++)
            {
                board[row, col].Item1 = null;
            }
        }   
    }

    static void placeDefender(NPC defender)
    {
        for (int pieceIndex = 0; pieceIndex < 16; pieceIndex++)
        {
            if (defender.pieces[pieceIndex] != null)
            {
                int defenderX = defender.pieces[pieceIndex].x;
                int defenderY = defender.pieces[pieceIndex].y;
                board[defenderX, defenderY] = (defender, pieceIndex);
            }
        }
    }

    static void placeAttacker(NPC attacker, NPC defender)
    {
        for (int pieceIndex = 0; pieceIndex < 16; pieceIndex++)
        {
            if (attacker.pieces[pieceIndex] != null)
            {
                int attackerX = attacker.pieces[pieceIndex].x;
                int attackerY = attacker.pieces[pieceIndex].y;

                if (board[attackerX, attackerY].Item1 != null) { defender.removePiece(attackerX, attackerY); }
                
                board[attackerX, attackerY] = (attacker, pieceIndex);
            }
        }  
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