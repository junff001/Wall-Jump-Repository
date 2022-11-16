using System;

[Serializable]
public enum PlayerState
{
    OnGround,
    StickToWall,
    Jump,
    Fall,
    AerialJump,
    BashJump,
    Death
}
