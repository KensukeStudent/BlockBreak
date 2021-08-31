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
    /// 計測時間
    /// </summary>
    float timer = 0.0f;
    /// <summary>
    /// 時間リミット
    /// </summary>
    float timeLimit = 10.0f;

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
    /// 消滅時間
    /// </summary>
    /// <returns></returns>
    protected bool DeadTimer()
    {
        timer += Time.deltaTime;

        return timer >= timeLimit;
    }

    /// <summary>
    /// 消滅時間をセット
    /// </summary>
    public void SetDeadTimerLimit(float timeLimit)
    {
        this.timeLimit = timeLimit;
    }
}