using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Creator: Mark Graham
 * Creation Date: April 12, 2022
 * Script Name: AIMgr.cs
 */

public class AIMgr : MonoBehaviour
{
    // Variables
    public static AIMgr inst;
    public RaycastHit hit;
    public int layerMask;
    public float clickRadius = 10000;
    private Vector3 offset = new Vector3(100, 0, 0);


    // Class instance for call in any other script
    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        layerMask = LayerMask.GetMask("Ocean");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),
                               out hit, float.MaxValue, layerMask))
            {
                Debug.DrawLine(Camera.main.transform.position, hit.point, Color.red, 2);
                Vector3 pos = hit.point;
                pos.y = 0;
                Entity381 ent = FindClosesEntInRadius(pos, clickRadius);
                if (ent == null)
                {
                    if (Input.GetKey(KeyCode.LeftAlt))
                    {
                        HandleTeleport(hit.point);
                    }
                    else
                    {
                        HandleMove(hit.point);
                    }
                }
                else
                {
                    if (Input.GetKey(KeyCode.LeftControl))
                    {
                        HandleIntercept(ent);
                    }
                    else
                    {
                        HandleFollow(ent);
                    }
                }
            }
            else
            {
                Debug.Log("Right mouse button did not collide with anything!");
            }
        }
    }

    void HandleTeleport(Vector3 point)
    {
        Teleport teleport = new Teleport(SelectionMgr.inst.selectedEntity, point);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if(Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(teleport);
        }
        else 
        {
            uai.SetCommand(teleport);
        }
    }

    void HandleMove(Vector3 point)
    {
        Move move = new Move(SelectionMgr.inst.selectedEntity, point);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(move);
        }
        else
        {
            uai.SetCommand(move);
        }
    }

    void HandleFollow(Entity381 entity)
    {
        Follow follow = new Follow(SelectionMgr.inst.selectedEntity, entity, offset);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(follow);
        }
        else
        {
            uai.SetCommand(follow);
        }
    }

    void HandleIntercept(Entity381 entity)
    {
        Intercept intercept = new Intercept(SelectionMgr.inst.selectedEntity, entity);
        UnitAI uai = SelectionMgr.inst.selectedEntity.GetComponent<UnitAI>();
        if (Input.GetKey(KeyCode.LeftShift))
        {
            uai.AddCommand(intercept);
        }
        else
        {
            uai.SetCommand(intercept);
        }
    }

    public Entity381 FindClosesEntInRadius(Vector3 point, float radiusSquared)
    {
        Entity381 minEnt = null;
        float minDistance = float.MaxValue;
        foreach (Entity381 ent in EntityMgr.inst.entities)
        {
            float distanceSqr = (ent.position - point).sqrMagnitude;
            if (distanceSqr < radiusSquared)
            {
                if (distanceSqr < minDistance)
                {
                    minDistance = distanceSqr;
                    minEnt = ent;
                }
            }
        }
        return minEnt;
    }
}
