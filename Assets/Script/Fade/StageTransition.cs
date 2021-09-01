using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ステージ内遷移クラス
/// </summary>
public class StageTransition : FadeBase
{
    [SerializeField] StageManager stageMan;
    [SerializeField] UIManager uiMan;

    private void Start()
    {
        SetFadeMode(FadeSequenceType.In);
    }

    protected override void FadeInBase()
    {
        GameManager.Instance.ChangeGamaMode(GameMode.GameStart);
        //今回のステージのボールを割り当てる
        stageMan.GetBallAblity();
    }

    protected override void FadeOutBase()
    {
        //表示テキストを非表示
        uiMan.InActiveDisplayText();
        //フェイドフラグをセット
        SetFadeFlag();

        switch (GameManager.Instance.gameMode)
        {
            case GameMode.GameOver:

                //現在のSceneをもう一度遷移
                stageMan.NowSceneLoad();
                break;

            case GameMode.GameClear:

                //次のSceneに遷移
                stageMan.NextSceneLoad();
                break;

            default:
                break;
        }

        //Waitモードへ切り替え
        GameManager.Instance.ChangeGamaMode(GameMode.GameWait);
    }
}
