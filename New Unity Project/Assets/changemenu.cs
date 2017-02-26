using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changemenu : MonoBehaviour
{
    public Sprite nextImage1;
    public Sprite nextImage2;
    public bool ImageState = false;
    private SpriteRenderer spriteRenderer;

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); //스프라이트 작성 함수선언
        spriteRenderer.sprite = nextImage2;
    }

    // Update is called once per frame
    void Update()
    {
        if (ImageState == false)
            spriteRenderer.sprite = nextImage1;
        else
            spriteRenderer.sprite = nextImage2;
    }
}