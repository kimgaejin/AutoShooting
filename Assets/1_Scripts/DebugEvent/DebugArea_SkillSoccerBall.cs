using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어가 영역에 들어오면 자동으로 투사체를 축구공으로 변경
/// </summary>
public class DebugArea_SkillSoccerBall : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player)
            return;
        if (player.GetComponent<Skill_ProjSoccerBall>())
            return;
        // 스킬의 중복처리 코드가 미흡해서 임시로 하드코딩
        if (player.GetComponent<Skill_ProjArrow>())
            Destroy(player.GetComponent<Skill_ProjArrow>());

        player.AddSkill(player.gameObject.AddComponent<Skill_ProjSoccerBall>());
        player.DelSkill(2); // 화살 투사체 스킬 삭제
    }
}
