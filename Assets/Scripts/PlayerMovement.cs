using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float _speed;
    [SerializeField] private float _verticalStep;
    private Vector3 _targetPosition;
    [SerializeField] private float _minHeight, _maxHeight; 

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if(_targetPosition != transform.position)
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }

    private void SetTargetPosition(float verticalOffset)
    {
        _targetPosition = new Vector3(_targetPosition.x, _targetPosition.y+verticalOffset, _targetPosition.z);
    }

    public bool TryMoveUp()
    {
        if (_targetPosition.y < _maxHeight)
        {
            SetTargetPosition(_verticalStep);
            return true;
        }

        return false;

    }
    public bool MoveDown()
    {
        if (_targetPosition.y > _minHeight)
        {
            SetTargetPosition(-_verticalStep);
            return true;
        }

        return false;

    }
    
}
