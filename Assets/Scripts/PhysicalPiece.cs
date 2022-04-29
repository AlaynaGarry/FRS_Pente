using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalPiece : MonoBehaviour
{
    [SerializeField] GameObject piece;
    public Vector2 locationOnBoard;
    bool hoverApplicable = true;


    public void PlacePiece()
    {
        if (hoverApplicable)
        {
            GameManager.Instance.RunPlayerTurn(locationOnBoard);
            piece.GetComponent<Image>().sprite = FindTextureFromEPiece(GameManager.Instance.currentPlayer.piece);
            piece.GetComponent<Image>().color = new Color(piece.GetComponent<Image>().color.r, piece.GetComponent<Image>().color.b, piece.GetComponent<Image>().color.g, 1);
            hoverApplicable = false;
        }

    }

    public Sprite FindTextureFromEPiece(ePiece type)
    {
        Sprite result = null;
        switch (type)
        {
            case ePiece.BLACK:
                result = GameManager.Instance.pieceTextures[0];
                break;
            case ePiece.BLUE:
                result = GameManager.Instance.pieceTextures[1];
                break;
            case ePiece.GREEN:
                result = GameManager.Instance.pieceTextures[2];
                break;
            case ePiece.ORANGE:
                result = GameManager.Instance.pieceTextures[3];
                break;
            case ePiece.PURPLE:
                result = GameManager.Instance.pieceTextures[4];
                break;
            case ePiece.RED:
                result = GameManager.Instance.pieceTextures[5];
                break;
            case ePiece.WHITE:
                result = GameManager.Instance.pieceTextures[6];
                break;
            case ePiece.YELLOW:
                result = GameManager.Instance.pieceTextures[7];
                break;
            default:
                break;
        }
        return result;
    }
    
    public void HoverOverPiece()
    {
        if (!hoverApplicable) return;
        var color = piece.GetComponent<Image>().color;

        color = new Color(color.r, color.g, color.b, 0.5f);

        piece.GetComponent<Image>().color = color;
        Debug.Log("am here");
    }

    public void ExitHover()
    {
        if (!hoverApplicable) return;
        var color = piece.GetComponent<Image>().color;

        color = new Color(color.r, color.g, color.b, 0);

        piece.GetComponent<Image>().color = color;
        Debug.Log("am gone");
    }
}
