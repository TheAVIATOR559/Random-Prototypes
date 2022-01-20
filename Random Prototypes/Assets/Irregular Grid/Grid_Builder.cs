using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid_Builder : MonoBehaviour
{
    private List<Vector2> mainPoints = new List<Vector2>();
    private List<Vector2> secondaryPoints = new List<Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        CreateGrid();
    }

    private void CreateGrid()
    {
        //main points
        for(int i = 6; i > 0; i--)
        {
            mainPoints.Add(new Vector2(i * Mathf.Sin(0 * (Mathf.PI / 180f)), i * Mathf.Cos(0 * (Mathf.PI / 180f))));
            mainPoints.Add(new Vector2(i * Mathf.Sin(60 * (Mathf.PI / 180f)), i * Mathf.Cos(60 * (Mathf.PI / 180f))));
            mainPoints.Add(new Vector2(i * Mathf.Sin(120 * (Mathf.PI / 180f)), i * Mathf.Cos(120 * (Mathf.PI / 180f))));
            mainPoints.Add(new Vector2(i * Mathf.Sin(180 * (Mathf.PI / 180f)), i * Mathf.Cos(180 * (Mathf.PI / 180f))));
            mainPoints.Add(new Vector2(i * Mathf.Sin(240 * (Mathf.PI / 180f)), i * Mathf.Cos(240 * (Mathf.PI / 180f))));
            mainPoints.Add(new Vector2(i * Mathf.Sin(300 * (Mathf.PI / 180f)), i * Mathf.Cos(300 * (Mathf.PI / 180f))));
        }

        for(int i = mainPoints.Count; i > 7; i -= 6)
        {
            for(int j = 0; j < 6; j++)
            {
                for(float k = 1; k < j; k++)
                {
                    //(x1 + k(x2-x1), y1 + k(y2-y1))
                    secondaryPoints.Add(new Vector2(mainPoints[i].x + (k/i) * (mainPoints[i-1].x - mainPoints[i].x), mainPoints[i].y + (k / i) * (mainPoints[i - 1].y - mainPoints[i].y)));
                }
            }
        }

        //secondary points
        //for(int i = 7; i >= 2; i--)
        //{
        //    for(float j = i-1; j > 0; j--)
        //    {
        //        //(x1 + k(x2-x1), y1 + k(y2-y1))
        //        secondaryPoints.Add(new Vector2(mainPoints[i].x + (j/i) * (mainPoints[i-1].x - mainPoints[i].x), mainPoints[i].y + (j / i) * (mainPoints[i - 1].y - mainPoints[i].y)));
        //        Debug.Log(j + "/" + i + "=" + (j / i));
        //    }
        //}
    }

    private void OnDrawGizmosSelected()
    {
        //core
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Vector3.zero, 0.1f);

        Gizmos.color = Color.blue;
        for (int i = 0; i < mainPoints.Count; i++)
        {
            Gizmos.DrawSphere(Vector2To3(mainPoints[i]), 0.1f);
        }

        Gizmos.color = Color.yellow;
        for (int i = 1; i < secondaryPoints.Count; i++)
        {
            Gizmos.DrawSphere(Vector2To3(secondaryPoints[i]), 0.1f);
        }

        Gizmos.color = Color.black;
        for (int i = 2; i < mainPoints.Count; i++)
        {
            Gizmos.DrawLine(Vector2To3(mainPoints[i]), Vector2To3(mainPoints[i - 1]));
        }

        //Gizmos.color = Color.green;
        //for(int i = 2; i < secondaryPoints.Count; i++)
        //{
        //    Gizmos.DrawLine(Vector2To3(secondaryPoints[i]), Vector2To3(secondaryPoints[i-1]));
        //}
    }

    private Vector3 Vector2To3(Vector2 point)
    {
        return new Vector3(point.x, 0, point.y);
    }
}
