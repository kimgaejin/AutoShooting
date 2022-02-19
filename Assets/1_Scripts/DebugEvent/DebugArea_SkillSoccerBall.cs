using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ������ ������ �ڵ����� ����ü�� �౸������ ����
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
        // ��ų�� �ߺ�ó�� �ڵ尡 �����ؼ� �ӽ÷� �ϵ��ڵ�
        if (player.GetComponent<Skill_ProjArrow>())
            Destroy(player.GetComponent<Skill_ProjArrow>());

        player.AddSkill(player.gameObject.AddComponent<Skill_ProjSoccerBall>());
        player.DelSkill(2); // ȭ�� ����ü ��ų ����
    }
}
