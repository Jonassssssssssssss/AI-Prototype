using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _attackPoint;
    [SerializeField] float _damage;
    Transform _player;
    EnemyController EC;

    [SerializeField] float _attackSpeed;
    float reload;

    [SerializeField] float _attackRange;

    void Start()
    {
        EC = GetComponent<EnemyController>();
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (EC.CurrentState == EnemyController.States.Attack)
        {
            if (Vector3.Distance(transform.position, _player.position) < _attackRange && reload <= 0f) StartCoroutine(Attack());
        }

        if (reload > 0f)
        {
            reload -= Time.deltaTime;
        }
    }

    IEnumerator Attack()
    {
        reload = _attackSpeed;

        yield return new WaitForSeconds(1f);

        RaycastHit hit;
        if (Physics.Raycast(_attackPoint.position, _attackPoint.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.transform.GetComponent<HealthPlayer>())
            {
                hit.transform.GetComponent<HealthPlayer>().TakeDamage(_damage);
            }
        }
    }
}
