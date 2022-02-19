using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugArea_SkillBow : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (!player)
            return;
        if (player.GetComponent<Skill_Bow>())
            return;
        // 스킬의 중복처리 코드가 미흡해서 임시로 하드코딩
        if (player.GetComponent<Skill_Bow_MultiShot1>())
            Destroy(player.GetComponent<Skill_Bow_MultiShot1>());

        player.AddSkill(player.gameObject.AddComponent<Skill_Bow>());
        player.DelSkill(1); // 멀티 공격 스킬 삭제
    }
}
