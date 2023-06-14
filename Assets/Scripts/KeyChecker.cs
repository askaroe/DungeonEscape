using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyChecker : MonoBehaviour
{
    public bool winGame = false;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if(GameManager.Instance.HasKeyToCastle == true)
            {
                UIManager.Instance.WinGame();
            }
        }
    }
}
