using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameObject gameWinObject;
    [SerializeField] SceneLoader sceneLoader;
    [SerializeField] GameObject hoverPiece;
    [SerializeField] public TextMeshProUGUI winPlayerNameObject;
    [SerializeField] public Image winPlayerColorObject;

    [SerializeField] public  List<Sprite> pieceTextures;
    public Player currentPlayer;
    public TextMeshProUGUI currentPlayerNameObject;
    public Image currentPlayerColorObject;
    public TextMeshProUGUI currentPlayerCaptureText;

    List<PhysicalPiece> boardPieces = new List<PhysicalPiece>();
    List<Player> players = new List<Player>();
    Board gameBoard = new Board();

    public void Start()
    {
        //DisplayWin();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        currentPlayer = players[0];
        gameBoard = new Board();
        currentPlayerNameObject.text = currentPlayer.name;
        currentPlayerColorObject.sprite = FindTextureFromEPiece(currentPlayer.piece);
        //update ui things
        if (gameWinObject != null)
        {
            gameWinObject.SetActive(false);
        }
        PopulateBoard();
    }

    public void PopulateBoard()
    {
        for (int x = 0; x < 19; x++)
        {
            for (int y = 0; y < 19; y++)
            {
                var piece = Instantiate(hoverPiece, new Vector3(x * 2.22f, y * -2.22f, 0), Quaternion.identity, GameObject.FindWithTag("Canvas").transform);
                piece.GetComponent<PhysicalPiece>().locationOnBoard = new Vector2(x, y);
                boardPieces.Add(piece.GetComponent<PhysicalPiece>());
            }
        }
    }

    public void SetupGame(List<Player> players)
    {
        this.players = players;
        OnLoadScene("TestBoard");
    }

    public void SetupGame()
    {
        gameWinObject.SetActive(false);
        boardPieces.ForEach(piece => Destroy(piece.gameObject));
        boardPieces.Clear();
        OnLoadScene("AutoLoadIntoBoard");

    }

    public void DisplayWin()
    {
        boardPieces.ForEach(piece => piece.hoverApplicable = false);
        winPlayerColorObject.sprite = FindTextureFromEPiece(currentPlayer.piece);
        winPlayerNameObject.text = currentPlayer.name;
        if (gameWinObject != null)
        {
            gameWinObject.SetActive(true);
        }
    }

    //called from button with the x and y of the placement
    public void RunPlayerTurn(Vector2 placementLocation)
    {
        gameBoard.board[(int)placementLocation.y][(int)placementLocation.x] = currentPlayer.piece;
        CheckForPlayerCapture(placementLocation);
        bool hasWon = gameBoard.CheckWin(currentPlayer, placementLocation) || CheckPlayerCaptureWin();
        if (hasWon) DisplayWin();
        else UpdatePlayerTurn();
    }

    public void CheckForPlayerCapture(Vector2 placementLocation)
    {
        Vector2[] positionsToCheckForCurPlayerPiece = new Vector2[] {
            new Vector2 (placementLocation.x - 3, placementLocation.y - 3),  new Vector2 (placementLocation.x, placementLocation.y - 3), new Vector2 (placementLocation.x + 3, placementLocation.y - 3),
            new Vector2 (placementLocation.x - 3, placementLocation.y),                                                                  new Vector2 (placementLocation.x + 3, placementLocation.y),
            new Vector2 (placementLocation.x - 3, placementLocation.y + 3),  new Vector2 (placementLocation.x, placementLocation.y + 3), new Vector2 (placementLocation.x + 3, placementLocation.y + 3),
        };
        List<int> indexOfValidPositionsToCheck = new List<int>();

        for (int position = 0; position < positionsToCheckForCurPlayerPiece.Length; position++)
        {
            if ((int)positionsToCheckForCurPlayerPiece[position].y < 0 || (int)positionsToCheckForCurPlayerPiece[position].y >= 19 || (int)positionsToCheckForCurPlayerPiece[position].x < 0 || (int)positionsToCheckForCurPlayerPiece[position].x >= 19) continue;
            if (gameBoard.board[(int)positionsToCheckForCurPlayerPiece[position].y][(int)positionsToCheckForCurPlayerPiece[position].x] == currentPlayer.piece)
            {
                indexOfValidPositionsToCheck.Add(position);
            }
        }

        foreach (var index in indexOfValidPositionsToCheck)
        {
            Vector2 positionOfOtherPiece = positionsToCheckForCurPlayerPiece[index];
            int verticalChange = (int)(placementLocation.y - positionOfOtherPiece.y);
            int horizontalChange = (int)(placementLocation.x - positionOfOtherPiece.x);

            bool hasCaptured = IsPositionCaptured(placementLocation, positionOfOtherPiece, verticalChange, horizontalChange);

            if (hasCaptured)
            {
                RemoveAppropriatePieces(placementLocation, positionOfOtherPiece, verticalChange, horizontalChange);
            }
        }
    }

    private bool IsPositionCaptured(Vector2 placementLocation, Vector2 positionOfOtherPiece, int verticalChange, int horizontalChange, bool hasCaptured = true)
    {
        ePiece pieceType = ePiece.NULL;
        if (horizontalChange == 0)
        {
            //independently will loop up or down in the board based on what the verticalChange is
            int verticalChangeForDivision = (verticalChange > 0) ? verticalChange - 1 : verticalChange + 1;
            for (int vert = (int)placementLocation.y - (verticalChangeForDivision / 2);
                (verticalChange > 0) ? (vert > positionOfOtherPiece.y) : (vert < positionOfOtherPiece.y);
                vert += (verticalChange > 0) ? -1 : 1)
            {
                CheckForPiecesBeingCaptureable(ref hasCaptured, ref pieceType, (int)placementLocation.x, vert);
            }
        }
        else if (verticalChange == 0)
        {
            int horizontalChangeForDivision = (horizontalChange > 0) ? horizontalChange-1 : horizontalChange + 1;

            //independently will loop left or right in the board based on what the horizontalChange is
            for (int horziontal = (int)placementLocation.x - (horizontalChangeForDivision / 2); (horizontalChange > 0) ? (horziontal > positionOfOtherPiece.x) : (horziontal < positionOfOtherPiece.x); horziontal += (horizontalChange > 0) ? -1 : 1)
            {
                CheckForPiecesBeingCaptureable(ref hasCaptured, ref pieceType, horziontal, (int)placementLocation.y);
            }
        }
        else
        {
            //independently will loop diagonally in the board based on what the horizontalChange and verticalChange are
            int horizontalChangeForDivision = (horizontalChange > 0) ? horizontalChange - 1 : horizontalChange + 1;
            int verticalChangeForDivision = (verticalChange > 0) ? verticalChange - 1 : verticalChange + 1;
            bool horizontalCondition = horizontalChange > 0;
            bool verticalCondition = (verticalChange > 0);
            for (int horziontal = (int)placementLocation.x - (horizontalChangeForDivision / 2), vert = (int)placementLocation.y - (verticalChangeForDivision / 2);
                horizontalCondition ? (horziontal > positionOfOtherPiece.x) : (horziontal < positionOfOtherPiece.x)
                && verticalCondition ? (vert > positionOfOtherPiece.y) : (vert < positionOfOtherPiece.y);
                horziontal += horizontalCondition ? -1 : 1, vert += verticalCondition ? -1 : 1)
            {
                CheckForPiecesBeingCaptureable(ref hasCaptured, ref pieceType, horziontal, vert);
            }
        }

        return hasCaptured;
    }


    private void CheckForPiecesBeingCaptureable(ref bool hasCaptured, ref ePiece pieceType, int horziontal, int vert)
    {
        if (vert >= 19 || horziontal >= 19 || vert < 0 || horziontal < 0) return;
        if ((gameBoard.board[vert][horziontal] == ePiece.NULL && pieceType != ePiece.NULL) || gameBoard.board[vert][horziontal] == currentPlayer.piece) hasCaptured = false;
        else if (pieceType == ePiece.NULL) pieceType = gameBoard.board[vert][horziontal];
    }
    
    private void RemoveAppropriatePieces(Vector2 placementLocation, Vector2 positionOfOtherPiece, int verticalChange, int horizontalChange)
    {
        currentPlayer.captures += 2;

        if (horizontalChange == 0)
        {
            int verticalChangeForDivision = (verticalChange > 0) ? verticalChange - 1 : verticalChange + 1;
            //independently will loop up or down in the board based on what the verticalChange is
            for (int vert = (int)placementLocation.y - (verticalChangeForDivision / 2); (verticalChange > 0) ? (vert > positionOfOtherPiece.y) : (vert < positionOfOtherPiece.y); vert += (verticalChange > 0) ? -1 : 1)
            {
                gameBoard.board[vert][(int)placementLocation.x] = ePiece.NULL;
                foreach(var piece in boardPieces)
                {
                    if (piece.locationOnBoard.Equals(new Vector2(placementLocation.x, vert)))
                    {
                        piece.RemovePiece();
                    }
                }
            }
        }
        else if (verticalChange == 0)
        {
            int horizontalChangeForDivision = (horizontalChange > 0) ? horizontalChange-1 : horizontalChange + 1;
            //independently will loop left or right in the board based on what the horizontalChange is
            for (int horziontal = (int)placementLocation.x - (horizontalChangeForDivision / 2); 
                (horizontalChange > 0) ? (horziontal > positionOfOtherPiece.x) : (horziontal < positionOfOtherPiece.x); 
                horziontal += (horizontalChange > 0) ? -1 : 1)
            {
                gameBoard.board[(int)placementLocation.y][horziontal] = ePiece.NULL;
                foreach (var piece in boardPieces)
                {
                    if (piece.locationOnBoard.Equals(new Vector2(horziontal, placementLocation.y)))
                    {
                        piece.RemovePiece();
                    }
                }
            }
        }
        else
        {
            int horizontalChangeForDivision = (horizontalChange > 0) ? horizontalChange-1 : horizontalChange + 1;
            int verticalChangeForDivision = (verticalChange > 0) ? verticalChange - 1 : verticalChange + 1;
            bool horizontalCondition = horizontalChange > 0;
            bool verticalCondition = (verticalChange > 0);
            //independently will loop diagonally in the board based on what the horizontalChange and verticalChange are
            for (int horziontal = (int)placementLocation.x - (horizontalChangeForDivision / 2), vert = (int)placementLocation.y - (verticalChangeForDivision / 2);
                horizontalCondition ? (horziontal > positionOfOtherPiece.x) : (horziontal < positionOfOtherPiece.x)
                && verticalCondition ? (vert > positionOfOtherPiece.y) : (vert < positionOfOtherPiece.y);
                horziontal += horizontalCondition ? -1 : 1, vert += verticalCondition ? -1 : 1)
            {
                gameBoard.board[vert][horziontal] = ePiece.NULL;
                foreach (var piece in boardPieces)
                {
                    if (piece.locationOnBoard.Equals(new Vector2(horziontal, vert)))
                    {
                        piece.RemovePiece();
                    }
                }
            }
        }
    }

    public bool CheckPlayerCaptureWin()
    {
        return currentPlayer.captures >= 10;
    }

    public void UpdatePlayerTurn()
    {
        currentPlayer = players[(players.FindIndex(player => player == currentPlayer) == players.Count - 1) ? 0 : players.FindIndex(player => player == currentPlayer) + 1];
        //update ui things
        currentPlayerNameObject.text = currentPlayer.name;
        currentPlayerColorObject.sprite = FindTextureFromEPiece(currentPlayer.piece);
        currentPlayerCaptureText.text = $"Current Player\nCaptures: {currentPlayer.captures}";
    }

    public void OnLoadScene(string sceneName)
    {
        gameWinObject.SetActive(false);
        sceneLoader.Load(sceneName);
    }


    public Sprite FindTextureFromEPiece(ePiece type)
    {
        Sprite result = null;
        switch (type)
        {
            case ePiece.BLACK:
                result = pieceTextures[0];
                break;
            case ePiece.BLUE:
                result = pieceTextures[1];
                break;
            case ePiece.GREEN:
                result = pieceTextures[2];
                break;
            case ePiece.ORANGE:
                result = pieceTextures[3];
                break;
            case ePiece.PURPLE:
                result = pieceTextures[4];
                break;
            case ePiece.RED:
                result = pieceTextures[5];
                break;
            case ePiece.WHITE:
                result = pieceTextures[6];
                break;
            case ePiece.YELLOW:
                result = pieceTextures[7];
                break;
            default:
                break;
        }
        return result;
    }
}
