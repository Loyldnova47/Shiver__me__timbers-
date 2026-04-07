using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class" , menuName = "Item/Tool")]
public class ToolClass : ItemClass
{
    [Header("Tool")]//data specific to tool class
    public ToolType toolType;
                

    public enum ToolType
    {
        Chum,
        Spunner,
        Shifting_Spunner_1,
        Shifting_Spunner_2   
    }
    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return this; } 
    public override MiscClass GetMisc() { return null; }
    public override ConsumerableClass GetConsumerable() { return null; }

}

