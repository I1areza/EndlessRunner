using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ParallaxEffect : MonoBehaviour
{
    
    [SerializeField] private float _parralaxEffectSpeed;
    
    private Transform cameraTransform;
    private float textureWidth;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture2D = sprite.texture;
        textureWidth = (texture2D.width / sprite.pixelsPerUnit) * transform.localScale.x;
        Debug.Log(textureWidth);
    }
    private void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * _parralaxEffectSpeed;
    }
    
    void LateUpdate()
    {
        if (Mathf.Abs(cameraTransform.position.x - transform.position.x) >= textureWidth/2) 
         {
              float offset = (cameraTransform.position.x - transform.position.x) % textureWidth;
             Debug.Log($"Offset {offset}");
             transform.position = new Vector3(cameraTransform.position.x + offset, transform.position.y);
         }
    } 
}
     