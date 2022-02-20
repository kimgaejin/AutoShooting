using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMonster : Character
{
    private Animator anim;

    public override void Init(int _maxHealth, int _attack, int _speed, CharacterType _characterType)
    {
        base.Init(_maxHealth, _attack, _speed, _characterType);
        anim = transform.Find("Model").GetComponent<Animator>();
    }

    public override void Damaged(int param)
    {
        base.Damaged(param);
        anim.SetTrigger("Shooted");
    }

}
