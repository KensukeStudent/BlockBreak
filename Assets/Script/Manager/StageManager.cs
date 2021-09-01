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
    int nowStage = 0;
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
        BallType.GroundOut, 
        BallType.RangeOut, 
        BallType.TimeOut, 
        BallType.GroundOut, 
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
    public void NextSceneLoad()
    {
        nowStage++;

        if(nowStage == stageCount)
        {
            SceneManager.LoadScene("Ending");

            //ステージ内で常に使っていたオブジェクトを破棄
            var managerObject = GameObject.Find("Manager");
            Destroy(managerObject);
        }
        else
        {
            var nextScene = "Stage" + (nowStage + 1);
            SceneManager.LoadScene(nextScene);
        }
    }

    /// <summary>
    /// 現在のSceneを遷移
    /// </summary>
    public void NowSceneLoad()
    {
        SceneManager.LoadScene("Stage" + (nowStage + 1));
    }
}