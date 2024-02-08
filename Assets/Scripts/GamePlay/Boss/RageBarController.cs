using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class RageBarController : MonoBehaviour, IRageListener
{
    private Slider rageSlider;
    private void Awake()
    {
        rageSlider = GetComponent<Slider>();
        // 注册到RageManager
        RageManager.Instance.AddRageListener(this);
    }

    public void OnRageEvent(float rageValue)
    {
        UpdateRageBar(rageValue);
    }

    // 更新进度条的值
    private void UpdateRageBar(float value)
    {
        rageSlider.value = value / 100;
    }
}