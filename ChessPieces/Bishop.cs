using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece [,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();
        int bound;

        Debug.Log("x:"+currentX+"y:"+currentY);
        
        // if (tileCountX - currentX > tileCountY - currentY)
        //     bound = tileCountY - currentY;
        // else
        //     bound = tileCountX - currentX;

        bound = (tileCountX - currentX > tileCountY - currentY) ? tileCountY - currentY : tileCountX - currentX;
        for (int i = 1; i < bound; i++)
        {
            r.Add(new Vector2Int(currentX + i, currentY + i));
            if(board[currentX + i, currentY + i] != null)
                break;
        }

        bound = (tileCountX - currentX > currentY + 1) ? currentY + 1: tileCountX - currentX;
        for (int i = 1; i < bound; i++)
        {
            r.Add(new Vector2Int(currentX + i, currentY - i));
            if(board[currentX + i, currentY - i] != null)
                break;
        }

        bound = (currentX + 1 > tileCountY - currentY) ? tileCountY - currentY : currentX + 1;
        for (int i = 1; i < bound; i++)
        {
            r.Add(new Vector2Int(currentX - i, currentY + i));
            if(board[currentX - i, currentY + i] != null)
                break;
        }

        bound = (currentX + 1 > currentY + 1) ? currentY + 1 : currentX + 1;
        for (int i = 1; i < bound; i++)
        {
            r.Add(new Vector2Int(currentX - i, currentY - i));
            if(board[currentX - i, currentY - i] != null)
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
