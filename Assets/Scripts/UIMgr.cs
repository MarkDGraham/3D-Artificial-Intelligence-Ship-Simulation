using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    public static UIMgr inst;
    public Text entityName;
    public Text entitySpeed;
    public Text entityDesiredSpeed;
    public Text entityHeading;
    public Text entityDesiredHeading;

    private void Awake()
    {
        inst = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        entityName.text = SelectionMgr.inst.selectedEntity.name;
        entitySpeed.text = SelectionMgr.inst.selectedEntity.speed.ToString();
        entityDesiredSpeed.text = SelectionMgr.inst.selectedEntity.desiredSpeed.ToString();
        entityHeading.text = SelectionMgr.inst.selectedEntity.heading.ToString();
        entityDesiredHeading.text = SelectionMgr.inst.selectedEntity.desiredHeading.ToString();
    }
}
