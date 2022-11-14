using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    public GameState _gameState;

    public BlockGeneManager blockGeneManager;


    void Awake()
    {
        blockGeneManager.setUp(_gameState);
    }

    // Start is called before the first frame update
    void Start()
    {
        blockGeneManager.initializeBlock();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
