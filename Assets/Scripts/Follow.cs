using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : Command
{
    public Vector3 offset;
    public Entity381 followEntity;
    public Follow(Entity381 ent, Entity381 followEnt, Vector3 off) : base(ent)
    {
        offset = off;
        followEntity = followEnt;
    }

    public override void Init()
    {

    }


    public Vector3 diff = Vector3.positiveInfinity;
    public float doneDistanceSqr = 1000;
    public override void Tick()
    {
        diff = (followEntity.position + offset) - entity.position;
        entity.desiredHeading = Utils.Degrees360(Mathf.Atan2(diff.x, diff.z) * Mathf.Rad2Deg);


        diff = (followEntity.position + offset) - entity.position;
        if (diff.sqrMagnitude < doneDistanceSqr)
        {
            entity.desiredSpeed = followEntity.speed;
        }
        else
        {
            entity.desiredSpeed = entity.maxSpeed;
        }
    }


    public override bool IsDone()
    {
        return false;
    }

    public override void Stop()
    {

    }
}
