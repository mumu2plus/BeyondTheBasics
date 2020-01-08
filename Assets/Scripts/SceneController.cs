using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public List<Shape> gameShapes;
    public Dictionary<string, Shape> shapeDictionary;
    public Queue<Shape> shapeQueue;
    public Stack<Shape> shapeStack;

    // Start is called before the first frame update
    void Start()
    {
        shapeDictionary = new Dictionary<string, Shape>();
        shapeQueue = new Queue<Shape>();
        shapeStack = new Stack<Shape>();

        foreach(var shape in gameShapes)
        {
            shapeDictionary.Add(shape.Name, shape);
        }

        shapeQueue.Enqueue(shapeDictionary["Triangle"]);
        shapeQueue.Enqueue(shapeDictionary["Square"]);
        shapeQueue.Enqueue(shapeDictionary["Octagon"]);
        shapeQueue.Enqueue(shapeDictionary["Circle"]);

        shapeStack.Push(shapeDictionary["Triangle"]);
        shapeStack.Push(shapeDictionary["Square"]);
        shapeStack.Push(shapeDictionary["Octagon"]);
        shapeStack.Push(shapeDictionary["Circle"]);
    }

    private void SetRedByName(string shapeName)
    {
        shapeDictionary[shapeName].SetColor(Color.red);
    }

    private void DeQueueExample()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shapeQueue.Count > 0)
            {
                Shape shape = shapeQueue.Dequeue();
                shape.SetColor(Color.blue);
            }
            else
            {
                Debug.Log("The shape queue is empty!");
            }
        }
    }

    private void FindExample()
    {
        Shape octagon = gameShapes.Find(s => s.Name == "Octagon");
        octagon.SetColor(Color.red);
    }

    private void ListExample()
    {

        string[] shapes = { "circle", "square", "triangle", "octagon" };
        List<string> moreShapes;

        moreShapes = new List<string> { "circle", "square", "triangle", "octagon" };
        moreShapes.Add("rectangle");
        moreShapes.Insert(2, "diamond");
        moreShapes.Sort();

        for (int i = 0; i < moreShapes.Count; i++)
        {
            moreShapes[i] = moreShapes[i].ToUpper();
            Debug.Log(moreShapes[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (shapeStack.Count > 0)
            {
                Shape shape = shapeStack.Pop();
                shape.SetColor(Color.green);
            }
            else
            {
                Debug.Log("The stack is empty!");
            }
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            SetRedByName("Square");
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            SetRedByName("Circle");
        }
    }
}
