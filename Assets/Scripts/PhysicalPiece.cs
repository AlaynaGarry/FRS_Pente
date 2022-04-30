using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalPiece : MonoBehaviour
{
    [SerializeField] GameObject piece;
    public Vector2 locationOnBoard;
    public bool hoverApplicable = true;


    public void PlacePiece()
    {
        if (hoverApplicable)
        {
            piece.GetComponent<Image>().sprite = GameManager.Instance.FindTextureFromEPiece(GameManager.Instance.currentPlayer.piece);
            piece.GetComponent<Image>().color = new Color(piece.GetComponent<Image>().color.r, piece.GetComponent<Image>().color.b, piece.GetComponent<Image>().color.g, 1);
            hoverApplicable = false;
            GameManager.Instance.RunPlayerTurn(locationOnBoard);
        }
    }

    public void RemovePiece()
    {
        piece.GetComponent<Image>().sprite = GameManager.Instance.pieceTextures[8];
        piece.GetComponent<Image>().color = new Color(piece.GetComponent<Image>().color.r, piece.GetComponent<Image>().color.b, piece.GetComponent<Image>().color.g, 0);
        hoverApplicable = true;
    }

    public void HoverOverPiece()
    {
        if (!hoverApplicable) return;
        var color = piece.GetComponent<Image>().color;

        color = new Color(color.r, color.g, color.b, 0.5f);

        piece.GetComponent<Image>().color = color;
        //Debug.Log("am here");
    }

    public void ExitHover()
    {
        if (!hoverApplicable) return;
        var color = piece.GetComponent<Image>().color;

        color = new Color(color.r, color.g, color.b, 0);

        piece.GetComponent<Image>().color = color;
        //Debug.Log("am gone");
    }
}
