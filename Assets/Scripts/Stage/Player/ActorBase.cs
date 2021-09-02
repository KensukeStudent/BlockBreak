using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 移動クラス基底
/// </summary>
public class ActorBase : MonoBehaviour
{
    protected Rigidbody2D rb2D;
    protected Animator anim;
    protected SpriteRenderer sr;

    /// <summary>
    /// 移動速度
    /// </summary>
    protected const float moveSpeed = 5.0f;
    /// <summary>
    /// ジャンプ速度
    /// </summary>
    protected const float jumpSpeed = 5.0f;

    /// <summary>
    /// 地面設置
    /// </summary>
    LayerMask ground;

    protected virtual void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        ground = LayerMask.GetMask("Ground");
    }

    /// <summary>
    /// 横の移動制御
    /// </summary>
    protected float Move(float h)
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

    /// <summary>
    /// 地面着地判定
    /// </summary>
    /// <returns></returns>
    protected bool IsGround(Vector3 pos)
    {
        pos.x -= 0.2f;
        var left = Physics2D.Linecast(pos - transform.right * 0.1f, pos - transform.up * 0.1f, ground);

        pos.x += 0.4f;
        var right = Physics2D.Linecast(pos + transform.right * 0.1f, pos - transform.up * 0.1f, ground);

        return left || right;
    }

    /// <summary>
    /// ジャンプ処理
    /// </summary>
    protected void Jump(float y)
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
}
