using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakenokoF : TakenokoBase
{
    protected override void Initialize()
    {
        positions = new Vector3[]
        {
            new Vector3(45.9f, 0.29f, 26.2f), // position[0]
            new Vector3(25.6f, 0.29f, 26.2f), // position[1]
            new Vector3(25.6f, 0.29f, 15.3f), // position[2]
            new Vector3(34.8f, 0.29f, 15.3f), // position[3]
            new Vector3(34.8f, 0.29f, -24.4f), // position[4]
            new Vector3(46.8f, 0.29f, -24.4f)  // position[5]
        };
        speed = 6.0f; // スピード
    }
}
