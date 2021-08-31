using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ内遷移クラス
/// </summary>
public class StageTransition : FadeBase
{
    protected override void FadeInBase()
    {
        GameManager.Instance.ChangeGamaMode(GameMode.GameStart);
    }

    protected override void FadeOutBase()
    {
        GameManager.Instance.ChangeGamaMode(GameMode.GameWait);
    }
}
