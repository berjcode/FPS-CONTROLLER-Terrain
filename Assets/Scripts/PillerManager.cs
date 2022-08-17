using UnityEngine;

public class PillerManager : MonoBehaviour
{
    [SerializeField]private PillerController pillerPrefab;
    [SerializeField] private Transform spawnPoint;

    [ContextMenu(nameof(create))]
    public void create()
    {

        var piller = Instantiate(pillerPrefab);

        var position =piller.transform.position;

        position.x = spawnPoint.position.x;
        piller.transform.position = position;

        piller.ChangeSize();
    }
}
