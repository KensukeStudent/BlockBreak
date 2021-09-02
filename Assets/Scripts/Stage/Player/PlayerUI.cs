using UnityEngine;
using UnityEngine.UI;
using TMPro;
 
/// <summary>
/// �v���C���[UI�N���X
/// </summary>
public class PlayerUI : MonoBehaviour
{
    [SerializeField] GameObject ui;
    [SerializeField] TMP_Text playerText;

    /// <summary>
    /// ���������̃e�L�X�g
    /// </summary>
    string[] winText = 
    { 
        "�����܂����`", 
        "������[", 
        "�Ƃ�ӂ��[���肽���B�B", 
        "���Ƃ����������[", 
        "�������`��", 
        "��䂤������", 
    };

    /// <summary>
    /// ���������̃e�L�X�g
    /// </summary>
    string[] loseText =
    {
        "���ꂨ������p�^�[���H",
        "�ڂ��̂������͂ނ����Ȃ�.....",
        "�����A\n�������B",
        "�͂�ւ����`",
        "�B�B�B�B",
        "�O�b�p�C�A�ڂ��̂��񂹂��B"
    };

    /// <summary>
    /// �X�e�[�W�̏󋵂ɂ���Č��t���ω�����
    /// </summary>
    public void SetVoice()
    {
        ui.SetActive(true);

        var rand = Random.Range(0, 6);

        var strVoice = "";

        switch (GameManager.Instance.gameMode)
        {
            case GameMode.GameOver:

                strVoice = loseText[rand];

                break;
            
            case GameMode.GameClear:

                strVoice = winText[rand];

                break;
            
            default:
                break;
        }

        playerText.text = strVoice;
    }
}