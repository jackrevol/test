using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour {
    GameObject player;
    //NavMeshAgent nav;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("player");
        //nav = GetComponent<NavMeshAgent>(); 
	}
	
	// Update is called once per frame
	void Update () {
        //nav.SetDestination(player.transform.position);
	}
}
