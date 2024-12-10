using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kinoko : MonoBehaviour
{
    public float moveSpeed = 5f; // Kinokoの移動速度だよーん
    private Rigidbody rb; // Rigidbodyの参照を保持する変数
    private Transform tf; // 回転や移動を保持する変数

    public float collisionDistance = 5.7f; // 衝突とみなす距離

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Rigidbodyコンポーネントを取得
        tf = GetComponent<Transform>(); // Transformコンポーネントを取得
    }

    void Update()
    {
        // 入力による移動と回転を処理
        MoveKinoko();
        KinokoRotation();

        // 独自の衝突判定
        CheckCollisionWithTakenoko();

    }

    // 独自の衝突判定
    private void CheckCollisionWithTakenoko()
    {
        // "Takenoko" タグを持つすべてのオブジェクトを取得
        GameObject[] takenokos = GameObject.FindGameObjectsWithTag("Takenoko");

        foreach (GameObject takenoko in takenokos)
        {
            // Kinoko と Takenoko の距離を測定
            float distance = Vector3.Distance(transform.position, takenoko.transform.position);

            // 衝突判定距離内に入った場合
            if (distance <= collisionDistance)
            {
                Debug.Log("Takenoko と衝突しました！");
                SceneManager.LoadScene("FailedScene"); // FailedScene に遷移
                break;
            }
        }
    }

    // Triggerを使ってGoalと衝突した場合にClearSceneへ遷移
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Goal"))  // ゴールと触れたら
        {
            SceneManager.LoadScene("ClearScene"); // ClearSceneに遷移
        }
    }

    // Kinokoの移動処理
    private void MoveKinoko()
    {
        float fb = getAllowKeyVertical(); // 前後方向の入力
        float lr = getAllowKeyHorizon(); // 左右方向の入力

        // 入力に基づいて速度を計算
        Vector3 velocity = tf.forward * fb + tf.right * lr;
        rb.velocity = velocity * moveSpeed;
    }

    // Kinokoの回転処理
    private void KinokoRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            tf.Rotate(new Vector3(0, -1, 0)); // 左回転
        }
        else if (Input.GetKey(KeyCode.S))
        {
            tf.Rotate(new Vector3(0, 1, 0)); // 右回転
        }
    }

    float getAllowKeyHorizon()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            return -1.0f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            return 1.0f;
        }
        else
        {
            return 0.0f;
        }
    }

    float getAllowKeyVertical()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            return 1.0f;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            return -1.0f;
        }
        else
        {
            return 0.0f;
        }
    }
}
