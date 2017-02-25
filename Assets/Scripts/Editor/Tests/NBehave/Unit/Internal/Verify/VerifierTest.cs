using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NUnit.Framework;

namespace Auroratide.NBehave.Unit {
    using Internal;

    public class VerifierTest {

        Core.NBehaveMock mock;
        Mock.MatcherList matchers;
        Verifier verifier;

        [SetUp] public void Init() {
            matchers = new Mock.MatcherList();
        }

    }

}