using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject mainPanel;
    public void GoToFirstScene()
    {
        if (string.IsNullOrEmpty(AiData.Instance.openaiUrl) || string.IsNullOrEmpty(AiData.Instance.openaiKey) 
        || string.IsNullOrEmpty(AiData.Instance.baiduSttApiKey) || string.IsNullOrEmpty(AiData.Instance.baiduSttSecretKey))
        {
            settingPanel.SetActive(true);
            mainPanel.SetActive(false);
            return;
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene("1-Takeout");
    }
}
