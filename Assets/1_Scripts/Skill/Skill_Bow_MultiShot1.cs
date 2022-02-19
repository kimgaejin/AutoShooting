using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Skill_Bow의 진화형으로 여러 개의 투사체를 발사하는 스킬입니다.
/// </summary>
public class Skill_Bow_MultiShot1 : Skill
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
            Projectile projectile1 = projectileManager.AllowcateInstance(player.GetProjType());
            projectile1.Shoot(player.GetPosition(), target.transform.position, 1, 3, 1);
            
            // 30도 차이나도록 두번째 투사체를 날립니다.
            // !issue: Sin(theta), Cos(theta) 미리 계산하여 캐싱하는 등 최적화 필요함
            Projectile projectile2 = projectileManager.AllowcateInstance(player.GetProjType());
            Vector2 diff = new Vector2 (target.transform.position.x - player.GetPosition().x, target.transform.position.z - player.GetPosition().z);
            float theta = Mathf.PI / 6.0f;
            Vector2 rotVec = new Vector2(diff.x * Mathf.Cos(theta) - diff.y * Mathf.Sin(theta), diff.x * Mathf.Sin(theta) + diff.y * Mathf.Cos(theta));
            projectile2.Shoot(player.GetPosition(), target.transform.position+new Vector3(rotVec.x, 0, rotVec.y), 1, 3, 1);
        }
    }

    public override void Init(Player _player)
    {
        base.Init(_player);

        this.player = _player;
        this.projectileManager = _player.projectileManager;
        idx = 1;
    }
}
