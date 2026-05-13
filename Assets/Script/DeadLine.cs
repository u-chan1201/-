using UnityEngine;

public class DeadLine : MonoBehaviour
{
    // インスペクターでGameManagerをドラッグ＆ドロップして紐付ける
    public GameManager gameManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 接触した相手が「Enemy」というタグを持っていたら
        if (collision.CompareTag("Enemy"))
        {
            gameManager.EnemyReachedLeft();

            // 到達した敵自身は消しておく
            Destroy(collision.gameObject);
        }
    }
}
