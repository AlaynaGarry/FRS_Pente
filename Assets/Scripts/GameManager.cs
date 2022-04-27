using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Player> players = new List<Player>();
    Player currentPlayer;
    Board gameBoard = new Board();

    public void Restart()
    {
        currentPlayer = players[0];
        gameBoard = new Board();
        //update ui thingse
    }

    public void DisplayWin()
    {

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
            new Vector2 (placementLocation.x - 2, placementLocation.y - 2),  new Vector2 (placementLocation.x, placementLocation.y - 2), new Vector2 (placementLocation.x + 2, placementLocation.y - 2),
            new Vector2 (placementLocation.x - 2, placementLocation.y),                                                                  new Vector2 (placementLocation.x + 2, placementLocation.y),
            new Vector2 (placementLocation.x - 2, placementLocation.y + 2),  new Vector2 (placementLocation.x, placementLocation.y - 2), new Vector2 (placementLocation.x + 2, placementLocation.y + 2),
        };
        List<int> indexOfValidPositionsToCheck = new List<int>();

        for (int position = 0; position < positionsToCheckForCurPlayerPiece.Length; position++)
        {
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

            bool hasCaptured =  IsPositionCaptured(placementLocation, positionOfOtherPiece, verticalChange, horizontalChange);

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
            for (int vert = (int)placementLocation.y + (verticalChange / 2); (verticalChange > 0) ? (vert >= positionOfOtherPiece.y) : (vert <= positionOfOtherPiece.y); vert += (verticalChange > 0) ? -1 : 1)
            {
                CheckForPiecesBeingCaptureable(ref hasCaptured, ref pieceType, (int)placementLocation.x, vert);
            }
        }
        else if (verticalChange == 0)
        {
            //independently will loop left or right in the board based on what the horizontalChange is
            for (int horziontal = (int)placementLocation.x + (horizontalChange / 2); (horizontalChange > 0) ? (horziontal >= positionOfOtherPiece.x) : (horziontal <= positionOfOtherPiece.x); horziontal += (horizontalChange > 0) ? -1 : 1)
            {
                CheckForPiecesBeingCaptureable(ref hasCaptured, ref pieceType, horziontal, (int)placementLocation.y);
            }
        }
        else
        {
            //independently will loop diagonally in the board based on what the horizontalChange and verticalChange are
            for (int horziontal = (int)placementLocation.x + (horizontalChange / 2), vert = (int)placementLocation.y + (verticalChange / 2);
                (horizontalChange > 0) ? (horziontal >= positionOfOtherPiece.x) : (horziontal <= positionOfOtherPiece.x)
                && (verticalChange > 0) ? (vert >= positionOfOtherPiece.y) : (vert <= positionOfOtherPiece.y);
                horziontal += (horizontalChange > 0) ? -1 : 1, vert += (verticalChange > 0) ? -1 : 1)
            {
                CheckForPiecesBeingCaptureable(ref hasCaptured, ref pieceType, horziontal, vert);
            }
        }

        return hasCaptured;
    }

    private void RemoveAppropriatePieces(Vector2 placementLocation, Vector2 positionOfOtherPiece, int verticalChange, int horizontalChange)
    {
        currentPlayer.captures += 2;

        if (horizontalChange == 0)
        {
            //independently will loop up or down in the board based on what the verticalChange is
            for (int vert = (int)placementLocation.y + (verticalChange / 2); (verticalChange > 0) ? (vert >= positionOfOtherPiece.y) : (vert <= positionOfOtherPiece.y); vert += (verticalChange > 0) ? -1 : 1)
            {
                gameBoard.board[vert][(int)placementLocation.x] = ePiece.NULL;
            }
        }
        else if (verticalChange == 0)
        {
            //independently will loop left or right in the board based on what the horizontalChange is
            for (int horziontal = (int)placementLocation.x + (horizontalChange / 2); (horizontalChange > 0) ? (horziontal >= positionOfOtherPiece.x) : (horziontal <= positionOfOtherPiece.x); horziontal += (horizontalChange > 0) ? -1 : 1)
            {
                gameBoard.board[(int)placementLocation.y][horziontal] = ePiece.NULL;

            }
        }
        else
        {
            //independently will loop diagonally in the board based on what the horizontalChange and verticalChange are
            for (int horziontal = (int)placementLocation.x + (horizontalChange / 2), vert = (int)placementLocation.y + (verticalChange / 2);
                (horizontalChange > 0) ? (horziontal >= positionOfOtherPiece.x) : (horziontal <= positionOfOtherPiece.x)
                && (verticalChange > 0) ? (vert >= positionOfOtherPiece.y) : (vert <= positionOfOtherPiece.y);
                horziontal += (horizontalChange > 0) ? -1 : 1, vert += (verticalChange > 0) ? -1 : 1)
            {
                gameBoard.board[vert][horziontal] = ePiece.NULL;

            }
        }
    }

    private void CheckForPiecesBeingCaptureable(ref bool hasCaptured, ref ePiece pieceType, int horziontal, int vert)
    {
        if (gameBoard.board[vert][horziontal] == ePiece.NULL && pieceType != ePiece.NULL) hasCaptured = false;
        else if (pieceType == ePiece.NULL) pieceType = gameBoard.board[vert][horziontal];
    }

    public bool CheckPlayerCaptureWin()
    {
        return currentPlayer.captures >= 10;
    }

    public void UpdatePlayerTurn()
    {
        currentPlayer = players[(players.FindIndex(player => player == currentPlayer) == players.Count - 1) ? 0 : players.FindIndex(player => player == currentPlayer) + 1];
        //update ui things
    }
}
