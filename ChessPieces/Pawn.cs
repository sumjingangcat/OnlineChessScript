using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : ChessPiece
{
    public override List<Vector2Int> GetAvailableMoves(ref ChessPiece [,] board, int tileCountX, int tileCountY)
    {
        List<Vector2Int> r = new List<Vector2Int>();

        Debug.Log("x:"+currentX+"y:"+currentY);

		// 팀에 따른 움직이는 방향
        int direction = team == 0 ? 1 : -1;
		
        if (currentY + direction > -1 && currentY + direction < tileCountY)
            if(board[currentX, currentY + direction] == null)
                r.Add(new Vector2Int(currentX, currentY + direction));
			// 폰이 시작 지점에 있을 경우
            if (oneStep)
                r.Add(new Vector2Int(currentX, currentY + direction * 2));
			// x 범위 벗어남 체크
            if (currentX - 1 > -1 && currentX + 1 < tileCountX)
				// 대각선 체크
                if (board[currentX - 1, currentY + direction] != null)
                    r.Add(new Vector2Int(currentX - 1, currentY + direction));
                if (board[currentX + 1, currentY + direction] != null)
                    r.Add(new Vector2Int(currentX + 1, currentY + direction));
        
				// team 체크, 같은 팀이면 움직일 수 있음에서 제외
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