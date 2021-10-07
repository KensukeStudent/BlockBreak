using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// サウンドインターフェイス
/// </summary>
interface ISound
{
    /// <summary>
    /// オーディオ
    /// </summary>
    [SerializeField] AudioSource audio { get; set; }
    /// <summary>
    /// オーディオクリップ
    /// </summary>
    [SerializeField] AudioClip[] clip { get; set; }

    /// <summary>
    /// SEを鳴らすクラス
    /// </summary>
    void PlaySE(int no, float vol = 1.0f);
}

/// <summary>
/// サウンドクラス
/// </summary>
public class ISoundClass : ISound
{
    public AudioSource audio { get; set; }
    public AudioClip[] clip { get; set; }

    public void PlaySE(int no = 0, float vol = 1)
    {
        audio.PlayOneShot(clip[no], vol);
    }
}
