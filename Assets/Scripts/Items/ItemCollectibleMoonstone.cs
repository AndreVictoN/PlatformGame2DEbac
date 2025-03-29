using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectibleMoonstone : ItemCollectibleBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemsManager.Instance.AddMoonstone();
    }
}
