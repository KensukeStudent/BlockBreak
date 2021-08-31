using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    GameWait,
    GameStart,
    GameOver,
    GameClear
}

/// <summary>
/// ゲーム管理
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    public GameMode gameMode { private set; get; } = GameMode.GameWait;
    [SerializeField] StageManager stageMan;
    [SerializeField] UIManager uiMan;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    /// <summary>
    /// ゲームモードを変更
    /// </summary>
    public void ChangeGamaMode(GameMode mode)
    {
        gameMode = mode;

        switch (gameMode)
        {
            //今回のお題
            case GameMode.GameStart:

                //今回のステージのボールを割り当てる
                stageMan.GetBallAblity();

                break;
            
            //ゲームオーバーUI表示
            case GameMode.GameOver:

                //ゲームオーバーUI表示
                uiMan.ActiveGameOver();

                break;
            
            //ゲームクリアUI表示
            //次の遷移
            case GameMode.GameClear:

                //ゲームクリアUI表示
                uiMan.ActiveGameClear();
                stageMan.NextScene();
                break;
            
            default:
         
                break;
        }
    }
}