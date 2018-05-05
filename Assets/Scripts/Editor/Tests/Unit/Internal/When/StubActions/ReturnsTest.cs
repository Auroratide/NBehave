using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class ReturnsTest {

        [Test] public void ShouldReturnSameValue() {
            object[] args = new object[0];
            Assert.That(new Returns(2).Return(args), Is.EqualTo(2));
            Assert.That(new Returns("hello").Return(args), Is.EqualTo("hello"));
        }

    }

}
