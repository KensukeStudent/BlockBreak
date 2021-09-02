using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �^�C�g����ʊǗ��N���X
/// </summary>
public class TitleManager : MonoBehaviour
{
    /// <summary>
    /// �^�C�g���v���C���[
    /// </summary>
    PlayerBase player;
    /// <summary>
    /// �^�C�g���J�ڃN���X
    /// </summary>
    [SerializeField] TitleTransition titleFade;
    AudioSource audio;

    /// <summary>
    /// �Q�[���J�nX���W
    /// </summary>
    const float startPosX = 6.5f;

    /// <summary>
    /// �Q�[���J�n�t���O
    /// </summary>
    bool gameStart = false;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerBase>();
    }

    private void Update()
    {
        if (gameStart) return;

        var posPlayer = player.transform.position;

        if(posPlayer.x >= startPosX)
        {
            gameStart = true;
            //�v���C���[�����ړ����[�h
            player.ChangeMoveMode(PlayerBase.MoveMode.AutoMode);
            //�J�ڃt���O�Z�b�g
            titleFade.SetFadeFlag();

            //�X�^�[�g��
            audio.PlayOneShot(audio.clip);
        }
    }
}