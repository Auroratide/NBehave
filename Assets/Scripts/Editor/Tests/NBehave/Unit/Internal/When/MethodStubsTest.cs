using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {
    using Internal;

    public class MethodStubsTest {

        Dictionary<string, Core.MethodStub> methods;
        Core.StubMemory methodStubs;

        [SetUp] public void Init() {
            methods = new Dictionary<string, Core.MethodStub>();
            methodStubs = new StubMemory(methods);
        }

        [Test] public void ShouldGetTheMethodStubCorrespondingWithTheMethodName() {
            Core.MethodStub methodStub = new Mock.MethodStub();
            methods["Method"] = methodStub;

            Assert.That(methodStubs.Get("Method"), Is.EqualTo(methodStub));
        }

        [Test] public void ShouldReturnANewMethodStubWhenOneIsNotInTheList() {
            Assert.That(methodStubs.Get("NotAMethod"), Is.Not.Null);
        }

    }

}