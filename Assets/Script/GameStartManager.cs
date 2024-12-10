using UnityEngine;
using TMPro;

public class GameStartManager : MonoBehaviour
{
    public TextMeshProUGUI messageText; // メッセージ表示用のTextMeshPro
    public GameObject kinoko; // Kinokoオブジェクト

    private bool gameStarted = false;

    void Start()
    {
        // 初期設定
        messageText.gameObject.SetActive(true); // メッセージを表示
        Time.timeScale = 0; // ゲームを一時停止
    }

    void Update()
    {
        // ユーザーが何かキーを押したらゲーム開始
        if (!gameStarted && Input.anyKeyDown)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        gameStarted = true;
        messageText.gameObject.SetActive(false); // メッセージを非表示
        Time.timeScale = 1; // ゲームを再開
        if (kinoko != null)
        {
            kinoko.GetComponent<Rigidbody>().isKinematic = false; // 必要に応じてKinokoを動かす
        }
    }
}
