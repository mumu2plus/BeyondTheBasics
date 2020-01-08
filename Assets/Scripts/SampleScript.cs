using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SampleScript : MonoBehaviour
{
    public int Number;

    // Start is called before the first frame update
    void Start()
    {
        //SayHello();
        AnonymousTypeExample();
    }

    
    private void SayHello()
    {
        for (int i = 0; i < Number; i++)
        {
            Debug.Log("Hello world!");
        }
    }

    private void AnonymousTypeExample()
    {
        var enemies = new[]
        {
            new {name="Monster", hitPoints=100},
            new {name="Goblin", hitPoints=200},
            new {name="Beast", hitPoints=250}
        };

        var enemyQuery =
            from enemy in enemies
            orderby enemy.name
            select enemy;

        foreach(var enemy in enemyQuery)
        {
            Debug.Log(enemy.name);
        }
    }
}
