using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �ʿ��� ���۳�Ʈ
    private Rigidbody2D rigid;
    [SerializeField] private GameObject[] characters; 
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    // ����
    [SerializeField] private float speed;       // �⺻ �̵� �ӵ�
    [SerializeField] private float addSpeed;    // �߰� �̵� �ӵ�

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