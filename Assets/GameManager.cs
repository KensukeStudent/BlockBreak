using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    GameWait,
    GameStart,
    GameOver,
    GameClear
}

/// <summary>
/// �Q�[���Ǘ�
/// </summary>
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { private set; get; }
    public GameMode gameMode { private set; get; } = GameMode.GameWait;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        //���Ԃ�x�点�ăX�^�[�g

    }

    /// <summary>
    /// �Q�[�����[�h��ύX
    /// </summary>
    public void ChangeGamaMode(GameMode mode)
    {
        gameMode = mode;

        switch (gameMode)
        {
            //����̂���
            case GameMode.GameStart:
            
                break;
            
            //�Q�[���I�[�o�[UI�\��
            case GameMode.GameOver:
            
                break;
            
            //�Q�[���N���AUI�\��
            //���̑J��
            case GameMode.GameClear:
            
                break;
            
            default:
         
                break;
        }
    }
}