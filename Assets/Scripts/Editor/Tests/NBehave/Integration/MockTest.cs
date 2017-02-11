using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Integration {
    public class MockTest {

        [SetUp] public void Init() {}

        [Test] public void ShouldMockMethod() {
            Interface mock = Mock.Basic<Interface>();

            mock.Method();

            Verify.That(() => mock.Method()).IsCalled();
        }

        private interface Interface {
            void Method();
        }

    }
}
