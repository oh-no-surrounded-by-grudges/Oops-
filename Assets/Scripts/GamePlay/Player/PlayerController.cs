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

    public Animator animator; // 确保在Unity编辑器中将你的角色的Animator组件拖拽到这个字段上
    public float blinkDistance = 5f; // 闪现距离
    public float blinkCooldown = 0.5f;
    private bool isflashing;
    private float moveX; //control horizontal movement  A:-1 D:1 0
    private float moveY; //control vertical movement  S:-1 W:1 0 

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

        isInvincible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentHealth == 0) return;

        moveX = Input.GetAxisRaw("Horizontal"); //control horizontal movement  A:-1 D:1 0
        moveY = Input.GetAxisRaw("Vertical"); //control vertical movement  S:-1 W:1 0

        if (Input.GetKeyDown(KeyCode.Space) && (moveX != 0 || moveY != 0) && !isflashing)
        {
            flash();
        }

        if (!isflashing)
        {
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
        if (currentHealth == 0)
        {
            m_TextBack.text = "你死了!";
            m_ChatHandler.StopConversation();
            StartCoroutine(WaitAndBackToMenu());
        }
    }

    private IEnumerator WaitAndBackToMenu()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("0-Menu");
    }

    void flash()
    {
        Debug.Log("flash");
        isflashing = true;
        animator.SetTrigger("flash");
    }

    public void move()
    {
        Vector2 blinkDirection = new Vector2(moveX, moveY) * blinkDistance;
        Physics.SyncTransforms();  // 使用Physics.SyncTransforms()来同步物理更新
        rbody.MovePosition(rbody.position + blinkDirection);
        StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(blinkCooldown);
        isflashing = false;
    }

    public bool IsAlive()
    {
        return currentHealth > 0;
    }
}
