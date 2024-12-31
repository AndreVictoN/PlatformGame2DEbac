using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public Vector3 direction;

    public float timeToDestroy = 2;

    public float side = 1;

    public int damageAmount = 1;

    void Awake()
    {
        Destroy(gameObject, timeToDestroy);
    }

    private void Update()
    {
        transform.Translate(direction * Time.deltaTime * side);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.transform.GetComponent<EnemyBase>();

            enemy.Damage(damageAmount);

            Destroy(gameObject);
        }
    }
}
