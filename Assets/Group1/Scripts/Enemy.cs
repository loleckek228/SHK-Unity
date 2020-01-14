using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private float distanceCoefficient = 0.001f;

    private Vector2 target;

    public event UnityAction<Enemy> OnDead;

    private void Start()
    {
        SetNextTargerPosition();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (Vector2.Distance(transform.position, target) < distanceCoefficient)
            SetNextTargerPosition();
    }

    private void SetNextTargerPosition()
    {
        target = Random.insideUnitCircle * _radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            OnDead?.Invoke(this);
        }
    }
}