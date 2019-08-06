using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{    
    private FlashDamage _damageEffect;
    private bool _isVisible = false;   
    private Rigidbody2D _rb;
    private AudioSource _audioHit;
    private bool _canTakeDamage = true;

    [SerializeField] private int _health = 3;
    [SerializeField] private float _speed = 4;
    [SerializeField] private float _jumpForce = 4;
   // [SerializeField] protected GameObject explosion;

    public LayerMask _layerCollision;
    public Transform _collisonDetector;
    private Animator _anim;
    public bool _isAlive = true;
    public float _knockBackForce = 18f;

    private bool _facingRight = false;
    private bool _canMove = true;
    // Use this for initialization
    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _damageEffect = GetComponent<FlashDamage>();
        _rb = GetComponent<Rigidbody2D>();
        _audioHit = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_isAlive)
        {
            bool wallHit = Physics2D.Raycast(_collisonDetector.position, Vector2.right, 0.1f, _layerCollision);
            bool groundHit = Physics2D.Raycast(_collisonDetector.position, Vector2.down, 1f, _layerCollision);

            if (_canMove)
                _rb.velocity = new Vector2(_speed, _rb.velocity.y);


            if (wallHit || !groundHit)
                Flip();
        }
        else
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
            _anim.SetTrigger("die");
        }
    }


    public void TakeDamage(int damage) 
    {
        if (_health > 0)
        {
            if (_isVisible && _canTakeDamage)
            {
                _canTakeDamage = false;
                _canMove = false;
                _health -= damage;
                _damageEffect.SetFlashDamage();
                _audioHit.Play();
                KnockBack();
                Invoke("EnableDamage", 0.5f);


            }
        }
        else
        {
            //Instantiate(explosion, transform.position, Quaternion.identity);
            //Destroy(gameObject);
            _isAlive = false;
        }
    }

    private void EnableDamage()
    {
        _canTakeDamage = true;
        _canMove = true;
    }

    private void OnBecameVisible()
    {
        _isVisible = true;
    }

    private void OnBecameInvisible()
    {
        _isVisible = false;
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _speed = -_speed;
    }

    public void Move()
    {
        _canMove = true;
    }

    public void Stop()
    {
        _canMove = false;
    }

    private void KnockBack()
    {
        _rb.velocity = Vector2.zero;

        Vector2 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        if (playerPos.x > transform.position.x)
            _rb.AddForce(new Vector2(-_knockBackForce, _knockBackForce));
        else
            _rb.AddForce(new Vector2(_knockBackForce, _knockBackForce));

    }

}
