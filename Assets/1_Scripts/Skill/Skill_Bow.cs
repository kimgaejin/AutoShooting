using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 가장 가까운 적에게 투사체를 발사하는 가장 기본적인 스킬입니다.
/// </summary>
public class Skill_Bow : Skill
{
    private ProjectileManager projectileManager;
    private Player player;
    private float timer = 0.0f;
    private float shootInterval = 1.0f;

    public override void ActRepeatly(bool isPlayerMoving, GameObject target)
    {
        base.ActRepeatly(isPlayerMoving, target);

        timer -= Time.deltaTime;
        if (isPlayerMoving)
            return;

        if (!target)
            return;
       
        if (timer < 0)
        {
            timer = shootInterval;
            Projectile projectile = projectileManager.AllowcateInstance(player.GetProjType());
            projectile.Shoot(player.GetPosition(), target.transform.position, 1, 3, 1);
        }
    }

    public override void Init(Player _player)
    {
        base.Init(_player);

        this.player = _player;
        this.projectileManager = _player.projectileManager;
        idx = 0;
        player.SetProjType(0);
    }
}
