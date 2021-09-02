using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボールが触れることでアクションを起こすボタン
/// </summary>
public abstract class SwitchButton : MonoBehaviour
{
    protected SpriteRenderer sr;
    /// <summary>
    /// スイッチオン画像
    /// </summary>
    [SerializeField] Sprite switchOn;

    /// <summary>
    /// イベントフラグ
    /// </summary>
    protected bool eventFlag = false;

    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// イベント発火
    /// </summary>
    public abstract void EventGO();

    private void OnTriggerEnter2D(Collider2D col)
    {
        //ボールに触れたらイベント起動
        if(col.gameObject.CompareTag("Ball") && !eventFlag)
        {
            eventFlag = true;
            sr.sprite = switchOn;
            EventGO();
        }
    }
}
