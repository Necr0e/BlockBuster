using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    //Config params
    [SerializeField] Paddle paddle = null;
    [SerializeField] float xVelocity = 1f;
    [SerializeField] float yVelocity = 8f;
    [SerializeField] AudioClip[] ballSounds = null;
    float randomFactor = 0.5f;

    //Cached refs
    AudioSource audioSource;
    Rigidbody2D ballRigidBody2D;

    //States
    Vector2 ballOffset;
    bool hasStarted = false;
    private void Start()
    {
        ballOffset = transform.position - paddle.transform.position;
        audioSource = GetComponent<AudioSource>();
        ballRigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(!hasStarted)
        {
            LockBalltoPaddle();
            LaunchBall();
        }
    }

    private void LockBalltoPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + ballOffset;
    }
    private void LaunchBall()
    {
        if(Input.GetMouseButtonDown(0))
        {
            hasStarted = true;
            ballRigidBody2D.velocity = new Vector2(xVelocity, yVelocity); 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(
            Random.Range(0f, randomFactor), 
            Random.Range(0f, randomFactor));

        if(hasStarted)
        {
            AudioClip ballBounceClip = ballSounds[Random.Range(1, ballSounds.Length)];
            audioSource.PlayOneShot(ballBounceClip);
            ballRigidBody2D.velocity += velocityTweak;
        }
    }
}
