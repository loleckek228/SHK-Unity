using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float _fixedSpeed;

    private float accelerationTime;
    private float speed;

    private void Update()
    {
        speed = _fixedSpeed;
        if (accelerationTime > 0)
        {
            accelerationTime -= Time.deltaTime;

            speed *= 2;
        }

        Move();
    }

    private void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed;
        float vertical = Input.GetAxis("Vertical") * speed;

        transform.Translate(horizontal, vertical, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMovement>())
        {
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.GetComponent<Accelerator>())
        {
            accelerationTime = 2;
        }
    }
}