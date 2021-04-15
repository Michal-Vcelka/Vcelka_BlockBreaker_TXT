using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f, 10f)][SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 2;

    [SerializeField] int currentScore = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    [SerializeField] Player player;
    // player sa nám bude starať o prepojenie mena na skript Player.cs
    [SerializeField] InputField playerName;
    //playerName je prepojenie na náš InputField, do ktorého používateľ zadá svoje men

    //GameData playerData;
    SceneLoader sceneLoader;
    GameObject PlayerInputMenu;

    public float GetGameSpeed()
    { 
        return gameSpeed; 
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
    }

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;

        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    
    private void OnEnable()
    {
        Debug.Log("OnEnable");
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        string tempString = Convert.ToString(currentScore);
        player.PlayerScore = tempString;

        if (scene.name.Contains("Level"))
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = currentScore.ToString();

            player.PlayerLevel = scene.name;
        }
        else
        {
            scoreText.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (!PauseMenu.isGamePaused)
        {
            Time.timeScale = gameSpeed;
        }
    }

    public void GetPlayerNameInput()
    {
        var playerNameInput = playerName.GetComponent<InputField>();
        player.PlayerName = playerNameInput.text;
        Debug.Log("meno je " + playerNameInput.text);
        playerNameInput.text = "";

        Destroy(PlayerInputMenu);
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
        player.PlayerScore = currentScore.ToString();
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
