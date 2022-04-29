using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameWinPrefab;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject hoverPiece;
    [SerializeField] GameObject canvas;

    List<Player> players = new List<Player>();
    Player currentPlayer;
    Board gameBoard = new Board();

    public void Start()
    {
        DisplayWin();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        currentPlayer = players[0];
        gameBoard = new Board();
        //update ui things
        GameObject go = GameObject.Find("WinScreen");
        Destroy(go);
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
        GameObject gameWin = Instantiate(gameWinPrefab, GameObject.FindWithTag("Canvas").transform);
        gameWin.name = "WinScreen";
    }

    //called from button with the x and y of the placement
    public void RunPlayerTurn(Vector2 placementLocation)
    {
        gameBoard.board[(int)placementLocation.y][(int)placementLocation.x] = currentPlayer.piece;
        bool hasWon = gameBoard.CheckWin(currentPlayer, placementLocation);
        if (hasWon) DisplayWin();
        else UpdatePlayerTurn();

    }

    public void UpdatePlayerTurn()
    {
        currentPlayer = players[(players.FindIndex(player => player == currentPlayer) == players.Count - 1) ? 0 : players.FindIndex(player => player == currentPlayer) + 1];
        //update ui things
    }

    public void OnLoadScene(string sceneName)
    {
        sceneLoader.Load(sceneName);
    }

}
