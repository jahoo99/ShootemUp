using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 _screenBounds;
    void Awake()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 playerCoor = transform.position;
       // Mathf.Clamp(viewPos.x, screenBounds.x * -1 - objectWidth, screenBounds.x + objectWidth)
        playerCoor.y = Mathf.Clamp(playerCoor.y, _screenBounds.y * -1, _screenBounds.y);
        transform.position = playerCoor;
    }
}
