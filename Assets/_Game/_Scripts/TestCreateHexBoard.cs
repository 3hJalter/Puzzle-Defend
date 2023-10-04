using UnityEngine;
using UnityEngine.SceneManagement;

public class TestCreateHexBoard : HMonoBehaviour
{
    [SerializeField] private Vector2Int boardSize;
    [SerializeField] private HexUnit hexUnitPrefab;
    private int count;

    // Start is called before the first frame update
    private void Start()
    {
        CreateHexBoard();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ReloadScene();
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CreateHexBoard()
    {

        for (int x = 0; x < boardSize.x; x++)
        for (int y = 0; y < boardSize.y; y++)
        {
            if ((x + y) % 2 == 0) continue;
            if ((x == 0 && y == 1) || (x == 0 && y == boardSize.y - 2) || (x == 1 && y == 0) ||
                (x == 1 && y == boardSize.y - 1))
            {
                continue;
            }

            if ((x == boardSize.x - 1 && y == 1) || (x == boardSize.x - 1 && y == boardSize.y - 2) ||
                (x == boardSize.x - 2 && y == 0) || (x == boardSize.x - 2 && y == boardSize.y - 1))
            {
                continue; 
            }
                
            HexUnit hexUnit = Instantiate(hexUnitPrefab, new Vector3(x * 0.725f, y * 0.415f, 0), Quaternion.identity);
            hexUnit.Index = new Vector2Int(x, y);
            hexUnit.Tf.parent = Tf;
            Debug.Log("x : " + x + " y : " + y + "");
        }
    }
}
