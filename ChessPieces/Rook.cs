using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rook : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece [,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        Debug.Log("x:"+currentX+"y:"+currentY);

        for (int i = currentX; i < tileCountX; i++)
        {  
            r.Add(new Vector2Int(i, currentY));
            if(i != currentX)
                if(board[i, currentY] != null)
                    break;
        }
        for (int i = currentX; i > -1; i--)
        {  
            r.Add(new Vector2Int(i, currentY));
            if(i != currentX)
                if(board[i, currentY] != null)
                    break;
        }
        for (int i = currentY; i < tileCountY; i++)
        {  
            r.Add(new Vector2Int(currentX, i));
            if(i != currentY)
                if(board[currentX, i] != null)
                    break;
        }
        for (int i = currentY; i > -1; i--)
        {  
            r.Add(new Vector2Int(currentX, i));
            if(i != currentY)
                if(board[currentX, i] != null)
                    break;
        }

        for (int i = 0; i < r.Count; i++)
        {
            if (board[r[i].x, r[i].y] == null)
                continue;

            if (board[r[i].x, r[i].y].team == team)
            {
                r.RemoveAt(i);
                i--;
            }
        }

        return r;
    }
}
