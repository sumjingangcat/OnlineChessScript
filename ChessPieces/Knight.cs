using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece [,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        Debug.Log("x:"+currentX+"y:"+currentY);

        List<Vector2Int> knightMovement = new List<Vector2Int>();
        knightMovement.Add(new Vector2Int(1, 2));
        knightMovement.Add(new Vector2Int(-1, 2));
        knightMovement.Add(new Vector2Int(1, -2));
        knightMovement.Add(new Vector2Int(-1, -2));
        knightMovement.Add(new Vector2Int(2, 1));
        knightMovement.Add(new Vector2Int(-2, 1));
        knightMovement.Add(new Vector2Int(2, -1));
        knightMovement.Add(new Vector2Int(-2, -1));

        for (int i = 0; i < knightMovement.Count; i++)
        {
            Vector2Int k = knightMovement[i];
            int kX = k.x;
            int kY = k.y;
            
            if (!(currentX + kX > -1 && currentX + kX < tileCountX 
                && currentY + kY > -1 && currentY + kY < tileCountY))
                continue;
            
            r.Add(new Vector2Int(currentX + kX, currentY + kY));
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
