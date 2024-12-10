using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoH : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(-34.8f, 0.29f, 15.3f), // position[0]
            new Vector3(-5.8f, 0.29f, 15.3f), // position[1]
            new Vector3(-34.8f, 0.29f, 15.3f), // position[2]
            new Vector3(-34.8f, 0.29f, -24.8f), // position[3]
        };
        speed = 4.0f; // スピード
    }
}
