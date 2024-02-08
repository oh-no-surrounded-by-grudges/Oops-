using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class BaiduSettings : MonoBehaviour
{
    #region 参数定义
    /// <summary>
    /// API Key
    /// </summary>
    [Header("填写应用的API Key")] public string m_API_key = string.Empty;
    /// <summary>
    /// Secret Key
    /// </summary>
    [Header("填写应用的Secret Key")] public string m_Client_secret = string.Empty;
    /// <summary>
    /// 是否从服务器获取token
    /// </summary>
    [SerializeField] private bool m_GetTokenFromServer = true;
    /// <summary>
    /// token值
    /// </summary>
    public string m_Token = string.Empty;
    /// <summary>
    /// 获取Token的地址
    /// </summary>
    private string m_AuthorizeURL = "https://aip.baidubce.com/oauth/2.0/token";
    public Text responseText;
    #endregion


    private void Awake()
    {
        if (m_GetTokenFromServer)
        {
            StartCoroutine(GetToken(GetTokenAction));
        }

    }


    /// <summary>
    /// 获取到token
    /// </summary>
    /// <param name="_token"></param>
    private void GetTokenAction(string _token)
    {
        m_Token = _token;
    }

    /// <summary>
    /// 获取token的方法
    /// </summary>
    /// <param name="_callback"></param>
    /// <returns></returns>
    private IEnumerator GetToken(System.Action<string> _callback)
    {
        if (string.IsNullOrEmpty(AiData.Instance.baiduSttApiKey) || string.IsNullOrEmpty(AiData.Instance.baiduSttSecretKey) || string.IsNullOrEmpty(m_AuthorizeURL))
        {
            Debug.LogWarning("API Key or Secret Key or AuthorizeURL is null");
            yield break;
        }
        //获取token的api地址
        string _token_url = string.Format(m_AuthorizeURL + "?client_id={0}&client_secret={1}&grant_type=client_credentials"
            , AiData.Instance.baiduSttApiKey, AiData.Instance.baiduSttSecretKey);

        using (UnityWebRequest request = new UnityWebRequest(_token_url, "POST"))
        {
            request.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            yield return request.SendWebRequest();
            if (request.isDone)
            {
                string _msg = request.downloadHandler.text;
                TokenInfo _textback = JsonUtility.FromJson<TokenInfo>(_msg);
                string _token = _textback.access_token;
                _callback(_token);
            }
            else if (request.result == UnityWebRequest.Result.ConnectionError)
            {
                responseText.text = "网络错误：" + request.error;
            }
            else if (request.result == UnityWebRequest.Result.ProtocolError)
            {
                responseText.text = "网络错误：" + request.error;
            }
            else
            {
                responseText.text = "未知错误：" + request.error;
            }
        }
    }


    /// <summary>
    /// 返回的token
    /// </summary>
    [System.Serializable]
    public class TokenInfo
    {
        public string access_token = string.Empty;
    }
}
