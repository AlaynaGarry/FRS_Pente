using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject hoverPiece;
    [SerializeField] GameObject canvas;

    List<Player> players = new List<Player>();
    Player currentPlayer;
    Board gameBoard = new Board();



    public void Restart()
    {
        currentPlayer = players[0];
        gameBoard = new Board();
        //update ui things
        PopulateBoard();
    }

    public void PopulateBoard()
    {
        for (int x = 0; x < 19; x++)
        {
            for (int y = 0; y < 19; y++)
            {
                Instantiate(hoverPiece, new Vector3(x * 2.22f, y * -2.22f, 0), Quaternion.identity, canvas.transform);
            }
        }
    }

    public void DisplayWin()
    {

    }



    //called from button with the x and y of the placement
    public void RunPlayerTurn(Vector2 placementLocation)
    {
        gameBoard.board[(int)placementLocation.y][(int)placementLocation.x] = currentPlayer.piece;
        bool hasWon = gameBoard.CheckWin(currentPlayer, placementLocation);
        //var button = Instantiate<Piece>(piece, new Vector3(placementLocation.x * 2.22f, placementLocation.y * 2.22f,0), Quaternion.identity); 
        if (hasWon) DisplayWin();
        else UpdatePlayerTurn();

    }

    public void UpdatePlayerTurn()
    {
        currentPlayer = players[(players.FindIndex(player => player == currentPlayer) == players.Count - 1) ? 0 : players.FindIndex(player => player == currentPlayer) + 1];
        //update ui things
    }
}
