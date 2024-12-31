using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public MenuButtonsManager buttonsManager;

    public void Load(int i)
    {
        if(i == 1)
        {
            buttonsManager.ExitScenes();

            StartCoroutine(ChangeSceneWithDelay(i));
        }else
        {
            SceneManager.LoadScene(i);
        }
    }

    IEnumerator ChangeSceneWithDelay(int j)
    {
        yield return new WaitForSeconds(.7f);

        SceneManager.LoadScene(j);
    }

    public void Load(string s)
    {
        SceneManager.LoadScene(s);
    }
}
