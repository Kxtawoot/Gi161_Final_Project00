using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character, IShootable
{
   
    Vector2 move;
    float moveX;
    bool facingRight = true;
    [SerializeField] float speed;
    [SerializeField] float jumpSpeed;

    [field: SerializeField]
    public GameObject Bullet
    {
        get;
        set;
    }
    [field: SerializeField]
    public Transform SpawnPoint
    {
        get;
        set;
    }
    public bool FacingRight => facingRight;
    [field: SerializeField]
    public float ReloadTime
    {
        get;
        set;
    }
    [field: SerializeField]
    public float WaitTime
    {
        get;
        set;
    }

    void Start()
    {
        Health = 100;
    }
    void Update()
    {
        PlayerController();
        Shoot();
    }

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        WaitTime -= Time.deltaTime;
    }

    void PlayerController()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        Rb.velocity = new Vector2(moveX * speed, Rb.velocity.y);
        Anim.SetBool("Run", moveX != 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (moveX < 0 && facingRight)
        {
            Flipplayer();
        }
        else if (moveX > 0 && !facingRight)
        {
            Flipplayer();
        }
    }

    void Flipplayer()
    {
        facingRight = !facingRight;
        Vector3 localscale = transform.localScale;
        localscale.x *= -1;
        transform.localScale = localscale;
    }

    void Jump()
    {
        Rb.velocity = new Vector2(0, jumpSpeed);
    }
    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && (WaitTime <= 0))
        {
            GameObject obj = Instantiate(Bullet, SpawnPoint.position, Quaternion.identity);
            Cherry cherry = obj.GetComponent<Cherry>();
            cherry.Init(10, this);
            WaitTime = 0;
        }
    }

}