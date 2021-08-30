using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// プレイヤーを制御するクラス
/// </summary>
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2D;
    Animator anim;
    SpriteRenderer sr;

    /// <summary>
    /// 移動速度
    /// </summary>
    const float moveSpeed = 5.0f;
    /// <summary>
    /// ジャンプ速度
    /// </summary>
    [SerializeField] float jumpSpeed;
    /// <summary>
    /// プレイヤー移動可能範囲
    /// </summary>
    const float moveRange = 8;

    [SerializeField] GameObject shotObject;
    /// <summary>
    /// 弾を発射フラグ
    /// </summary>
    bool shotFlag = false;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        //横の移動
        var h = Input.GetAxisRaw("Horizontal");

        var move = rb2D.velocity;
        move.x = Move(h);

        rb2D.velocity = move;
    }

    /// <summary>
    /// 横の移動制御関数
    /// </summary>
    float Move(float h)
    {
        //向き反転
        if (h > 0 && sr.flipX || h < 0 && !sr.flipX)
        {
            sr.flipX = !sr.flipX;
        }

        //0に限りなく近くないなら
        //Runアニメーション再生
        anim.SetBool("Run", !Mathf.Approximately(h, 0f));

        //現在の移動速度を返します
        return h * moveSpeed;
    }

    void Update()
    {
        //縦の移動
        //var v = Input.GetAxisRaw("Vertical");

        var pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, -moveRange + sr.size.x / 2, moveRange - sr.size.x / 2);
        transform.position = pos;

        if(Input.GetMouseButtonDown(0) && !shotFlag)
        {
            Shot(pos);
        }
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

        //弾生成
        var shot = Instantiate(shotObject, transform.position, Quaternion.identity);
        ////角度変換
        var rot = shot.transform.localEulerAngles;
        rot.z = angle;
        shot.transform.localEulerAngles = rot;
    }
}
