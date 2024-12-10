using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoG : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(5.1f, 0.29f, 33.2f), // position[0]
            new Vector3(13.9f, 0.29f, 33.2f), // position[1]
            new Vector3(13.9f, 0.29f, 25.1f), // position[2]
            new Vector3(5.1f, 0.29f, 25.1f), // position[3]
        };
        speed = 4.0f; // スピード
    }
}
