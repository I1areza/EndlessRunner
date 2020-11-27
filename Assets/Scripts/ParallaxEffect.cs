using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxEffect : MonoBehaviour
{
    
    [SerializeField] private float _parralaxEffectSpeed;
    
    private Transform _cameraTransform;
    private float _textureWidth;
    
    void Start()
    {
        _cameraTransform = Camera.main.transform;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture2D = sprite.texture;
        _textureWidth = (texture2D.width / sprite.pixelsPerUnit) * transform.localScale.x;
        Debug.Log(_textureWidth);
    }
    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _parralaxEffectSpeed;
    }
    
    void LateUpdate()
    {
        if (Mathf.Abs(_cameraTransform.position.x - transform.position.x) >= _textureWidth/2) 
         {
              float offset = (_cameraTransform.position.x - transform.position.x) % _textureWidth;
             Debug.Log($"Offset {offset}");
             transform.position = new Vector3(_cameraTransform.position.x + offset, transform.position.y);
         }
    } 
}
     