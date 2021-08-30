using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 上下左右の範囲を超えたら弾破壊クラス
/// </summary>
public class RangeOutBall : BallBase
{
    protected override bool DeadFlag()
    {
        var pos = transform.position;
        return RangeXOver(pos) || RangeYOver(pos);
    }
}