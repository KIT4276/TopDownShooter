using System;

namespace TDS
{
    public enum SideType : byte
    {
        None = 0,
        Player = 1,
        Enemy = 2,
    }

    public enum ProjectileType : byte
    {
        Тear = 1,
        Further = 2,
    }

    [Flags]
    public enum IgnoreAxisType : byte
    {
        None = 0,
        X = 1,
        Y = 2,
        Z = 4,
    }

    public enum AISttateType : byte
    {
        Seek = 0,
        Flee = 1,
        Wander = 2,
    }

    public enum ActionType : byte
    {
        Idle = 0, // ожидание
        Move = 1, // хотьба
        Shooting = 2, // стрельба
        Interact = 3, // взаимодействие
        Die = 4,
        HitReact = 5, // ранение
        Walk = 6,
    }

    public enum TriggerType : byte
    {
        Non = 0,
        Ammo = 1,
        Projectile = 2,
        AidKit = 3,
        Docs = 4,
        Artifact = 5,
        LeaveTheBase = 6,
    }

    public enum Chapter : byte
    {
        Non = 0,
        RoutineTask = 1,
        FirstMeeting = 2,
        TheIceHasBroken = 3,
        LookUp = 4,
        between = 5,
    }
}
