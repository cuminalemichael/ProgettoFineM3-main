using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _fireRate = 0.5f;
    [SerializeField] private float _fireRange = 5f;

    private float _lastShot;

    void Update()
    {
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

    private void Shoot(Vector2 dir)
    {
        Bullet bullet = Instantiate(_bulletPrefab);
    }


    private Transform FindClosestEnemy(GameObject[] enemies)
    {
        Transform closestEnemy = null;

        float fireRange = _fireRange;
        Vector2 currentPosition = transform.position;

        foreach (GameObject enemy in enemies)
        {
            float range = Vector2.Distance(currentPosition, enemy.transform.position);
            if (range <= fireRange)
            {
                fireRange = range;
                closestEnemy = enemy.transform;
            }
        }
        return closestEnemy;
    }

}
