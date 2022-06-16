using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : Command

{
    public Vector3 movePos;
    public Move(Entity381 ent, Vector3 pos) : base(ent)
    {
        movePos = pos;
    }

    public override void Init()
    {
        entity.desiredSpeed = entity.maxSpeed;
    }

    public override void Tick()
    {
        diff = movePos - entity.position;
        entity.desiredHeading = Utils.Degrees360(Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg);
    }

    public Vector3 diff = Vector3.positiveInfinity;
    public float doneDistanceSqr = 1000;
    public override bool IsDone()
    {
        diff = movePos - entity.position;
        return (diff.sqrMagnitude < doneDistanceSqr);
    }
    public override void Stop()
    {
        entity.desiredSpeed = 0;
    }
}
