using System.Collections;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tool Class" , menuName = "Item/Consumerable")]
public class ConsumerableClass : ItemClass
{
    [Header("Consumerable")]//data specific to consumerable class
    public float healthRestore;

    public override ItemClass GetItem() { return this; }
    public override ToolClass GetTool() { return null; }
    public override MiscClass GetMisc() { return null; }
    public override ConsumerableClass GetConsumerable() { return this; }
}
