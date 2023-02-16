using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaw : MonoBehaviour
{
    [SerializeField] private int Damage;
    [SerializeField] private float Speed;
    [SerializeField] private float MovementDistance;
    private bool MovingLeft;
    private float EdgeLeft;
    private float EdgeRight;
    private void Awake()
    {
        EdgeLeft = transform.position.x -   MovementDistance;
        EdgeRight = transform.position.x + MovementDistance;

    }
    private void Update()
    {
        if (MovingLeft)
        {
            if (transform.position.x > EdgeLeft)
            {
                transform.position = new Vector3(transform.position.x - Speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else MovingLeft = false;
        }
        else
        {
            if (transform.position.x < EdgeRight)
            {
                transform.position = new Vector3(transform.position.x + Speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else MovingLeft = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(Damage);
        }
    }
}
