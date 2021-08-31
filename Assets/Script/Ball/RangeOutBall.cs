using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 上下左右の範囲を超えたら弾破壊クラス
/// </summary>
public class RangeOutBall : BallAblity
{
    public override void OnUpdate(Vector2 pos) { }

    public override bool DeadFlag()
    {
        var pos = ballBase.transform.position;
        return ballBase.RangeXOver(pos) || ballBase.RangeYOver(pos);
    }
}