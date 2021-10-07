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
    [SerializeField] AudioSource audio;

    /// <summary>
    /// ゲームが始まるフラグ
    /// </summary>
    bool gameStart = false;

    string[] stageTitle =
    {
        "ボールを画面外に出さずにクリアせよ！！",
        "ボールを地面につけずにクリアせよ！！",
        "ボールを画面外に出さずタイミングよくクリアせよ！！",
        "5秒以内にクリアせよ！！",
        "ボールを地面につけずにギミックを使ってクリアせよ！！",
    };

    private void Start()
    {
        SetFadeMode(FadeSequenceType.In);
    }

    protected override void FadeInBase()
    {
        if(!gameStart)
        {
            gameStart = true;
            audio.Play();
        }

        switch (GameManager.I.gameMode)
        {
            case GameMode.GameWait:

                //今回のステージのボールを割り当てる
                stageMan.GetBallAblity();

                //ステージお題表示
                uiMan.StageDisplayText = stageTitle[stageMan.NowStage];

                break;

            case GameMode.GameAllClear:

                //ステージ内で常に使っていたオブジェクトを破棄
                var managerObject = GameObject.Find("Manager");
                Destroy(managerObject);

                break;
            
            default:
                break;
        }
    }

    protected override void FadeOutBase()
    {
        //表示テキストを非表示
        uiMan.InActiveDisplayText();
        //フェイドフラグをセット
        SetFadeFlag();

        //※ゲームオールクリア時に
        //モードを変更するので変数として定義します
        var gameMode = GameManager.I.gameMode;

        //Waitモードへ切り替え
        GameManager.I.ChangeGamaMode(GameMode.GameWait);

        switch (gameMode)
        {
            case GameMode.GameOver:

                //現在のSceneをもう一度遷移
                stageMan.NowSceneLoad();
                break;

            case GameMode.GameClear:

                //次のSceneに遷移
                stageMan.NextSceneLoad();

                //ゲームを全てクリアしたらオーディオを止める
                if (GameManager.I.gameMode == GameMode.GameAllClear) audio.Stop();

                break;

            default:
                break;
        }
    }
}