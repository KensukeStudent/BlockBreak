using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ボックス制御クラス
/// </summary>
public class Box : MonoBehaviour
{
    Animator anim;
    /// <summary>
    /// 当たったか判定
    /// </summary>
    public bool Hit { private set; get; } = false;
    /// <summary>
    /// アニメションは再生したかフラグ
    /// </summary>
    public bool Anim { private set; get; } = false;
   
    /// <summary>
    /// ヒットオブジェクト名
    /// </summary>
    [SerializeField] string hitName = "Ball";

    /// <summary>
    /// サウンドクラス
    /// </summary>
    ISoundClass sound = new ISoundClass();
    [SerializeField] AudioClip[] clip;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        sound.audio = GetComponent<AudioSource>();
        sound.clip = clip;
    }

    /// <summary>
    /// 更新処理
    /// </summary>
    public virtual void OnUpdate() { }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag(hitName))
        {
            Hit = true;
        }
    }

    /// <summary>
    /// 破壊アニメーション再生
    /// </summary>
    public void SetBreak()
    {
        Anim = true;
        anim.SetBool("Break", true);
        sound.PlaySE();
    }
}
