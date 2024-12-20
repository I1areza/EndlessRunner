﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.TryGetComponent(out Player player))
        {
            player.ApplyDamage(_damage);
        }

        Die();
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
