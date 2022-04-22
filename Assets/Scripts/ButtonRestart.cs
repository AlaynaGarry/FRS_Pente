using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRestart : MonoBehaviour
{
    public void CallRestart() {
        GameManager.Instance.Restart();
    }
}
