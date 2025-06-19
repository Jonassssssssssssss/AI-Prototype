using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAndFallPlayer : MonoBehaviour
{
    [SerializeField] Transform _groundPoint;
    [SerializeField] LayerMask _groundLayer;
    [SerializeField] float _groundDistance = 0.4f;

    [SerializeField] float _gravity = 8f;
    [SerializeField] float _jump = 8f;

    [SerializeField] Vector3 fall;

    bool _isGrounded;
    bool _isJumping;

    public void ResetFall()
    {
        fall = new Vector3(0f, 0f, 0f);
    }

    void Update()
    {
        _isGrounded = Physics.CheckSphere(_groundPoint.position, _groundDistance, _groundLayer);

        if (_isGrounded && !_isJumping) fall.y = -0.1f;
        else if (!_isJumping) fall.y -= Time.deltaTime * _gravity;

        if (GetComponent<CharacterController>())
        {
            CharacterController CC = GetComponent<CharacterController>();
            CC.Move(fall * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded) StartCoroutine(Jump());

        else transform.position = new Vector3(transform.position.x, transform.position.y + fall.y, transform.position.z);
    }

    IEnumerator Jump()
    {
        _isJumping = true;
        fall.y = _jump;
        yield return new WaitForSeconds(0.1f);
        _isJumping = false;
    }
}
