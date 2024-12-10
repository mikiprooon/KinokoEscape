using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoA : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(-17.0f, 0.3f, -45.6f), // 初期位置（position[0]）
            new Vector3(40.6f, 0.3f, -45.6f), // 目的地1（position[1]）
            new Vector3(-47.8f, 0.3f, -45.6f)  // 目的地2（position[2]）
        };
        speed = 5.0f; // スピード
    }
}


