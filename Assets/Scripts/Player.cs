using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : MonoBehaviour
{
    private PlayerMovement player;

    [SerializeField] private int health;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            player.TryMoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.MoveDown();
        }
    }

    public void ApplyDamage(int damage)
    {
        health -= damage;
    }
}
