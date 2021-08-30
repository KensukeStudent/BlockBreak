using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボックス制御クラス
/// </summary>
public class Box : MonoBehaviour
{
    /// <summary>
    /// 当たったか判定
    /// </summary>
    public bool Hit { private set; get; } = false;

    /// <summary>
    /// 初期化
    /// </summary>
    public void Initialize(float x, float y)
    {
        //座標セット
        transform.position = new Vector2(x, y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Shot"))
        {
            Hit = true;
        }
    }
}
