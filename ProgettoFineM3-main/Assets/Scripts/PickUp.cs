using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;
    [SerializeField] private Transform _player;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EquipWeapon(other.transform);
            Destroy(gameObject);
        }
    }

    private void EquipWeapon(Transform player)   //quando Player raccoglie arma viene istanziato il prefab dell'arma come child di Player
    {
        if (_weaponPrefab == null) return;

        if (_player == null)
        {
            _player = player.Find("Player");
        }
       
        //l'arma si vede equipaggiata al player

        GameObject newWeapon = Instantiate(_weaponPrefab, player);
    }
}
