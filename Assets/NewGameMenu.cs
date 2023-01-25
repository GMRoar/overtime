using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGameMenu : MonoBehaviour
{  
    //enableMenu
    public GameObject NewGame;
    public GameObject NewGameWarning;
    public GameObject Options;
    public Button NewGameButton;
    public Button ContinueButton;

    void Start()
    {
        if (PlayerPrefs.GetInt("gameSaved") != 1)
        {
            ContinueButton.interactable = false;
        }
    }
    public void enableMenu()
   {
       if(NewGame != null && PlayerPrefs.GetInt("gameSaved") == 0)
       {
           NewGame.SetActive(true);
       }
       else if (NewGame != null && PlayerPrefs.GetInt("gameSaved") == 1)
       {
            NewGameWarning.SetActive(true);
       }
   }
    public void warningAgree()
    {
        NewGameWarning.SetActive(false);
        NewGame.SetActive(true);

    }

    public void warningDisagree()
    {
        NewGameWarning.SetActive(false);
    }

    public void enableOptionsMenu()
    {
        Options.SetActive(true);
    }

    public void Continue()
    {
        SceneManager.LoadScene("Level1");

    }

}


