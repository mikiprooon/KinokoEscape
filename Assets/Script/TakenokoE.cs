using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TakenokoE : MonoBehaviour
{
    public float speed = 3.0f; // 追跡時の速度
    public float detectionRange = 20.0f; // 視界の範囲を50fに変更
    public Transform kinoko; // 追跡対象（Kinoko）
    public LayerMask obstacleMask; // 壁のレイヤーマスク

    private Vector3 initialPosition; // 初期位置
    private NavMeshAgent agent; // NavMeshAgentコンポーネント
    private bool isChasing = false; // 追跡中かどうか

    void Start()
    {
        // 初期位置の記録
        initialPosition = transform.position;

        // NavMeshAgentの取得と設定
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        agent.stoppingDistance = 1.0f; // Kinokoに近づく停止距離
        agent.isStopped = true; // 初期状態で停止
    }

    void Update()
    {
        // Kinokoとの距離を測定
        float distanceToKinoko = Vector3.Distance(transform.position, kinoko.position);

        // Kinokoが視界に入っているかどうかをチェック
        if (distanceToKinoko <= detectionRange && CanSeeKinoko())
        {
            StartChasing(); // 追跡開始
        }
        else if (isChasing)
        {
            StopChasing(); // 追跡終了
        }

        Debug.Log("Distance to Kinoko: " + Vector3.Distance(transform.position, kinoko.position));
 // 現在位置のログ（デバッグ用）
    }

    // Kinokoを追跡する処理
    private void StartChasing()
    {
        isChasing = true;
        agent.isStopped = false;
        agent.SetDestination(kinoko.position); // Kinokoの位置を目的地として設定
    }

    // 追跡を停止し、初期位置に戻る処理
    private void StopChasing()
    {
        isChasing = false;
        agent.isStopped = false;
        agent.SetDestination(initialPosition); // 初期位置に戻る

        // 初期位置に戻ったら停止
        if (Vector3.Distance(transform.position, initialPosition) < 0.1f)
        {
            agent.isStopped = true;
        }
    }

    // Kinokoが視界内にいるか確認
    private bool CanSeeKinoko()
    {
        Vector3 directionToKinoko = kinoko.position - transform.position;
        float distanceToKinoko = directionToKinoko.magnitude;

        // RaycastでKinokoと障害物の判定
        if (!Physics.Raycast(transform.position, directionToKinoko.normalized, distanceToKinoko, obstacleMask))
        {
            return true; // 障害物がない場合、Kinokoが見える
        }
        return false; // 障害物がある場合、Kinokoが見えない
    }
}
