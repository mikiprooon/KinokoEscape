using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoC : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(-26.4f, 0.29f, -35.6f), // 初期位置（position[0]）
            new Vector3(-26.4f, 0.29f, -24.9f), // 目的地1（position[1]）
            new Vector3(-15.3f, 0.29f, -24.9f), // 目的地2（position[2]）
            new Vector3(-26.4f, 0.29f, -24.9f), // 目的地3（position[3]）
            new Vector3(-26.4f, 0.29f, -35.6f), // 目的地4（position[4]）
            new Vector3(-36.1f, 0.29f, -35.6f)  // 目的地5（position[5]）
        };
        speed = 5.0f; // スピード
    }
}

