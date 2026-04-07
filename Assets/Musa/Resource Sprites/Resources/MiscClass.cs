using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class" , menuName = "Item/Misc")]
public class MiscClass : ItemClass
{
    //data specific to misc class

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MiscClass GetMisc() { return null; }
    public override ConsumerableClass GetConsumerable() { return null; }

}

