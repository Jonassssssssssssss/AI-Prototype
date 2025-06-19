using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class HealthPlayer : MonoBehaviour
{
    [SerializeField] float MaxHP;
    float _hp;

    void Start()
    {
        _hp = MaxHP;
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("take damage");
        _hp -= damage;
    }

    void Update()
    {
        if (_hp <= 0f) Die();
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
