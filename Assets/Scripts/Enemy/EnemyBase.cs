using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int damage = 2;

    public Animator animator;
    public string triggerAttack = "Attack";
    public string triggerKill = "Kill";

    public HealthBase healthBase;

    public float timeToDestroy = 1;

    void Awake()
    {
        if(healthBase != null)
        {
            healthBase.OnKill += OnEnemyKill;
        }
    }

    private void OnEnemyKill()
    {
        healthBase.OnKill -= OnEnemyKill;

        PlayKillAnimation();

        Invoke("PlayKillVFX", 1f);

        Invoke(nameof(DestroyEnemy), timeToDestroy);
    }

    private void DestroyEnemy()
    {
        //gameObject.SetActive(false);

        Destroy(gameObject);
    }

    private void PlayKillVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.EnemyDie, transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var health = collision.gameObject.GetComponent<HealthBase>();

        if(health != null)
        {
            health.Damage(damage);
            PlayAttackAnimation();
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(triggerAttack);
    }

    private void PlayKillAnimation()
    {
        animator.SetTrigger(triggerKill);
    }

    public void Damage(int amount)
    {
        healthBase.Damage(amount);
    }
}
