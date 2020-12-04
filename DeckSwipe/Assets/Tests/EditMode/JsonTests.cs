using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class JsonTests
    {
        [Test]
        public void JsonLoadTest()
        {
            var scene = SceneManager.GetSceneByName("GameplayScene");
            Assert.IsNotNull(scene);
            EditorSceneManager.OpenScene(scene.path, OpenSceneMode.Single);

            UtilTestsResources tests = Resources.FindObjectsOfTypeAll<UtilTestsResources>().FirstOrDefault();
            Assert.IsNotNull(tests);

            List<TestClass> testClasses = Outfrost.JsonResources.Load<TestClass>("Editor/Tests");

            foreach (TestClass testClass in testClasses)
            {
                Assert.AreEqual("test1", testClass.field1);
                Assert.AreEqual("test2", testClass.field2);
                Assert.AreEqual(123, testClass.field3.field1);
                Assert.AreEqual("test3", testClass.field3.field2);
            }
        }
    }
}
