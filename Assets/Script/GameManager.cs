using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static int score = 0;               // 現在の得点
    public int targetScore = 300;       // 目標の得点
    public int enemyCount = 0;          // 到達した敵の数
    public int gameOverEnemyCount = 3;  // 何体でゲームオーバーか

    public static bool isClear = false; // クリア判定
    public static int finalScore = 0;

    public AudioSource audioSource;    // スピーカー
    public AudioClip damageSE;        // ダメージ音
    public Image[] heartIcons;        // ライフの画像

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = 0;
        finalScore = 0;
        UpdateLifeUI();
    }

    // 敵が左端に到達したときに、敵側のスクリプトから呼ばれる命令(敵をカウント)
    public void EnemyReachedLeft()
    {
        // 到達したら数える
        enemyCount++;
        Debug.Log("敵が到達、現在" + enemyCount);

        // ダメージ音を鳴らす
        if (audioSource != null && damageSE != null)
        {
            audioSource.PlayOneShot(damageSE);
        }

        // ライフの見た目を更新
        UpdateLifeUI();

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
        finalScore = score;
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

    // ライフ画像を表示・非表示にする関数
    void UpdateLifeUI()
    {
        for (int i = 0; i < heartIcons.Length; i++)
        {
            // enemyCount（通った数）より後ろのアイコンだけ表示する
            // 例：1体通ったら 0番目のハートを消す
            if (i < enemyCount)
            {
                heartIcons[i].enabled = false; // 非表示
            }
            else
            {
                heartIcons[i].enabled = true;  // 表示
            }
        }
    }
}
