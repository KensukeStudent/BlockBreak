using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ステージお題表示クラス
/// </summary>
public class StageDisplay : MonoBehaviour
{
    enum MoveMode
    {
        Start,
        Center,
        End
    }
    /// <summary>
    /// 移動モード
    /// </summary>
    MoveMode mode = MoveMode.Start;

    /// <summary>
    /// 横幅
    /// </summary>
    const float witdh = 1600.0f;
    /// <summary>
    /// 表示ディスプレイ高さ
    /// </summary>
    const float hight = -135.0f;

    RectTransform rect;

    /// <summary>
    /// 移動速度
    /// </summary>
    float moveSpeed = 2500.0f;

    /// <summary>
    /// 計測
    /// </summary>
    float timer = 0.0f;
    /// <summary>
    /// 停止時間
    /// </summary>
    float stopTime = 1.2f;

    /// <summary>
    /// 移動完了
    /// </summary>
    bool moveFinish = false;

    [SerializeField] Text displayText;

    void Start()
    {
        rect = GetComponent<RectTransform>();    
    }

    /// <summary>
    /// 初期化
    /// </summary>
    /// <param name="displayText">ステージ表示テキスト</param>
    public void Initialize(string displayText)
    {
        mode = MoveMode.Start;
        moveFinish = false;
        rect.anchoredPosition = new Vector2(witdh, hight);
        timer = 0;
        this.displayText.text = displayText;
    }

    /// <summary>
    /// 移動し終わったフラグ
    /// </summary>
    public bool MoveEnd()
    {
        var dispPos = rect.anchoredPosition;

        switch (mode)
        {
            case MoveMode.Start:
            case MoveMode.End:

                dispPos.x -= Time.deltaTime * moveSpeed;

                if (mode == MoveMode.Start && dispPos.x <= 0)
                {
                    mode = MoveMode.Center;
                    dispPos.x = 0;
                }
                else if (mode == MoveMode.End && dispPos.x <= -witdh)
                {
                    moveFinish = true;
                }

                break;

            case MoveMode.Center:

                timer += Time.deltaTime;

                if (timer >= stopTime)
                {
                    timer = 0;
                    mode = MoveMode.End;
                }

                break;

            default:

                break;
        }

        rect.anchoredPosition = dispPos;

        return moveFinish;
    }
}
