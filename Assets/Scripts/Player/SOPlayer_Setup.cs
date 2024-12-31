using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[CreateAssetMenu]
public class SOPlayer_Setup : ScriptableObject
{
    public Animator player;

    [Header("Speed Setup")]
    public Vector2 friction = new Vector2(.1f, 0);

    public float speed;
    public float speedRun;

    public float jumpForce = 20;

    [Header("Animation Setup")]
    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float animationDuration = .2f;
    public float playerSwipeDuration = .1f;

    public Ease ease = Ease.OutBack;

    [Header("Animation Player")]
    public string boolRun = "run";
    public string triggerKill = "kill";
    public string boolRunning = "running";
}
