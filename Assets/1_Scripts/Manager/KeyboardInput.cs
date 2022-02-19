using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput
{
    /// <summary>
    /// Ű����� �Է��� wasd �Է��� Vector2�� �ٲ㼭 ����
    /// </summary>
    /// <returns>���� �÷��̾ �̵��ϰ��� �ϴ� ����</returns>
    public Vector2 GetKeyboardArrow()
    {
        Vector2 arrow = Vector2.zero;
        if (Input.GetKey(KeyCode.W))
            arrow += Vector2.up;
        if (Input.GetKey(KeyCode.A))
                arrow += Vector2.left;
        if (Input.GetKey(KeyCode.S))
            arrow += Vector2.down;
        if (Input.GetKey(KeyCode.D))
            arrow += Vector2.right;

        return arrow.normalized;
    }
}
