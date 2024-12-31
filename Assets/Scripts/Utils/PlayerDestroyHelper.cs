using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyHelper : MonoBehaviour
{
    public Player player;

    void Awake()
    {
        if(player == null)
        {
            player = transform.parent.GetComponent<Player>();
        }
    }

    public void KillPlayer()
    {
        player.DestroyMe();
    }
}
