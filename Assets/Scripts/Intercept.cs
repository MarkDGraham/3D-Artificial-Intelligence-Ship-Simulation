using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Intercept : Command
{
    public Entity381 target;
    public Vector3 predPosition;
    float distance, relativeSpeed, interceptTime;

    public Intercept(Entity381 ent, Entity381 targetedEnt) : base(ent)
    {
        target = targetedEnt;
    }


    public override void Init()
    {
        entity.desiredSpeed = entity.maxSpeed;
    }



    public override void Tick()
    {
        distance = (target.position - entity.position).magnitude;
        relativeSpeed = (entity.velocity - target.velocity).magnitude;
        interceptTime = distance / relativeSpeed;

        predPosition = target.position + (target.velocity * interceptTime);

        diff = predPosition - entity.position;
        entity.desiredHeading = Utils.Degrees360(Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg);
    }

    public Vector3 diff = Vector3.positiveInfinity;
    public float doneDistanceSqr = 1000;
    public override bool IsDone()
    {
        diff = target.position - entity.position;
        return (diff.sqrMagnitude < doneDistanceSqr);

    }

    public override void Stop()
    {
        entity.desiredSpeed = 0;
    }
}
