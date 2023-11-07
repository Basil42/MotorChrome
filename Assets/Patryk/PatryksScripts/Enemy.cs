using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    [SerializeField] Transform laserShootingPoint;
    private bool _canShoot = true;
    
    void Update()
    {
        if (_canShoot)
        Invoke("ShootLaser", 2f);
        _canShoot = true;
    }
    void ShootLaser()
    {
        Instantiate(laserPrefab, laserShootingPoint.transform.position, transform.rotation);
        _canShoot = false;
    }
}
