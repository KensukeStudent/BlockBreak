using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �T�E���h�C���^�[�t�F�C�X
/// </summary>
interface ISound
{
    /// <summary>
    /// �I�[�f�B�I
    /// </summary>
    [SerializeField] AudioSource audio { get; set; }
    /// <summary>
    /// �I�[�f�B�I�N���b�v
    /// </summary>
    [SerializeField] AudioClip[] clip { get; set; }

    /// <summary>
    /// SE��炷�N���X
    /// </summary>
    void PlaySE(int no, float vol = 1.0f);
}

/// <summary>
/// �T�E���h�N���X
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
