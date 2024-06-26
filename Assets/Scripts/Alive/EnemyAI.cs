﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    
    public List<Transform> patrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerController player;
    private bool _isPlayerNoticed;
    public float viewAngle;
    private AudioSource vipewvimvpowejvpo;
    public float damage = 898148869148;
    private PlayerHealth _playerHealth;


    private void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                _playerHealth.DealDamage(damage * Time.deltaTime);
            }
        }
    }
    private void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }
    private void Update()
    {
        NoticePlayer();
        Chase();
        AttackUpdate();
        PatrolUpdate();
        Audio();
        
    }

    private void Chase()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
        
    }

    private void NoticePlayer()
    {
        _isPlayerNoticed = false;
        var direction = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;

                    
                }

            }


        }
    }

        private void Audio()
    {
        
            AudioSource sound = gameObject.GetComponent<AudioSource>();
        
        if (_isPlayerNoticed)
        {
            if (sound.isPlaying)
            {

                
            }
            else
            {
                sound.Play();
            }
            
        }
        else
        {
            sound.Stop();
        }
        
    }
    private void PatrolUpdate()
    {
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance == _navMeshAgent.stoppingDistance)
            {
                PickNewPatrolPoint();
            }
        }
        
    }
    
    private void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
}
