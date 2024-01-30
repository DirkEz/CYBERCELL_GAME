using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    // Changed to GameObject because only the game object of the menu needs to be accessed, you can 
    // change this to any class that inherits MonoBehaviour
    public GameObject optionsMenu;

    // Update is called once per frame
    void Update()
    {
        bool isActive = optionsMenu.activeSelf;
        // Reverse the active state every time escape is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            if (optionsMenu.activeSelf)
            {
                // Check whether it's active / inactive 
                optionsMenu.SetActive(!isActive);
                Debug.Log("Options menu is active: " + optionsMenu.activeSelf);
                
            } else
            {
                optionsMenu.SetActive(isActive);
                Debug.Log("Options menu is inactive: " + optionsMenu.activeSelf);
            }

            
        }
    }
}