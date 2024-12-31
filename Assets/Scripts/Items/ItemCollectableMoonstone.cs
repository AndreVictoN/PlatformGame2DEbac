using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectableMoonstone : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemsManager.Instance.AddMoonstone();
    }
}
