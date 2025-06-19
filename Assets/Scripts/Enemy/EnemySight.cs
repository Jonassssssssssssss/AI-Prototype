using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
    Transform _player;
    [SerializeField] Transform _sightPoint;

    public bool SeePlayer;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void Update()
    {
        SightUpdate();
    }

    void SightUpdate()
    {
        _sightPoint.LookAt(_player.position);

        RaycastHit hit;
        if (Physics.Raycast(_sightPoint.position, _sightPoint.TransformDirection(Vector3.forward), out hit))
        {
            if (hit.transform.GetComponent<Movement>())
            {
                if (hit.transform.GetComponent<Movement>().IsHidden == false)
                {
                    SeePlayer = true;
                }
                else
                {
                    SeePlayer = false;
                }
            }
            else
            {
                SeePlayer = false;
            }
        }
    }
}
