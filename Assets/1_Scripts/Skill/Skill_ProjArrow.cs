using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾��� ����ü�� �ٽ� ȭ��� �����ϴ� ��ų�Դϴ�.
/// </summary>
public class Skill_ProjArrow : Skill
{
    public override void ActRepeatly(bool isPlayerMoving, GameObject target)
    {
        base.ActRepeatly(isPlayerMoving, target);
    }

    public override void Init(Player player)
    {
        base.Init(player);
        player.SetProjType(0);
        idx = 2;
    }
}