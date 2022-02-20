using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �Ϲ������� ����ϴ� ����ü�Դϴ�.
/// </summary>
public class Projectile_Arrow : Projectile
{
    public override void Collide(Collider coll)
    {
        base.Collide(coll);
    }

    public override Projectile Init(ProjectileManager projectileManager, int _type)
    {
        return base.Init(projectileManager, _type);
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Shoot(Vector3 start, Vector3 dest, Character.CharacterType _characterType, float speed = 1, float damage = 1)
    {
        base.Shoot(start, dest, _characterType, speed, damage);
    }
}
