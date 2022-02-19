using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �÷��̾ ����� �� �ִ� ��ų�� �߻� Ŭ�����Դϴ�.
/// �÷��̾ ���� ���� ��ų�� ����� �� �ִٰ� �����߽��ϴ�. 
/// <example>�������� ȭ���� ������ + ȭ���� �౸������ �ٲٱ� + ���������� 2�ʰ� ���� </example>
/// </summary>
public abstract class Skill : MonoBehaviour
{
    protected int idx;  // ��ų�� �ߺ��� �������� �ε���
    protected List<int> requestSkill;   // ��ų�� �ر��ϱ� ���� ���� �ʿ��� ��ų -�̱���
    protected List<int> sufficientSkill;    // ��ų�� �ر��ϸ� �ر��� �� �ִ� ��ų -�̱���

    /// <summary>
    /// ��ų�� ����� ���� �÷��̾ ������ �� �� ȣ���մϴ�.
    /// ��ų���� �ʿ���ϴ� ������ �ٸ��� ������ player�� �ɷ�ġ���� �ʿ��� �κ��� ������ �˾Ƽ� ����ϰ� �ۼ��߽��ϴ�.
    /// ���ݷ� ����, ����ü ���� �� 1ȸ������ �����ؾ��ϴ� �κе鵵 Init���� �߰��մϴ�.
    /// </summary>
    /// <param name="player"></param>
    public virtual void Init(Player player)
    {
        requestSkill = new List<int>();
        sufficientSkill = new List<int>();
    }

    /// <summary>
    /// �����Ӹ��� ȣ��Ǹ� n�ʿ� 1ȸ ȭ���� ��� �� �۾��� �մϴ�.
    /// </summary>
    /// <param name="isPlayerMoving"></param>
    /// <param name="target"></param>
    public virtual void ActRepeatly(bool isPlayerMoving, GameObject target)
    {

    }

    public int GetIdx()
    {
        return idx;
    }
}
