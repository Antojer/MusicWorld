using UnityEngine;

public class SortInLayer : MonoBehaviour {

    public int iOffset;

	void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.tag == "enemy")
        {
            if (coll.transform.position.y > this.transform.position.y)
            {
                iOffset = 0;
                iOffset = coll.gameObject.GetComponent<SortInLayer>().iOffset + 100;
                foreach (Transform child in this.transform)
                {
                    if(child.name!="Canvas" &&  child.name!="whiteArms")
                        child.GetComponent<SpriteRenderer>().sortingOrder += iOffset;
                    if(child.name == "whiteArms")
                        foreach (Transform child2 in child.transform)
                            child.GetComponent<SpriteRenderer>().sortingOrder += iOffset;
                }                 
            }
        }
    }
}
