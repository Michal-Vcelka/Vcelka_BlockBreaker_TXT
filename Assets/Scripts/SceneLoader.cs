using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] SaveSystem saveSystem;

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
       
        if(currentSceneIndex == 0) { FindObjectOfType<GameStatus>().GetPlayerNameInput(); }
        
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        //FindObjectOfType<GameStatus>().ResetGame();
    }
    
    //---------------------------------------------------------//
    
    public void LoadSavedScene(string scene)
    {
        SceneManager.LoadScene(player.playerLevel);
    }
    //tento úsek som nakoniec nepoužil, ale nechal som si to tu pre prípad
    /*
    public string GetActiveScene()
    {
        return SceneManager.GetActiveScene().name;
    }
    */
    //---------------------------------------------------------//
    public void QuitGame()
    {
        Application.Quit();
    }
}
