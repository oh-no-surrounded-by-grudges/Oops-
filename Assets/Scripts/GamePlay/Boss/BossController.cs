using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BossController : MonoBehaviour, IRageListener
{
    public int speed = 1;
    public PlayerController player;
    private Rigidbody2D rbody;
    private bool isCalmDown = false;
    public Text responseText;
    void Awake() {
        // 注册到RageManager
        RageManager.Instance.AddRageListener(this);
        rbody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (player != null && player.IsAlive() && !isCalmDown)
        {
            Vector3 position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
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
        
        if (rageValue <= 20f) {
            isCalmDown = true;
            responseText.text = "谢谢你！我现在冷静下来了！";
            StartCoroutine(WaitAndBackToMenu());
        }
    }

    private IEnumerator WaitAndBackToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("0-Menu");
    }
}
