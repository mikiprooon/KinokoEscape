using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // シーン管理の名前空間を追加

public class TitleScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // ボタンクリック時に呼び出されるメソッド
    public void OnStartButtonClicked()
    {   
        
        Debug.Log("Start");
        // "GameScene"にシーンを変更
        SceneManager.LoadScene("GameScene");
    }
}

