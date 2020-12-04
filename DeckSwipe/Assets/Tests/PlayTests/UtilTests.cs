using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Threading.Tasks;
using DeckSwipe.CardModel.Import;
using NUnit.Framework;
using Outfrost;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

namespace Tests
{
    public class UtilTests
    {
        private bool pauseCoroutineTest;

        [UnityTest]
        public IEnumerator UtilTestsWithEnumeratorPasses()
        {
            pauseCoroutineTest = false;
            DateTime start = DateTime.Now;
            yield return Util.DelayCoroutine(SetCoroutineTestToTrue, 1f);
            DateTime end = DateTime.Now;

            Assert.AreEqual(1, (int)(end - start).TotalSeconds);
            Assert.IsTrue(pauseCoroutineTest);
        }

        private void SetCoroutineTestToTrue()
        {
            pauseCoroutineTest = true;
        }

        [UnityTest]
        public IEnumerator MyAsyncTest()
        {
            Sprite sprite = Sprite.Create(new Texture2D(1,1), new Rect(), new Vector2());
            CollectionImporter importer = new CollectionImporter(sprite, false);
            var task = importer.Import();
            yield return AsIEnumeratorReturnNull(task);

            var returnValue = task.Result;
            //Debug.LogError("CARDS: " + returnValue.cards.Count);
            Assert.AreEqual(11, returnValue.cards.Count);
        }

        public static IEnumerator AsIEnumeratorReturnNull<T>(Task<T> task)
        {
            while (!task.IsCompleted)
            {
                yield return null;
            }

            if (task.IsFaulted)
            {
                ExceptionDispatchInfo.Capture(task.Exception).Throw();
            }

            yield return null;
        }
    }
}
