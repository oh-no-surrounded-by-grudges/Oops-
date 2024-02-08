using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageManager : MonoBehaviour
{
    public static RageManager Instance;
    public float rageValue = 60f;
    public float maxRageValue = 100f;
    public float minRagevalue = 0f;

    public List<IRageListener> rageListeners = new List<IRageListener>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetRage(float value)
    {
        if (value > minRagevalue && value < maxRageValue)
        {
            rageValue = value;
            NotifyRageListeners();
        }
    }

    public void IncreaseRage(float value)
    {
        if (value <= 0)
        {
            return;
        }
        if (rageValue + value > maxRageValue)
        {
            rageValue = maxRageValue;
        }
        else
        {
            rageValue += value;
        }
        NotifyRageListeners();
    }

    public void DecreaseRage(float value)
    {
        if (value <= 0)
        {
            return;
        }
        if (rageValue - value < minRagevalue)
        {
            rageValue = minRagevalue;
        }
        else
        {
            rageValue -= value;
        }
        NotifyRageListeners();
    } 

    public void AddRageListener(IRageListener listener)
    {
        if (!rageListeners.Contains(listener))
        {
            rageListeners.Add(listener);
            listener.OnRageEvent(rageValue);
        }
    }

    public void RemoveRageListener(IRageListener listener)
    {
        if (rageListeners.Contains(listener))
        {
            rageListeners.Remove(listener);
        }
    }

    private void NotifyRageListeners()
    {
        foreach (var listener in rageListeners)
        {
            listener.OnRageEvent(rageValue);
        }
    }
}
