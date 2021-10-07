using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BallType
{
    RangeOut,//上下左右幅を超えたら消滅
    GroundOut,//地面に当たったら消滅
    TimeOut,//時間制限
};

/// <summary>
/// ステージに応じたボール割り当てるクラス
/// </summary>
public class BallManager : Singleton<BallManager>
{
    protected override bool DontDestroy { get; } = true;

    const int ballTypeCount = 3;
    [SerializeField] BallAblity[] ballAblities = new BallAblity[ballTypeCount];
    [SerializeField] GameObject ball;

    public BallManager()
    {
        ballAblities[0] = new RangeOutBall();
        ballAblities[1] = new GroundOutBall();
        ballAblities[2] = new TimeOutBall();
    }

    /// <summary>
    /// ボールのタイプをセット
    /// </summary>
    /// <param name="ballType"></param>
    /// <returns></returns>
    public GameObject GetBallType(BallType ballType)
    {
        //ボールを生成
        var bal = Instantiate(this.ball);
        var ballScript = bal.GetComponent<BallBase>();
        
        //アビリティの初期化
        ballAblities[(int)ballType].Initilize();

        //今回のボールに割り当て
        ballScript.SetAblity(ballAblities[(int)ballType]);

        bal.SetActive(false);
        return bal;
    }
}
