using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed = 5;
    [SerializeField] private int _dmg = 2;

    private Rigidbody2D _rb;
    private Animator _animator;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();

        if (_target == null)
        {
            GameObject gameObj = GameObject.FindGameObjectWithTag("Player");
            if (gameObj != null)
            {
                _target = gameObj.transform;
            }
        }
    }


    void FixedUpdate()
    {
        EnemyMovement();
    }


    private void OnCollisionEnter2D(Collision2D collision)          //si diostruggono se collidono con Player dopo il danno
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<LifeController>().TakeDamage(_dmg);
            Destroy(gameObject);
        }
    }

    //movimento e animazione Enemy
    void EnemyMovement()
    {
        Vector2 toTarget = (_target.position - transform.position).normalized;
        _rb.MovePosition(_rb.position + toTarget * (_speed * Time.deltaTime));
        //transform.position = Vector2.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        EnemyAnimator(toTarget);
    }


    private void EnemyAnimator(Vector2 dir)
    {
        _animator.SetFloat("xSpeed", dir.x);
        _animator.SetFloat("ySpeed", dir.y);
    }
}

