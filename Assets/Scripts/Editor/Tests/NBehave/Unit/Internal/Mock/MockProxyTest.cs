using System;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.MockTest {
    using Internal;

    public class MockProxyTest {

        Mock.CallMemory callMemory;
        Mock.StubMemory stubMemory;
        MockProxy mockProxy;

        [SetUp] public void Init() {
            callMemory = new Mock.CallMemory();
            stubMemory = new Mock.StubMemory();
            mockProxy = new MockProxy(callMemory, stubMemory);
        }

        [Test] public void ShouldReturnCallMemory() {
            Assert.That(mockProxy.CallMemory, Is.EqualTo(callMemory));
        }

        [Test] public void ShouldReturnStubMemory() {
            Assert.That(mockProxy.StubMemory, Is.EqualTo(stubMemory));
        }

        [Test] public void ShouldRegisterMethodCallIntoCallMemory() {
            mockProxy.Call(2, "hello");

            Assert.That(callMemory.CalledWith.Call.First, Is.EqualTo("ShouldRegisterMethodCallIntoCallMemory"));
            Assert.That(callMemory.CalledWith.Call.Second[0], Is.EqualTo(2));
            Assert.That(callMemory.CalledWith.Call.Second[1], Is.EqualTo("hello"));
        }

        [Test] public void ShouldReturnMethodCallForMethodFromStubMemory() {
            Mock.MethodStub stub = new Mock.MethodStub();
            object[] arguments = new object[] { 2, "hello" };
            stubMemory.Returns.Get.Enqueue(stub);

            var expected = new MethodCall(stub, arguments);

            Assert.That((MethodCall)mockProxy.Call(2, "hello"), Is.EqualTo(expected));
        }

    }
}
