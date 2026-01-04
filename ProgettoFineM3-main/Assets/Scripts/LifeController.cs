using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    [SerializeField] private int _hp = 10;

    //gestire vita e danno ricevuto
    public float GetHp() => _hp;

    public void SetHp(int hp)
    {
        _hp = Mathf.Max(0, hp);
        Debug.Log($"{gameObject.name} HP: {_hp}");

        if (_hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHp(int amount) => SetHp(_hp + amount);

    public void TakeDamage(int damage) => AddHp(-damage);

}
