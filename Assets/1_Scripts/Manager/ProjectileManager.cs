using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어나 몬스터가 사용하려는 투사체들을 할당해주는 클래스입니다.
/// 2개의 리스트를 사용하여 오브젝트의 생성/삭제를 줄이고 쉬고있는 오브젝트를 없게 만듭니다.
/// <remarks>큐 형태였으나, 투사체 종류가 섞이면서 선입선출을 지키기 어려워 중간 요소 삭제를 위해 리스트로 변경됨. <remarks>
/// </summary>
public class ProjectileManager : MonoBehaviour
{
    public Transform projectilesParent;
    public GameObject[] projectilePrefab;
    private List<Projectile> enableProjectile; // 사용가능한 (현재 사용되길 기다리는) 투사체
    private List<Projectile> usingProjectile;  // 사용 중인 투사체

    public void Init()
    {
        enableProjectile = new List<Projectile>();
        usingProjectile = new List<Projectile>();
    }

    /// <summary>
    /// 투사체들이 움직이는 함수입니다. GameManager의 FixedUpdate에서 호출됩니다.
    /// </summary>
    public void CallMove()
    {
        // 큐의 앞부분부터, 사용하지 않는 투사체는 삭제합니다.
        for (int i = 0; i < usingProjectile.Count; i++)
        //while (usingProjectile.Count > 0)
        {

            // !issue: 가장 앞에 있는 투사체가 곧 사라질 가능성이 제일 크다는 전제하에 가장 앞에있는 투사체들이 사라지는지만 검사해 대기 큐로 보내고 있었으나
            // 투사체의 종류가 섞이면서 가장 앞에 있는 것이 오랫동안 남아있고 재사용되지 않을 가능성이 생김.
            // 오브젝트가 끝났는지 확인하기 위해 모든 오브젝트를 돌고있는 코드이기 때문에 수정해야 함.
            // 투사체 사용이 끝난 후 Delete() 함수를 호출 할 때, 사용중인 투사체 큐의 특정 위치를 기억하고 있다면 해결할 수 있으나 아직 고민 중.
            //Projectile p = usingProjectile.Peek();
            //if (p.myAble)
            //    break;

            // 
            Projectile p = usingProjectile[i];
            if (!p.myAble)
            {
                usingProjectile.RemoveAt(i);
                enableProjectile.Add(p);
            }
        }

        // 사용중인 모든 투사체를 순회하며 동작합니다.
        foreach (Projectile p in usingProjectile)
        {
            if (!p.myAble)
                continue;
            p.Move();
        }
    }

    /// <summary>
    /// 투사체를 할당받습니다.
    /// </summary>
    /// <remarks> 초기에는 하나의 투사체만 풀링한다고 생각하였으나, 모델링이 다른 투사체도 고려하면서 큐로 관리하는 의미가 줄었습니다. 관련해서 고민중입니다. </remarks>>
    /// <returns>Shoot() 함수를 호출하여 사용할 수 있는 투사체 클래스 </returns>
    public Projectile AllowcateInstance(int type)
    {
        // 투사체 오브젝트 풀링 디버깅 코드
        //Debug.Log(string.Format("proj{0}({1}+{2}) enable{1} using{2}", projectilesParent.childCount, enableProjectile.Count, usingProjectile.Count));
        
        // 사용이 끝난 투사체를 찾아 반환합니다
        Projectile target = null;
        for (int i = 0; i < enableProjectile.Count; i++)
        {
            Projectile p = enableProjectile[i];
            if (p.myAble == false && p.CompareProjType(type))
            {
                target = p;
                usingProjectile.Add(target);
                enableProjectile.RemoveAt(i);
                break;
            }
        }

        // 사용이 끝난 해당 타입 투사체가 없다면 하나 생성합니다
        if (target == null)
        {
            target = CreateInstance(type);
        }

        return target;
    }

    /// <summary>
    /// 투사체 객체를 새로 만들어 초기화합니다.
    /// </summary>
    public Projectile CreateInstance(int type)
    {
        GameObject targetObj = Instantiate(projectilePrefab[type], projectilesParent);
        Projectile targetProjectile = targetObj.GetComponent<Projectile>();
        targetProjectile.Init(this, type);
        usingProjectile.Add(targetProjectile);
        return targetProjectile;
    }
}
