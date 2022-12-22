using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(CharacterDie))]
[RequireComponent(typeof(CharacterSound))]
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Animator _animator;
    private SpriteRenderer _renderer;
    private CharacterDie _characterDie;
    private CharacterSound _characterSound;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _characterDie = GetComponent<CharacterDie>();
        _characterSound = GetComponent<CharacterSound>();
    }

    private void Update()
    {
        if (_characterDie.IsAlive)
        {
            float direction = 0;
            float animatorSpeed = 0;
            bool isMoving = false;

            if (Input.GetKey(KeyCode.D))
            {
                direction = 1;
                animatorSpeed = 1;
                isMoving = true;
                _renderer.flipX = true;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                direction = -1;
                animatorSpeed = 1;
                isMoving = true;
                _renderer.flipX = false;
            }

            _characterSound.PlayRunSound(isMoving);

            _animator.SetFloat("Speed", animatorSpeed);

            transform.Translate(direction * _speed * Time.deltaTime, 0, 0);
        }
    }
}
