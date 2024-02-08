using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IRageListener
{
    public int speed = 1;
    public Transform target;
    private Rigidbody2D rbody;
    void Awake() {
        // 注册到RageManager
        RageManager.Instance.AddRageListener(this);
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            rbody.MovePosition(position); 
        }
    }

    public void OnRageEvent(float rageValue)
    {
        if (rageValue > 50f)
        {
            speed = 2;
        }
        else
        {
            speed = 1;
        }
    }
}
