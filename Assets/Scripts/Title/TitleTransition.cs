using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �^�C�g���J�ڃN���X
/// </summary>
public class TitleTransition : FadeBase
{
    /// <summary>
    /// title�p�̃I�[�f�B�I
    /// </summary>
    [SerializeField] AudioSource audio;

    const string firstScene = "Stage1";

    private void Start()
    {
        //�J�ڃt���O�Z�b�g
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
