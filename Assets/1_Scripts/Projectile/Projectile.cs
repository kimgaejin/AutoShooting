using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 플레이어나 몬스터가 발사하는 투사체들이 갖고있는 클래스입니다.
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
    protected Character.CharacterType ownerType;   // 누구의 화살인지 식별하여 충돌할지 안할지 결정
    protected int projType;   // 화살의 모델링, 이펙트 종류

    public virtual Projectile Init(ProjectileManager _projectileManager, int _type)
    {
        projType = _type;
        myAble = false;
        this.projectileManager = _projectileManager;
        this.gameObject.SetActive(false);
        return this;
    }

    /// <summary>
    /// start부터 dest 방향으로 향하는 투사체를 발사합니다.
    /// </summary>
    /// <param name="start">시작위치로 초기화</param>
    /// <param name="dest">목적지에 도달해도 사라지진 않음</param>
    /// <param name="_team">충돌 여부: 1 플레이어, 2 몬스터. 팀이 같을 시 맞지 않음</param>
    /// <param name="speed"></param>
    /// <param name="damage"></param>
    public virtual void Shoot(Vector3 start, Vector3 dest, Character.CharacterType _ownerType, float speed=1.0f, float damage=1)
    {
        this.gameObject.SetActive(true);

        // 시작 위치
        transform.position = start;
        // 방향과 속도
        Vector3 diff = new Vector3(dest.x - start.x, 0, dest.z - start.z).normalized * speed;
        arrowVec = diff;
        transform.rotation = Quaternion.Euler(0, -Mathf.Atan2(diff.z, diff.x) * Mathf.Rad2Deg, 0);
        // 팀
        this.ownerType = _ownerType;
        // 활성화 여부
        myAble = true;
        timer = 0.0f;
    }

    /// <summary>
    /// 투사체의 기능을 정지하고 숨길 때 사용합니다.
    /// </summary>
    public virtual void Delete()
    {
        myAble = false;
        this.gameObject.SetActive(false);
    }

    /// <summary>
    /// 매 프레임마다 arrowVec 방향대로 움직이며, 외부 조건(바람, 폭발 힘 등)은 받지 않는다고 가정합니다.
    /// </summary>
    public virtual void Move()
    {
        if (!myAble)
            return;
        transform.position += arrowVec * Time.deltaTime;

        // 일정 시간 이상 움직이면 영원히 맞지 않는 것으로 생각하고 삭제합니다.
        timer += Time.deltaTime;
        if (timer > TIME_OUT)
        {
            Delete();
        }
    }

    /// <summary>
    /// 다른 오브젝트와 trigger가 충돌했을 때 작업입니다.
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
        // 벽과의 충돌인지는 일단 tag로 구분합니다.
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
