using System.Collections;
using System.Collections.Generic;
// BossScript.cs
using UnityEngine;
public class BossScript : MonoBehaviour
{
    public float maxRage = 100f; // 怒气值最大值
    private float currentRage = 60f; // 当前怒气值

    public delegate void OnRageChanged(float newRagePercent); // 定义一个事件代理
    public event OnRageChanged onRageChanged; // 怒气值改变的事件
    

    void Update()
    {
        // 检测'J'键被按下
        if (Input.GetKeyDown(KeyCode.J))
        {
            DecreaseRage(10f);  // 减少10怒气值
        }

        // 检测'K'键被按下
        if (Input.GetKeyDown(KeyCode.K))
        {
            IncreaseRage(10f);  // 增加10怒气值
        }
    }
    
    // 调用这个方法来增加怒气值
    public void IncreaseRage(float amount)
    {
        currentRage += amount;
        currentRage = Mathf.Min(currentRage, maxRage); // 确保怒气值不超过最大值
        // 触发事件
        if (onRageChanged != null)
        {
            onRageChanged(currentRage / maxRage); // 发送怒气值的百分比
        }
    }

    public void DecreaseRage(float amount)
    {
        currentRage -= amount;
        currentRage = Mathf.Max(currentRage, 0); // 确保怒气值不小于0
        // 触发事件
        if (onRageChanged != null)
        {
            onRageChanged(currentRage / maxRage); // 发送怒气值的百分比
        }
    }

    public void SetRage(float newRage)
    {
        currentRage = Mathf.Clamp(newRage, 0, maxRage);  // 确保新的怒气值在有效范围内

        // 触发事件
        if (onRageChanged != null)
        {
            onRageChanged(currentRage / maxRage);  // 发送怒气值的百分比
        }
    }


    // 一个外部接口，允许其他脚本获取当前的怒气值百分比
    public float GetCurrentRagePercent()
    {
        return currentRage / maxRage;
    }
}
