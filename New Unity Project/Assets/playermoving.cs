using UnityEngine;
using System.Collections;

public class playermoving : MonoBehaviour {

    public GameObject stone;
    public static bool arrow=true;
    public Sprite standmotion;
    public Sprite jumpmotion;
    public Sprite Rstandmotion;
    public Sprite Rjumpmotion;
    public Sprite Lstandmotion;
    public Sprite Ljumpmotion;
    public float Speed = 10f;
    private float movex = 10f;
    //private float movey = 10f;
    private float jump = -0.1f;
    private float jumpspeed = 15f;
    private int jumptimer = 0;
    private SpriteRenderer spriteRenderer;
    private bool Jstate = true;
    //캐릭터의 속도를 지정한다

    // Use this for initialization
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = standmotion;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        movex = Input.GetAxis("Horizontal");

        //movey = Input.GetAxis("Vertical");
        //에딧>프로젝트세팅>인풋 을 통해 설정하는 입력값에 따른 연산이다

        if(Input.GetKey(KeyCode.LeftArrow))
        {
            arrow = false;
            standmotion = Lstandmotion;
            jumpmotion = Ljumpmotion;
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            arrow = true;
            standmotion = Rstandmotion;
            jumpmotion = Rjumpmotion;
        }

        if(Jstate && jumptimer == 0)
        {
            jump -= 0.5f;
        }

        if(jump==0)
        {
            spriteRenderer.sprite = standmotion;
            if (Input.GetKey(KeyCode.Space))
            {
                Jstate = true;
                jump = jumpspeed;
            }
        }
        else
        {
            spriteRenderer.sprite = jumpmotion;
        }

        if (jump == jumpspeed)
        {
            jumptimer++;
        }
        else if (jump!=0)
        {
            jump -= 0.5f;
        }

        if (jumptimer == 20)
        {
            jumptimer = 0;
            jump = -1f;
            Jstate = false;            
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, jump);

        if(Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(stone, this.transform.position, Quaternion.identity);
        }



        //GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
        //입력과 속도를 움직임에 적용하는거같다 아직 뭐하는 코드인지 잘모르겠다.

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Jstate = false;
            jump = 0;
        }
    }
    public void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            Jstate = false;
            jump = 0;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Jstate = true;
        }
    }

}
