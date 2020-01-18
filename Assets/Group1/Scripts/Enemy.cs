using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 pointOfTarget;

    public event UnityAction<Enemy> OnDead;

    private void Start()
    {
        pointOfTarget = GetNextTargetPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointOfTarget, _speed * Time.deltaTime);

        if (transform.position == pointOfTarget)
            pointOfTarget = GetNextTargetPosition();
    }

    private Vector3 GetNextTargetPosition()
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