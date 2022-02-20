using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public ProjectileManager projectileManager;
    public MonsterManager monsterManager;

    private Rigidbody rigid;

    private int projType;
    private List<Skill> skills;

    public override void Init(long _id, int _maxHealth, int _attack, int _speed, CharacterType _characterType = CharacterType.PLAYER)
    {
        base.Init(_id, _maxHealth, _attack, _speed, _characterType);

        rigid = GetComponent<Rigidbody>();

        skills = new List<Skill>();

        // ���͸� ��� ���� �ּ��� �ϳ��� ��ų�� �ʿ��մϴ�.
        AddSkill(this.gameObject.AddComponent<Skill_Bow>());
    }

    /// <summary>
    ///  x,z �࿡�� �̵��ϸ� �ش� ������ �ٶ󺾴ϴ�. 
    /// </summary>
    /// <param name="arrow"> �̵�/�ֽ��Ϸ��� ���� </param>
    /// <returns>�̵� ����(���ڰ� �����Ͷ�� false)</returns>
    public bool Move(Vector2 arrow)
    {
        if (arrow == Vector2.zero)
            return false;

        Vector3 moveVelocity = new Vector3(arrow.x, 0, arrow.y) * speed * Time.deltaTime;
        rigid.MovePosition(transform.position + moveVelocity);
        rigid.rotation = Quaternion.Euler(0,-Mathf.Atan2(arrow.y, arrow.x) * Mathf.Rad2Deg, 0);
        return true;
    }
    
    /// <summary>
    /// �� ������ ��ų�� ȣ���մϴ�.
    /// </summary>
    /// <param name="isMoving"></param>
    public void CallSkill(bool isMoving)
    {
        // ���� ����� ���� ǥ������ ����ϴ�.
        GameObject target = monsterManager.FindNearestMonster(GetPosition());

        foreach (Skill skill in skills)
        {
            skill.ActRepeatly(isMoving, target);
        }
    }

    /// <summary>
    /// ��ų�� �߰��մϴ�.
    /// </summary>
    /// <param name="skill"></param>
    public void AddSkill(Skill skill)
    {
        // !issue: Ư�� ��ų�� �ߺ��̰ų�, ��ø�� �� ���� ��ų���� �Ǻ��ϴ� �Լ� �ʿ�
        skill.Init(this);
        skills.Add(skill);
    }

    /// <summary>
    /// ��ų�� ������ ��, �ߺ��� ���� ���� �ӽ���ġ
    /// </summary>
    /// <param name="skillIdx"></param>
    public void DelSkill(int skillIdx)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (skills[i].GetIdx() == skillIdx)
            {
                skills.RemoveAt(i);
                break;
            }
        }
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    public void SetProjType(int type)
    {
        projType = type;
    }

    public int GetProjType()
    {
        return projType;
    }
}
