using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rbody;

    Vector2 MoveDirection;
    private float changeDirectionTime = 2f;
    private float changeTimer;
    public float speed = 30f;
    public bool isVertical;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        MoveDirection = isVertical ? Vector2.up : Vector2.right;

        changeTimer = changeDirectionTime;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Vector2 position = rbody.position;
        position.x += MoveDirection.x * speed * Time.deltaTime;
        position.y += MoveDirection.y * speed * Time.deltaTime;
        rbody.MovePosition(position);
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            MoveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
        */
        Vector2 position = transform.position;
        position.x += MoveDirection.x * speed * Time.deltaTime;
        position.y += MoveDirection.y * speed * Time.deltaTime;
        transform.position = position;
        changeTimer -= Time.deltaTime;
        if (changeTimer < 0)
        {
            MoveDirection *= -1;
            changeTimer = changeDirectionTime;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.ChangeHealth(-1);
            Debug.Log(pc.GetcurrentHealth + "/" + pc.GetmaxHealth);
        }
    }
}
