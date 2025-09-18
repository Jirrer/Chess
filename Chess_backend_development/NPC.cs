namespace ChessBackendDevelopment;

using System;

public class NPC
{
    public int color;
    public Piece?[] pieces = new Piece?[16];
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
            this.pieces[0] = new Piece(1, (0,4));
            this.pieces[1] = new Piece(2, (0,3));
            this.pieces[2] = new Piece(3, (0, 2));
            this.pieces[3] = new Piece(3, (0, 5));
            this.pieces[4] = new Piece(4, (0, 1));
            this.pieces[5] = new Piece(4, (0, 6));
            this.pieces[6] = new Piece(5, (0, 0));
            this.pieces[7] = new Piece(5, (0, 7));
            this.pieces[8] = new Piece(6, (1, 0));
            this.pieces[9] = new Piece(6, (1, 1));
            this.pieces[10] = new Piece(6, (1, 2));
            this.pieces[11] = new Piece(6, (1, 3));
            this.pieces[12] = new Piece(6, (1, 4));
            this.pieces[13] = new Piece(6, (1, 5));
            this.pieces[14] = new Piece(6, (1, 6));
            this.pieces[15] = new Piece(6, (1, 7));
        }

        else if (this.color == 1)
        {
            this.pieces[0] = new Piece(1, (7,4));
            this.pieces[1] = new Piece(2, (7,3));
            this.pieces[2] = new Piece(3, (7, 2));
            this.pieces[3] = new Piece(3, (7, 5));
            this.pieces[4] = new Piece(4, (7, 1));
            this.pieces[5] = new Piece(4, (7, 6));
            this.pieces[6] = new Piece(5, (7, 0));
            this.pieces[7] = new Piece(5, (7, 7));
            this.pieces[8] = new Piece(6, (6, 0));
            this.pieces[9] = new Piece(6, (6, 1));
            this.pieces[10] = new Piece(6, (6, 2));
            this.pieces[11] = new Piece(6, (6, 3));
            this.pieces[12] = new Piece(6, (6, 4));
            this.pieces[13] = new Piece(6, (6, 5));
            this.pieces[14] = new Piece(6, (6, 6));
            this.pieces[15] = new Piece(6, (6, 7));
        }
    }

    public void removePiece(int x, int y)
    {
        for (int index = 0; index < 16; index++)
        {
            if (this.pieces[index].x == x && this.pieces[index].y == y)
            {
                this.pieces[index] = null;
            }
        }
    }

    public void makeMove((NPC?, int)[,] board)
    {
        // need to determine move here
        if (this.color == 0)
        {
            this.pieces[0].x = 7;
            this.pieces[0].y = 5;

        }
        else
        {
            this.pieces[4].x = 5;
            this.pieces[4].y = 1;
        }





    }
}