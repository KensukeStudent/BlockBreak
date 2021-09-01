using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ウェーブ上の動きをするブロック
/// </summary>
public class WaveBox : Box
{
    [Range(1, 1.2f)]
    /// <summary>
    /// 開始位置
    /// </summary>
    [SerializeField] float startLag;

    [Range(0.5f,3.0f)]
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] float moveSpeed = 2.0f;

    [Range(0.05f, 1.5f)]
    /// <summary>
    /// 移動長さ
    /// </summary>
    [SerializeField] float moveLength;

    /// <summary>
    /// 初期座標
    /// </summary>
    Vector2 initPos;

    protected override void Start()
    {
        base.Start();
        initPos = transform.position;
    }

    public override void OnUpdate()
    {
        var pos = transform.position;
        //周期
        var rad = (Time.time - startLag) * Mathf.PI;
        pos.y = Mathf.Sin(rad * moveSpeed) * moveLength + initPos.y;
        transform.position = pos;
    }
}