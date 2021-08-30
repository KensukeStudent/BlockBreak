using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾基底クラス
/// </summary>
public abstract class BallBase : MonoBehaviour
{
    SpriteRenderer sr;
    /// <summary>
    /// 移動速度X
    /// </summary>
    [SerializeField] float moveSpeedX = 5.0f;
    /// <summary>
    /// 移動速度Y
    /// </summary>
    [SerializeField] float moveSpeedY = 5.0f;

    /// <summary>
    /// プレイヤー移動可能範囲
    /// </summary>
    protected const float moveRangeX = 8;
    /// <summary>
    /// Y軸の最大
    /// </summary>
    protected const float maxRangeY = 5;
    /// <summary>
    /// Y軸の最小
    /// </summary>
    protected const float minRangeY = -4;

    /// <summary>
    /// 角度
    /// </summary>
    float angle;

    protected virtual void Start()
    {
        angle = transform.localEulerAngles.z;
        sr = GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        var pos = transform.position;
        //移動処理
        transform.position = Move(pos);

        //消滅フラグ
        if(DeadFlag())
        {
            //ゲームオーバー処理
            GameManager.Instance.ChangeGamaMode(GameMode.GameOver);

            gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    Vector2 Move(Vector2 pos)
    {
        //移動速度の正規化
        var rad = angle * (Mathf.PI / 180);

        pos.x += Mathf.Cos(rad) * moveSpeedX * Time.deltaTime;
        pos.y += Mathf.Sin(rad) * moveSpeedY * Time.deltaTime;

        return pos;
    }

    /// <summary>
    /// MaxXかMinXを超えた時に判定します
    /// </summary>
    protected bool RangeXOver(Vector2 pos)
    {
        return pos.x >= moveRangeX - sr.size.x / 2 || pos.x <= -moveRangeX + sr.size.x / 2;
    }

    /// <summary>
    /// MaxYかMinYを超えた時に判定します
    /// </summary>
    protected bool RangeYOver(Vector2 pos)
    {
        return pos.y >= maxRangeY - sr.size.y / 2 || pos.y <= minRangeY + sr.size.y / 2;
    }

    /// <summary>
    /// X軸の移動方向を反転します
    /// </summary>
    public void ChangeVectorX()
    {
        moveSpeedX *= -1;
    }

    /// <summary>
    /// X軸の移動方向を反転します
    /// </summary>
    public void ChangeVectorY()
    {
        moveSpeedY *= -1;
    }

    /// <summary>
    /// 弾消滅フラグ
    /// </summary>
    protected abstract bool DeadFlag();
}
