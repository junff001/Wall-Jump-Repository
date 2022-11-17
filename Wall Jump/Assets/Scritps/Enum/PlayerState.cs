using System;

[Serializable]
public enum PlayerState
{
    Idle,       // Group
    OnGround,
    StickToWall,
    BasicJump,
    AerialJump,
    BashJump,
    Death
}
