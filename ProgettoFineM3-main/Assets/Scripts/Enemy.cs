using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] float _speed = 2f;
    [SerializeField] private int _dmg = 2;
    private PlayerController _playerController;
    private Animator _animator;
    private LifeController _lifeController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _animator = GetComponent<Animator>();
        _lifeController = GetComponent<LifeController>();
    }

    void Start()
    {
        GameObject gameObject = GameObject.FindGameObjectWithTag("Player");
        if (gameObject != null)
        {
            _target = gameObject.transform;
        }
    }

    void Update()
    {
        EnemyMovement();
        EnemyAnimator();
    }

    void EnemyMovement()
    {
        transform.position = Vector2.(transform.position, _target.position, _speed * Time.deltaTime).normalized;
    }

    private void EnemyAnimator()
    {
        Vector2 dir = new Vector2(transform.position.x, transform.position.y);
        if (_target != null)
        {
            Vector2 dir2 = dir - new Vector2(_target.transform.position.x, _target.transform.position.y);

            _animator.SetFloat("xSpeed", dir2.x);
            _animator.SetFloat("ySpeed", dir2.y);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)          //si diostruggono se collidono con Player dopo il danno
    {
        if (collision.collider.CompareTag("Player"))
        {
            collision.collider.GetComponent<LifeController>().TakeDamage(_dmg);
            Destroy(gameObject);
        }
    }
}

