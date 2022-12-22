using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CoinAnimation))]
public class Coin : MonoBehaviour
{
    private bool _isCoinAnimationActive = false;
    private CoinAnimation _coinAnimation;

    private void Awake()
    {
        _coinAnimation = GetComponent<CoinAnimation>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(_isCoinAnimationActive == false)
        {
            _isCoinAnimationActive = true;
            _coinAnimation.StartAnimation();
        }
    }


}
