using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject Menu;
    public GameObject OptionsMenu;

    public GameObject Warning;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ContinueButton()
    {
        Menu.SetActive(false);
    }
    public void Options()
    {
        OptionsMenu.SetActive(true);
        FirstPersonMovement.movementSpeed = 0f;
    }
    private void Update()
    {
        Cursor.lockState = CursorLockMode.None;
        if (Input.GetButtonDown("Cancel"))
        {
            Menu.SetActive(false);
            OptionsMenu.SetActive(false);
            FirstPersonMovement.movementSpeed = 2.0f;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    public void ExitButton()
    {
        Warning.SetActive(true);
    }
    public void ExitButtonTrue()
    {
        Warning.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
    public void ExitButtonFalse()
    {
        Warning.SetActive(false);
    }
}
