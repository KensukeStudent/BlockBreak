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
    LayerMask ground;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        ground = LayerMask.GetMask("Ground");
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
        var v = Input.GetAxisRaw("Vertical");

        var pos = transform.position;
        if (IsGround(pos))
        {
            //ジャンプ処理
            Jump(v);
        }

        pos.x = Mathf.Clamp(pos.x, -moveRange + sr.size.x / 2, moveRange - sr.size.x / 2);
        transform.position = pos;

        //高さからアニメーションを変更
        var y = Mathf.Round(rb2D.velocity.y);
        anim.SetBool("Jump", y > 0 && !IsGround(pos));
        anim.SetBool("Fall",( y == 0 || y < 0 ) && !IsGround(pos));

        //弾を発射
        if(Input.GetMouseButtonDown(0) && !shotFlag)
        {
            Shot(pos);
            shotFlag = true;
        }
    }

    /// <summary>
    /// 地面着地判定
    /// </summary>
    /// <returns></returns>
    bool IsGround(Vector3 pos)
    {
        pos.x -= 0.2f;
        var left = Physics2D.Linecast(pos - transform.right * 0.1f, pos - transform.up * 0.1f, ground);

        pos.x += 0.4f;
        var right = Physics2D.Linecast(pos + transform.right * 0.1f, pos - transform.up * 0.1f, ground);

        return left || right;
    }

    /// <summary>
    /// ジャンプに関する処理
    /// </summary>
    void Jump(float y)
    {
        //スペースキーでジャンプ
        if (Input.GetButtonDown("Jump"))
        {
            //ジャンプ量を代入します
            var move = rb2D.velocity;
            //下への重力速度を0にします
            move.y = 0;
            move.y = jumpSpeed;
            rb2D.velocity = move;
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

        playerPos.y += sr.size.y / 2;

        //弾生成
        var shot = Instantiate(shotObject, playerPos, Quaternion.identity);
        ////角度変換
        var rot = shot.transform.localEulerAngles;
        rot.z = angle;
        shot.transform.localEulerAngles = rot;
    }
}
