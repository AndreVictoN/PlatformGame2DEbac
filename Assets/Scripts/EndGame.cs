using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public string tagToCompare = "Player";
    public List<GameObject> gameObjects;
    public GameObject uiEndGame;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.transform.CompareTag(tagToCompare))
        {
            CallEndGame();
        }
    }

    public void CallEndGame()
    {
        uiEndGame.SetActive(true);

        foreach(GameObject go in gameObjects)
        {
            if(go != null) go.SetActive(false);
        }
    }
}
