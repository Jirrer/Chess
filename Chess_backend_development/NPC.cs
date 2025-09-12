namespace ChessBackendDevelopment;

using System;

public class NPC
{
    public int color;
    public Dictionary<(int, int), Piece> pieces = new Dictionary<(int, int), Piece>();
    public bool checkMate = false;

    public void checkForMate() {
        // change checkMate boolean if there is a mate
    }

    public NPC(int color)
    {
        this.color = color;
        this.instantiatePieces();
    }

    private void instantiatePieces()
    {
        if (this.color == 0)
        {
            this.pieces.Add((0, 4), new Piece(1));
            this.pieces.Add((0, 3), new Piece(2));
            this.pieces.Add((0, 2), new Piece(3));
            this.pieces.Add((0, 5), new Piece(3));
            this.pieces.Add((0, 1), new Piece(4));
            this.pieces.Add((0, 6), new Piece(4));
            this.pieces.Add((0, 0), new Piece(5));
            this.pieces.Add((0, 7), new Piece(5));
            this.pieces.Add((1, 0), new Piece(6));
            this.pieces.Add((1, 1), new Piece(6));
            this.pieces.Add((1, 2), new Piece(6));
            this.pieces.Add((1, 3), new Piece(6));
            this.pieces.Add((1, 4), new Piece(6));
            this.pieces.Add((1, 5), new Piece(6));
            this.pieces.Add((1, 6), new Piece(6));
            this.pieces.Add((1, 7), new Piece(6));
        }

        else if (this.color == 1)
        {
            this.pieces.Add((7, 4), new Piece(1));
            this.pieces.Add((7, 3), new Piece(2));
            this.pieces.Add((7, 2), new Piece(3));
            this.pieces.Add((7, 5), new Piece(3));
            this.pieces.Add((7, 1), new Piece(4));
            this.pieces.Add((7, 6), new Piece(4));
            this.pieces.Add((7, 0), new Piece(5));
            this.pieces.Add((7, 7), new Piece(5));
            this.pieces.Add((6, 0), new Piece(6));
            this.pieces.Add((6, 1), new Piece(6));
            this.pieces.Add((6, 2), new Piece(6));
            this.pieces.Add((6, 4), new Piece(6));
            this.pieces.Add((6, 3), new Piece(6));
            this.pieces.Add((6, 5), new Piece(6));
            this.pieces.Add((6, 6), new Piece(6));
            this.pieces.Add((6, 7), new Piece(6));
        }
    }

    public NPC?[,] makeMove(NPC?[,] board)
    {


        return board;
    }
}