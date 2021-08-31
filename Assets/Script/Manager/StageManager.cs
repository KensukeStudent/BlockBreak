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
    /// 記録はstatic化
    /// </summary>
    public static int nowStage = 1;
    /// <summary>
    /// ボール管理
    /// </summary>
    [SerializeField] BallManager ballMan;

    /// <summary>
    /// ステージごとのボールの種類を定義
    /// </summary>
    BallType[] ballType = 
    {
        BallType.RangeOut, 
        BallType.RangeOut, 
        BallType.RangeOut, 
        BallType.RangeOut, 
        BallType.RangeOut, 
    };

    /// <summary>
    /// ボールの能力をセット
    /// </summary>
    public void GetBallAblity()
    {
        var player = GameObject.Find("Player").GetComponent<PlayerController>();
        //ステージごとのボール能力を変更
        player.ShotObject = (ballMan.GetBallType(ballType[nowStage]));
    }

    /// <summary>
    /// 次のSceneに遷移
    /// </summary>
    public void NextScene()
    {
        nowStage++;
        var nextScene = "Stage" + nowStage;
        SceneManager.LoadScene(nextScene);
    }
}