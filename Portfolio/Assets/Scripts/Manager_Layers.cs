using UnityEngine;

[CreateAssetMenu(fileName = "", menuName = "Manager/Layers", order = 2)]
public class Manager_Layers : ScriptableObject
{
    [SerializeField]
    private LayerMask tileMap;
    [SerializeField]
    private LayerMask enemyZone;
    [SerializeField]
    private LayerMask character;
    [SerializeField]
    private LayerMask thrownObject;

    public LayerMask TileMap { get { return tileMap; } }
    public LayerMask EnemyZone { get { return enemyZone; } }
    public LayerMask Character { get { return character; } }
    public LayerMask ThrownObject { get { return thrownObject; } }
}
