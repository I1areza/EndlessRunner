using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private PlayerMovement _player;
    public event UnityAction<int> HealthChanged;
    public event UnityAction PlayerDied;
    [SerializeField] private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerMovement>();
        HealthChanged(_health);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _player.TryMoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            _player.MoveDown();
        }
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);
        if (_health <= 0)
        {
            Die();
        
        }
    }

    private void Die()
    {
        PlayerDied?.Invoke();
        Time.timeScale = 0;
    }
}
