using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneThrow : MonoBehaviour {
    private float Xspeed = 0;
    private float Yspeed = 0;
    private float Xbuf = 0;
    private float Ybuf = 0;
    private int count=100;
    private bool move=false;
    private bool one = true;
    private SpriteRenderer spriteRenderer;
    // Use this for initialization

    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.transform.parent = GameObject.Find("player").transform;
    }
	
	// Update is called once per frame
	void Update () {
        
        if(one&&Input.GetKey(KeyCode.F)&&Xbuf<10f)
        {
            Xbuf += 0.3f;
            Ybuf += 0.1f;
        }
        if(one&&Input.GetKeyUp(KeyCode.F))
        {
            this.transform.parent = null;
            one = false;
            move = true;            
            Yspeed = Ybuf;
            Ybuf = 0;
            if (playermoving.arrow)
            {
                Xspeed = Xbuf;
                Xbuf = 0;
            }
            else
            {
                Xspeed = -Xbuf;
                Xbuf = 0;
            }
        }

        if(move)
        {
            Yspeed -= 0.1f;
            if (playermoving.arrow)
            {
                if (Xspeed > 1f)
                    Xspeed -= 0.001f;
            }
            else
            {
                if (Xspeed < -1f)
                    Xspeed += 0.001f;
            }
        }
        GetComponent<Rigidbody2D>().velocity = new Vector2(Xspeed, Yspeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            move = false;
            Xspeed = 0;
            Yspeed = 0;
        }
    } 

}
