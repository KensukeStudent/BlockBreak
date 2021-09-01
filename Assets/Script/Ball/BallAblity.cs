using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボール能力クラス
/// </summary>
public abstract class BallAblity
{
    protected BallBase ballBase;

    /// <summary>
    /// 死亡フラグ判定
    /// </summary>
    public bool deadFlag { set; get; } = false;
    protected string deadHitName = "";

    /// <summary>
    /// ボールをセット
    /// </summary>
    /// <param name="ballBase"></param>
    public void SetBallBase(BallBase ballBase)
    {
        this.ballBase = ballBase;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public virtual void OnUpdate(Vector2 pos)
    {
        //反転処理
        if (ballBase.RangeXOver(pos)) ballBase.ChangeVectorX();

        if (ballBase.RangeYOver(pos)) ballBase.ChangeVectorY();
    }

    /// <summary>
    /// 消滅フラグ
    /// </summary>
    /// <returns></returns>
    public abstract bool DeadFlag();

    /// <summary>
    /// 当たるとゲームオーバーになるオブジェクト名を取得
    /// </summary>
    public string GetDeadHit()
    {
        return deadHitName;
    }

    /// <summary>
    /// 退場処理
    /// </summary>
    public virtual void Exit()
    {
        deadFlag = false;
    }
}