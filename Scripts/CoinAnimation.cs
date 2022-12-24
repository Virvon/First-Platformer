using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;
using UnityEngine;

public class CoinAnimation : MonoBehaviour
{
    [SerializeField] private float _amplitude;
    [SerializeField] private float _frequency;
    [SerializeField] private float _groundDistance;

    private Vector2 _startPosition;

    private IEnumerator Animate()
    {
        bool isFinish = false;
        float runningTime = 0;

        while (isFinish == false)
        {
            runningTime += Time.deltaTime;

            float offset = _amplitude * Mathf.Sin(runningTime * _frequency) + _groundDistance;

            transform.position = _startPosition + new Vector2(0, offset);

            yield return null;
        }
    }

    public void StartAnimation()
    {
        _startPosition = transform.position;

        StartCoroutine(Animate());
    }
}
