using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoD : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(-3.2f, 0.29f, -14.2f), // 初期位置（position[0]）
            new Vector3(13.8f, 0.29f, -14.2f), // 目的地1（position[1]）
            new Vector3(-14.5f, 0.29f, -14.2f) // 目的地2（position[2]）
        };
        speed = 5.0f; // スピード
    }
}

