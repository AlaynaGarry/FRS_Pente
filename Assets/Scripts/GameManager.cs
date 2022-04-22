using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    List<Player> players = new List<Player>();
    [SerializeField] GameObject gameWinPrefab;

    public void Restart()
    {
    
    }

    public void DisplayWin()
    {
        GameObject gameWin = Instantiate(gameWinPrefab, GameObject.FindWithTag("Canvas").transform);
    }
}
