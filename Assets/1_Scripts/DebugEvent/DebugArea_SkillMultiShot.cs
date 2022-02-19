using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugArea_SkillMultiShot : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player)
            return;
        if (player.GetComponent<Skill_Bow_MultiShot1>())
            return;
        // 스킬의 중복처리 코드가 미흡해서 임시로 하드코딩
        if (player.GetComponent<Skill_Bow>())
            Destroy(player.GetComponent<Skill_Bow>());

        player.AddSkill(player.gameObject.AddComponent<Skill_Bow_MultiShot1>());
        player.DelSkill(0); // 일반 공격 스킬 삭제
    }
}
