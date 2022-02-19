using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected bool enable;
    protected int maxHealth;
    protected int health;
    protected int attack;
    protected int speed;
    protected int team;

    public int Hp{
        get { return health;  }
        set {
            if (value > maxHealth) value = maxHealth;
            health = value;
        }
    }

    public virtual void Init(int _maxHealth, int _attack, int _speed, int _team)
    {
        this.maxHealth = _maxHealth;
        this.Hp = _maxHealth;
        this.attack = _attack;
        this.speed = _speed;
        this.team = _team;
        this.enable = true;
    }

    /// <summary>
    /// ���� ������ Ȯ���մϴ�.
    /// </summary>
    /// <param name="_team"></param>
    /// <returns> ���� ���̶�� true ��ȯ </returns>
    public bool CompareTeam(int _team)
    {
        return Equals(team, _team);
    }

    /// <summary>
    /// �ǰ� �� ȣ���ϴ� �Լ��Դϴ�.
    /// </summary>
    /// <param name="param"></param>
    public virtual void Damaged(int param)
    {
        Hp -= param;
    }
}
