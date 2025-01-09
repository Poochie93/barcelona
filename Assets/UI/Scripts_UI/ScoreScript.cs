
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreHit;
    public static int scoreValueHit;
    // Text scoreHit;
    // Start is called before the first frame update
    void Start()
    {
        scoreHit = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreHit.text = "" + scoreValueHit;
    }
}
