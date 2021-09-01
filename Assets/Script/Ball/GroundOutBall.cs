using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 地面に当たるとゲームオーバーボール
/// </summary>
public class GroundOutBall : BallAblity
{
    public GroundOutBall()
    {
        //地面にヒットでゲームオーバー
        deadHitName = "Ground";
    }

    public override bool DeadFlag()
    {
        return deadFlag;
    }
}
