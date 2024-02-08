using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class RageBarController : MonoBehaviour
{
    public BossController boss; // 引用Boss脚本
    private Slider rageSlider; // 引用UI滑动条

    private void Start()
    {
        rageSlider = GetComponent<Slider>();
        if (boss != null)
        {
            UpdateRageBar(boss.GetCurrentRagePercent()); // 初始化怒气条
            boss.onRageChanged += UpdateRageBar; // 订阅怒气值变化事件
        }
    }

    // 更新进度条的值
    private void UpdateRageBar(float value)
    {
        rageSlider.value = value;
    }
}