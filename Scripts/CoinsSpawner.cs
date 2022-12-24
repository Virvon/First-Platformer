using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinsSpawner : MonoBehaviour
{
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private float _delay;

    private Vector2 _position;
    private Coin _coin;
    private AudioSource _audioSource;

    private void Awake()
    {
        _position = transform.position;
        _audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(SpawCoin());
    }

    private IEnumerator SpawCoin()
    {
        var delay = new WaitForSeconds(_delay);
        bool isFinish = false;

        while(isFinish == false)
        {   
            if (_coin == null)
            {
                _audioSource.Play();
                _coin = Instantiate(_coinPrefab, new Vector2(_position.x, _position.y), Quaternion.identity);

                yield return delay;
            }

            yield return null;
        }
    }
}
