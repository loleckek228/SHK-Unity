using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _fixedSpeed;

    private float accelerationTime;
    private float speed;
    private float speedCoefficient = 2;

    private void Update()
    {
        speed = _fixedSpeed;
        if (accelerationTime > 0)
        {
            accelerationTime -= Time.deltaTime;

            speed *= speedCoefficient;
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
        if (collision.gameObject.GetComponent<Accelerator>())
        {
            accelerationTime = speedCoefficient;
        }
    }
}