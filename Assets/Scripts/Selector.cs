using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{
    void Start()
    {
        entity = GetComponentInParent<Entity381>();
    }
    public Entity381 entity;
    public GameObject selectionCircle;
    public Vector3 endPos = new Vector3();

    // Update is called once per frame
    void Update()
    {

        if (entity != null)
        {
            selectionCircle.SetActive(entity.isSelected);
        }


    }

    private void OnMouseDown()
    {
        SelectionMgr.inst.SelectEntity(entity);
    }

}
