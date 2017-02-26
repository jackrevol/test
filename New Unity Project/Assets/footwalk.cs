using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footwalk : MonoBehaviour {

    public AudioSource move;
    public int count = 35;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (count < 35)
            count++;
	}
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            if(Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
            {
                if(count == 35)
                {
                    move.Play();
                    count = 0;
                }
               
            }
        }
    } 
    
}
