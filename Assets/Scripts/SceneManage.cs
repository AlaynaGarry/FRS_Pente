using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManage : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.Restart();
    }
}
