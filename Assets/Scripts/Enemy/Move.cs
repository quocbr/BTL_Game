using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] protected Transform playerPos;
    [SerializeField] protected float moveSpeed = 3f;
    [SerializeField] protected Transform attackPoint;
    [SerializeField] private Animator animator;
    [SerializeField] protected bool canMove = true;
    [SerializeField] protected int damage = 1;

    [SerializeField] protected LayerMask playerLayer;
    [SerializeField] protected float attackRange = 1f;
    [SerializeField] protected float coldDownTime = 2f;
    private float countTime = 0f;
    private bool canAttack = false;

    private void Reset()
    {
        LoadComponent();
    }

    private void Awake()
    {
        LoadComponent();
    }

    protected void LoadComponent()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        attackPoint = transform.Find("AttackPoint");
        animator = transform.GetComponent<Animator>();
        playerLayer = LayerMask.GetMask("Player");
    }

    private void Update()
    {
        Vector3 direction = playerPos.position - this.transform.position;
        direction.Normalize();
        this.transform.localScale = new Vector3(Mathf.Sign(direction.x), 1, 1);

        //Move
        EMove();

        //Attack
        EAttack();
    }

    protected void EMove()
    {
        if (!canMove) return;
        transform.position = Vector2.MoveTowards(this.transform.position, playerPos.transform.position,
            moveSpeed * Time.deltaTime);
    }

    protected void EAttack()
    {
        if (canAttack)
        {
            if (animator.GetBool("Hit") == false)
            {
                countTime += Time.deltaTime;
            }

            if (countTime >= coldDownTime)
            {
                countTime = 0;
                animator.SetBool("Hit", true);
                Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);
                foreach (Collider2D player in hitPlayer)
                {
                    player.GetComponent<PlayerHealth>().TakeDamage(damage);
                }
            }
        }
        else
        {
            countTime = 0;
        }


        if (animator.GetBool("Hit") == true && canMove == true)
        {
            canMove = false;
        }
        else if (animator.GetBool("Hit") == false && canMove == true && canAttack == true)
        {
            canMove = false;
        }
        else if (animator.GetBool("Hit") == false && canMove == false && canAttack == false)
        {
            canMove = true;
            animator.SetBool("Walk", canMove);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    protected void swapBehaviors()
    {
        if (attackPoint == null) return;
        animator.SetBool("Hit", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = false;
            canAttack = true;
            animator.SetBool("Walk", canMove);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canMove = true;
            canAttack = false;
            animator.SetBool("Walk", canMove);
        }
    }
}