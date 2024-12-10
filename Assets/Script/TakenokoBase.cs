using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TakenokoBase : MonoBehaviour
{
    protected Vector3[] positions; // 目的地の配列
    protected float speed;
    protected float rotationSpeed = 60f; // 回転速度（度/秒）

    protected float t = 0.0f; // 1になったら目的地到着
    protected bool isRotating = false; // 回転中かどうか
    private Vector3 targetDirection; // 目的地の方向

    private int currentTargetIndex = 0; // 現在の目的地のインデックス
    private Rigidbody rb; // Rigidbodyコンポーネント

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyの取得
        Initialize(); // 初期化（派生クラスで具体化）
        transform.position = positions[0]; // 初期位置を設定（position[0]）
    }

    void Update()
    {
        if (isRotating)
        {
            RotateAtDestination(); // 目的地の方向へ回転
        }
        else
        {
            Move(); // 移動処理（共通）
        }
    }

    private void Move()
    {
        // 次の目的地
        Vector3 from = positions[currentTargetIndex];
        Vector3 to = positions[(currentTargetIndex + 1) % positions.Length]; // 配列を循環

        t += Time.deltaTime * speed / Vector3.Distance(from, to); // 1フレームの間に動いた量を比率にする
        t = Mathf.Clamp01(t); // 0 <= t <= 1に丸める
        
        // Rigidbodyを使って移動
        Vector3 direction = (to - from).normalized; // 移動方向
        rb.velocity = direction * speed;

        // 目的地に到達したら
        if (t >= 1.0f)
        {
            t = 0.0f; // 補間係数リセット
            currentTargetIndex = (currentTargetIndex + 1) % positions.Length; // 次の目的地に進む
            StartRotation(); // 回転開始
        }
    }

    private void StartRotation()
    {
        isRotating = true; // 回転状態にする
        
        // 目的地に向かう方向を設定
        targetDirection = positions[(currentTargetIndex + 1) % positions.Length] - transform.position;
        targetDirection.y = 0f; // Y軸の回転を無視して水平方向のみ回転
    }

    private void RotateAtDestination() // 目的地の方向へ回転
    {
        // 目標の方向と現在の方向を使って回転
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        // 目標回転方向に向かって回転
        float step = rotationSpeed * Time.deltaTime;
        Quaternion currentRotation = transform.rotation;
        transform.rotation = Quaternion.RotateTowards(currentRotation, targetRotation, step);

        // 回転が完了したら、移動を再開
        if (Quaternion.Angle(transform.rotation, targetRotation) <= 0.1f)
        {
            isRotating = false;
            rb.velocity = Vector3.zero; // 移動を停止
        }
    }

    // 派生クラスで実装すべき初期化処理
    protected abstract void Initialize();
}
