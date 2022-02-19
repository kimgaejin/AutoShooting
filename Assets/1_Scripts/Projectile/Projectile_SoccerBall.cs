using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �⺻���� ����ü�� �޸� �浹�ϴ��� 1ȸ�� ������� �ʴ� ����ü�Դϴ�.
/// </summary>
public class Projectile_SoccerBall : Projectile
{
    private int bounceLife;

    public override void Collide(Collider coll)
    {
        // if character ...
        Character collCharacter = coll.GetComponent<Character>();
        if (collCharacter)
        {
            if (!collCharacter.CompareTeam(team))
            {
                collCharacter.Damaged(damage);

                bounceLife--;
            }
        }

        // if wall ...
        if (coll.CompareTag("Map"))
        {
            bounceLife--;
        }

        if (bounceLife < 0)
            Delete();
    }

    public override Projectile Init(ProjectileManager projectileManager, int _type)
    {
        return base.Init(projectileManager, _type);
    }

    public override void Move()
    {
        base.Move();
    }

    public override void Shoot(Vector3 start, Vector3 dest, int _team, float speed = 1, float damage = 1)
    {
        base.Shoot(start, dest, _team, speed, damage);
        bounceLife = 1;
    }
}
