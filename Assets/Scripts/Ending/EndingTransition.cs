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

    [SerializeField] AudioSource audioBGM;
    AudioSource audioSE;

    private void Start()
    {
        SetFadeMode(FadeSequenceType.In);

        audioSE = GetComponent<AudioSource>();
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

        //ゲームクリアSE
        audioSE.PlayOneShot(audioSE.clip);

        GameManager.I.Delete();
        UIManager.I.Delete();
        StageManager.I.Delete();
        BallManager.I.Delete();
    }

    protected override void FadeOutBase()
    {
        SceneManager.LoadScene("Title");
    }
}
