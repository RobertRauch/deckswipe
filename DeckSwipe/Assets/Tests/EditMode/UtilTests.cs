using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tests
{
    public class UtilTests
    {
        [Test]
        public void IsPrefabTests()
        {
            var rootObjects = new List<GameObject>();
            var scene = SceneManager.GetSceneByName("GameplayScene");
            Assert.IsNotNull(scene);
            EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Single);

            UtilTestsResources tests = Resources.FindObjectsOfTypeAll<UtilTestsResources>().FirstOrDefault();
            Assert.IsNotNull(tests);

            Assert.IsTrue(Outfrost.Util.IsPrefab(tests.PrefabGameObject));
            Assert.IsTrue(!Outfrost.Util.IsPrefab(tests.SceneGameObject));
        }

        [Test]
        public void SetTextAlphaTest()
        {
            var scene = SceneManager.GetSceneByName("GameplayScene");
            Assert.IsNotNull(scene);
            EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Single);

            UtilTestsResources tests = Resources.FindObjectsOfTypeAll<UtilTestsResources>().FirstOrDefault();
            Assert.IsNotNull(tests);

            TextMeshPro textMeshPro = tests.TestTextMeshPro;
            Assert.IsNotNull(textMeshPro);

            for (float i = 0.00f; i < 1; i+=0.01f)
            {
                Outfrost.Util.SetTextAlpha(textMeshPro, i);
                Assert.AreEqual(textMeshPro.color.a, i);
            }
        }

        [Test]
        public void IsFacingCameraTest()
        {
            var scene = SceneManager.GetSceneByName("GameplayScene");
            Assert.IsNotNull(scene);
            EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Single);

            UtilTestsResources tests = Resources.FindObjectsOfTypeAll<UtilTestsResources>().FirstOrDefault();
            Assert.IsNotNull(tests);

            Assert.IsNotNull(tests.Card);
            Assert.IsNotNull(tests.Camera);

            Assert.IsTrue(Outfrost.Util.IsFacingCamera(tests.Card, tests.Camera));
            tests.Card.transform.Rotate(new Vector3(0,90,0));
            Assert.IsTrue(!Outfrost.Util.IsFacingCamera(tests.Card, tests.Camera));
        }


        [Test]
        public void BytesFromStreamTest()
        {
            byte[] testingBytes = new byte[] { 65, 115, 115, 101, 114, 116, 32, 84, 101, 115, 116 };
            string testingString = "Assert Test";

            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(testingString);
            writer.Flush();
            stream.Position = 0;

            string result = System.Text.Encoding.UTF8.GetString(testingBytes);
            Assert.AreEqual(testingString, result);

            byte[] bytes = Outfrost.Util.BytesFromStream(stream);

            Assert.AreEqual(bytes, testingBytes);
        }


        [Test]
        public void OrthoCameraWorldDiagonalSizeTest()
        {
            var scene = SceneManager.GetSceneByName("GameplayScene");
            Assert.IsNotNull(scene);
            EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Single);

            UtilTestsResources tests = Resources.FindObjectsOfTypeAll<UtilTestsResources>().FirstOrDefault();
            Assert.IsNotNull(tests);

            float result = Outfrost.Util.OrthoCameraWorldDiagonalSize(tests.Camera);
            Assert.AreEqual((float)(Mathf.Round(result*100)/100), 11.47f);
        }
    }
}
