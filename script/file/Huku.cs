using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //���� �� ��

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
        //���ӿ����� �۵�x
        if (!GameManager.isLive) return;

        //����
        if((Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0)) && isGround)
        {   //������
            rigid.AddForce(Vector2.up * startJumpPower, ForceMode2D.Impulse);
        }
        isjumpkey = Input.GetButton("Jump") || Input.GetMouseButton(0);
    }

    void FixedUpdate()
    {
        //���ӿ����� �۵�x
        if (!GameManager.isLive) return;

        //fixedupdate�� input�� ���� �� ����
        if (isjumpkey && !isGround)
        {
            //������   
            jumpPower = Mathf.Lerp(jumpPower, 0, 0.2f);
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        //����
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
        //����
        ChangeAnim(State.jump);
        sound.PlaySound(Sounder.Sfx.Jump);
        isGround = false;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //��ֹ� ��ġ
        rigid.simulated = false;
        sound.PlaySound(Sounder.Sfx.Hit);
        ChangeAnim(State.hit);
        onHit.Invoke();
    }

    void ChangeAnim(State state)
    {
        //�ִϸ��̼� ����
        anim.SetInteger("state", (int)state);
    }


}
