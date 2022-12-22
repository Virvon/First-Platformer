using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CharacterSound))]
public class TakeCoin : MonoBehaviour
{
    private CharacterSound _characterSound;

    private void Awake()
    {
        _characterSound = GetComponent<CharacterSound>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Coin coin))
        {
            _characterSound.PlayTakeCoinSound();
            Destroy(coin.gameObject);
        }
    }
}
