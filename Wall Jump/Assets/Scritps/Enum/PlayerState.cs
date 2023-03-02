using System;

[Serializable]
public enum PlayerState
{
    Idle,       // Group
    OnGround,
    StickToWall,
    PostureCorrection,
    BasicJump,
    AerialJump,
    BashJump,
    Death
}
