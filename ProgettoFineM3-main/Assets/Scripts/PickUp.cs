using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] private GameObject _weaponPrefab;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject weapon = Instantiate(_weaponPrefab, other.transform);    //istanzia il prefab come figlio di Player
            Gun gun = other.GetComponentInChildren<Gun>();   //prende il componente Gun dal player o dai suoi figli
            if (gun != null)
            {
                gun.Equip();
            }
            Destroy(gameObject);
        }
    }
}
