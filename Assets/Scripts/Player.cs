using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private PlayerMovement _player;

    [SerializeField] private int _health;
    // Start is called before the first frame update
    void Start()
    {
        _player = GetComponent<PlayerMovement>();
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
    }
}
