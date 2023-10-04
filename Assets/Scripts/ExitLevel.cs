using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitLevel : MonoBehaviour
{
    [SerializeField] int Level = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Level++;
        SceneManager.LoadScene(Level);
    }
}
