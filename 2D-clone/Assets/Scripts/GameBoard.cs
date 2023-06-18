using UnityEngine;

public class GameBoard : MonoBehaviour {

    private static int boardWidth = 29;
    private static int boardHeight = 32;

    public int totalFoods = 0;
    public int score = 0;

    public GameObject[,] board = new GameObject[boardWidth, boardHeight];

	void Start () {

        Object[] objects = GameObject.FindObjectsOfType(typeof(GameObject));

        foreach(GameObject o in objects)
        {
            Vector2 pos = o.transform.position;

            if (o.CompareTag("pacdottag")){
                board[(int)pos.x, (int)pos.y] = o;
                totalFoods++;
                //Debug.Log("totalfood: " + totalFoods); 
            }
            else
            {
                //Debug.Log("o is not dot-food");
            } 
        }
        Debug.Log("totalfood: " + totalFoods);
    }

	void Update () {
       // Debug.Log("SCORE: " + GameObject.Find("ScoreControl").GetComponent<ScoreControl>().score);
	}
}
