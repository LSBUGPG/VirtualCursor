using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualMouseBaseInput : BaseInput
{
    public Vector2 virtualCursorPosition;

    public override Vector2 mousePosition => virtualCursorPosition;

    protected override void OnEnable()
    {
        base.OnEnable();
        GetComponent<StandaloneInputModule>().inputOverride = this;
    }

    public override float GetAxisRaw(string axisName)
    {
        if (axisName == "Horizontal") return Input.GetAxis("Horizontal");
        if (axisName == "Vertical") return Input.GetAxis("Vertical");
        return base.GetAxisRaw(axisName);
    }

    public override bool GetMouseButtonDown(int button)
    {
        if (button == 0)
            return Input.GetButtonDown("Jump");
        return base.GetMouseButtonDown(button);
    }
    public override bool GetMouseButtonUp(int button)
    {
        if (button == 0)
            return Input.GetButtonUp("Jump");
        return base.GetMouseButtonUp(button);
    }
}