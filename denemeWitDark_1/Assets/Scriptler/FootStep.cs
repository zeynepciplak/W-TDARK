using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    AudioSource audioSource;
    Rigidbody2D rbd2D;
    float horizontalInput;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rbd2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        float moveVelocity = horizontalInput * speed;

        // X ekseni üzerinde hareketi güncelle
        rbd2D.velocity = new Vector2(moveVelocity, rbd2D.velocity.y);

        // Hareket varsa yürüme sesini çal
        if (Mathf.Abs(moveVelocity) > 0.1f) // Eğer hareket varsa
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
        else // Hareket yoksa
        {
            audioSource.Stop();
        }
    }
}

