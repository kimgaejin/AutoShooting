using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ���Ͱ� �߻��ϴ� ����ü���� �����ִ� Ŭ�����Դϴ�.
/// </summary>
public class Projectile : MonoBehaviour
{
    protected const float TIME_OUT = 60.0f;
    protected ProjectileManager projectileManager;

    public bool myAble;
    protected Vector3 arrowVec;
    protected float timer;
    protected int damage;
    protected long ownerId;
    protected Character.CharacterType ownerType;   // ������ ȭ������ �ĺ��Ͽ� �浹���� ������ ����
    protected int projType;   // ȭ���� �𵨸�, ����Ʈ ����

    public virtual Projectile Init(ProjectileManager _projectileManager, int _type)
    {
        projType = _type;
        myAble = false;
        this.projectileManager = _projectileManager;
        this.gameObject.SetActive(false);
        return this;
    }

    /// <summary>
    /// start���� dest �������� ���ϴ� ����ü�� �߻��մϴ�.
    /// </summary>
    /// <param name="start">������ġ�� �ʱ�ȭ</param>
    /// <param name="dest">�������� �����ص� ������� ����</param>
    /// <param name="_team">�浹 ����: 1 �÷��̾�, 2 ����. ���� ���� �� ���� ����</param>
    /// <param name="speed"></param>
    /// <param name="damage"></param>
    public virtual void Shoot(Vector3 start, Vector3 dest, Character.CharacterType _ownerType, float speed=1.0f, float damage=1)
    {
        this.gameObject.SetActive(true);

        // ���� ��ġ
        transform.position = start;
        // ����� �ӵ�
        Vector3 diff = new Vector3(dest.x - start.x, 0, dest.z - start.z).normalized * speed;
        arrowVec = diff;
        transform.rotation = Quaternion.Euler(0, -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg, 0);
        // ��
        this.ownerType = _ownerType;
        // Ȱ��ȭ ����
        myAble = true;
        timer = 0.0f;
    }

    /// <summary>
    /// ����ü�� ����� �����ϰ� ���� �� ����մϴ�.
    /// </summary>
    public virtual void Delete()
    {
        myAble = false;
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// �� �����Ӹ��� arrowVec ������ �����̸�, �ܺ� ����(�ٶ�, ���� �� ��)�� ���� �ʴ´ٰ� �����մϴ�.
    /// </summary>
    public virtual void Move()
    {
        if (!myAble)
            return;
        transform.position += arrowVec * Time.deltaTime;

        // ���� �ð� �̻� �����̸� ������ ���� �ʴ� ������ �����ϰ� �����մϴ�.
        timer += Time.deltaTime;
        if (timer > TIME_OUT)
        {
            Delete();
        }
    }

    /// <summary>
    /// �ٸ� ������Ʈ�� trigger�� �浹���� �� �۾��Դϴ�.
    /// </summary>
    /// <param name="coll"></param>
    public virtual void Collide(Collider coll)
    {
        // if character ...
        Character collCharacter = coll.GetComponent<Character>();
        if (collCharacter)
        {
            if (!collCharacter.CompareTeam(ownerType))
            {
                collCharacter.Damaged(damage);
                Delete();
            }
        }
        
        // if wall ...
        // ������ �浹������ �ϴ� tag�� �����մϴ�.
        if (coll.CompareTag("Map"))
        {
            Delete();
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        Collide(other);
    }

    public bool CompareProjType(int _type)
    {
        return Equals(projType, _type);
    }
}
