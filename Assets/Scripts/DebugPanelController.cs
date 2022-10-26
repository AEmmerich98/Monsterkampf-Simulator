using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPanelController : MonoBehaviour
{
    private ArenaManager arenaManager;

    // Start is called before the first frame update
    void Start()
    {
        arenaManager = FindObjectOfType<ArenaManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
