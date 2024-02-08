using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour, IRageListener
{
    public int speed = 5;
    public Transform target;
    void Awake() {
        // 注册到RageManager
        RageManager.Instance.AddRageListener(this);
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }

    public void OnRageEvent(float rageValue)
    {
        if (rageValue > 50f)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }
    }
}
