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
        // ��ų�� �ߺ�ó�� �ڵ尡 �����ؼ� �ӽ÷� �ϵ��ڵ�
        if (player.GetComponent<Skill_Bow_MultiShot1>())
            Destroy(player.GetComponent<Skill_Bow_MultiShot1>());

        player.AddSkill(player.gameObject.AddComponent<Skill_Bow>());
        player.DelSkill(1); // ��Ƽ ���� ��ų ����
    }
}
