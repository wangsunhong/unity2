using UnityEngine;
using System.Collections;

/// <summary>
/// 关卡开始时显示的文本
/// </summary>
public class StageStartText : MonoBehaviour {

    [SerializeField]
    private float delayTime = 2.0f;
    [SerializeField]
    private string[] startText = new string[] { 
        "Stage 1", "Stage 2", "Final Stage" 
    };
    [SerializeField]
    private string[] missionText = new string[] { 
        "Kill the Enemy!", 
        "Get the Recovery Item!", 
        "Stay alive as long as possible!" 
    };

    private GUIText missionGUIText = null;
    private Color startColor;

    void Start()
    {
        GameObject missionObj = GameObject.Find("MissionText");
        missionGUIText = missionObj.guiText;
        startColor = new Color(guiText.material.color.r, guiText.material.color.g, guiText.material.color.b, guiText.material.color.a);
    }

    void OnAwakeStage(int index)
    {
        // 提前准备好开始游戏前的文字
        if (index >= startText.Length) return;
        guiText.text = startText[index];
        guiText.enabled = true;
        guiText.material.color = new Color(startColor.r, startColor.g, startColor.b, startColor.a);
        missionGUIText.text = missionText[index];
        missionGUIText.enabled = true;
        missionGUIText.material.color = new Color(startColor.r, startColor.g, startColor.b, startColor.a);
    }

    void OnGameStart()
    {
        enabled = true;
        StartCoroutine("Delay");
    }

    // 为保险起见不显示
    void OnGameClear()
    {
        StopAllCoroutines();
        OnEndTextFade();
    }
    // 为保险起见不显示
    void OnGameOver()
    {
        StopAllCoroutines();
        OnEndTextFade();
    }

    void OnEndTextFade()
    {
        enabled = false;
    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        // TextFader
        BroadcastMessage("OnTextFadeOut");
    }

}
