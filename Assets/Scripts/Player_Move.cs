using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private static Player_Move _instance;

    public static Player_Move Instance
    {
        get => _instance;
    }
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected Vector3 moveInput;
    [SerializeField] protected float rollBoots = 2f;
    [SerializeField] protected float rollTimeDefault = 2f;
    [SerializeField] protected bool rollOnce = false;
    //[SerializeField] protected SpriteRenderer spriteRenderer;
    
    private float rollTime;
    private Rigidbody2D rb;
    private Animator animator;

    protected void Awake()
    {
        Player_Move._instance = this;
    }
    
    protected void Start()
    {
        this.animator = this.GetComponent<Animator>();
    }

    protected void Update()
    {
        //Lay input
        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");
        
        this.animator.SetFloat("Speed", moveInput.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space) && rollTime <= 0f)
        {
            animator.SetBool("Roll",true);
            moveSpeed += rollBoots;
            rollTime = rollTimeDefault;
            rollOnce = true;
        }

        if (rollTime <= 0 && rollOnce == true)
        {
            animator.SetBool("Roll",false);
            moveSpeed -= rollBoots;
            rollOnce = false;
        }
        else
        {
            rollTime -= Time.deltaTime;
        }
        
        Turning();

        transform.position += moveInput * moveSpeed * Time.deltaTime;
    }

    protected virtual void Turning()
    {
        Vector3 mouse = Input.mousePosition;
        Vector3 vt3 = new Vector3(mouse.x, mouse.y, this.transform.position.y);
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(vt3);
        Vector2 lookDir = mousePos - this.transform.position;

        this.transform.localScale = new Vector3(Mathf.Sign(lookDir.x), 1, 1);

    }

    public void SetMoveSpeed(float sp = 10)
    {
        this.moveSpeed += (this.moveSpeed * sp / 100f);
    }
 
}
