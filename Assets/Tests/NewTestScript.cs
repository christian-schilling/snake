using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;

public class SnakeTest
{
    Transform food;
    Transform snake;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        yield return EditorSceneManager.LoadSceneAsyncInPlayMode(
            "Assets/Scenes/SampleScene.unity",
            new LoadSceneParameters(LoadSceneMode.Single));

        Transform[] objects = Resources.FindObjectsOfTypeAll<Transform>();
        foreach (Transform t in objects)
        {
            if(t.GetComponent<Food>() is not null) {
                food = t;
            }
            if(t.GetComponent<Snake>() is not null) {
                snake = t;
            }
        }

    }

    [UnityTest]
    public IEnumerator SnakeGrowsWhenPickingUpFood()
    {
        var initial = snake.gameObject.GetComponent<Snake>().length;

        yield return null;
        food.position = new Vector3(4,0,0);

        yield return new WaitForSeconds(3);
        var after = snake.gameObject.GetComponent<Snake>().length;

        Assert.Greater(after, initial);

        yield return null;

    }
}
