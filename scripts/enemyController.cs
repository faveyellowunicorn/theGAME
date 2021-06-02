using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class enemyController : MonoBehaviour
{
    NavMeshAgent nav;
    public GameObject player;
    Transform player_tr;

    void Start()
    {
        
        nav = GetComponent<NavMeshAgent>();
        player_tr = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        nav.SetDestination(player_tr.position);
    }
}
