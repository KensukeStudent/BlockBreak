using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI管理クラス
/// </summary>
public class UIManager : Singleton<UIManager>
{
    protected override bool DontDestroy { get; } = true;

    /// <summary>
    /// ゲームクリア・ゲームオーバーテキスト
    /// </summary>
    [SerializeField] Text displayText;

    /// <summary>
    /// ステージお題表示クラス
    /// </summary>
    [SerializeField] StageDisplay stageDisplay;
    string stageDisplayText = "";
    /// <summary>
    /// 表示テキスト
    /// </summary>
    public string StageDisplayText
    {
        set
        {
            stageDisplayText = value;
            dispMove = true;
            stageDisplay.Initialize(stageDisplayText);
        }
    }

    /// <summary>
    /// ステージお題表示フラグ
    /// </summary>
    bool dispMove = false;

    private void Update()
    {
        if (!dispMove) return;

        //お題移動
        if(stageDisplay.MoveEnd())
        {
            //移動完了後、ゲーム開始
            GameManager.I.ChangeGamaMode(GameMode.GameStart);
            dispMove = false;
        }
    }

    /// <summary>
    /// ゲームオーバーパネル表示
    /// </summary>
    public void ActiveGameOver()
    {
        displayText.text = "～ゲームオーバー～";
        displayText.gameObject.SetActive(true);
    }

    /// <summary>
    /// ゲームクリアパネルを表示
    /// </summary>
    public void ActiveGameClear()
    {
        displayText.text = "～クリア～";
        displayText.gameObject.SetActive(true);
    }

    /// <summary>
    /// テキストを非表示
    /// </summary>
    public void InActiveDisplayText()
    {
        displayText.gameObject.SetActive(false);
    }
}
