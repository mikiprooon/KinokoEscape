using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoB : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(45.7f, 0.29f, -35.6f), // 初期位置（position[0]）
            new Vector3(5.0f, 0.29f, -35.6f),  // 目的地1（position[1]）
            new Vector3(20.0f, 0.29f, -35.6f)  // 目的地2（position[2]）
        };
        speed = 7.0f; // スピード
    }
}

