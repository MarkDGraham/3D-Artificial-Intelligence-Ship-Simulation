using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMgr : MonoBehaviour
{
    public static ControlMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public float deltaHeading = 2.0f;
    public float deltaSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredSpeed += deltaSpeed;
        }
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredSpeed -= deltaSpeed;
        }
        SelectionMgr.inst.selectedEntity.desiredSpeed =
            Utils.Clamp(SelectionMgr.inst.selectedEntity.desiredSpeed,
            SelectionMgr.inst.selectedEntity.minSpeed, SelectionMgr.inst.selectedEntity.maxSpeed);

        
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredHeading -= deltaHeading;
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            SelectionMgr.inst.selectedEntity.desiredHeading += deltaHeading;
        }
        SelectionMgr.inst.selectedEntity.desiredHeading = Utils.Degrees360(SelectionMgr.inst.selectedEntity.desiredHeading);
    }
}
