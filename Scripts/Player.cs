using Godot;

public class Player : KinematicBody2D
{
    [Export]
    private readonly int _speed = 160;

    private RayCast2D _node;

    public override void _Ready()
    {
        _node = (RayCast2D)GetNode("RayCast2D");
    }

    public override void _Process(float delta)
    {
        var motion = new Vector2();
        if (Input.IsActionPressed("ui_up"))
        {
            motion += new Vector2(0, -1);
            _node.RotationDegrees = 180;
        }
        if (Input.IsActionPressed("ui_down"))
        {
            motion += new Vector2(0, 1);
            _node.RotationDegrees = 0;
        }
        if (Input.IsActionPressed("ui_left"))
        {
            motion += new Vector2(-1, 0);
            _node.RotationDegrees = 90;
        }
        if (Input.IsActionPressed("ui_right"))
        {
            motion += new Vector2(1, 0);
            _node.RotationDegrees = -90;
        }
        motion = motion.Normalized() * _speed;
        MoveAndSlide(motion);
    }
}
