using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class changeScene : MonoBehaviour {
    private const int MaxIndex = 4;
    public changemenu[] menu = new changemenu[MaxIndex];

    private int scenestate = 0;
    private int loading;
    private int delay = 0;
    private int i;
    public AudioSource move;
    public AudioSource select;
	// Use this for initialization
	void Start () {
        loading = 0;
	}
	// Update is called once per frame
	void Update () {

        for (i = 0; i < MaxIndex; i++)
        {
            if (i == scenestate)
                menu[i].ImageState = true;
            else
                menu[i].ImageState = false;
        }
        if (loading == 1)
                delay++;
        if (loading != 1)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                scenestate = ++scenestate % MaxIndex;
                move.Play();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                scenestate = --scenestate;
                move.Play();
                if (scenestate == -1)
                    scenestate = MaxIndex-1;
            }
            else if (Input.GetKeyDown(KeyCode.Return))
            {
                select.Play();
                loading = 1;

            }
        }
        if (delay > 120)
        { 
            loading = 0;
            delay = 0;
            switch (scenestate)
            {
                case 0:
                    SceneManager.LoadScene(1);
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    Application.Quit();
                    break;
            }
        }
	}
}
