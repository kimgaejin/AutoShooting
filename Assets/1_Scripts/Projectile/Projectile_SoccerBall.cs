using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 기본적인 투사체와 달리 충돌하더라도 1회는 사라지지 않는 투사체입니다.
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
