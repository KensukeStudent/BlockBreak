using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dossun : MonoBehaviour
{
    enum MoveType
    {
        MoveRepeat,
        Fall,
        End
    }

    MoveType moveType = MoveType.MoveRepeat;

    SpriteRenderer sr;
    /// <summary>
    /// 落下する時の顔画像
    /// </summary>
    [SerializeField] Sprite fallFace;
    Rigidbody2D rb2d;
    /// <summary>
    /// 落下速度
    /// </summary>
    float fallSpeed = 20.0f;
    /// <summary>
    /// 落下エフェクト
    /// </summary>
    [SerializeField] GameObject fallEffect;

    /// <summary>
    /// 初期座標
    /// </summary>
    Vector2 initPos;

    /// <summary>
    /// 移動速度
    /// </summary>
    const float moveSpeed = 0.5f;

    /// <summary>
    /// 移動長さ
    /// </summary>
    const float moveLength = 2.0f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        
        initPos = transform.position;
    }

    private void Update()
    {
        if (GameManager.I.gameMode != GameMode.GameStart) return;

        switch (moveType)
        {
            case MoveType.MoveRepeat:
                
                var pos = transform.position;
                //周期運動
                var rad = Time.timeSinceLevelLoad * Mathf.PI;
                pos.x = Mathf.Cos(rad * moveSpeed) * moveLength + initPos.x;
                transform.position = pos;

                break;
            
            case MoveType.Fall:

                //落下移動
                var move = rb2d.velocity;
                //落下速度を上昇
                move.y -= Time.deltaTime * fallSpeed;
                rb2d.velocity = move;

                break;

            default:
                break;
        }
    }

    /// <summary>
    /// 落下フラグセット
    /// </summary>
    public void SetFallFlag()
    {
        moveType = MoveType.Fall;
        //物理速度を初期化
        rb2d.velocity = Vector2.zero;
        //動的なものに変化
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        //落下時に顔を変化
        sr.sprite = fallFace;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //床に当たったら落下を停止
        if(col.gameObject.CompareTag("Ground"))
        {
            moveType = MoveType.End;
            rb2d.velocity = Vector2.zero;
            //動的なものに変化
            rb2d.bodyType = RigidbodyType2D.Kinematic;

            //エフェクト生成

        }
    }
}
