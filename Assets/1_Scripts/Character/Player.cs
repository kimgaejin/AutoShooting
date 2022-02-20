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

        // 몬스터를 잡기 위해 최소한 하나의 스킬은 필요합니다.
        AddSkill(this.gameObject.AddComponent<Skill_Bow>());
    }

    /// <summary>
    ///  x,z 축에서 이동하며 해당 방향을 바라봅니다. 
    /// </summary>
    /// <param name="arrow"> 이동/주시하려는 방향 </param>
    /// <returns>이동 여부(인자가 영벡터라면 false)</returns>
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
    /// 매 프레임 스킬을 호출합니다.
    /// </summary>
    /// <param name="isMoving"></param>
    public void CallSkill(bool isMoving)
    {
        // 가장 가까운 적을 표적으로 삼습니다.
        GameObject target = monsterManager.FindNearestMonster(GetPosition());

        foreach (Skill skill in skills)
        {
            skill.ActRepeatly(isMoving, target);
        }
    }

    /// <summary>
    /// 스킬을 추가합니다.
    /// </summary>
    /// <param name="skill"></param>
    public void AddSkill(Skill skill)
    {
        // !issue: 특정 스킬이 중복이거나, 중첩될 수 없는 스킬인지 판별하는 함수 필요
        skill.Init(this);
        skills.Add(skill);
    }

    /// <summary>
    /// 스킬을 삽입할 때, 중복을 막기 위해 임시조치
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
