using UnityEngine;

public class BulletFactory : MonoBehaviour
{
    [SerializeField] TextDatas textDatas;
    [SerializeField] private Bullet bullet;
    private Canvas c;
    private RectTransform canvasRect;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        c = GameObject.Find("Canvas").GetComponent<Canvas>();
        canvasRect = c.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shoot(Vector2 pos, float x)
    {
        int rand = Random.Range(0, textDatas.text.Count);

        GameObject parent = c.gameObject;
        var b = Instantiate(bullet, c.transform);

        Vector2 screenPos = Camera.main.WorldToScreenPoint(pos);

        //  スクリーン座標を、Canvasの中の座標に変換
        Vector2 localPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            canvasRect,
            screenPos,
            c.worldCamera,
            out localPos
        );
        b.SetParam(localPos, x, textDatas.text[rand]);
    }
}
