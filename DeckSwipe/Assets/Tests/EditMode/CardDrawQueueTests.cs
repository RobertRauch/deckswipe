using System.Collections;
using System.Collections.Generic;
using DeckSwipe.CardModel.DrawQueue;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CardDrawQueueTests
    {
        [Test]
        public void InsertTest()
        {
            CardDrawQueue queue = new CardDrawQueue();
            queue.Insert(new Followup(0, 10));
            Assert.AreEqual(1, queue.Queue.Count);
            Assert.AreEqual(10, queue.Queue[0].Delay);

            queue.Insert(new Followup(1, 16));
            Assert.AreEqual(2, queue.Queue.Count);
            Assert.AreEqual(6, queue.Queue[1].Delay);

            queue.Insert(new Followup(2, 55));
            Assert.AreEqual(3, queue.Queue.Count);
            Assert.AreEqual(39, queue.Queue[2].Delay);
        }

        [Test]
        public void NextTest()
        {
            CardDrawQueue queue = new CardDrawQueue();
            queue.Insert(new Followup(0, 2));
            queue.Insert(new Followup(1, 4));
            queue.Insert(new Followup(2, 5));

            Followup next = (Followup) queue.Next();
            Assert.IsNull(next);

            next = (Followup)queue.Next();
            Assert.IsNotNull(next);
            Assert.AreEqual(0, next.id);

            next = (Followup)queue.Next();
            Assert.IsNull(next);

            next = (Followup)queue.Next();
            Assert.IsNotNull(next);
            Assert.AreEqual(1, next.id);

            next = (Followup)queue.Next();
            Assert.IsNotNull(next);
            Assert.AreEqual(2, next.id);
        }

        [Test]
        public void ClearTest()
        {
            CardDrawQueue queue = new CardDrawQueue();
            queue.Insert(new Followup(0, 2));
            queue.Insert(new Followup(1, 4));
            queue.Insert(new Followup(2, 5));

            Assert.AreEqual(queue.Queue.Count, 3);

            queue.Clear();

            Assert.AreEqual(queue.Queue.Count, 0);
        }
    }
}
