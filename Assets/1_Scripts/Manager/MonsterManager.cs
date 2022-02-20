using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/// <summary>
/// ���͸� �����Ͽ� �����ϰ� ��� ���Ͱ� �׾����� �˻��մϴ�.
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
    /// ���� ��� ������ ���� �� ���ڷ� ���� ��ǥ�� ���� ����� ���͸� ��ȯ�մϴ�.
    /// </summary>
    /// <remarks> �Ÿ� ���� y�࿡ ������� ����ϹǷ� ���ǰ� �ʿ��մϴ�.</remarks>>
    /// <param name="_position">���Ϳ��� �Ÿ��� ����� ��ġ</param>
    /// <returns>���ڷκ��� ���� ����� ����</returns>
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
