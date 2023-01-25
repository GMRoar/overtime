using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadSavedSettings : MonoBehaviour
{
    public GameObject OptionsMenu;
    // Start is called before the first frame update
    void Start()
    {
        OptionsMenu.SetActive(true);
    }
    void Update()
    {
        OptionsMenu.SetActive(false);
    }

}
