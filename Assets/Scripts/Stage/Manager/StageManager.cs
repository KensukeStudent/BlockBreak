using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 全てのステージを管理
/// </summary>
public class StageManager : MonoBehaviour
{
    /// <summary>
    /// ステージ数
    /// </summary>
    const int stageCount = 5;
    /// <summary>
    /// 現在のステージ数
    /// </summary>
    public int NowStage { private set; get; } = 0;
    /// <summary>
    /// ボール管理
    /// </summary>
    [SerializeField] BallManager ballMan;

    /// <summary>
    /// ステージごとのボールの種類を定義
    /// </summary>
    BallType[] ballType = 
    {
        BallType.RangeOut, //範囲外でゲームオーバー
        BallType.GroundOut,//地面に触れたらゲームオーバー 
        BallType.RangeOut, 
        BallType.TimeOut, //タイムアップでゲームオーバー
        BallType.GroundOut, 
    };

    /// <summary>
    /// ボールの能力をセット
    /// </summary>
    public void GetBallAblity()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerController>();
        //ステージごとのボール能力を変更
        player.ShotObject = (ballMan.GetBallType(ballType[NowStage]));
    }

    /// <summary>
    /// 次のSceneに遷移
    /// </summary>
    public void NextSceneLoad()
    {
        NowStage++;

        //ゲームクリア時の処理
        if(NowStage == stageCount)
        {
            SceneManager.LoadScene("Ending");

            GameManager.Instance.ChangeGamaMode(GameMode.GameAllClear);
        }
        //ゲームステージ時の処理
        else
        {
            var nextScene = "Stage" + (NowStage + 1);
            SceneManager.LoadScene(nextScene);
        }
    }

    /// <summary>
    /// 現在のSceneを遷移
    /// </summary>
    public void NowSceneLoad()
    {
        SceneManager.LoadScene("Stage" + (NowStage + 1));
    }
}