using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //아직 잘 모름

public class Huku : MonoBehaviour
{
    public enum State {stand, run, jump, hit };
    public float startJumpPower;
    public float jumpPower;
    public bool isGround;
    public bool isjumpkey;
    public UnityEvent onHit;

    Rigidbody2D rigid;
    Animator anim;
    Sounder sound;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sound = GetComponent<Sounder>();
    }

    void Start()
    {
        sound.PlaySound(Sounder.Sfx.Reset);
    }
    // Update is called once per frame
    void Update()
    {
        //게임오버시 작동x
        if (!GameManager.isLive) return;

        //점프
        if((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGround)
        {   //숏점프
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }
        isjumpkey = Input.GetButton("Jump") || Input.GetMouseButton(0);
    }

    void FixedUpdate()
    {
        //게임오버시 작동x
        if (!GameManager.isLive) return;

        //fixedupdate는 input이 씹힐 수 있음
        if (isjumpkey && !isGround)
        {
            //롱정프   
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.2f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //착지
        if (!isGround)
        {
            ChangeAnim(State.run);
            sound.PlaySound(Sounder.Sfx.Land);
            jumpPower = 1;
        }
        isGround = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        //점프
        ChangeAnim(State.jump);
        sound.PlaySound(Sounder.Sfx.Jump);
        isGround = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //장애물 터치
        rigid.simulated = false;
        sound.PlaySound(Sounder.Sfx.Hit);
        ChangeAnim(State.hit);
        onHit.Invoke();
    }

    void ChangeAnim(State state)
    {
        //애니메이션 변경
        anim.SetInteger("state", (int)state);
    }


}
