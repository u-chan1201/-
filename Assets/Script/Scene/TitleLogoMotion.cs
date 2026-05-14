using UnityEngine;

public class TitleLogoMotion : MonoBehaviour
{
    public float amplitude = 2.0f; // 揺れる幅
    public float speed = 0.5f;     // 揺れる速さ

    Vector3 startPos;

    void Start()
    {
        // 最初の位置を覚えておく
        startPos = transform.localPosition;
    }

    void Update()
    {
        // サイン波（Mathf.Sin）を使って上下に動かす
        float y = Mathf.Sin(Time.time * speed) * amplitude;
        transform.localPosition = startPos + new Vector3(0, y, 0);
    }
}
