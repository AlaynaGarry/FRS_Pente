using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneManage : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI playerNameText;
    [SerializeField] Image playerColorImage;
    [SerializeField] TextMeshProUGUI currentPlayerCaptureText;


    private void Awake()
    {
        GameManager.Instance.currentPlayerNameObject = playerNameText;
        GameManager.Instance.currentPlayerColorObject = playerColorImage;
        GameManager.Instance.currentPlayerCaptureText = currentPlayerCaptureText;
        GameManager.Instance.Restart();
    }

    public void Restart()
    {
        GameManager.Instance.SetupGame();
    }
}
