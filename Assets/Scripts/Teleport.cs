using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : Command
{
    public Vector3 teleportPosition;

    public Teleport(Entity381 ent, Vector3 position) : base(ent)
    {
        teleportPosition = position;
    }

    public override void Init()
    {
        Debug.Log("Teleporting Entity to " + teleportPosition);
    }

    public override void Tick()
    {
        entity.position = teleportPosition;
    }

    public Vector3 diff = Vector3.positiveInfinity;
    public float doneDistanceSqr = 1000;
    public override bool IsDone()
    {
        diff = teleportPosition - entity.position;
        return (diff.sqrMagnitude < doneDistanceSqr);
    }

    public override void Stop()
    {

    }
}
