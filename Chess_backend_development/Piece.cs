namespace ChessBackendDevelopment;

using System;

public class Piece
{
    public int pieceType;
    public string ?name;
    public int x;
    public int y;

    public Piece(int pieceType, (int, int) location)
    {
        this.pieceType = pieceType;
        this.x = location.Item1;
        this.y = location.Item2;

        switch (pieceType)
        {
            case 1: this.name = "King"; break;
            case 2: this.name = "Queen"; break;
            case 3: this.name = "Rook"; break;
            case 4: this.name = "Bishop"; break;
            case 5: this.name = "Knight"; break;
            case 6: this.name = "Pawn"; break;
            default: break;
        }
    }

}