using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum States {Patrol, Investigate, Attack};
    public States CurrentState = States.Patrol;

    EnemySight ES;

    [SerializeField] float _maxHuntTime;
    [SerializeField] float _huntTime;

    void Start()
    {
        ES = GetComponent<EnemySight>();
    }

    void Update()
    {
        if (ES.SeePlayer == true)
        {
            CurrentState = States.Attack;
            _huntTime = _maxHuntTime;
        }
        else if (ES.SeePlayer == false && _huntTime > 0f)
        {
            CurrentState = States.Investigate;
            _huntTime -= Time.deltaTime;
        }
        else
        {
            CurrentState = States.Patrol;
        }
    }
}
