using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemOrangeCollector : MonoBehaviour
{
   private int oranges = 0;
   [SerializeField] private Text orangeText;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orange"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("collected",true);
            Destroy(collision.gameObject);
            oranges++;
            orangeText.text = oranges.ToString();
        }
    }
}
