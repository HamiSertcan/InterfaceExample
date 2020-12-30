using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    NavMeshAgent enemy;
    Transform player;
    public bool canlilik;
    float speed;
    void Start()
    {
        canlilik = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void OnEnable()
    {
        enemy = gameObject.GetComponent<NavMeshAgent>();
        speed = 0.8f + Game_Manager.gameTime / 250;
        enemy.speed = speed;
    }

    void Update()
    {
        if (canlilik == true)
        {
            enemy.destination = player.position;
        }
        
    }
}
