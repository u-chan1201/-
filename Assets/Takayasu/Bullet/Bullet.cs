using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    float vec;

    private Rigidbody2D rb;
    private TextMeshProUGUI m_text;
    private RectTransform rectTransform;

    private Camera cam;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.anchoredPosition += new Vector2(vec * Time.deltaTime * 100f, 0);

        // UIÀ•WianchoredPositionj‚Å”»’è
        if (rectTransform.anchoredPosition.x > 1500)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetParam(Vector2 canvasPos, float x, string text)
    {
        m_text = GetComponent<TextMeshProUGUI>();
        rectTransform = GetComponent<RectTransform>();

        rectTransform.anchoredPosition = canvasPos;

        vec = x;
        m_text.text = text;

        if (transform.childCount > 0)
        {
            var childText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            if (childText != null) childText.text = text;
        }
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}



