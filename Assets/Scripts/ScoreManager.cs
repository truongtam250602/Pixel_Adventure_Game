using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textNumber;
    private int score;
    void Start()
    {
        score = ItemOrangeCollector.Instance.oranges;
        textNumber.text = score.ToString();
    }
}
