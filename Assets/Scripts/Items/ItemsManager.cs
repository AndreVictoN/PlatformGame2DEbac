using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using TMPro;

public class ItemsManager : Singleton<ItemsManager>
{
    [Header("Coins")]
    public SOInt coins;
    public SOInt moonstones;
    public SOInt alienEggs;

    public TextMeshProUGUI coinsNumber;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins.value = 0;
        moonstones.value = 0;
        alienEggs.value = 0;
    }

    public void AddCoins(int amount = 1)
    {
        coins.value += amount;
    }

    public void AddMoonstone(int amount = 1)
    {
        moonstones.value += amount;
    }

        public void AddAlienEgg(int amount = 1)
    {
        alienEggs.value += amount;
    }
}
