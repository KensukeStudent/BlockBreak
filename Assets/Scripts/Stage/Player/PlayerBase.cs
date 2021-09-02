using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBase : ActorBase
{
    public enum MoveMode
    {
        GameMode, //�C�ӑ���
        AutoMode�@//�I�[�g����
    }

    MoveMode moveMode = MoveMode.GameMode;

    protected virtual void FixedUpdate()
    {
        //���̈ړ�
        var h = Input.GetAxisRaw("Horizontal");

        var move = rb2D.velocity;

        switch (moveMode)
        {
            case MoveMode.GameMode:

                move.x = GameModeDirection(h);

                break;
            case MoveMode.AutoMode:

                move.x = Move(AutoModeDirection());

                break;

            default:
                break;
        }

        rb2D.velocity = move;
    }

    protected virtual float GameModeDirection(float h)
    {
        return Move(h);
    }

    /// <summary>
    /// �I�[�g�ړ�����
    /// </summary>
    protected virtual float AutoModeDirection()
    {
        return moveSpeed;
    }

    protected virtual void Update()
    {
        var pos = transform.position;
        //��������A�j���[�V������ύX
        var y = Mathf.Round(rb2D.velocity.y);
        anim.SetBool("Jump", y > 0 && !IsGround(pos));
        anim.SetBool("Fall", (y == 0 || y < 0) && !IsGround(pos));

        if (!JumpFlag()) return;

        if (moveMode != MoveMode.GameMode) return;
        //�c�̈ړ�
        var v = Input.GetAxisRaw("Vertical");

        if (IsGround(pos))
        {
            //�W�����v����
            Jump(v);
        }

        //�h�����Ƃ̍X�V����
        transform.position = OnUpdate(pos);
    }

    /// <summary>
    /// �X�V����
    /// </summary>
    /// <param name="pos">�v���C���[���W</param>
    protected virtual Vector2 OnUpdate(Vector2 pos) { return pos; }

    /// <summary>
    /// �ړ����[�h��ύX
    /// </summary>
    public virtual void ChangeMoveMode(MoveMode mode)
    {
        moveMode = mode;
    }

    /// <summary>
    /// �W�����v�t���O
    /// </summary>
    /// <returns></returns>
    protected virtual bool JumpFlag() { return true; }
}
