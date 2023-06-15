using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 필요한 컴퍼넌트
    private Rigidbody2D rigid;
    [SerializeField] private GameObject[] characters; 
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    // 스탯
    [SerializeField] private float speed;       // 기본 이동 속도
    [SerializeField] private float addSpeed;    // 추가 이동 속도

    private bool isDie = false;
    private bool isWalk = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        for(int i = 0; i < characters.Length; i++)
        {
            if (characters[i].activeSelf)
            {
                spriteRenderer = characters[i].GetComponent<SpriteRenderer>();
                anim = characters[i].GetComponent<Animator>();
                break;
            }
        }
    }
    
    private void Update()
    {
        Test();
        if (!isDie)
        {
            Move();
        }
        Die();
    }

    private void Test()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            anim.SetTrigger("ToIdle");
            isDie = false;
        }
    }

    private void Move()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        float dirY = Input.GetAxisRaw("Vertical");

        if (dirX == 0 && dirY == 0) isWalk = false;
        else isWalk = true;

        anim.SetBool("IsWalk", isWalk);

        if (dirX > 0) spriteRenderer.flipX = false;
        else if( dirX < 0)spriteRenderer.flipX = true;

        Vector2 _moveHorizontal = transform.right * dirX;
        Vector2 _moveVertical = transform.up * dirY;

        Vector2 movePos = (_moveHorizontal + _moveVertical).normalized * (speed + addSpeed) * Time.deltaTime;

        rigid.MovePosition(rigid.position + movePos);
    }

    private void Die()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDie = true;
            anim.SetTrigger("ToDie");
        }
    }
}