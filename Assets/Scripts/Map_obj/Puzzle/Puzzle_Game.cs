using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_Game : MonoBehaviour
{

    public GameObject Puzzle_Game_obj;
    public GameObject[] Puzzle_image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PuzzleGameClose()
    {
        Puzzle_Game_obj.gameObject.SetActive(false);
       
    }


}
