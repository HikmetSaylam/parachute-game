using GeneralScripts;
using UnityEngine;

public class InputController : MonoSingleton<InputController>
{
    [SerializeField] private Joystick controlJoystick;
    [SerializeField] private Joystick rotationJoystick;
    
    public float GetHorizontal()
    {
        return controlJoystick.Horizontal;
    }

    public float GetVertical()
    {
        return controlJoystick.Vertical;
    }

    public float GetRotationHorizontal()
    {
        return rotationJoystick.Horizontal;
    }
    
}
