using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool gameOver;

    public static GameManager gameManager;

    private void Awake()
    {
        if (GameManager.gameManager != null && GameManager.gameManager != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager.gameManager = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        GameStarted();
    }

    public void YouLoseRoad()
    {
        gameOver = true;
    }

    public void GameStarted()
    {

    }
}
