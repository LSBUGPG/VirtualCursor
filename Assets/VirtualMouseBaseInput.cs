using UnityEngine;
using UnityEngine.EventSystems;

public class VirtualMouseBaseInput : BaseInput
{
    public Vector2 virtualCursorPosition;
    Vector2 realMousePosition;
    [Tooltip("UI units per second")]public Vector2 cursorSpeed;

    public override Vector2 mousePosition => virtualCursorPosition;

    protected override void OnEnable()
    {
        base.OnEnable();
        GetComponent<StandaloneInputModule>().inputOverride = this;
    }

    public override bool GetMouseButtonDown(int button)
    {
        if (button == 0)
            return Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0);

        return base.GetMouseButtonDown(button);
    }

    public override bool GetMouseButton(int button)
    {
        if (button == 0)
            return Input.GetButton("Jump") || Input.GetMouseButton(0);

        return base.GetMouseButton(button);
    }

    public override bool GetMouseButtonUp(int button)
    {
        if (button == 0)
            return Input.GetButtonUp("Jump") || Input.GetMouseButtonUp(0);

        return base.GetMouseButtonUp(button);
    }

    void Update()
    {
        Vector2 mouseDelta = (Vector2)Input.mousePosition - realMousePosition;
        Vector2 stickDelta = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Time.deltaTime * cursorSpeed;
        virtualCursorPosition += mouseDelta + stickDelta;
        virtualCursorPosition.x = Mathf.Clamp(virtualCursorPosition.x, 0, Screen.width);
        virtualCursorPosition.y = Mathf.Clamp(virtualCursorPosition.y, 0, Screen.height);
        realMousePosition = Input.mousePosition;
    }
}