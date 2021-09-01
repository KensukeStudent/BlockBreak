using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// エンディング専用遷移クラス
/// </summary>
public class EndingTransition : FadeBase
{
    [SerializeField] GameObject[] effects;

    /// <summary>
    /// ゲーム終わりフラグ
    /// </summary>
    bool endFlag = false;

    /// <summary>
    /// 計測
    /// </summary>
    float timer = 0.0f;
    /// <summary>
    /// タイムリミット
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
