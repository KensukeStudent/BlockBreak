using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �{�b�N�X����]�N���X
/// ��������e����
/// </summary>
public class AroundBoxMan : SwitchButton
{
    /// <summary>
    /// �{�b�N�X�I�u�W�F�N�g
    /// </summary>
    [SerializeField] GameObject[] boxes;
    
    /// <summary>
    /// ���˒e
    /// </summary>
    [SerializeField] GameObject shotObject;

    /// <summary>
    /// ���a
    /// </summary>
    const float radius = 3.5f;

    Vector2 initPos;
    const float size = 0.9f;

    float[] angles = new float[5];

    protected override void Start()
    {
        base.Start();

        initPos = transform.position;
        SetInitPos();
    }

    /// <summary>
    /// �������W�ɃZ�b�g
    /// </summary>
    void SetInitPos()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            //�S�̂̈������̊p�x
            var angle = ( 360.0f / boxes.Length ) * i + 90;
            
            //�\�����鋗��
            var distance = radius - size / 2;

            //�p�x�����W�A���ɕϊ�
            var rad =  angle * Mathf.Deg2Rad;

            //���� + �p�x + ��������e�̍��W
            var x = distance * Mathf.Cos(rad) + initPos.x;
            var y = distance * Mathf.Sin(rad) + initPos.y;

            boxes[i].transform.position = new Vector2(x, y);
            angles[i] = angle;
        }
    }

    private void Update()
    {
        if (GameManager.Instance.gameMode != GameMode.GameStart) return;

        Around();
    }

    /// <summary>
    /// ��]����
    /// </summary>
    void Around()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            //�\�����鋗��
            var distance = radius - size / 2;

            //�p�x�����W�A���ɕϊ�
            var rad = angles[i] * Mathf.Deg2Rad;

            //��]
            var rotate = rad + Time.timeSinceLevelLoad;

            //���� + �p�x + ��������e�̍��W
            var x = distance * Mathf.Cos(rotate) + initPos.x;
            var y = distance * Mathf.Sin(rotate) + initPos.y;

            boxes[i].transform.position = new Vector2(x, y);
        }
    }

    public override void EventGO()
    {
        for (int i = 0; i < boxes.Length; i++)
        {
            var shot = Instantiate(shotObject, transform.position, Quaternion.identity);

            //�p�x�ϊ�
            var rot = shot.transform.localEulerAngles;
            rot.z = angles[i];
            shot.transform.localEulerAngles = rot;
        }
    }
}