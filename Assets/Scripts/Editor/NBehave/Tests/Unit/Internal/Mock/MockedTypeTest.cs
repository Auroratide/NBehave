using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.MockTest {
    using Internal;

    public class MockedTypeTest {

        MockedType<Winter> winter;
        MockedType<Autumn> autumn;

        [SetUp] public void Init() {
            winter = new MockedType<Winter>(typeof(Winter));
            autumn = new MockedType<Autumn>(typeof(Autumn));
        }

        [Test] public void ShouldReturnTypeThatIsBeingMocked() {
            Assert.That(winter.Type, Is.EqualTo(typeof(Winter)));
            Assert.That(autumn.Type, Is.EqualTo(typeof(Autumn)));
        }

        [Test] public void ShouldCreateObjectOfCorrectType() {
            Assert.That(winter.Create().GetType(), Is.EqualTo(typeof(Winter)));
            Assert.That(autumn.Create().GetType(), Is.EqualTo(typeof(Autumn)));
        }

        private class Winter {}
        private class Autumn {}

    }
}
