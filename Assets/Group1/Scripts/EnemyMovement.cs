using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector2 target;

    private void Start()
    {
        SetNextTargerPosition();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < 0.001f)
            SetNextTargerPosition();
    }

    private void SetNextTargerPosition()
    {
        target = Random.insideUnitCircle * _radius;
    }
}