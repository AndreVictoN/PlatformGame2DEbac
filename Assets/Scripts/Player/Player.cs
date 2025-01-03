using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;
using Unity.VisualScripting;

public class Player : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public HealthBase healthBase;

    [Header("Setup")]
    public SOPlayer_Setup soPlayer_Setup;
    private Animator _currentPlayer;

    private float _currentSpeed;
    public bool _isOnFloor;

    [Header("Jump")]
    public ParticleSystem jumpVFX;

    /*[Header("JumpCollisionCheck")]
    public Collider2D coll2D;
    public float distToGround;
    public float spaceToGround = .1f;*/

    private void Awake()
    {
        //_isOnFloor = false;

        if(healthBase != null)
        {
            healthBase.OnKill += OnPlayerKill;
        }

        _currentPlayer = Instantiate(soPlayer_Setup.player, transform);

        /*if(coll2D != null)
        {
            distToGround = coll2D.bounds.extents.y;
        }*/
    }

    /*private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, -Vector2.up, Color.magenta, distToGround + spaceToGround);

        return Physics2D.Raycast(transform.position, -Vector2.up, distToGround + spaceToGround);
    }*/

    private void OnPlayerKill()
    {
        healthBase.OnKill -= OnPlayerKill;

        _currentPlayer.SetTrigger(soPlayer_Setup.triggerKill);
    }

    private void Update()
    {
        //IsGrounded();
        HandleJump();
        HandleMovement();
    }

    public void HandleMovement()
    {
        if((Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.A)) || (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.D)))
        {
            _currentSpeed = soPlayer_Setup.speedRun;
            _currentPlayer.SetBool(soPlayer_Setup.boolRunning, true);
        }
        else
        {
            _currentSpeed = soPlayer_Setup.speed;
            _currentPlayer.SetBool(soPlayer_Setup.boolRunning, false);
        }

        if(Input.GetKey(KeyCode.A))
        {
            //myRigidbody.MovePosition(myRigidbody.position - velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(-_currentSpeed, myRigidbody.velocity.y);

            if(myRigidbody.transform.localScale.x != -1)
            {
                myRigidbody.transform.DOScaleX(-1, soPlayer_Setup.playerSwipeDuration);
            }
            
            //gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

            _currentPlayer.SetBool(soPlayer_Setup.boolRun, true);
        }else if(Input.GetKey(KeyCode.D))
        {
            //myRigidbody.MovePosition(myRigidbody.position + velocity * Time.deltaTime);
            myRigidbody.velocity = new Vector2(_currentSpeed, myRigidbody.velocity.y);

            if(myRigidbody.transform.localScale.x != 1)
            {
                myRigidbody.transform.DOScaleX(1, soPlayer_Setup.playerSwipeDuration);
            }

            //gameObject.transform.rotation = Quaternion.Euler(0, 0 , 0);

            _currentPlayer.SetBool(soPlayer_Setup.boolRun, true);
        }else
        {
            _currentPlayer.SetBool(soPlayer_Setup.boolRun, false);
        }

        if(myRigidbody.velocity.x > 0)
        {
            myRigidbody.velocity += soPlayer_Setup.friction;
        }else if (myRigidbody.velocity.x < 0)
        {
            myRigidbody.velocity -= soPlayer_Setup.friction;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.CompareTag("floor") || coll.gameObject.CompareTag("Enemy"))
        {
            _isOnFloor = true;
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("floor") || collision.gameObject.CompareTag("Enemy"))
        {
            _isOnFloor = true;
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("floor") || col.gameObject.CompareTag("Enemy"))
        {
            _isOnFloor = false;
        }
    }

    public void HandleJump()
    {
        if(_isOnFloor)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                myRigidbody.velocity = Vector2.up * soPlayer_Setup.jumpForce;

                DOTween.Kill(myRigidbody.transform);
                
                HandleScaleJump();
                PlayJumpVFX();
            }
        }
    }

    private void PlayJumpVFX()
    {
        VFXManager.Instance.PlayVFXByType(VFXManager.VFXType.JUMP, transform.position);
        //if(jumpVFX != null) jumpVFX.Play();
    }

    private void HandleScaleJump()
    {
        if(myRigidbody.transform.localScale.x == 1)
        {
            myRigidbody.transform.DOScaleX(soPlayer_Setup.jumpScaleX, soPlayer_Setup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer_Setup.ease);
        }
        else if(myRigidbody.transform.localScale.x == -1)
        {
            myRigidbody.transform.DOScaleX(-soPlayer_Setup.jumpScaleX, soPlayer_Setup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer_Setup.ease);
        }
        myRigidbody.transform.DOScaleY(soPlayer_Setup.jumpScaleY, soPlayer_Setup.animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(soPlayer_Setup.ease);
    }

    public void DestroyMe()
    {
        Destroy(gameObject);
    }
}
