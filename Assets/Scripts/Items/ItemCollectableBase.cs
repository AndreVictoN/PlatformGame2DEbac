using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemCollectableBase : MonoBehaviour
{
    public string compareTag = "Player";
    public ParticleSystem particleSys;
    public float timeToHide = 3f;
    public GameObject graphicItem;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect(collision);
        }
    }

    protected virtual void Collect(Collider2D collision)
    {
        if(graphicItem != null) graphicItem.SetActive(false);

        if(this.gameObject.CompareTag("Coin"))
        {
            Invoke(nameof(HideObject), timeToHide);

            Physics2D.IgnoreCollision(collision.gameObject.GetComponent<BoxCollider2D>(), this.gameObject.GetComponent<CircleCollider2D>());
        }else
        {
            HideObject();
        }

        OnCollect();
    }

    private void HideObject()
    {
        gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if(particleSys != null) particleSys.Play();
    }
}
