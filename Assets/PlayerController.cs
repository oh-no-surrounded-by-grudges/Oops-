using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rbody;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); //control horizontal movement  A:-1 D:1 0
        float moveY = Input.GetAxisRaw("Vertical"); //control vertical movement  S:-1 W:1 0

        Vector2 position = rbody.position;
        position.x += moveX * speed * Time.fixedDeltaTime;
        position.y += moveY * speed * Time.fixedDeltaTime;
        rbody.MovePosition(position);
    }
}
