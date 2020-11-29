using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class Heart : MonoBehaviour
{
    [SerializeField] private float lerpDuration;
    private Image _image;

    private void Awake()
    {
        _image = GetComponent<Image>();
        _image.fillAmount = 1;
    }


    public void FillHeart()
    {
        StartCoroutine(FillingCoroutine(0, 1, lerpDuration));
    }

    public void EmptyHeart()
    {
        StartCoroutine(FillingCoroutine(1, 0, lerpDuration, DestroyHeart));
    }

    

    private IEnumerator FillingCoroutine(float startValue, float endValue, float duration,
        UnityAction actionAfterCoroutine=null)
    {
        float timePassed = 0;
        while (duration > timePassed)
        {
            _image.fillAmount = Mathf.Lerp(startValue, endValue, timePassed / duration);
            timePassed += Time.deltaTime;
            yield return null;
        }
        _image.fillAmount = endValue;
        actionAfterCoroutine?.Invoke();
    }

    public void DestroyHeart()
    {
        Destroy(gameObject);
    }

    


}
