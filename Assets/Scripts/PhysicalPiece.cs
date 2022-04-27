using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhysicalPiece : MonoBehaviour
{
    [SerializeField] GameObject piece;

    public void HoverOverPiece()
    {
        var color = piece.GetComponent<Image>().color;

        color = new Color(color.r, color.g, color.b, 0.5f);

        piece.GetComponent<Image>().color = color;
        Debug.Log("am here");
    }

    public void ExitHover()
    {
        var color = piece.GetComponent<Image>().color;

        color = new Color(color.r, color.g, color.b, 0);

        piece.GetComponent<Image>().color = color;
        Debug.Log("am gone");
    }
}
