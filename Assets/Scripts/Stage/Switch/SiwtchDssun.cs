using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///�{�[�����G�ꂽ��h�b�X���N��
/// </summary>
public class SiwtchDssun : SwitchButton
{
    /// <summary>
    /// �h�b�X���I�u�W�F�N�g
    /// </summary>
    [SerializeField] Dossun dossun;

    public override void EventGO()
    {
        dossun.SetFallFlag();
    }
}