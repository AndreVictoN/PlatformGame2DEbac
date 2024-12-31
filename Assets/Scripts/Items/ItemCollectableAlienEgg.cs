using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableAlienEgg : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemsManager.Instance.AddAlienEgg();
    }
}
