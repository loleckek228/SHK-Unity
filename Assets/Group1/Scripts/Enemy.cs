﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _speed;

    private Vector3 target;

    public event UnityAction<Enemy> Died;

    private void Start()
    {
        target = GetRandomPosition();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.deltaTime);

        if (transform.position == target)
            target = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        return Random.insideUnitCircle * _radius;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>())
        {
            Destroy(gameObject);
            Died?.Invoke(this);
        }
    }
}