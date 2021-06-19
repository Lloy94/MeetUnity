using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _EnemyBulletPref;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private int _maxHP;
    [SerializeField] private Transform []_targets;

    private NavMeshAgent _agent;
    private int _hp;

    private int m_CurrentWaypointIndex;
    private void Awake()
    {
        _hp = _maxHP;
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_targets[0].position);
    }

    private void Update()
    {
        if (_agent.remainingDistance < _agent.stoppingDistance&&_agent.isStopped==false)
        {
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % _targets.Length;
            _agent.SetDestination(_targets[m_CurrentWaypointIndex].position);
        }
    }

    public void TakeDamage(int damage) 
    {
        _hp -= damage;
        if (_hp<=0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject);
    }
    public void Fire()
    {
        _agent.isStopped = true;
        gameObject.transform.LookAt(GameObject.FindWithTag("Player").transform.position);
        var bullet = Instantiate(_EnemyBulletPref, _bulletStartPosition.position, transform.rotation);
        var b = bullet.GetComponent<EnemyBullet>();
        b.Init();



    }

    public void ReturnPatrol()
    {
        _agent.isStopped = false;
    }

}
