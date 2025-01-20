using System.Collections;
using System.Collections.Generic;
using DG.Tweening.Plugins.Options;
using UnityEngine;

public class AudioRandomPlayAudioClips : MonoBehaviour
{
    public List<AudioClip> audioClipList;
    public List<AudioSource> audioSourceList;
    public Player player;
    private int _index = 0;

    void Awake()
    {
        if(player == null)
        {
            player = GetComponentInParent<Player>();
        }
    }

    public void PlayRandom()
    {
        if(_index >= audioSourceList.Count) _index = 0;

        var audioSource = audioSourceList[_index];

        audioSource.clip = audioClipList[Random.Range(0, audioClipList.Count)];

        if(player._isOnFloor) audioSource.Play();

        _index++;
    }
}
