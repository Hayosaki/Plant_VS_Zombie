using System.Collections.Generic;
using UnityEngine;

public class GridManagemnet : MonoBehaviour
{
    private List<GameObject> gridComponents = new List<GameObject>();
    public List<GridScript> gridScripts = new List<GridScript>();

    void Start()
    {
        CreateGrids();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(GetGridByMouse());
        }
    }

    private void CreateGrids()
    {
        GameObject gridComponentPrefab = new GameObject();
        gridComponentPrefab.transform.SetParent(transform);
        gridComponentPrefab.transform.position = transform.position;
        gridComponentPrefab.AddComponent<BoxCollider2D>().size = new Vector2(GridScript.CollisionWidth, GridScript.CollisionHeight);
        for (int row = 0; row < 9; row++)
        {
            for (int col = 0; col < 5; col++)
            {
                GameObject gridComponent = GameObject.Instantiate(gridComponentPrefab, transform.position + new Vector3(row * GridScript.Width, col * GridScript.Height, 0), Quaternion.identity, transform);
                gridComponent.name = row + "-" + col;
                gridComponents.Add(gridComponent);

                gridScripts.Add(new GridScript(new Vector2(row, col), new Vector2(row * GridScript.Width, col * GridScript.Height)));
            }
        }
        Destroy(gridComponentPrefab);
    }

    private Vector2 GetGridByMouse()
    {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        MousePosition = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
        foreach (GridScript grid in gridScripts)
        {
            float x = grid.Position.x;
            float y = grid.Position.y;
            if (x - GridScript.Width / 2 < MousePosition.x && MousePosition.x < x + GridScript.Width / 2)
            {
                if (y - GridScript.Height / 2 < MousePosition.y && MousePosition.y < y + GridScript.Height / 2)
                {
                    return grid.Point;
                }
            }
        }
        return new Vector2(-1, -1);
    }
}
