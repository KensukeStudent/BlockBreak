using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 弾を制御するクラス
/// </summary>
public class ShotController : MonoBehaviour
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
    const float moveRangeX = 8;
    /// <summary>
    /// Y軸の最大
    /// </summary>
    const float maxRangeY = 5;
    /// <summary>
    /// Y軸の最小
    /// </summary>
    const float minRangeY = -4;

    /// <summary>
    /// 角度
    /// </summary>
    float angle;

    private void Start()
    {
        angle = transform.localEulerAngles.z;
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        var pos = transform.position;

        //壁に当たったら反転
        ChangeVectorByWall(pos);

        //移動処理
        transform.position = Move(pos);
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
    /// 移動ベクトルを変更
    /// </summary>
    void ChangeVectorByWall(Vector2 pos)
    {
        //MaxかMinを超えたら
        if (pos.x >= moveRangeX - sr.size.x / 2 || pos.x <= -moveRangeX + sr.size.x / 2)
        {
            //Xの速度を反転
            ChangeVectorX();
        }

        //MaxかMinを超えたら
        if (pos.y >= maxRangeY - sr.size.y / 2 || pos.y <= minRangeY + sr.size.y / 2)
        {
            //Yの速度を反転
            ChangeVectorY();
        }
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
}