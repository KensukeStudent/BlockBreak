using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するクラス
/// </summary>
public class PlayerController : PlayerBase
{
    /// <summary>
    /// プレイヤー移動可能範囲
    /// </summary>
    const float moveRange = 8.9f;

    /// <summary>
    /// 発射するボール
    /// </summary>
    public GameObject ShotObject { set; get; }
    /// <summary>
    /// 弾を発射フラグ
    /// </summary>
    bool shotFlag = false;

    /// <summary>
    /// サウンドクラス
    /// </summary>
    ISoundClass sound = new ISoundClass();
    [SerializeField] AudioClip[] clip;
    /// <summary>
    /// プレイヤーの言葉が聞けるUI
    /// </summary>
    [SerializeField] PlayerUI playerUI;

    protected override void Start()
    {
        base.Start();
        sound.audio = GetComponent<AudioSource>();
        sound.clip = clip;
    }

    protected override float GameModeDirection(float h)
    {
        if (GameManager.Instance.gameMode != GameMode.GameStart) return 0.0f;

        return base.GameModeDirection(h);
    }

    protected override float AutoModeDirection()
    {
        var move = 1;

        switch (GameManager.Instance.gameMode)
        {
            case GameMode.GameOver:
                move = -1;
                break;
        
            default:
                break;
        }

        return move;
    }

    protected override bool JumpFlag()
    {
        return GameManager.Instance.gameMode == GameMode.GameStart;
    }

    protected override Vector2 OnUpdate(Vector2 pos)
    {
        pos.x = Mathf.Clamp(pos.x, -moveRange + sr.size.x / 2, moveRange - sr.size.x / 2);

        //弾を発射
        if (Input.GetMouseButtonDown(0) && !shotFlag)
        {
            //弾発射
            Shot(pos);
            sound.PlaySE();
        }

        return pos;
    }

    /// <summary>
    /// 弾発射
    /// </summary>
    /// <param name="playerPos">プレイヤー座標</param>
    void Shot(Vector3 playerPos)
    {
        //マウス座標
        var mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouse.z = 10;

        //プレイヤー座標とマウス座標を引いた値ベクトル方向を出力
        //狙う座標を中心
        var direct = mouse - playerPos;

        //ラジアンから角度に変換
        var angle = Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg;

        playerPos.y += sr.size.y / 2;

        //座標設定
        ShotObject.transform.position = playerPos;
        ////角度変換
        var rot = ShotObject.transform.localEulerAngles;
        rot.z = angle;
        ShotObject.transform.localEulerAngles = rot;

        //弾を表示
        ShotObject.SetActive(true);
        shotFlag = true;
    }

    public override void ChangeMoveMode(MoveMode mode)
    {
        playerUI.SetVoice();

        base.ChangeMoveMode(mode);
    }
}