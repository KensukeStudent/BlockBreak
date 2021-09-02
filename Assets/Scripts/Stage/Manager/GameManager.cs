using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    GameWait,
    GameStart,
    GameOver,
    GameClear,
    GameAllClear
}

/// <summary>
/// ゲーム管理
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    public GameMode gameMode { private set; get; } = GameMode.GameWait;
    /// <summary>
    /// UI管理クラス
    /// </summary>
    [SerializeField] UIManager uiMan;
    /// <summary>
    /// 遷移クラス
    /// </summary>
    [SerializeField] FadeBase fadeMan;
    
    /// <summary>
    /// プレイヤークラス
    /// </summary>
    PlayerController player;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Update()
    {
        switch (gameMode)
        {
            case GameMode.GameOver:
            case GameMode.GameClear:
                
                if (Input.GetMouseButton(0) && !fadeMan.FadeFlag)
                {
                    fadeMan.SetFadeFlag();
                }

                break;

            case GameMode.GameStart:

                //初めからやり直し
                if (Input.GetMouseButton(1) && !fadeMan.FadeFlag)
                {
                    fadeMan.SetFadeFlag();
                    gameMode = GameMode.GameOver;
                }

                break;
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
            case GameMode.GameOver:
            case GameMode.GameClear:

                //ゲームオーバーUI表示
                if (gameMode == GameMode.GameOver) uiMan.ActiveGameOver();
                //ゲームクリアUI表示
                if (gameMode == GameMode.GameClear) uiMan.ActiveGameClear();

                player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
                player.ChangeMoveMode(PlayerBase.MoveMode.AutoMode);

                break;
            
            default:
         
                break;
        }
    }
}