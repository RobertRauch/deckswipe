using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UtilTestsResources : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneGameObject;

    public GameObject SceneGameObject { get { return sceneGameObject; } }


    [SerializeField]
    private GameObject prefabGameObject;

    public GameObject PrefabGameObject { get { return prefabGameObject; } }

    [SerializeField]
    private TextMeshPro testTextMeshPro;

    public TextMeshPro TestTextMeshPro { get { return testTextMeshPro; } }

    [SerializeField]
    private GameObject card;

    public GameObject Card { get { return card; } }


    [SerializeField]
    private Camera camera;

    public Camera Camera { get { return camera; } }

    [SerializeField]
    private TextAsset jsonTextAsset;

    public TextAsset JsonTextAsset { get { return jsonTextAsset; } }

}

public class TestClass
{
    public string field1;
    public string field2;
    public TestClass2 field3;
}

[Serializable]
public class TestClass2
{
    public int field1;
    public string field2;
}
