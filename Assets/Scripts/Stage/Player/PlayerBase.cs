using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : ActorBase
{
    public enum MoveMode
    {
        GameMode, //任意操作
        AutoMode　//オート操作
    }

    MoveMode moveMode = MoveMode.GameMode;

    protected virtual void FixedUpdate()
    {
        //横の移動
        var h = Input.GetAxisRaw("Horizontal");

        var move = rb2D.velocity;

        switch (moveMode)
        {
            case MoveMode.GameMode:

                move.x = GameModeDirection(h);

                break;
            case MoveMode.AutoMode:

                move.x = Move(AutoModeDirection());

                break;

            default:
                break;
        }

        rb2D.velocity = move;
    }

    protected virtual float GameModeDirection(float h)
    {
        return Move(h);
    }

    /// <summary>
    /// オート移動方向
    /// </summary>
    protected virtual float AutoModeDirection()
    {
        return moveSpeed;
    }

    protected virtual void Update()
    {
        var pos = transform.position;
        //高さからアニメーションを変更
        var y = Mathf.Round(rb2D.velocity.y);
        anim.SetBool("Jump", y > 0 && !IsGround(pos));
        anim.SetBool("Fall", (y == 0 || y < 0) && !IsGround(pos));

        if (!JumpFlag()) return;

        if (moveMode != MoveMode.GameMode) return;
        //縦の移動
        var v = Input.GetAxisRaw("Vertical");

        if (IsGround(pos))
        {
            //ジャンプ処理
            Jump(v);
        }

        //派生もとの更新処理
        transform.position = OnUpdate(pos);
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    /// <param name="pos">プレイヤー座標</param>
    protected virtual Vector2 OnUpdate(Vector2 pos) { return pos; }

    /// <summary>
    /// 移動モードを変更
    /// </summary>
    public virtual void ChangeMoveMode(MoveMode mode)
    {
        moveMode = mode;
    }

    /// <summary>
    /// ジャンプフラグ
    /// </summary>
    /// <returns></returns>
    protected virtual bool JumpFlag() { return true; }
}
