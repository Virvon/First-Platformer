using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CharacterSound))]
public class CharacterDie : MonoBehaviour
{
    private bool _isAlive = true;

    public bool IsAlive => _isAlive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.TryGetComponent(out Enemy enemy))
        {
            _isAlive = false;

            GetComponent<Animator>().SetTrigger(CharacterAnimationsController.States.Die);
            GetComponent<CharacterSound>().PlayDieSound();
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
    }
}
