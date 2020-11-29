using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private TMP_Text healthDisplay;

    private void OnEnable()
    {
        player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int health)
    {
        healthDisplay.text = $"Health: {health}";
    }
     
}
