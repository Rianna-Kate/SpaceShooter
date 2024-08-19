using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject ship;

    public Boundary boundary;

    public GameObject bolt;
    public float speed;
    public float length;
    public AudioSource audioData;
    public Transform shotSpawn;

    void Start()
    {
        GameObject ship = GetComponent<GameObject>();
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(Mathf.PingPong(1.2f, length), 0.0f, -2.75f);
        rb.velocity = movement * speed;

    }

    void Shoot ()
    {
        if (ship != null)
        {
            if ((Time.time % 2) == 0)
            {
                Instantiate(bolt, shotSpawn.position, shotSpawn.rotation);
                audioData.Play();
            }
        }
    }

    private void FixedUpdate()
    {
        Shoot();
    }
}
