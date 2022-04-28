using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerSetup : MonoBehaviour
{
    [SerializeField] TMP_InputField numOfPlayers;
    [SerializeField] List<GameObject> playerNames;
    [SerializeField] List<Button> pieceColors;
    [SerializeField] List<Sprite> pieceTextures;

    private void Start()
    {
        UpdateShownPlayerSlots();
    }

    public void SetupGame()
    {
        List<Player> players = new List<Player>();

        if(int.TryParse(numOfPlayers.text, out int numPlayers) && ValidSetup(numPlayers))
        {
            for(int i = 0; i < numPlayers; i++)
            {
                players.Add(new Player());
                players[i].name = playerNames[i].GetComponentInChildren<TMP_InputField>().text;
                players[i].piece = FindePieceFromTexture(pieceColors[i].GetComponent<Image>().sprite);
                players[i].captures = 0;
            }
            GameManager.Instance.SetupGame(players);
        }
    }

    public bool ValidSetup(int numberPlayers)
    {
        for(int i = 0; i < numberPlayers; i++)
        {
            if (string.IsNullOrEmpty(playerNames[i].GetComponentInChildren<TMP_InputField>().text)) return false;
            for(int j = i + 1; j < numberPlayers; j++)
            {
                if (pieceColors[i].GetComponent<Image>().sprite == pieceColors[j].GetComponent<Image>().sprite) return false;
            }
        }

        return true;
    }

    public ePiece FindePieceFromTexture(Sprite sprite)
    {
        ePiece result = ePiece.NULL;
        switch (sprite.name)
        {
            case "Black":
                result = ePiece.BLACK;
                break;
            case "Blue":
                result = ePiece.BLUE;
                break;
            case "Green":
                result = ePiece.GREEN;
                break;
            case "Orange":
                result = ePiece.ORANGE;
                break;
            case "Purple":
                result = ePiece.PURPLE;
                break;
            case "Red":
                result = ePiece.RED;
                break;
            case "White":
                result = ePiece.WHITE;
                break;
            case "Yellow":
                result = ePiece.YELLOW;
                break;
            default:
                break;
        }
        return result;
    }

    public void ChangeColor(int playerIndex)
    {
        for(int i = 0; i < pieceTextures.Count; i++)
        {
            if(pieceColors[playerIndex].GetComponent<Image>().sprite == pieceTextures[i])
            {
                pieceColors[playerIndex].GetComponent<Image>().sprite = pieceTextures[(i == pieceTextures.Count - 1) ? 0 : i + 1];
                break;
            }
        }
    }

    public void UpdateShownPlayerSlots()
    {
        if (int.TryParse(numOfPlayers.text, out int numPlayers))
        {
            for (int i = 0; i < numPlayers; i++)
            {
                playerNames[i].gameObject.SetActive(true);
            }
            for (int i = numPlayers; i < playerNames.Count; i++)
            {
                playerNames[i].gameObject.SetActive(false);
            }
        }
    }

    public void LimitNumOfPlayersInput()
    {
        string newValue = numOfPlayers.text;
        if (string.IsNullOrEmpty(newValue)) return;
        if (int.Parse(newValue) > 8 || int.Parse(newValue) < 2)
        {
            numOfPlayers.text = ((int)Mathf.Clamp(int.Parse(newValue), 2, 8)).ToString();
        }
    }
}
