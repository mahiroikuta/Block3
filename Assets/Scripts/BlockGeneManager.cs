using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGeneManager : MonoBehaviour
{
    GameState _gameState;

    public void setUp(GameState gameState)
    {
        _gameState = gameState;
    }

    public GameState onUpdate()
    {
        return _gameState;
    }
    // 初期ブロック配置
    public void initializeBlock()
    {
        var parent = this.transform;

        Vector3 placePosition = new Vector3(-6, 14, 0);
        Vector3 initPosition = placePosition;

        Quaternion q = new Quaternion();
        q = Quaternion.identity;

        for ( int i=0 ; i<3 ; i++ )
        {
            placePosition.x = initPosition.x;
            for ( int j=0 ; j<5 ; j++ )
            {
                Block block = Instantiate(_gameState.block, placePosition, q, parent) as Block;
                block.life = _gameState.blockLife;
                placePosition.x += 3;
            }
            placePosition.y -= 3;
        }
    }

    // 追加ブロック配置
    public void addBlock()
    {
        var parent = this.transform;

        Vector3 placePosition = new Vector3(-6, 14, -1);
        Vector3 initPosition = placePosition;

        Quaternion q = new Quaternion();
        q = Quaternion.identity;

        for ( int j=0 ; j<5 ; j++ )
        {
            Block block = Instantiate(_gameState.block, placePosition, q, parent) as Block;
            placePosition.x += 3;
        }
    }

}
