using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Player _player;
    private List<Heart> _hearts = new List<Heart>();
    [SerializeField] private Heart _heartTemplate;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        
    }
    
    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;   
    }

    private void OnHealthChanged(int value)
    {
        
        if (_hearts.Count < value)
        {
            int heartsToBeCreated = value - _hearts.Count;
            for (int i = 0; i < heartsToBeCreated; i++)
            {
                CreateHeart();
            }
        }
        else
        {
            int heartsToBeDeleted = _hearts.Count - value;
            for (int i = 0; i < heartsToBeDeleted; i++)
            {
                
                DestroyHeart(_hearts[_hearts.Count-1]);
            }
        }
    }

    private void CreateHeart()
    {
        Heart heart = Instantiate(_heartTemplate, transform);
        _hearts.Add(heart);
        heart.FillHeart();
    }

    private void DestroyHeart(Heart heart)
    {
        _hearts.Remove(heart);
        heart.EmptyHeart();
    }

   
}
