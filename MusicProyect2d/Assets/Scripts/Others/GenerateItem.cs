using System.Collections.Generic;
using UnityEngine;

public class GenerateItem : MonoBehaviour {

    public List<GameObject> aItems;
    private GameObject _goItemInstance;

	public void generateItem()
    {
        int iIndex = Random.Range(0, aItems.Count);
        _goItemInstance = Instantiate(aItems[iIndex], new Vector2(this.transform.position.x, this.transform.position.y), this.transform.rotation);
        _goItemInstance.transform.parent = GameObject.Find("ItemGenerator").transform;
        aItems.RemoveAt(iIndex);
    }

    public void generateItemHere(Transform pos)
    {
        int iIndex = Random.Range(0, aItems.Count);
        _goItemInstance = Instantiate(aItems[iIndex], new Vector2(pos.position.x, pos.position.y), this.transform.rotation);
        _goItemInstance.transform.parent = GameObject.Find("ItemGenerator").transform;
        aItems.RemoveAt(iIndex);
    }

    public void generateItemInThisPosition(Vector2 pos)
    {
        int iIndex = Random.Range(0, aItems.Count);
        _goItemInstance = Instantiate(aItems[iIndex], pos, this.transform.rotation);
        _goItemInstance.transform.parent = GameObject.Find("ItemGenerator").transform;
        aItems.RemoveAt(iIndex);
    }
}
