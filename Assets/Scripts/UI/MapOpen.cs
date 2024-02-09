using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapOpen : MonoBehaviour
{
    public static bool mapIsOpen = false;
    public GameObject mapScreen;
  

    // Update is called once per frame
    void Update()
    {
        if (mapIsOpen == true)
        {
            OpenMap();
        }
        else
        {
            CloseMap();
        }

        if (mapIsOpen == false && Input.GetKeyDown(KeyCode.M))
        {
            OpenMap();
        }
    }
    void OpenMap()
    {
        mapScreen.SetActive(true);
        Time.timeScale = 0f;
        mapIsOpen = true;
    }

    void CloseMap()
    {
        mapScreen.SetActive(false);
        Time.timeScale = 1f;
        mapIsOpen = false;
    }
}
