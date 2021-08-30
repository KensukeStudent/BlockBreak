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

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //時間を遅らせてスタート

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
            
                break;
            
            //ゲームオーバーUI表示
            case GameMode.GameOver:
            
                break;
            
            //ゲームクリアUI表示
            //次の遷移
            case GameMode.GameClear:
            
                break;
            
            default:
         
                break;
        }
    }
}