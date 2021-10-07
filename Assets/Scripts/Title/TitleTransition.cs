using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// タイトル遷移クラス
/// </summary>
public class TitleTransition : FadeBase
{
    /// <summary>
    /// title用のオーディオ
    /// </summary>
    [SerializeField] AudioSource audio;

    const string firstScene = "Stage1";

    private void Start()
    {
        //遷移フラグセット
        SetFadeMode(FadeBase.FadeSequenceType.In);
    }

    protected override void FadeInBase()
    {
        audio.Play();
    }

    protected override void FadeOutBase()
    {
        SceneManager.LoadScene(firstScene);
    }
}
