using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dead : MonoBehaviour {
    // Use this for initialization
    int gameover = 0;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gameover == 1)
        {
            if (Input.GetKeyDown(KeyCode.Y))
            {
                gameover = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKeyDown(KeyCode.N))
            {
                gameover = 0;
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
            }
                
        }
	}

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            gameover = 1;
            
    }
    public void OnGUI()
    {
        if(gameover == 1)
        {
            GUI.TextField(new Rect(Screen.width/2, Screen.height/2, 100, 50), "Game Over.\nReTry? Y/N");
            Time.timeScale = 0;
        }
            
    }
}
