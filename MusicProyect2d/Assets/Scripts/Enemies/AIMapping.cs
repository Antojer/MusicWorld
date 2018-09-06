using UnityEngine;
using System.Collections.Generic;

public class AIMapping : MonoBehaviour
{

    public int iTargetBoxIndex;
    public List<GameObject> agoBoxes;
    public List<GameObject> agoObstacles;
    public  int iRows, iCols;
    public int[,] aaGraph;
    public int[,] aaAllPaths;

    void Start()
    {
        for (int i = 0; i < 55; i++)
            agoBoxes.Add(this.transform.Find("Square (" + i + ")").gameObject);
        iRows = 5;
        iCols = 11;
        aaGraph = new int[55, 55];
        aaAllPaths = new int[55, 55];
        valueGraph();
        floyd();
    }

    void valueGraph()
    {
        for (int i = 0; i < 55; i++)
            for (int j = 0; j < 55; j++)
            {
                if (j == i)
                    aaGraph[i,j] = 0;
                if (j == i - 1 && (i % iCols != 0))
                    aaGraph[i,j] = 1;
                if (j == i + 1 && (j % iCols != 0))
                    aaGraph[i, j] = 1;
                if (j == i + iCols || j == i - iCols)
                    aaGraph[i,j] = 1;
                if (j != i + iCols && j != i - iCols && j != i - 1 && j != i + 1 && j != i)
                    aaGraph[i,j] = int.MaxValue;
                if (j == i + 1 && (j % iCols == 0))
                    aaGraph[i, j] = int.MaxValue;
                if (j == i - 1 && (i % iCols == 0))
                    aaGraph[i, j] = int.MaxValue;
            }
        //marcamos los obstaculos como zona por la que no se puede pasar
        for (int i = 0; i < agoObstacles.Count; i++)
        {
            if ((int.Parse(agoObstacles[i].name.Split('(', ')')[1]) + iCols) < 98)
            {
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]), int.Parse(agoObstacles[i].name.Split('(', ')')[1]) + iCols] = int.MaxValue;
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]) + iCols, int.Parse(agoObstacles[i].name.Split('(', ')')[1])] = int.MaxValue;
            }
            if ((int.Parse(agoObstacles[i].name.Split('(', ')')[1]) - iCols) >=0)
            {
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]), int.Parse(agoObstacles[i].name.Split('(', ')')[1]) - iCols] = int.MaxValue;
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]) - iCols, int.Parse(agoObstacles[i].name.Split('(', ')')[1])] = int.MaxValue;
            }
            if((int.Parse(agoObstacles[i].name.Split('(', ')')[1]) + 1) < 98)
            {
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]), int.Parse(agoObstacles[i].name.Split('(', ')')[1]) + 1] = int.MaxValue;
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]) + 1, int.Parse(agoObstacles[i].name.Split('(', ')')[1])] = int.MaxValue;
            }
            if ((int.Parse(agoObstacles[i].name.Split('(', ')')[1]) - 1) >= 0)
            {
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]), int.Parse(agoObstacles[i].name.Split('(', ')')[1]) - 1] = int.MaxValue;
                aaGraph[int.Parse(agoObstacles[i].name.Split('(', ')')[1]) - 1, int.Parse(agoObstacles[i].name.Split('(', ')')[1])] = int.MaxValue;
            }
        }
    }


    int sum(int x, int y)
    {
        if (x == int.MaxValue || y == int.MaxValue)
            return int.MaxValue;
        else
            return x + y;
    }


    void floyd()
    {
        int[,] aaAllPathCosts;
        aaAllPathCosts = new int[55, 55];
        for (int i = 0; i < 55; i++)
        {
            for (int j = 0; j < 55; j++)
            {
                aaAllPathCosts[i, j] = aaGraph[i, j];
                if (i == j)
                    aaAllPathCosts[i,j] = 0;
                aaAllPaths[i, j] = i;
            }
        }
        // Calcular costes mínimos y caminos correspondientes
        // entre cualquier par de vértices i, j
        for (int k = 0; k < 55; k++)
            for (int i = 0; i < 55; i++)
                for (int j = 0; j < 55; j++)
                {
                    int ikj = sum(aaAllPathCosts[i,k], aaAllPathCosts[k,j]);
                    if (ikj < aaAllPathCosts[i,j])
                    {
                        aaAllPathCosts[i,j] = ikj;
                        aaAllPaths[i,j] = k;
                    }
                }
    }
}
