using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class ReturnsTest {

        [Test] public void ShouldReturnSameValue() {
            Assert.That(new Returns(2).Return(), Is.EqualTo(2));
            Assert.That(new Returns("hello").Return(), Is.EqualTo("hello"));
        }

    }

}
