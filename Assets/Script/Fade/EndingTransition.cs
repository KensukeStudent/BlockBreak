using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �G���f�B���O��p�J�ڃN���X
/// </summary>
public class EndingTransition : FadeBase
{
    [SerializeField] GameObject[] effects;

    /// <summary>
    /// �Q�[���I���t���O
    /// </summary>
    bool endFlag = false;

    /// <summary>
    /// �v��
    /// </summary>
    float timer = 0.0f;
    /// <summary>
    /// �^�C�����~�b�g
    /// </summary>
    float timeLimit = 3.5f;

    private void Start()
    {
        SetFadeMode(FadeSequenceType.In);
    }

    protected override void Update()
    {
        base.Update();

        timer += Time.deltaTime;
        if(timer >= timeLimit)
        {
            if (Input.GetMouseButtonDown(0) && !FadeFlag && !endFlag)
            {
                endFlag = true;
                SetFadeFlag();
            }
        }
    }

    protected override void FadeInBase()
    {
        for (int i = 0; i < effects.Length; i++)
        {
            effects[i].SetActive(true);
        }
    }

    protected override void FadeOutBase()
    {
        SceneManager.LoadScene("Title");
    }
}