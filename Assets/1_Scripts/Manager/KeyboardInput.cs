using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput
{
    /// <summary>
    /// 키보드로 입력한 wasd 입력을 Vector2로 바꿔서 전달
    /// </summary>
    /// <returns>현재 플레이어가 이동하고자 하는 방향</returns>
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
