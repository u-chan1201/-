using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private bool m_pressedLeft = false;
    private bool m_pressedRight= false;
    private bool m_pressedUp = false;
    private bool m_pressedDown = false;

    private Move move;
    private BulletFactory bf;

    [SerializeField] private float x;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        move = this.gameObject.GetComponent<Move>();
        bf = this.gameObject.GetComponent<BulletFactory>();

        move.rightMove = this.PressedRight();
        move.leftMove = this.PressedLeft();
        move.upMove = this.PressedUp();
        move.downMove = this.PressedDown();
    }

    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.wKey.IsPressed() || Keyboard.current.upArrowKey.IsPressed())
        {
            m_pressedUp = true;
        }
        else
        {
            m_pressedUp = false;
        }

        if (Keyboard.current.sKey.IsPressed() || Keyboard.current.downArrowKey.IsPressed())
        {
            m_pressedDown = true;
        }
        else
        {
            m_pressedDown = false;
        }

        if(Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            bf.Shoot(this.gameObject.transform.position, x);
        }
    }

    PressedJudge PressedRight()
    {
        return  new PressedJudge(() => { return m_pressedRight; });
    }
    PressedJudge PressedLeft()
    {
        return new PressedJudge(() => { return m_pressedLeft; });
    }
    PressedJudge PressedUp()
    {
        Debug.Log("上");
        return new PressedJudge(() => { return m_pressedUp; });
    }
    PressedJudge PressedDown()
    {
        Debug.Log("下");
        return new PressedJudge(() => { return m_pressedDown; });
    }
}
