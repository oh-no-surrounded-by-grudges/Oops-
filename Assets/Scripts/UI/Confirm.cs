using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Confirm : MonoBehaviour
{
    public TMP_InputField openaiUrl;
    public TMP_InputField openaiKey;
    public TMP_InputField baiduSttApiKey;
    public TMP_InputField baiduSttSecretKey;

    public void Awake() {
        openaiUrl.text = AiData.Instance.openaiUrl;
        openaiKey.text = AiData.Instance.openaiKey;
        baiduSttApiKey.text = AiData.Instance.baiduSttApiKey;
        baiduSttSecretKey.text = AiData.Instance.baiduSttSecretKey;
    }

    public void ConfirmSettings()
    {
        AiData.Instance.openaiUrl = openaiUrl.text;
        AiData.Instance.openaiKey = openaiKey.text;
        AiData.Instance.baiduSttApiKey = baiduSttApiKey.text;
        AiData.Instance.baiduSttSecretKey = baiduSttSecretKey.text;
    }
}
