using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;

    public GameController controller;

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameObject != null)
        {
            controller = gameControllerObject.GetComponent<GameController>();
        }

        if (gameObject == null)
        {
            Debug.Log("Cannot find game controller.");
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            controller.setGameState(true);
        }

        if (other.tag == "Bolt")
        {
            controller.addScore(scoreValue);
        }

        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
