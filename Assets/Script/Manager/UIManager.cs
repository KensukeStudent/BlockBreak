using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// UI�Ǘ��N���X
/// </summary>
public class UIManager : MonoBehaviour
{
    /// <summary>
    /// �\���e�L�X�g
    /// </summary>
    [SerializeField] Text displayText;

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
