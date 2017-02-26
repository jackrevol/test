using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changelight : MonoBehaviour {

    public Sprite left;
    public Sprite right;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = right;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = left;
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            spriteRenderer.sprite = right;
        }

	}
}
