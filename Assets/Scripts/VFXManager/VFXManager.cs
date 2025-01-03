using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

public class VFXManager : Singleton<VFXManager>
{
    public enum VFXType
    {
        JUMP,
        EnemyDie
    }

    public List<VFXManagerSetup> vfxSetup;

    public void PlayVFXByType(VFXType vfxType, Vector3 position)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                
                if(i.vfxType == VFXType.JUMP)
                {
                    item.transform.position = position;

                    Destroy(item.gameObject, 2f);
                }else if(i.vfxType == VFXType.EnemyDie)
                {
                    position.y += 2.5f;
                    item.transform.position = position;

                    Destroy(item.gameObject, 5f);
                }

                break;
            }
        }
    }
}

[System.Serializable]
public class VFXManagerSetup
{
    public VFXManager.VFXType vfxType;
    public GameObject prefab;
}
