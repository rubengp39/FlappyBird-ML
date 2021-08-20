using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bird : MonoBehaviour
{
    private const float JUMP_AMOUNT = 100f;
    private Rigidbody2D birdrigidbody2D;

    private static Bird instance;
    
    public static Bird GetInstance()
    {
        return instance;
    }
    public event EventHandler OnDied;
    public event EventHandler OnStartedPlaying;
    private State state;
    private enum State
    {
        WaitingToStart,
        Playing,
        Dead
    }
    void Awake()
    {
        instance = this;
        birdrigidbody2D = GetComponent<Rigidbody2D>();
        birdrigidbody2D.bodyType = RigidbodyType2D.Static;
        state = State.WaitingToStart;
    }
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            default:
            case State.WaitingToStart:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    state = State.Playing;
                    birdrigidbody2D.bodyType = RigidbodyType2D.Dynamic;
                    Jump();
                    if (OnStartedPlaying != null) OnStartedPlaying(this, EventArgs.Empty);
                }
                break;
            case State.Playing:
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Jump();
                }
                transform.eulerAngles = new Vector3(0, 0, birdrigidbody2D.velocity.y * 0.3f);
                break;
            case State.Dead:
                break;
        }
       
    }
    private void Jump()
    {
        birdrigidbody2D.velocity = Vector2.up * JUMP_AMOUNT;
        SoundManager.PlaySound(SoundManager.Sound.BirdJump);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        birdrigidbody2D.bodyType = RigidbodyType2D.Static;
        SoundManager.PlaySound(SoundManager.Sound.Lose);
        if (OnDied != null) OnDied(this, EventArgs.Empty);
    }
}
