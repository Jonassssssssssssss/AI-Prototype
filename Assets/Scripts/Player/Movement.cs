using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float Speed;
    CharacterController CC;

    [SerializeField] Transform _cameraGroup;

    public bool IsHidden;

    void Start()
    {
        CC = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown("c"))
        {
            CrouchSwitch(true);
        }
        if (Input.GetKeyUp("c"))
        {
            CrouchSwitch(false);
        }

        float X = Input.GetAxis("Horizontal") * Speed * Time.deltaTime;
        float Z = Input.GetAxis("Vertical") * Speed * Time.deltaTime;

        Vector3 movement = X * transform.right + Z * transform.forward;

        CC.Move(movement);
    }

    void CrouchSwitch(bool Switch)
    {
        if (Switch == true)
        {
            _cameraGroup.localPosition = new Vector3(0f, -0.5f, 0f);
            CC.height = 1f;
            CC.center = new Vector3(0f, -0.5f, 0f);
        }
        else
        {
            _cameraGroup.localPosition = new Vector3(0f, 0.5f, 0f);
            CC.height = 2f;
            CC.center = new Vector3(0f, 0f, 0f);
        }
    }
}
