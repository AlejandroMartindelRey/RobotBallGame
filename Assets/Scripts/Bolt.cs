using System;
using Unity.VisualScripting;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float speed = 0.01f;
    private float amplitude = 0.01f;
    [SerializeField] AudioSource boltSound;
    [SerializeField] AudioClip sound;
    private Vector3 basePosition;
    private float timer;
    bool dead = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basePosition = transform.localPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        boltSound.Play();
        dead = true;
    }

    void Death()
    {
        timer += Time.deltaTime;
        if (timer >= 0.3)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
        if (dead)
        {
            Death();
        }
        transform.eulerAngles+=new Vector3(0,1,0);
        float y = Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = basePosition + new Vector3(0, y, 0);
    }
}
