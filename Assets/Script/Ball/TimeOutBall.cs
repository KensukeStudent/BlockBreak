using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeOutBall : BallAblity
{
    /// <summary>
    /// 計測
    /// </summary>
    float timer = 0.0f;
    /// <summary>
    /// 制限時間
    /// </summary>
    float timeLimit = 5.0f;

    public override bool DeadFlag()
    {
        timer += Time.deltaTime;

        return timer >= timeLimit;
    }

    public override void Exit()
    {
        base.Exit();
        timer = 0;
    }
}
