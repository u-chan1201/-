using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public int score = 0;               // 現在の得点
    public int targetScore = 100;       // 目標の得点
    public int enemyCount = 0;          // 到達した敵の数
    public int gameOverEnemyCount = 3;  // 何体でゲームオーバーか

    public static bool isClear = false; // クリア判定
    public static int finalScore = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        finalScore = 0;
    }

    // 敵が左端に到達したときに、敵側のスクリプトから呼ばれる命令(敵をカウント)
    public void EnemyReachedLeft()
    {
        // 到達したら数える
        enemyCount++;
        finalScore = score;
        Debug.Log("敵が到達、現在" + enemyCount);

        // 3体以上通ったらゲームオーバー
        if (enemyCount >= gameOverEnemyCount)
        {
            GameOver();
        }
    }

    // 敵を倒したときに、敵側のスクリプトから呼ばれる命令(スコア加点)
    public void AddScore(int amount)
    {
        // 得点加点
        score += amount;
        Debug.Log("得点ゲット！ 現在: " + score);

        // 目標の得点に到達したらクリア
        if (score >= targetScore)
        {
            GameClear();
        }
    }

    void GameClear()
    {
        isClear = true;
        Debug.Log("クリア！");
        SceneManager.LoadScene("ResultScene");
    }

    void GameOver()
    {
        isClear = false;
        Debug.Log("ゲームオーバー...");
        SceneManager.LoadScene("ResultScene");
    }
}
