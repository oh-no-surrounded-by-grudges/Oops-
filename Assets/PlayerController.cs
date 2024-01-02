using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody2D rbody;

    public Animator animator; // 确保在Unity编辑器中将你的角色的Animator组件拖拽到这个字段上
    public float blinkDistance = 0.5f; // 闪现距离
    public float blinkCooldown = 1f;
    private float lastBlinkTime = -Mathf.Infinity;
    private bool isflashing;

    public float moveDistance = 0;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // float moveX = Input.GetAxisRaw("Horizontal"); //control horizontal movement  A:-1 D:1 0
        // float moveY = Input.GetAxisRaw("Vertical"); //control vertical movement  S:-1 W:1 0

        // Vector2 position = rbody.position;
        // position.x += moveX * speed * Time.fixedDeltaTime;
        // position.y += moveY * speed * Time.fixedDeltaTime;
        // rbody.MovePosition(position);

        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastBlinkTime >=blinkCooldown && !isflashing) // 检测是否按下空格键
        {
            moveDistance = blinkDistance;
            flash();
            lastBlinkTime = Time.time; // 更新上次闪现时间            
        }else
        {
            moveDistance = speed * Time.fixedDeltaTime;
        }
    }

    void flash()
    {
        // 设置动画状态，开始闪现动画
        isflashing = true;
        animator.SetTrigger("flash");
        isflashing = false;
    }

    void move()
    {
        // 在角色当前朝向的方向上移动一段距离
        float moveX = Input.GetAxisRaw("Horizontal"); //control horizontal movement  A:-1 D:1 0
        float moveY = Input.GetAxisRaw("Vertical"); //control vertical movement  S:-1 W:1 0

        // Vector2 position = rbody.position;
        Vector2 moveDirection = new Vector2(moveX, moveY) * moveDistance;
        // position += moveDirection;
        // rbody.MovePosition(position);
        transform.position = new Vector2(transform.position.x, transform.position.y) + moveDirection;

        // 此处你可以添加更多的代码来处理动画帧的逻辑，比如使角色在闪现过程中无法被攻击等
    }
}
