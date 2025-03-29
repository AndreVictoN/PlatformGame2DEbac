using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleAlienEgg : ItemCollectibleBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemsManager.Instance.AddAlienEgg();
    }
}
