using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// �X�e�[�W����\���N���X
/// </summary>
public class StageDisplay : MonoBehaviour
{
    enum MoveMode
    {
        Start,
        Center,
        End
    }
    /// <summary>
    /// �ړ����[�h
    /// </summary>
    MoveMode mode = MoveMode.Start;

    /// <summary>
    /// ����
    /// </summary>
    const float witdh = 1600.0f;
    /// <summary>
    /// �\���f�B�X�v���C����
    /// </summary>
    const float hight = -135.0f;

    RectTransform rect;

    /// <summary>
    /// �ړ����x
    /// </summary>
    float moveSpeed = 2500.0f;

    /// <summary>
    /// �v��
    /// </summary>
    float timer = 0.0f;
    /// <summary>
    /// ��~����
    /// </summary>
    float stopTime = 1.2f;

    /// <summary>
    /// �ړ�����
    /// </summary>
    bool moveFinish = false;

    [SerializeField] Text displayText;

    void Start()
    {
        rect = GetComponent<RectTransform>();    
    }

    /// <summary>
    /// ������
    /// </summary>
    /// <param name="displayText">�X�e�[�W�\���e�L�X�g</param>
    public void Initialize(string displayText)
    {
        mode = MoveMode.Start;
        moveFinish = false;
        rect.anchoredPosition = new Vector2(witdh, hight);
        timer = 0;
        this.displayText.text = displayText;
    }

    /// <summary>
    /// �ړ����I������t���O
    /// </summary>
    public bool MoveEnd()
    {
        var dispPos = rect.anchoredPosition;

        switch (mode)
        {
            case MoveMode.Start:
            case MoveMode.End:

                dispPos.x -= Time.deltaTime * moveSpeed;

                if (mode == MoveMode.Start && dispPos.x <= 0)
                {
                    mode = MoveMode.Center;
                    dispPos.x = 0;
                }
                else if (mode == MoveMode.End && dispPos.x <= -witdh)
                {
                    moveFinish = true;
                }

                break;

            case MoveMode.Center:

                timer += Time.deltaTime;

                if (timer >= stopTime)
                {
                    timer = 0;
                    mode = MoveMode.End;
                }

                break;

            default:

                break;
        }

        rect.anchoredPosition = dispPos;

        return moveFinish;
    }
}
