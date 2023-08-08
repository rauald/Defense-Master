using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    // 필요한 컴퍼넌트
    [SerializeField] private Transform tr;
    [SerializeField] private Rigidbody2D rigid;
    [SerializeField] private GameObject[] characters;
    private SpriteRenderer spriteRenderer;
    private Animator anim;

    // 스탯
    [SerializeField] private float speed;       // 기본 이동 속도
    [SerializeField] private float addSpeed;    // 추가 이동 속도

    private Vector2 dir;

    private bool isFight = false;
    private bool isWalk = false;
    private bool isDie = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else Destroy(this.gameObject);

        for(int i = 0; i < characters.Length; i++)
        {
            if (characters[i].activeSelf)
            {
                spriteRenderer = characters[i].GetComponent<SpriteRenderer>();
                anim = characters[i].GetComponent<Animator>();
                break;
            }
        }

        isFight = true;
    }
    
    private void Update()
    {
        Test();
        if (!isDie && isFight)
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

        Vector2 _moveHorizontal = tr.right * dirX;
        Vector2 _moveVertical = tr.up * dirY;

        dir = (_moveHorizontal + _moveVertical).normalized;

        rigid.MovePosition(rigid.position + dir * (speed + addSpeed) * Time.deltaTime);
    }

    private void Die()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            isDie = true;
            anim.SetTrigger("ToDie");
        }
    }

    public Vector2 GetDirection()
    {
        return dir;
    }
}