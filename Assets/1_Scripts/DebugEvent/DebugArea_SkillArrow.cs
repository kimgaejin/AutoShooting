using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugArea_SkillArrow : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player)
            return;
        if (player.GetComponent<Skill_ProjArrow>())
            return;
        // 스킬의 중복처리 코드가 미흡해서 임시로 하드코딩
        if (player.GetComponent<Skill_ProjSoccerBall>())
            Destroy(player.GetComponent<Skill_ProjSoccerBall>());

        player.AddSkill(player.gameObject.AddComponent<Skill_ProjArrow>());
        player.DelSkill(3); // 축구공 투사체 스킬 삭제
    }
}
