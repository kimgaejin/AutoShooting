using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ����ϴ� ����ü�� �౸������ �����ϴ� 1ȸ�� ��ų�Դϴ�.
/// </summary>
public class Skill_ProjSoccerBall : Skill
{
    public override void ActRepeatly(bool isPlayerMoving, GameObject target)
    {
        base.ActRepeatly(isPlayerMoving, target);
    }

    public override void Init(Player player)
    {
        base.Init(player);
        player.SetProjType(1);
        idx = 3;
    }
}
