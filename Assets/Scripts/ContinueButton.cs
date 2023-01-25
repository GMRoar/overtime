using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueButton : MonoBehaviour
{
    public GameObject TitleScreen;
    public GameObject MainMenu;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Submit")){
            TitleScreen.SetActive(false);
            MainMenu.SetActive(true);
        }

    }
}
