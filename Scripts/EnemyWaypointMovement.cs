using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyWaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint = 0;
    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _points = new Transform[_path.childCount];

        for(int i = 0; i < _points.Length; i++)
            _points[i] = _path.GetChild(i).transform;
    }

    private void Update()
    {
        Transform target = _points[_currentPoint];

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), _speed * Time.deltaTime);

        if(transform.position.x == target.position.x)
        {
            _currentPoint++;

            if (_currentPoint >= _points.Length)
                _currentPoint = 0;

            Transform newxtTarget = _points[_currentPoint];

            if (newxtTarget.position.x > transform.position.x)
                _renderer.flipX = true;
            else
                _renderer.flipX = false;
        }
    }
}
