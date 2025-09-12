namespace ChessBackendDevelopment;

using System;

public class Piece
{
    public int pieceType;
    public string ?name;

    public Piece(int pieceType)
    {
        this.pieceType = pieceType;

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