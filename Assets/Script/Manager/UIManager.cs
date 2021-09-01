using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI管理クラス
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// 表示テキスト
    /// </summary>
    [SerializeField] Text displayText;

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
