using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] GameObject paddle1;
    Vector2 paddleToBallVector;
    [SerializeField] float xPush;
    [SerializeField] float yPush;
    [SerializeField] AudioClip[] collisionSounds;
    [SerializeField] float randomVector;
    Rigidbody2D Myrigidbody2d;
    AudioSource audioSource;
    bool Started;
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        audioSource = GetComponent<AudioSource>();
        Myrigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Started)
        {
            Launch();
            BeforeLaunch();
        }
    }
    private void Launch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Started = true;
            Myrigidbody2d.velocity = new Vector2(xPush,yPush);
        }
    }
    private void BeforeLaunch()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak=new Vector2(Random.Range(0f,randomVector), Random.Range(0f, randomVector));

        if(Started)
        {
            AudioClip clip = collisionSounds[UnityEngine.Random.Range(0, collisionSounds.Length)];
            audioSource.PlayOneShot(clip);
            Myrigidbody2d.velocity += velocityTweak;
        }
    }
}
