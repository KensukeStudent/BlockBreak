using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI�Ǘ��N���X
/// </summary>
public class UIManager : Singleton<UIManager>
{
    protected override bool DontDestroy { get; } = true;

    /// <summary>
    /// �Q�[���N���A�E�Q�[���I�[�o�[�e�L�X�g
    /// </summary>
    [SerializeField] Text displayText;

    /// <summary>
    /// �X�e�[�W����\���N���X
    /// </summary>
    [SerializeField] StageDisplay stageDisplay;
    string stageDisplayText = "";
    /// <summary>
    /// �\���e�L�X�g
    /// </summary>
    public string StageDisplayText
    {
        set
        {
            stageDisplayText = value;
            dispMove = true;
            stageDisplay.Initialize(stageDisplayText);
        }
    }

    /// <summary>
    /// �X�e�[�W����\���t���O
    /// </summary>
    bool dispMove = false;

    private void Update()
    {
        if (!dispMove) return;

        //����ړ�
        if(stageDisplay.MoveEnd())
        {
            //�ړ�������A�Q�[���J�n
            GameManager.I.ChangeGamaMode(GameMode.GameStart);
            dispMove = false;
        }
    }

    /// <summary>
    /// �Q�[���I�[�o�[�p�l���\��
    /// </summary>
    public void ActiveGameOver()
    {
        displayText.text = "�`�Q�[���I�[�o�[�`";
        displayText.gameObject.SetActive(true);
    }

    /// <summary>
    /// �Q�[���N���A�p�l����\��
    /// </summary>
    public void ActiveGameClear()
    {
        displayText.text = "�`�N���A�`";
        displayText.gameObject.SetActive(true);
    }

    /// <summary>
    /// �e�L�X�g���\��
    /// </summary>
    public void InActiveDisplayText()
    {
        displayText.gameObject.SetActive(false);
    }
}
