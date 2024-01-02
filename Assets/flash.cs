using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkMovement : MonoBehaviour
{
    public Animator animator; // 确保在Unity编辑器中将你的角色的Animator组件拖拽到这个字段上
    public float blinkDistance = 5f; // 闪现距离
    public float blinkCooldown = 1f;
    private float lastBlinkTime = -Mathf.Infinity;
    private bool isflashing;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastBlinkTime >=blinkCooldown && !isflashing) // 检测是否按下空格键
        {
            flash();
            lastBlinkTime = Time.time; // 更新上次闪现时间
        }
    }

    void flash()
    {
        // 设置动画状态，开始闪现动画
        isflashing = true;
        animator.SetTrigger("flash");
        isflashing = false;
        // move();        
    }

    void move()
    {
        // 在角色当前朝向的方向上移动一段距离
        float moveX = Input.GetAxisRaw("Horizontal"); //control horizontal movement  A:-1 D:1 0
        float moveY = Input.GetAxisRaw("Vertical"); //control vertical movement  S:-1 W:1 0

        Vector2 blinkDirection = new Vector2(moveX, moveY) * blinkDistance;
        transform.position = new Vector2(transform.position.x, transform.position.y) + blinkDirection;

        // 此处你可以添加更多的代码来处理动画帧的逻辑，比如使角色在闪现过程中无法被攻击等
    }
}
