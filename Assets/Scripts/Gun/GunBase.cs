using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;

public class GunBase : MonoBehaviour
{
    public ProjectileBase prefabProjectile;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    private Coroutine _currentCoroutine;
    public Transform playerSideReference;
    public List<AudioSource> audioSources;
    public AudioClip audioClip;
    private int _index = 0;

    void Awake()
    {
        playerSideReference = transform.parent;

        while(playerSideReference != null)
        {
            if(playerSideReference.gameObject.CompareTag("Player"))
            {
                break;
            }

            playerSideReference = playerSideReference.parent;
        }
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            _currentCoroutine = StartCoroutine(StartShoot());
        }else if(Input.GetMouseButtonUp(0))
        {
            if(_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
            }
        }
    }

    IEnumerator StartShoot()
    {
        while(true)
        {
            Shoot();

            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }

    public void Shoot()
    {
        if(_index >= audioSources.Count) _index = 0;
        
        var audioSource = audioSources[_index];
        if(audioClip != null) audioSource.clip = audioClip;
        audioSource.Play();

        var projectile = Instantiate(prefabProjectile);
        projectile.transform.position = positionToShoot.position;
        projectile.side = playerSideReference.transform.localScale.x;

        _index++;
    }
}
