using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    [SerializeField, Range(0.1f, 15)] private float _ShootingTime;
    [SerializeField] private BalaMovement BalaPrefab;
    private void Start()
    {
        StartCoroutine(WaitForShoot());
        
    }

    private IEnumerator WaitForShoot()
    {
        yield return new WaitForSeconds(_ShootingTime);
        Shoot();

        Start();
    }


    private void Shoot()
    {

        Instantiate(BalaPrefab);

    }
}