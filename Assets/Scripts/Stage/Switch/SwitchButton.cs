using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�[�����G��邱�ƂŃA�N�V�������N�����{�^��
/// </summary>
public abstract class SwitchButton : MonoBehaviour
{
    protected SpriteRenderer sr;
    /// <summary>
    /// �X�C�b�`�I���摜
    /// </summary>
    [SerializeField] Sprite switchOn;

    /// <summary>
    /// �C�x���g�t���O
    /// </summary>
    protected bool eventFlag = false;

    protected virtual void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    /// <summary>
    /// �C�x���g����
    /// </summary>
    public abstract void EventGO();

    private void OnTriggerEnter2D(Collider2D col)
    {
        //�{�[���ɐG�ꂽ��C�x���g�N��
        if(col.gameObject.CompareTag("Ball") && !eventFlag)
        {
            eventFlag = true;
            sr.sprite = switchOn;
            EventGO();
        }
    }
}
