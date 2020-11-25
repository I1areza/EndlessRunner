using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private float verticalStep;
    private Vector3 targetPosition;
    [SerializeField] private float minHeight, MaxHeight; 

    private void Start()
    {
        targetPosition = transform.position;
    }

    private void Update()
    {
        if(targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void SetTargetPosition(float verticalOffset)
    {
        targetPosition = new Vector3(targetPosition.x, targetPosition.y+verticalOffset, targetPosition.z);
    }

    public bool TryMoveUp()
    {
        if (targetPosition.y < MaxHeight)
        {
            SetTargetPosition(verticalStep);
            return true;
        }

        return false;

    }
    public bool MoveDown()
    {
        if (targetPosition.y > minHeight)
        {
            SetTargetPosition(-verticalStep);
            return true;
        }

        return false;

    }
    
}
