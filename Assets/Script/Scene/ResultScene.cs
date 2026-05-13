using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultScene : MonoBehaviour
{
    public GameObject resultClearPanel;
    public GameObject resultGameOverPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 両方消す
        resultClearPanel.SetActive(false);
        resultGameOverPanel.SetActive(false);

        // GameManagerの判定を見て表示を分ける
        if (GameManager.isClear)
        {
            // クリアパネルを表示
            resultClearPanel.SetActive(true);
        }
        else
        {
            // ゲームオーバーパネルを表示
            resultGameOverPanel.SetActive(true);
        }
    }

    // タイトルへ戻る
    public void BackToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    // リスタート
    public void RestartGame()
    {
        // 判定用の変数をリセットしてから遷移）
        GameManager.isClear = false;
        SceneManager.LoadScene("GamePlayScene");
    }
}
