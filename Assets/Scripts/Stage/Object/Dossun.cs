using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dossun : MonoBehaviour
{
    enum MoveType
    {
        MoveRepeat,
        Fall,
        End
    }

    MoveType moveType = MoveType.MoveRepeat;

    SpriteRenderer sr;
    /// <summary>
    /// �������鎞�̊�摜
    /// </summary>
    [SerializeField] Sprite fallFace;
    Rigidbody2D rb2d;
    /// <summary>
    /// �������x
    /// </summary>
    float fallSpeed = 20.0f;
    /// <summary>
    /// �����G�t�F�N�g
    /// </summary>
    [SerializeField] GameObject fallEffect;

    /// <summary>
    /// �������W
    /// </summary>
    Vector2 initPos;

    /// <summary>
    /// �ړ����x
    /// </summary>
    const float moveSpeed = 0.5f;

    /// <summary>
    /// �ړ�����
    /// </summary>
    const float moveLength = 2.0f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        
        initPos = transform.position;
    }

    private void Update()
    {
        if (GameManager.I.gameMode != GameMode.GameStart) return;

        switch (moveType)
        {
            case MoveType.MoveRepeat:
                
                var pos = transform.position;
                //�����^��
                var rad = Time.timeSinceLevelLoad * Mathf.PI;
                pos.x = Mathf.Cos(rad * moveSpeed) * moveLength + initPos.x;
                transform.position = pos;

                break;
            
            case MoveType.Fall:

                //�����ړ�
                var move = rb2d.velocity;
                //�������x���㏸
                move.y -= Time.deltaTime * fallSpeed;
                rb2d.velocity = move;

                break;

            default:
                break;
        }
    }

    /// <summary>
    /// �����t���O�Z�b�g
    /// </summary>
    public void SetFallFlag()
    {
        moveType = MoveType.Fall;
        //�������x��������
        rb2d.velocity = Vector2.zero;
        //���I�Ȃ��̂ɕω�
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        //�������Ɋ��ω�
        sr.sprite = fallFace;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //���ɓ��������痎�����~
        if(col.gameObject.CompareTag("Ground"))
        {
            moveType = MoveType.End;
            rb2d.velocity = Vector2.zero;
            //���I�Ȃ��̂ɕω�
            rb2d.bodyType = RigidbodyType2D.Kinematic;

            //�G�t�F�N�g����

        }
    }
}
