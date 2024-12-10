using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takenoko00 : MonoBehaviour
{
    // 目的地
    private Vector3 pointA = new Vector3(40.6f, 0.3f, -45.6f); // 以前のpointB
    private Vector3 pointB = new Vector3(-45.4f, 0.3f, -45.6f); // 以前のpointA

    // 初期位置
    private Vector3 startPosition = new Vector3(-4.2f, 0.3f, -45.6f);

    // スピード
    public float speed = 5.0f; // スピードを5.0fに設定

    // 回転の設定
    public float rotationDuration = 3.0f; // 回転にかける時間
    private bool isRotating = false;      // 回転中かどうか

    // 動作に必要な変数
    private bool movingToB = false; // A→Bの移動かどうか
    private float t = 0.0f;         // Lerpの補間係数
    private bool movingToA = true;  // 初期位置→Aへの移動中フラグ

    // 回転処理に必要な変数
    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float rotationProgress;

    void Start()
    {
        // 初期位置を設定
        transform.position = startPosition;
    }

    void Update()
    {
        if (isRotating)
        {
            // 回転処理を実行
            RotateObject();
        }
        else if (movingToA)
        {
            // 初期位置からAへの移動
            MoveToPositionA();
        }
        else
        {
            // AとBの間を移動
            MoveBetweenPoints();
        }
    }

    private void MoveToPositionA()
    {
        // 初期位置からAへの移動
        t += Time.deltaTime * speed / Vector3.Distance(startPosition, pointA);

        // 補間係数をクランプ（0〜1の範囲）
        t = Mathf.Clamp01(t);

        // Lerpで現在の位置を計算
        transform.position = Vector3.Lerp(startPosition, pointA, t);

        // 到着後にA→Bの動作を開始
        if (t >= 1.0f)
        {
            t = 0.0f; // 補間係数をリセット
            movingToA = false; // 初期位置→Aの移動終了
            movingToB = true;  // 次はA→Bの移動
            StartRotation();
        }
    }

    private void MoveBetweenPoints()
    {
        // 移動方向に応じて補間係数を更新
        t += (movingToB ? 1 : -1) * Time.deltaTime * speed / Vector3.Distance(pointA, pointB);

        // 補間係数をクランプ（0〜1の範囲）
        t = Mathf.Clamp01(t);

        // Lerpで現在の位置を計算
        transform.position = Vector3.Lerp(pointA, pointB, t);

        // 到着後に方向を切り替え
        if (t <= 0.0f || t >= 1.0f)
        {
            movingToB = !movingToB; // 移動方向を反転
            StartRotation();
        }
    }

    private void StartRotation()
    {
        isRotating = true; // 回転モードに切り替え
        rotationProgress = 0.0f;

        // 現在の回転を取得
        startRotation = transform.rotation;

        // 180度回転後の目標回転を計算
        targetRotation = startRotation * Quaternion.Euler(0, 180, 0);
    }

    private void RotateObject()
    {
        // 回転の進行度を計算
        rotationProgress += Time.deltaTime / rotationDuration;

        // 補間を使用して回転を更新
        transform.rotation = Quaternion.Lerp(startRotation, targetRotation, rotationProgress);

        // 回転が完了したら移動を再開
        if (rotationProgress >= 1.0f)
        {
            isRotating = false;
        }
    }
}
