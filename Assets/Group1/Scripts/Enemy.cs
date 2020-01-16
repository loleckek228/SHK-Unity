using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 target;

    public event UnityAction<Enemy> OnDead;

    private void Start()
    {
        target = GetNextTargerPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (transform.position == target)
            target = GetNextTargerPosition();
    }

    private Vector3 GetNextTargerPosition()
    {
        return Random.insideUnitCircle * _radius;
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