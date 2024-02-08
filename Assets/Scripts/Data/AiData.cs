using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiData : MonoBehaviour
{
    public static AiData Instance;
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

    public string openaiUrl
    {
        get {
            if (PlayerPrefs.HasKey("openaiUrl"))
            {
                return PlayerPrefs.GetString("openaiUrl");
            }
            else
            {
                return "https://api.openai.com/v1/chat/completions";
            }
        }
        set
        {
            PlayerPrefs.SetString("openaiUrl", value);
        }
    }
    public string openaiKey {
        get {
            if (PlayerPrefs.HasKey("openaiKey"))
            {
                return PlayerPrefs.GetString("openaiKey");
            }
            else
            {
                return "";
            }
        }
        set
        {
            PlayerPrefs.SetString("openaiKey", value);
        }
    }
    public string baiduSttApiKey {
        get {
            if (PlayerPrefs.HasKey("baiduSttApiKey"))
            {
                return PlayerPrefs.GetString("baiduSttApiKey");
            }
            else
            {
                return "";
            }
        }
        set
        {
            PlayerPrefs.SetString("baiduSttApiKey", value);
        }
    }
    public string baiduSttSecretKey {
        get {
            if (PlayerPrefs.HasKey("baiduSttSecretKey"))
            {
                return PlayerPrefs.GetString("baiduSttSecretKey");
            }
            else
            {
                return "";
            }
        }
        set
        {
            PlayerPrefs.SetString("baiduSttSecretKey", value);
        }
    }
}
