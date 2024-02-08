using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IRageListener
{
    public float rotationSpeed = 25f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rotationSpeed * Time.fixedDeltaTime));
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
