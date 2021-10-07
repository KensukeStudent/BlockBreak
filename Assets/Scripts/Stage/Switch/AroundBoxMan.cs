using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボックスを回転クラス
/// 中央から弾発射
/// </summary>
public class AroundBoxMan : SwitchButton
{
    /// <summary>
    /// ボックスオブジェクト
    /// </summary>
    [SerializeField] GameObject[] boxes;
    
    /// <summary>
    /// 発射弾
    /// </summary>
    [SerializeField] GameObject shotObject;

    /// <summary>
    /// 半径
    /// </summary>
    const float radius = 3.5f;

    Vector2 initPos;
    const float size = 0.9f;

    float[] angles = new float[5];

    protected override void Start()
    {
        base.Start();

        initPos = transform.position;
        SetInitPos();
    }

    /// <summary>
    /// 初期座標にセット
    /// </summary>
    void SetInitPos()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            //全体の一つ当たりの角度
            var angle = ( 360.0f / boxes.Length ) * i + 90;
            
            //表示する距離
            var distance = radius - size / 2;

            //角度をラジアンに変換
            var rad =  angle * Mathf.Deg2Rad;

            //距離 + 角度 + 生成する親の座標
            var x = distance * Mathf.Cos(rad) + initPos.x;
            var y = distance * Mathf.Sin(rad) + initPos.y;

            boxes[i].transform.position = new Vector2(x, y);
            angles[i] = angle;
        }
    }

    private void Update()
    {
        if (GameManager.I.gameMode != GameMode.GameStart) return;

        Around();
    }

    /// <summary>
    /// 回転処理
    /// </summary>
    void Around()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            //表示する距離
            var distance = radius - size / 2;

            //角度をラジアンに変換
            var rad = angles[i] * Mathf.Deg2Rad;

            //回転
            var rotate = rad + Time.timeSinceLevelLoad;

            //距離 + 角度 + 生成する親の座標
            var x = distance * Mathf.Cos(rotate) + initPos.x;
            var y = distance * Mathf.Sin(rotate) + initPos.y;

            boxes[i].transform.position = new Vector2(x, y);
        }
    }

    public override void EventGO()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            var shot = Instantiate(shotObject, transform.position, Quaternion.identity);

            //角度変換
            var rot = shot.transform.localEulerAngles;
            rot.z = angles[i];
            shot.transform.localEulerAngles = rot;
        }
    }
}