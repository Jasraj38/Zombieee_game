//Pratik Niroula
//Jas Raj Dangi
// priyanka Chaudhary
// Samip Thapa

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour
{
    public GameObject player;

    public Animator enemyanimator;

    public float damage = 20f;
    public float health = 100f;
    public GameManager gameManager;

    // Start is called before the first frame update


    public void Hit(float damage)
    {
        health -= damage;
        if (health <= 0) {
            gameManager.enemiesAlive--;
            Destroy(player);
        }
        


    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<NavMeshAgent>().destination = player.transform.position;

        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyanimator.SetBool("isRunning", true);
        }
        else
        {
            enemyanimator.SetBool("isRunning", false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerMnager>().Hit(damage);
        }
    }

}
