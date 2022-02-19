using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어의 투사체를 다시 화살로 변경하는 스킬입니다.
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