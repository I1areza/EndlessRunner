using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private float verticalStep;
    private Vector3 targetPosition;

    private void Update()
    {
        if(targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void SetTargetPosition(float verticalOffset)
    {
        targetPosition = new Vector3(transform.position.x, transform.position.y+verticalOffset, transform.position.z);
    }

    public void MoveUp()
    {
        SetTargetPosition(verticalStep);
    }
    public void MoveDown()
    {
        SetTargetPosition(-verticalStep);
    }
    
}
