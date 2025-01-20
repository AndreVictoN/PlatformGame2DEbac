using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public List<GameObject> gameObjects;
    public bool isPaused;

    void Awake()
    {
        isPaused = false;
    }

    public void ActiveMenu()
    {
        if(!isPaused)
        {
            foreach(GameObject go in gameObjects)
            {
                if(go != null) go.SetActive(false);
            }

            Time.timeScale = 0;
            isPaused = true;
        }
    }

    public void ExitMenu()
    {
        if(isPaused)
        {
            foreach(GameObject go in gameObjects)
            {
                if(go != null) go.SetActive(true);
            }

            Time.timeScale = 1;
            isPaused = false;
        }
    }
}
