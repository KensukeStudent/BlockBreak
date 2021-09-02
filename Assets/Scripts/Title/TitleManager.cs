using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タイトル画面管理クラス
/// </summary>
public class TitleManager : MonoBehaviour
{
    /// <summary>
    /// タイトルプレイヤー
    /// </summary>
    PlayerBase player;
    /// <summary>
    /// タイトル遷移クラス
    /// </summary>
    [SerializeField] TitleTransition titleFade;
    AudioSource audio;

    /// <summary>
    /// ゲーム開始X座標
    /// </summary>
    const float startPosX = 6.5f;

    /// <summary>
    /// ゲーム開始フラグ
    /// </summary>
    bool gameStart = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBase>();
    }

    private void Update()
    {
        if (gameStart) return;

        var posPlayer = player.transform.position;

        if(posPlayer.x >= startPosX)
        {
            gameStart = true;
            //プレイヤー自動移動モード
            player.ChangeMoveMode(PlayerBase.MoveMode.AutoMode);
            //遷移フラグセット
            titleFade.SetFadeFlag();

            //スタート音
            audio.PlayOneShot(audio.clip);
        }
    }
}