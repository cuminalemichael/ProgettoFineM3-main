using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate = 0.7f;
    [SerializeField] private float _fireRange = 6;

    private float _lastShot;
    private bool _equipped = false; //controllo se il player ha raccolto l'arma

    void Update()
    {
        if (_equipped == false)     //se l'arma non è equipaggita allora non spara
            return;

        if (Input.GetButtonDown("Fire1") && Time.time - _lastShot >= _fireRate)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            Transform target = FindClosestEnemy(enemies);

            if (target != null)
            {
                Vector2 dir = (target.position - transform.position).normalized;
                _lastShot = Time.time;
                Shoot(dir);
            }
        }
    }


    public void Equip()
    {
        _equipped = true;
    }

    private void Shoot(Vector2 dir)
    {
        Bullet bullet = Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        bullet.SetDirection(dir);
    }


    private Transform FindClosestEnemy(GameObject[] enemies)
    {
        Transform closestEnemy = null;
        float fireRange = _fireRange;

        foreach (GameObject enemy in enemies)
        {
            float range = Vector2.Distance(transform.position, enemy.transform.position);
            if (range <= fireRange)
            {
                fireRange = range;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }
}
