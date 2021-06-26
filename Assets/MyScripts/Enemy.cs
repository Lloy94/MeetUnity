using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _EnemyBulletPref;
    [SerializeField] private Transform _bulletStartPosition;
    [SerializeField] private int _maxHP;
    [SerializeField] private Transform []_targets;
    [SerializeField] private Animator _animator;
    [SerializeField] private Boss _boss;


    private NavMeshAgent _agent;
    private int _hp;

    private bool _death = false;

    private int m_CurrentWaypointIndex;
    private void Awake()
    {        
        _hp = _maxHP;      
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_targets[0].position);
        _animator.SetBool("Walk", true);
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
        if (_boss != null)
        {
            _death = true;
            _boss.DeathAnimation();
            Destroy(gameObject, 4);          
        }
        else Destroy(gameObject);
    }
    public void Fire()
    {
        if (!_death)
        {
            _agent.isStopped = true;
            gameObject.transform.LookAt(GameObject.FindWithTag("Player").transform.position);
            var bullet = Instantiate(_EnemyBulletPref, _bulletStartPosition.position, transform.rotation);
            var b = bullet.GetComponent<EnemyBullet>();
            b.Init();
            _animator.SetBool("Walk", false);
        }


    }

    public void ReturnPatrol()
    {
        _agent.isStopped = false;
        _animator.SetBool("Walk", true);
    }

}
