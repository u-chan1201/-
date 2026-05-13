using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

// 抽象クラスを作成
public abstract class Judge
{
    public abstract bool Is();
}

// 実際の処理を書くコンポーネント
public class PressedJudge : Judge
{

    public PressedJudge(Func<bool> f)
    {
        func = f;
    }
    [SerializeField] private Func<bool> func;
    public override bool Is() => func.Invoke();
}

// 移動コンポーネント
public class Move : MonoBehaviour
{
    public PressedJudge rightMove;
    public PressedJudge leftMove;
    public PressedJudge upMove;
    public PressedJudge downMove;
    public PressedJudge jumpMove;

    [SerializeField] private Vector2 speed = new Vector2(0.5f, 0.5f);
    private float impuctSpeed = 0.0f;
    private bool m_isjump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (rightMove != null && rightMove.Is())
        {
            this.gameObject.transform.Translate(speed.x, 0, 0);
        }
        if (leftMove != null && leftMove.Is())
        {
            this.gameObject.transform.Translate(-speed.x, 0, 0);
        }
        if (upMove != null && upMove.Is())
        {
            this.gameObject.transform.Translate(0, speed.y, 0);
        }
        if (downMove != null && downMove.Is())
        {
            this.gameObject.transform.Translate(0, -speed.y, 0);
        }
        if (jumpMove != null && jumpMove.Is())
        {
            this.gameObject.transform.Translate(0, impuctSpeed, 0);
            if (!m_isjump) m_isjump = true;
        }

        if(m_isjump)
            this.gameObject.transform.Translate(0, impuctSpeed, 0);
    }
}
