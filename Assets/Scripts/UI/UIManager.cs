using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    private static UIManager _instance;

    public static UIManager Instance
    {
        get
        {
            if(_instance == null)
            {
                Debug.LogError("Intance is NULL!");
            }
            return _instance;
        }
    }

    public Text playerGemCountText;
    public Image selectionImage;
    public Text gemCountText;
    public Image[] healthBar;
    public GameObject gameOverScreen;
    public GameObject hud;
    public GameObject winGameScreen;

    private void Awake()
    {
        _instance = this;
    }

    public void OpenShop(int gemCount)
    {
        playerGemCountText.text = "" + gemCount + "G";
    }

    public void UpdateShopSelection(int yPos)
    {
        selectionImage.rectTransform.anchoredPosition = new Vector2(selectionImage.rectTransform.anchoredPosition.x, yPos);
    }

    public void UpdateGemCount(int gemCount)
    {
        gemCountText.text = "" + gemCount;
    }

    public void UpdateLives(int livesRemaining)
    {
        for(int i = 0; i <= livesRemaining; i++)
        {
            if(i == livesRemaining)
            {
                healthBar[i].enabled = false;
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GameOverSequence()
    {
        gameOverScreen.SetActive(true);
        hud.SetActive(false);
    }

    public void WinGame()
    {
        winGameScreen.SetActive(true);
    }

}
