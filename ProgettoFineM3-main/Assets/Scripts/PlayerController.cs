using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _horizontal;
    private float _vertical;

    public Vector2 Direction { get; private set;  }

    //player movement tramite rb.MovePosition()
}
