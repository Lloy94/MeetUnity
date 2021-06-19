using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _maxLifeTime = 10;
    [SerializeField] private int _damage = 10;

  

    public void Init()
    {
        Destroy(gameObject, _maxLifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) return;
        if (other.CompareTag("FireZone")) return;
        if (other.CompareTag("Player"))

        {
            other.GetComponent<HeroMove>().TakeDamage(_damage);
        }
        Destroy(gameObject);
    }
}
