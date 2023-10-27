using Godot;
using System;

// To use this script:
// 1.Create a Sprite node in your Godot 2D project.
// 2.Attach this script to the Sprite node.
// 3.Make sure the DragAndCropController script's properties are set correctly (e.g., the script should be placed in the Scripts tab of the Sprite node).
// 4.Run your project, and you should be able to click and drag the sprite within the TileMap.

public class DragAndCropController : Sprite
{
    private bool dragging = false;
    private Vector2 offset;

    public override void _Input(InputEvent @event)
    {
        if (@event is InputEventMouseButton mouseEvent)
        {
            if (mouseEvent.ButtonIndex == (int)ButtonList.Left)
            {
                if (mouseEvent.Pressed)
                {
                    Vector2 mousePosition = GetGlobalMousePosition();
                    if (RectMinSize.HasPoint(mousePosition))
                    {
                        // Start dragging when the left mouse button is pressed while the cursor is over the sprite
                        dragging = true;
                        offset = mousePosition - GlobalPosition;
                        CaptureMouse();
                    }
                }
                else if (dragging)
                {
                    // Stop dragging when the left mouse button is released
                    dragging = false;
                    ReleaseMouse();
                }
            }
        }
    }

    public override void _Process(float delta)
    {
        if (dragging)
        {
            // Update the sprite's position based on the cursor position
            GlobalPosition = GetGlobalMousePosition() - offset;
        }
    }
}

