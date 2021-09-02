using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///ボールが触れたらドッスン起動
/// </summary>
public class SiwtchDssun : SwitchButton
{
    /// <summary>
    /// ドッスンオブジェクト
    /// </summary>
    [SerializeField] Dossun dossun;

    public override void EventGO()
    {
        dossun.SetFallFlag();
    }
}