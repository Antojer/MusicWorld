using UnityEngine;
using System.Collections.Generic;

public class PlaceTeleporter : MonoBehaviour {
    public GameObject goUpTeleporter;
    public GameObject goDownTeleporter;
    public GameObject goRightTeleporter;
    public GameObject goLeftTeleporter;

    public void placeTeleporters(List<GameObject> createdRooms)
    {
        foreach (GameObject i in createdRooms)
        {
            foreach (GameObject j in createdRooms)
            {
                if (i != j)
                {
                    if (Mathf.FloorToInt(i.transform.position.x) == Mathf.FloorToInt(j.transform.position.x) && Mathf.FloorToInt(i.transform.position.y + 10) == Mathf.FloorToInt(j.transform.position.y))
                        placeTeleporterUp(i);
                    if (Mathf.FloorToInt(i.transform.position.x) == Mathf.FloorToInt(j.transform.position.x) && Mathf.FloorToInt(i.transform.position.y - 10) == Mathf.FloorToInt(j.transform.position.y))
                        placeTeleporterDown(i);
                    if (Mathf.FloorToInt(i.transform.position.x + 18) == Mathf.FloorToInt(j.transform.position.x) && Mathf.FloorToInt(i.transform.position.y) == Mathf.FloorToInt(j.transform.position.y))
                        placeTeleporterRight(i);
                    if (Mathf.FloorToInt(i.transform.position.x - 18) == Mathf.FloorToInt(j.transform.position.x) && Mathf.FloorToInt(i.transform.position.y) == Mathf.FloorToInt(j.transform.position.y))
                        placeTeleporterLeft(i);
                }
            }
        }
    }

    public void placeTeleporterUp(GameObject a)
    {
        Vector2 vaux;
        vaux = new Vector2(a.transform.position.x + 8.2f, a.transform.position.y + 3f);
        Instantiate(goUpTeleporter, vaux, Quaternion.Euler(0,0,180));
    }

    public void placeTeleporterDown(GameObject a)
    {
        Vector2 vaux;
        vaux = new Vector2(a.transform.position.x + 8.2f, a.transform.position.y - 3.45f);
        Instantiate(goDownTeleporter, vaux, Quaternion.Euler(0, 0, 90));
    }

    public void placeTeleporterRight(GameObject a)
    {
        Vector2 vaux;
        vaux = new Vector2(a.transform.position.x + 15f, a.transform.position.y);
        Instantiate(goRightTeleporter, vaux, a.transform.rotation);
    }

    public void placeTeleporterLeft(GameObject a)
    {
        Vector2 vaux;
        vaux = new Vector2(a.transform.position.x + 1.26f, a.transform.position.y);
        Instantiate(goLeftTeleporter, vaux, a.transform.rotation);
    }
}
