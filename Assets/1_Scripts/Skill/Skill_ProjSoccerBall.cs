using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 사용하는 투사체를 축구공으로 변경하는 1회성 스킬입니다.
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
