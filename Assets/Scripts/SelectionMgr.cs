using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionMgr : MonoBehaviour
{
    public static SelectionMgr inst;
    private void Awake()
    {
        inst = this;
    }

    public Entity381 selectedEntity;
    public int selectedEntityIndex;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            SelectNextEntity();
        }
    }

    public void SelectEntity(Entity381 ent)
    {
        UnselectAll();
        selectedEntity = ent;
        selectedEntity.isSelected = true;
        selectedEntityIndex = EntityMgr.inst.entities.FindIndex(x => (x == ent));
    }

    void SelectNextEntity()
    {
        UnselectAll();
        selectedEntityIndex = (selectedEntityIndex >= EntityMgr.inst.entities.Count - 1 ? 0 : selectedEntityIndex + 1);
        selectedEntity = EntityMgr.inst.entities[selectedEntityIndex];
        selectedEntity.isSelected = true;
    }

    void UnselectAll()
    {
        foreach (Entity381 ent in EntityMgr.inst.entities)
        {
            ent.isSelected = false;
        }
    }
}
