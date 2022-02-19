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
        // ��ų�� �ߺ�ó�� �ڵ尡 �����ؼ� �ӽ÷� �ϵ��ڵ�
        if (player.GetComponent<Skill_Bow>())
            Destroy(player.GetComponent<Skill_Bow>());

        player.AddSkill(player.gameObject.AddComponent<Skill_Bow_MultiShot1>());
        player.DelSkill(0); // �Ϲ� ���� ��ų ����
    }
}
