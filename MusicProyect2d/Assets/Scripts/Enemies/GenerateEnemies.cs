using UnityEngine;
using System.Collections.Generic;

public class GenerateEnemies : MonoBehaviour {
    public bool bGenerated;
    public int iEnemyCount;
    public List<GameObject> aEnemies;
    public List<GameObject> aSpawnPoints;
    private GameObject _goEnemyInstance;

    void Start () {
        iEnemyCount = 1;
        bGenerated = false;
	}

	public void generateEnemies () {
        int iEnemyIndex;
        int iEnemyPositionIndex;
        iEnemyIndex = Random.Range(0, aEnemies.Count);
        iEnemyPositionIndex = Random.Range(0, aSpawnPoints.Count);
        if (aEnemies[iEnemyIndex].name.Substring(0, 3) == "Duo")
            iEnemyCount = 2;
        if (aEnemies[iEnemyIndex].name.Substring(0,4) == "Trio")
            iEnemyCount = 3;
        _goEnemyInstance = Instantiate(aEnemies[iEnemyIndex], aSpawnPoints[iEnemyPositionIndex].transform.position, this.transform.rotation);
        _goEnemyInstance.transform.parent = this.transform;
        aEnemies.Remove(aEnemies[iEnemyIndex]);
        aSpawnPoints.Remove(aSpawnPoints[iEnemyPositionIndex]);
        bGenerated = true;
	}
}
