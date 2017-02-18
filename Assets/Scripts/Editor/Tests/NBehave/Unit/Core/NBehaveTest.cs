using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {

    public class NBehaveTest {

        [Test] public void ShouldAddMethodCallToCallMemory() {
            var nbehave = new Core.NBehave();

            nbehave.Call("arg");

            Assert.That(nbehave.CallMemory.TimesCalled("ShouldAddMethodCallToCallMemory", null), Is.EqualTo(1));
        }

    }

}