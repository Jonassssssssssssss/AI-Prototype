using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //Test1: Go to next waypoint
    //Test2: Switch to next waypoint
    //Test3: Detect when see player
    //Test4: Switch to chaising player or waypoints depending on EnemyController.CurrentState;

    NavMeshAgent agent;
    [SerializeField] List<Transform> _wayPoints;
    [SerializeField] int _waypointIndex;
    EnemyController EC;

    Transform _player;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        EC = GetComponent<EnemyController>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        switch (EC.CurrentState)
        {
            case EnemyController.States.Patrol:
                MoveToWaypoint();
                break;
            case EnemyController.States.Investigate:
                InvestigatePattern();
                break;
            case EnemyController.States.Attack:
                MoveToPlayer();
                break;
        }
    }

    void MoveToWaypoint()
    {
        if (_waypointIndex < _wayPoints.Count)
        {
            if (Vector3.Distance(transform.position, _wayPoints[_waypointIndex].position) > 1.1f)
            {
                agent.SetDestination(_wayPoints[_waypointIndex].position);
            }
            else
            {
                _waypointIndex++;
                if (_waypointIndex > _wayPoints.Count) _waypointIndex = 0;
            }
        }
        else
        {
            _waypointIndex = 0;
        }
    }

    void InvestigatePattern()
    {
        //Debug.Log("Investigate");
    }

    void MoveToPlayer()
    {
        agent.SetDestination(_player.position);
    }
}
