using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
/// <summary>
/// プレイヤーUIクラス
/// </summary>
public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] TMP_Text playerText;

    /// <summary>
    /// 勝った時のテキスト
    /// </summary>
    string[] winText = 
    { 
        "かちました～", 
        "やったー", 
        "とろふぃーうりたい。。", 
        "あともうすこしー", 
        "おっけ～い", 
        "よゆうすぎた", 
    };

    /// <summary>
    /// 負けた時のテキスト
    /// </summary>
    string[] loseText =
    {
        "これおわったパターン？",
        "ぼくのせいかはむくわれない.....",
        "もう、\nかえるわ。",
        "はらへった～",
        "。。。。",
        "グッパイ、ぼくのじんせい。"
    };

    /// <summary>
    /// ステージの状況によって言葉が変化する
    /// </summary>
    public void SetVoice()
    {
        ui.SetActive(true);

        var rand = Random.Range(0, 6);

        var strVoice = "";

        switch (GameManager.I.gameMode)
        {
            case GameMode.GameOver:

                strVoice = loseText[rand];

                break;
            
            case GameMode.GameClear:

                strVoice = winText[rand];

                break;
            
            default:
                break;
        }

        playerText.text = strVoice;
    }
}