using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI;
//using TMPro;

public class NumberWizard : MonoBehaviour
{
    [SerializeField] int max;
    [SerializeField] int min;
    [SerializeField] Text Text = null;
    //[SerializeField] TextMeshProUGUI guessText;
    [SerializeField] Button higherButton = null;
    [SerializeField] Button lowerButton = null;

    int guess;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        NextGuess();
    }

    public void OnPressHigher()
    {
        if (max != guess)
        {
            min = guess + 1;
            NextGuess();
        }
    }

    public void OnPressLower()
    {
        if (max != guess)
        {
            max = guess - 1;
            NextGuess();
        }
    }

    public void NextGuess()
    {
        if (max - min >= 0)
        {
            guess = Random.Range(min, max + 1);
            Text.text = guess.ToString();
        }
        else
        {
            higherButton.interactable = false;
            lowerButton.interactable = false;
        }
    }
}