using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class ThrowsTest {

        [Test] public void ShouldThrowGivenException() {
            Assert.Throws<System.Exception>(() => new Throws(new System.Exception()).Return(new object[0]));
        }

        [Test] public void ShouldThrowCustomException() {
            Assert.Throws<CustomException>(() => new Throws(new CustomException()).Return(new object[0]));
        }

        private class CustomException : System.Exception {}

    }

}
