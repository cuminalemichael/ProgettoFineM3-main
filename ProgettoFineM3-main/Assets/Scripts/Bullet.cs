using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private int _dmg = 3;
    [SerializeField] private float _lifeTime = 3f;

    public Vector2 _dir { get; private set; }
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        //distruggi bullet dopo N secondi
        Destroy(gameObject, _lifeTime);
    }

    void FixedUpdate()
    {
        //movimnto bullet
        _rb.velocity = _dir * _speed;
    }


    private void OnCollisionEnter2D(Collision2D collision)      //gestione collisione con enemy o objects
    {                                                           //gestione danno inflitto da bullet
        if (collision.collider.CompareTag("Enemy"))
        {
            collision.collider.GetComponent<LifeController>().TakeDamage(_dmg);
            Destroy(gameObject);
        }
        else if (collision.collider.CompareTag("Objects"))
        {
            Destroy(gameObject);
        }
    }
}
