using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// 몬스터를 생성하여 관리하고 모든 몬스터가 죽었는지 검사합니다.
/// </summary>
public class MonsterManager : MonoBehaviour
{
    public GameObject tempMonsterParent;

    private Queue<GameObject> enableMonster;

    public void Init()
    {
        enableMonster = new Queue<GameObject>();

        foreach (Transform tf in tempMonsterParent.transform)
        {
            enableMonster.Enqueue(tf.gameObject);
            tf.GetComponent<Character>().Init(1, 10000, 0, 0, Character.CharacterType.OFFENSIVE);
        }
    }

    /// <summary>
    /// 현재 사용 가능한 몬스터 중 인자로 받은 좌표와 가장 가까운 몬스터를 반환합니다.
    /// </summary>
    /// <remarks> 거리 계산시 y축에 상관없이 계산하므로 주의가 필요합니다.</remarks>>
    /// <param name="_position">몬스터와의 거리를 계산할 위치</param>
    /// <returns>인자로부터 가장 가까운 몬스터</returns>
    public GameObject FindNearestMonster(Vector3 _position)
    {
        GameObject neareastObject = enableMonster.OrderBy(obj =>
       {
           return Vector3.Distance(_position, obj.transform.position);
       })
   .FirstOrDefault();

        return neareastObject;
    }
}
