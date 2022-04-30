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
        int count = 1;
        for (int i = ((int)position.y) + 1; i < position.y + 6 && i < board.Length; i++)
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
        for (int i = ((int)position.y) - 1; i > position.y - 6 && i >= 0; i--)
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
        int count = 1;
        for (int i = ((int)position.x) + 1; i < position.x + 6 && i < board.Length; i++)
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
        for (int i = ((int)position.x) - 1; i > position.x - 6 && i >= 0; i--)
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
        int count = 1;
        for (int i = ((int)position.x) + 1, j = ((int)position.y) + 1; i < position.x + 6 && j < position.y + 6 && i < board.Length && j < board.Length; i++, j++)
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

        for (int i = ((int)position.x) - 1, j = ((int)position.y) - 1; i > position.x - 6 && j > position.y - 6 && i >= 0 && j >= 0; i--, j--)
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

        count = 1;
        for (int i = ((int)position.x) - 1, j = ((int)position.y) + 1; i > position.x - 6 && j < position.y + 6 && i >= 0 && j < board.Length; i--, j++)
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

        for (int i = ((int)position.x) + 1, j = ((int)position.y) - 1; i < position.x + 6 && j > position.y - 6 && i < board.Length && j >= 0; i++, j--)
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
