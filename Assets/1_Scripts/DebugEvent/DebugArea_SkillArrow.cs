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
        // ��ų�� �ߺ�ó�� �ڵ尡 �����ؼ� �ӽ÷� �ϵ��ڵ�
        if (player.GetComponent<Skill_ProjSoccerBall>())
            Destroy(player.GetComponent<Skill_ProjSoccerBall>());

        player.AddSkill(player.gameObject.AddComponent<Skill_ProjArrow>());
        player.DelSkill(3); // �౸�� ����ü ��ų ����
    }
}
