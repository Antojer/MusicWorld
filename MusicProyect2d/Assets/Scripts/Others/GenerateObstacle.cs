using System.Collections.Generic;
using UnityEngine;

public class GenerateObstacle : MonoBehaviour
{
    public List<int> aiNotFreeBox;
    public List<GameObject> agoObstacles;
    private List<GameObject> _agoBoxes;
    private GameObject _goObstacleInstance;
    private GameObject _goMatrix;

    // Use this for initialization
    void Start()
    {
        _goMatrix = this.transform.parent.Find("movementMatrix").gameObject;
        _agoBoxes = new List<GameObject>(55);
        for (int i = 0; i < 55; i++)
        {
            _agoBoxes.Add(_goMatrix.transform.Find("Square (" + i + ")").gameObject);
        }
    }

    public void generateObstacles()
    {
        int iMaxObstables = Random.Range(0, 3);
        int iObstacleIndex;
        int iBoxIndex;
        Debug.Log(iMaxObstables);
        while (iMaxObstables >= 0)
        {
            iBoxIndex = Random.Range(0, _agoBoxes.Count);
            if (!aiNotFreeBox.Exists(x => x == iBoxIndex))
            {
                iObstacleIndex = Random.Range(0, agoObstacles.Count);
                _goObstacleInstance = Instantiate(agoObstacles[iObstacleIndex], _agoBoxes[iBoxIndex].transform.position, _agoBoxes[iBoxIndex].transform.rotation);
                Debug.Log(_agoBoxes[iBoxIndex].transform.position);
                _goObstacleInstance.transform.parent = this.transform;
                aiNotFreeBox.Add(iBoxIndex);
                iMaxObstables--;
            }
        }
    }
}
