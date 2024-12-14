//Pratik Niroula
//Jas Raj Dangi
// priyanka Chaudhary
// Samip Thapa
// samip and pratik work on this part of game
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

    //helath is reduce when it is hit with the palyer
        health -= damage;
        if (health <= 0) {
        //enemy is die on this code
            gameManager.enemiesAlive--;
            Destroy(player);
        }
        


    }
    void Start()
    {
    //this code helps the zombie to find tthe player location and follow it
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<NavMeshAgent>().destination = player.transform.position;
//this is the for the animation of zombie of moving 
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
        {// gettin the component of player manager
            player.GetComponent<PlayerMnager>().Hit(damage);
        }
    }

}
