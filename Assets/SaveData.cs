using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Linq;

public class SaveData : MonoBehaviour
{
    // This script saves the player data to the PlayerPrefs file, which stores preferences for Unity. In a case where sensitive information or large amounts of informations
    // needs to be stored, this should not be done within the PlayerPrefs file. However, due to the small amount of information I need to store for this game, PlayerPrefs should be 
    // fine, and adequate for the job. The only down side to using the PlayerPrefs file is it opens the ability for players to cheat and modify this data, however, this is not neccessarily an issue
    // as the game is an offline single player game, and if the player chooses to cheat, it is up to them.
    public TMP_InputField playerName;
    public int gameDifficulty;
    public int playerLevel;
    public int playerMoney;
    public int gameSaved;
    public int doTutorial;
    private Scene scene;

    //Toggles
    public ToggleGroup toggleGroup;

    void Start()
    {
        scene = SceneManager.GetActiveScene();
    }
    public Toggle selection
    {
        get { return toggleGroup.ActiveToggles().FirstOrDefault(); }
    }
    public void commitSave()
    {
        if (scene.name == "MainMenu")
        {
            if (gameSaved != 1)
            {
                gameSaved = 1;
                doTutorial = 1;
                playerLevel = 1;
            }
            else { doTutorial = 0; }

            if (selection.name == "Learning")
            {
                gameDifficulty = 1;
            }
            else if (selection.name == "Competent")
            {
                gameDifficulty = 2;
            }
            else if (selection.name == "Expert")
            {
                gameDifficulty = 3;
            }

        }
            // Data saved to the PlayerPrefs file
        PlayerPrefs.SetString("playerName", playerName.text);
        PlayerPrefs.SetInt("gameDifficulty", gameDifficulty);
        PlayerPrefs.SetInt("playerLevel", playerLevel);
        PlayerPrefs.SetInt("playerMoney", playerMoney);
        PlayerPrefs.SetInt("gameSaved", gameSaved);
        PlayerPrefs.SetInt("doTutorial", doTutorial);
        // Save the PlayerPrefs
        PlayerPrefs.Save();
        

    }
    public void printDebug()
    {
        Debug.Log(PlayerPrefs.GetString("playerName"));
        Debug.Log(PlayerPrefs.GetInt("gameDifficulty"));
        Debug.Log(PlayerPrefs.GetInt("playerLevel"));
        Debug.Log(PlayerPrefs.GetInt("playerMoney"));
        Debug.Log(PlayerPrefs.GetFloat("masterVolume"));

    }

    public void StartGame()
    {
        PlayerPrefs.Save();
        SceneManager.LoadScene("Level1");
    }

}
