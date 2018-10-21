using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Auroratide.NBehave.Core {

/// <summary>
/// Base class for emitting mock types.
/// </summary>
/// <typeparam name="T">Interface to mock.</typeparam>
/// <remarks>
/// This makes use of C#'s reflection emittor library.
/// </remarks>
    public abstract class MockEmitter<T> where T : class {
        protected Type type;
        protected ModuleBuilder moduleBuilder;

    /// <summary>
    /// Initialize a new <c>MockEmitter</c>
    /// </summary>
    /// <param name="moduleBuilder">Module builder.</param>
        public MockEmitter(ModuleBuilder moduleBuilder) {
            this.type = typeof(T);
            this.moduleBuilder = moduleBuilder;
        }

    /// <summary>
    /// Returns the mocked type.
    /// </summary>
        public Type Emit() {
            Type cachedType = moduleBuilder.GetType(type.FullName);

            if(cachedType != null)
                return cachedType;
            else
                return BuildType();
        }

    /// <summary>
    /// Builds the mocked type from the ground up, implementing the interface and <c>NBehaveMock</c>.
    /// </summary>
        public abstract Type BuildType();

    }
}