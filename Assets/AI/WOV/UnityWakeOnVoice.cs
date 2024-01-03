using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
#if UNITY_STANDALONE_WIN
using UnityEngine.Windows.Speech;
#endif
/// <summary>
/// Unity语音唤醒
/// </summary>
public class UnityWakeOnVoice : WOV
{
    /// <summary>
    /// 唤醒关键词
    /// </summary>
    [SerializeField]
    private string[] m_Keywords = { "胡桃" };
    
#if UNITY_STANDALONE_WIN
    private KeywordRecognizer m_Recognizer;
    // Use this for initialization
    void Start()
    {
        m_Recognizer = new KeywordRecognizer(m_Keywords);
        Debug.Log("Start UnityWakeOnVoice");
        m_Recognizer.OnPhraseRecognized += OnPhraseRecognized;

    }
    
    /// <summary>
    /// 开始识别
    /// </summary>
    public override void StartRecognizer()
    {
        if (m_Recognizer == null)
            return;

        m_Recognizer.Start();
    }
    /// <summary>
    /// 结束识别
    /// </summary>
    public override void StopRecognizer()
    {
        if (m_Recognizer == null)
            return;

        m_Recognizer.Stop();
    }

    /// <summary>
    /// 唤醒词回调
    /// </summary>
    /// <param name="args"></param>
    private void OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0}", args.text);
        string _keyWord = builder.ToString();
        Debug.Log("检测到关键词：" + _keyWord);
        OnAwakeOnVoice(_keyWord);
    }
    #endif
}
