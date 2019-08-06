using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [HideInInspector] public PlayerAnimation anim;    
    [HideInInspector] public PlayerAudio audioPlayer;

    PlayerAttackHit hitAttack;
    Rigidbody2D rb2d;

    bool isAttacking = false;
    bool canTakeDamage = true;
    bool facingRight = true;
    bool jump = false;

    [Header("Properties")]
    public float speed = 7f;
    public float jumpForce = 20f;
    public int health = 3;
    public bool canMove = true;

    
    [Header("Collision")]
    public Vector2 bottomOffset = new Vector2(0, -0.5f);
    public float collisionRadius = 0.25f;
    public LayerMask groundLayer;
    public bool isOnFloor = true;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<PlayerAnimation>();
        hitAttack = GetComponentInChildren<PlayerAttackHit>();
        audioPlayer = GetComponent<PlayerAudio>();
    }

    // Update is called once per frame
    private void Update()
    {
        GroundCheck();

        if (!canMove)
            return;

        if (Input.GetButtonDown("Jump") && isOnFloor && !isAttacking)
        {
            jump = true;
            
        }
    }

    private void FixedUpdate()
    {
        if (!canMove)
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
            return;
        }

        if (!isAttacking)
        {
            float move = Input.GetAxisRaw("Horizontal");

            if ((facingRight && move < 0) || (!facingRight && move > 0))
                Flip();

            rb2d.velocity = new Vector2(speed * move, rb2d.velocity.y);

            anim.PlayerRun(move);

            if (Input.GetButtonDown("Attack") && isOnFloor)
                StartAttack();

            if (jump)
            {
                jump = false;                
                rb2d.velocity = new Vector2(rb2d.velocity.x, jumpForce);
                audioPlayer.JumpFx();
            }
        }
        else
        {
            rb2d.velocity = new Vector2(0f, rb2d.velocity.y);
        }
    }

    void StartAttack()
    {
        isAttacking = true;
        anim.PlayerAttack();
        audioPlayer.AttackFx();
    }

    public void EnableAttackHit()
    {
        hitAttack.hitEnabled = true;
    }

    public void StopAttack()
    {
        isAttacking = false;
        hitAttack.hitEnabled = false;
    }

    private void GroundCheck()
    {
        isOnFloor = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset, collisionRadius, groundLayer);
        anim.PlayerJump(isOnFloor);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
       // speed = -speed;
    }

    public void TakeDamage(int damage)
    {
        if (health > 0)
        {
            if (canTakeDamage)
            {
                canTakeDamage = false;
                health -= damage;
                anim.PlayerDamage();
                audioPlayer.HurtFx();
                Invoke("EnableDamage", 0.6f);


            }
        }
        
        if (health <= 0)
        {            
            if (canMove)
            {
                canMove = false;
                Level.instance.GameOver();
                anim.PlayerDie();
                audioPlayer.DieFx();
                Level.instance.RestartLevel();

                
            }
        }
    }

    private void EnableDamage()
    {
        canTakeDamage = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;      
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset, collisionRadius);
    }
}
