using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireZone : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private float _fireSpeed=2f;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        _enemy.InvokeRepeating("Fire", 1f, _fireSpeed);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _enemy.CancelInvoke();
        _enemy.Invoke("ReturnPatrol", 1);
    }
}
