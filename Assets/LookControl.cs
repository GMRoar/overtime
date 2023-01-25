using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookControl : MonoBehaviour
{
    public static float sensitivity;
    public Transform player;
    public GameObject pauseMenu;
    public GameObject tutorialActive;
    public GameObject finishedMenu;

    float xRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        sensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }
    // Update is called once per frame
    void Update()
    {
        if (tutorialActive.activeSelf)
        { 
            Cursor.lockState = CursorLockMode.None;
        }
        else if (finishedMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
        }
        else if (!pauseMenu.activeSelf)
        {
            Cursor.lockState = CursorLockMode.Locked;
            float mouseX = Input.GetAxis("Mouse X") * sensitivity;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            player.Rotate(Vector3.up * mouseX);
        }
        

        
    }
}
