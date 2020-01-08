using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void EnemyEscapedHandler(EnemyController enemy);

public class EnemyController : Shape, IKillable
{
    public event EnemyEscapedHandler EnemyEscaped;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        Name = "Enemy";
    }

    // Update is called once per frame
    void Update()
    {
        MoveEnemy();
    }

    private void MoveEnemy()
    {
        transform.Translate(Vector2.down * Time.deltaTime, Space.World);

        float bottom = transform.position.y - halfHeight;

        if (bottom <= -gameSceneController.screenBounds.y)
        {
            EnemyEscaped?.Invoke(this);
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

    public string GetName()
    {
        return Name;
    }
}
