using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitAI : MonoBehaviour
{
    public Entity381 entity;
    public Command currCommand;
    public List<Command> commands;

    // Start is called before the first frame update
    void Start()
    {
        entity = GetComponentInParent<Entity381>();
        commands = new List<Command>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (commands.Count > 0)
        {
            if (!currCommand.IsDone())
            {
                currCommand.Tick();
            }
            else
            {
                currCommand.Stop();
                if (commands.Count > 1)
                {
                    currCommand = commands[1];
                }
                else
                {
                    currCommand = null;
                }
                commands.RemoveAt(0);
            }
        }
    }


    public void AddCommand(Command nextCommand)
    {
        commands.Add(nextCommand);
        if (commands.Count <= 1)
        {
            currCommand = nextCommand;
        }
    }

    public void SetCommand(Command nextCommand)
    {
        commands.Clear();
        commands.Add(nextCommand);
        currCommand = nextCommand;
    }
}
