using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private static InputManager instance; //singleton
    private InputManager() { } //Constructor
    public static InputManager Instance
    {
        get
        {
            if(instance == null)
            {
              instance = new InputManager();
            }
            return instance;     
        }
    }

    public float Horizontal()
    {
        return Input.GetAxisRaw("Horizontal");
    }
    public float Vertical()
    {
        return Input.GetAxisRaw("Vertical");
    }
    public Vector2 Movement()
    {
        return new Vector2(Horizontal(),Vertical());
    }
    public bool Jump()
    {
        return Input.GetButtonDown("Jump");
    }
    public bool HasJumped()
    {
        return Input.GetButtonUp("Jump");
    }
    public bool Attack()
    {
        return Input.GetButtonDown("Attack");
    }
}
