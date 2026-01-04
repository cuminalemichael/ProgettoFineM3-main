using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontal;
    private float _vertical;
    private Rigidbody2D _rb;
    private bool isAlive = false;       //aggiungere IsAlive per far uscire in runtime error se il player muore

    public Vector2 Direction { get; private set; }


    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    //movimento player tramite rb.MovePosition()

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        Direction = new Vector2(_horizontal, _vertical).normalized;
    }

    private void FixedUpdate()
    {
        if (Direction != Vector2.zero)
            _rb.MovePosition(_rb.position + Direction * (_speed * Time.deltaTime));
    }
}
