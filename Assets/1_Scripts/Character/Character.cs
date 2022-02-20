using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public enum CharacterType { NONE, PLAYER, FRIENDLY, OFFENSIVE };

    protected bool enable;
    protected int maxHealth;
    protected int health;
    protected int attack;
    protected int speed;
    protected CharacterType characterType;

    public int Hp{
        get { return health;  }
        set {
            if (value > maxHealth) value = maxHealth;
            health = value;
        }
    }

    public virtual void Init(int _maxHealth, int _attack, int _speed, CharacterType _characterType)
    {
        this.maxHealth = _maxHealth;
        this.Hp = _maxHealth;
        this.attack = _attack;
        this.speed = _speed;
        this.characterType = _characterType;
        this.enable = true;
    }

    /// <summary>
    /// ���� ������ Ȯ���մϴ�.
    /// </summary>
    /// <param name="_team"></param>
    /// <returns> ���� ���̶�� true ��ȯ </returns>
    public bool CompareTeam(CharacterType _characterType)
    {
        return Equals(characterType, _characterType);
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
