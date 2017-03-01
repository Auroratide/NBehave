using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit.When {
    using Internal;

    public class ThrowsTest {

        [ExpectedException(typeof(System.Exception))]
        [Test] public void ShouldThrowGivenException() {
            new Throws(new System.Exception()).Return(new object[0]);
        }

        [ExpectedException(typeof(CustomException))]
        [Test] public void ShouldThrowCustomException() {
            new Throws(new CustomException()).Return(new object[0]);
        }

        private class CustomException : System.Exception {}

    }

}
