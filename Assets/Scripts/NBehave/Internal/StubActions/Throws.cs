namespace Auroratide.NBehave.Internal {
	public class Throws : StubAction {
		private System.Exception exception;

		public Throws(System.Exception exception) {
			this.exception = exception;
		}

		public object Return() {
			throw exception;
		}
	}
}
