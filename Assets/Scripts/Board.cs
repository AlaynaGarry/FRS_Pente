using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    public ePiece[][] board = new ePiece[][]
    {
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL },
        new ePiece[]{ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL,ePiece.NULL }
    };

    

    public bool CheckWin(Player player, Vector2 placementPosition)
    {
        return checkDiagonalFromPosition(player, placementPosition) || checkHorizontalFromPosition(player, placementPosition) || checkVerticalFromPosition(player, placementPosition);
    }

    private bool checkVerticalFromPosition(Player player, Vector2 position)
    {
        int count = 0;
        for (int i = ((int)position.y); i < position.y + 5 && i < board.Length; i++)
        {
            if (board[i][((int)position.x)] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }
        for (int i = ((int)position.y); i < position.y - 5; i--)
        {
            if (board[i][((int)position.x)] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }
        return false;
    }

    private bool checkHorizontalFromPosition(Player player, Vector2 position)
    {
        int count = 0;
        for (int i = ((int)position.x); i < position.x + 5; i++)
        {
            if (board[((int)position.y)][i] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }
        for (int i = ((int)position.x); i < position.x - 5; i--)
        {
            if (board[((int)position.y)][i] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }
        return false;
    }

    private bool checkDiagonalFromPosition(Player player, Vector2 position)
    {
        int count = 0;
        for (int i = ((int)position.x), j = ((int)position.y); i < position.x + 5 && j < position.y + 5; i++, j++)
        {
            if (board[j][i] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }

        for (int i = ((int)position.x), j = ((int)position.y); i < position.x - 5 && j < position.y - 5; i--,j--)
        {
            if (board[j][i] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }

        count = 0;
        for (int i = ((int)position.x), j = ((int)position.y); i < position.x - 5 && j < position.y + 5; i--,j++)
        {
            if (board[j][i] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }

        for (int i = ((int)position.x), j = ((int)position.y); i < position.x + 5 && j < position.y - 5; i++, j--)
        {
            if (board[j][i] != player.piece)
            {
                break;
            }
            else
            {
                count++;
                if (count >= 5) return true;
            }
        }

        return false;
    }
}
