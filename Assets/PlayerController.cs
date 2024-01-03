using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rbody;
    //hit damage
    private int maxHealth = 1;
    private int currentHealth = 1;
    public RTSpeechHandler m_ChatHandler;
    public Text m_TextBack;

    public int GetmaxHealth { get { return maxHealth; } }
    public int GetcurrentHealth { get { return currentHealth; } }

    private bool isInvincible;
    private float invincibleTime = 2f;
    private float invincibleTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        isInvincible = false;
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

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0) isInvincible = false;
        }
    }

    public void ChangeHealth(int amount)
    {
        if (amount < 0)
        {
            if (isInvincible) return;
            isInvincible = true;
            invincibleTimer = invincibleTime;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if(currentHealth == 0)
        {
            Destroy(gameObject);
            m_TextBack.text = "你死了!";
            m_ChatHandler.StopConversation();            
        }
    }
}


