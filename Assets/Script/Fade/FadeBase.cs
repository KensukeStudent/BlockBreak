using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 点滅処理させるクラス
/// </summary>
public abstract class FadeBase : MonoBehaviour
{
    /// <summary>
    /// 点滅モード
    /// </summary>
    public enum FadeSequenceType
    {
        In,//明るくなる
        Out//暗くなる
    }

    protected FadeSequenceType fadeSequenceType = FadeSequenceType.Out;

    /// <summary>
    /// 速度
    /// </summary>
    float fadeSpeed = 1.2f;

    /// <summary>
    /// アルファ値最大
    /// </summary>
    float maxAlpha = 1.0f;
    /// <summary>
    /// アルファ値最小
    /// </summary>
    float minAlpha = 0.0f;

    /// <summary>
    /// 変更するアルファ値
    /// </summary>
    protected float alpha = 1.0f;

    /// <summary>
    /// フェイドさせるUI
    /// </summary>
    [SerializeField] Image panel;

    /// <summary>
    /// フェイドフラグ
    /// </summary>
    public bool FadeFlag { private set; get; } = false;

    protected virtual void Update()
    {
        FadeUpdate();
    }

    /// <summary>
    /// 初期化処理
    /// </summary>
    protected void Initialize(float fadeSpeed, float maxAlpha, float minAlpha)
    {
        this.fadeSpeed = fadeSpeed;

        this.maxAlpha = maxAlpha;
        this.minAlpha = minAlpha;
    }

    /// <summary>
    /// フェイド処理
    /// </summary>
    void FadeUpdate()
    {
        if (!FadeFlag) return;

        switch (fadeSequenceType)
        {
            //フェイドイン処理
            case FadeSequenceType.In:

                UpdateIn();

                if (EndIn())
                {
                    FadeFlag = false;
                    fadeSequenceType = FadeSequenceType.Out;
                    //継承されるクラスで処理記述
                    FadeInBase();
                }

                break;

            //フェイドアウト処理
            case FadeSequenceType.Out:

                UpdateOut();

                if (EndOut())
                {
                    FadeFlag = false;
                    fadeSequenceType = FadeSequenceType.In;
                    //継承されるクラスで処理記述
                    FadeOutBase();
                }

                break;
        }

        panel.fillAmount = alpha;
    }

    /// <summary>
    /// フェイドイン処理(透明化)
    /// </summary>
    void UpdateIn()
    {
        alpha -= Time.deltaTime * fadeSpeed;
        alpha = Mathf.Clamp(alpha, minAlpha, maxAlpha);
    }

    /// <summary>
    /// フェイドアウト処理(暗化)
    /// </summary>
    void UpdateOut()
    {
        alpha += Time.deltaTime * fadeSpeed;
        alpha = Mathf.Clamp(alpha, minAlpha, maxAlpha);
    }

    /// <summary>
    /// フェイドイン終了
    /// </summary>
    bool EndIn()
    {
        return alpha == minAlpha;
    }

    /// <summary>
    /// フェイドアウト終了
    /// </summary>
    bool EndOut()
    {
        return alpha == maxAlpha;
    }

    /// <summary>
    /// フェイドイン後処理
    /// </summary>
    protected abstract void FadeInBase();

    /// <summary>
    /// フェイドアウト後処理
    /// </summary>
    protected abstract void FadeOutBase();

    /// <summary>
    /// フェイドタイプを指定
    /// <para>In ---> 透過処理</para>
    /// Out --> 暗化処理
    /// </summary>
    /// <param name="fadeType">フェイドタイプ</param>
    public void SetFadeMode(FadeSequenceType fadeType)
    {
        fadeSequenceType = fadeType;

        switch (fadeType)
        {
            case FadeSequenceType.In:
                alpha = 1;
                break;

            case FadeSequenceType.Out:
                alpha = 0;
                break;
        }

        panel.fillAmount = alpha;
        SetFadeFlag();
    }

    /// <summary>
    /// フェイド開始
    /// </summary>
    public void SetFadeFlag()
    {
        FadeFlag = true;
    }
}