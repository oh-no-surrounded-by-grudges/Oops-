using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IRageListener
{
    Rigidbody2D rbody;
    public float rotationSpeed = 25f;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rbody.MoveRotation(rbody.rotation + rotationSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null)
        {
            pc.ChangeHealth(-1);
        }
    }

    public void OnRageEvent(float rageValue)
    {
        if (rageValue > 50f)
        {
            rotationSpeed = 30f;
        }
        else
        {
            rotationSpeed = 25f;
        }
    }
}
