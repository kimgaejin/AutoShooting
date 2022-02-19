using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ���Ͱ� ����Ϸ��� ����ü���� �Ҵ����ִ� Ŭ�����Դϴ�.
/// 2���� ����Ʈ�� ����Ͽ� ������Ʈ�� ����/������ ���̰� �����ִ� ������Ʈ�� ���� ����ϴ�.
/// <remarks>ť ���¿�����, ����ü ������ ���̸鼭 ���Լ����� ��Ű�� ����� �߰� ��� ������ ���� ����Ʈ�� �����. <remarks>
/// </summary>
public class ProjectileManager : MonoBehaviour
{
    public Transform projectilesParent;
    public GameObject[] projectilePrefab;
    private List<Projectile> enableProjectile; // ��밡���� (���� ���Ǳ� ��ٸ���) ����ü
    private List<Projectile> usingProjectile;  // ��� ���� ����ü

    public void Init()
    {
        enableProjectile = new List<Projectile>();
        usingProjectile = new List<Projectile>();
    }

    /// <summary>
    /// ����ü���� �����̴� �Լ��Դϴ�. GameManager�� FixedUpdate���� ȣ��˴ϴ�.
    /// </summary>
    public void CallMove()
    {
        // ť�� �պκк���, ������� �ʴ� ����ü�� �����մϴ�.
        for (int i = 0; i < usingProjectile.Count; i++)
        //while (usingProjectile.Count > 0)
        {

            // !issue: ���� �տ� �ִ� ����ü�� �� ����� ���ɼ��� ���� ũ�ٴ� �����Ͽ� ���� �տ��ִ� ����ü���� ����������� �˻��� ��� ť�� ������ �־�����
            // ����ü�� ������ ���̸鼭 ���� �տ� �ִ� ���� �������� �����ְ� ������� ���� ���ɼ��� ����.
            // ������Ʈ�� �������� Ȯ���ϱ� ���� ��� ������Ʈ�� �����ִ� �ڵ��̱� ������ �����ؾ� ��.
            // ����ü ����� ���� �� Delete() �Լ��� ȣ�� �� ��, ������� ����ü ť�� Ư�� ��ġ�� ����ϰ� �ִٸ� �ذ��� �� ������ ���� ��� ��.
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

        // ������� ��� ����ü�� ��ȸ�ϸ� �����մϴ�.
        foreach (Projectile p in usingProjectile)
        {
            if (!p.myAble)
                continue;
            p.Move();
        }
    }

    /// <summary>
    /// ����ü�� �Ҵ�޽��ϴ�.
    /// </summary>
    /// <remarks> �ʱ⿡�� �ϳ��� ����ü�� Ǯ���Ѵٰ� �����Ͽ�����, �𵨸��� �ٸ� ����ü�� ����ϸ鼭 ť�� �����ϴ� �ǹ̰� �پ����ϴ�. �����ؼ� ������Դϴ�. </remarks>>
    /// <returns>Shoot() �Լ��� ȣ���Ͽ� ����� �� �ִ� ����ü Ŭ���� </returns>
    public Projectile AllowcateInstance(int type)
    {
        // ����ü ������Ʈ Ǯ�� ����� �ڵ�
        //Debug.Log(string.Format("proj{0}({1}+{2}) enable{1} using{2}", projectilesParent.childCount, enableProjectile.Count, usingProjectile.Count));
        
        // ����� ���� ����ü�� ã�� ��ȯ�մϴ�
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

        // ����� ���� �ش� Ÿ�� ����ü�� ���ٸ� �ϳ� �����մϴ�
        if (target == null)
        {
            target = CreateInstance(type);
        }

        return target;
    }

    /// <summary>
    /// ����ü ��ü�� ���� ����� �ʱ�ȭ�մϴ�.
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
