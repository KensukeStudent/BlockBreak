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
    /// ゲームオーバーパネル表示
    /// </summary>
    public void ActiveGameOver()
    {
        Debug.Log("ゲームオーバー");
    }

    /// <summary>
    /// ゲームクリアパネルを表示
    /// </summary>
    public void ActiveGameClear()
    {
        Debug.Log("ゲームクリア");
    }
}
